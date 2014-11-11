﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.ComponentModel;
using zvs.Processor;
using zvs.WPF.Groups;
using zvs.WPF.AdapterManager;
using System.Data.Entity;
using zvs.DataModel;
using zvs.WPF.JavaScript;

namespace zvs.WPF
{
    /// <summary>
    /// interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ZvsMainWindow
    {
        private App _app = (App)Application.Current;
        private readonly ZvsContext _context;
        public WindowState LastOpenedWindowState = WindowState.Normal;

        public ZvsMainWindow()
        {
            InitializeComponent();
            _context = new ZvsContext(_app.EntityContextConnection);
        }

#if DEBUG
        ~ZvsMainWindow()
        {
            //Cannot write to log here, it has been disposed. 
            Debug.WriteLine("zvsMainWindow Deconstructed.");
        }
#endif

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Do not load your data at design time.
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            await _context.LogEntries
                .OrderByDescending(o => o.Datetime)
                .Take(100)
                .ToListAsync();

            //Load your data here and assign the result to the CollectionViewSource.
            var myCollectionViewSource = (CollectionViewSource)Resources["ListViewSource"];
            myCollectionViewSource.Source = _context.LogEntries.Local.OrderBy(o => o.Datetime);

            var log = new DatabaseFeedback(_app.EntityContextConnection) { Source = "Main Window" };
            await log.ReportInfoFormatAsync(_app.Cts.Token, "{0} User Interface Loaded", Utils.ApplicationName);

            var dataView = CollectionViewSource.GetDefaultView(logListView.ItemsSource);
            //clear the existing sort order
            dataView.SortDescriptions.Clear();

            //create a new sort order for the sorting that is done lastly            
            var dir = ListSortDirection.Ascending;

            var option = await _context.ProgramOptions.FirstOrDefaultAsync(o => o.UniqueIdentifier == "LOGDIRECTION");
            if (option != null && option.Value == "Descending")
                dir = ListSortDirection.Descending;

            myCollectionViewSource.SortDescriptions.Clear();
            myCollectionViewSource.SortDescriptions.Add(new SortDescription("Datetime", dir));

            dList1.ShowMore = false;

            Title = Utils.ApplicationNameAndVersion;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ShowOrCreateWindow<GroupEditor>();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ShowOrCreateWindow<AdapterManagerWindow>();
        }

        private void ManagePluginsMi(object sender, RoutedEventArgs e)
        {
            ShowOrCreateWindow<PluginManagerWindow>();
        }

        private void ShowOrCreateWindow<T>() where T : Window, new()
        {
            var w = _app.Windows.OfType<T>().FirstOrDefault();
            if (w != null)
            {
                w.Activate();
                return;
            }

            var newWindow = new T { Owner = this };
            newWindow.Show();
        }

        private void ActivateGroupMI_Click_1(object sender, RoutedEventArgs e)
        {
            ShowOrCreateWindow<ActivateGroup>();
        }

        private void Window_Closing_1(object sender, CancelEventArgs e)
        {
            if (_app.Cts.IsCancellationRequested) return;
            if (_app.TaskbarIcon != null)
                _app.TaskbarIcon.ShowBalloonTip(Utils.ApplicationName, Utils.ApplicationNameAndVersion + " is still running", 3000, System.Windows.Forms.ToolTipIcon.Info);
        }

        private void MainWindow_Closed_1(object sender, EventArgs e)
        {
            _app = null;

            if (_context != null)
                _context.Dispose();
        }

        private async void RepollAllMI_Click_1(object sender, RoutedEventArgs e)
        {
            var cmd = await _context.BuiltinCommands.FirstOrDefaultAsync(c => c.UniqueIdentifier == "REPOLL_ALL");
            if (cmd == null)
                return;
            await _app.ZvsEngine.RunCommandAsync(cmd.Id, string.Empty, string.Empty, CancellationToken.None);
        }

        private async void ExitMI_Click_1(object sender, RoutedEventArgs e)
        {
            if (_app != null) await _app.ShutdownZvs();
        }

        private void ViewDBMI_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(Utils.AppDataPath);
            }
            catch
            {
                MessageBox.Show("Unable to launch Windows Explorer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_StateChanged_1(object sender, EventArgs e)
        {
            if (WindowState != WindowState.Minimized)
                LastOpenedWindowState = WindowState;

            if (WindowState == WindowState.Minimized)
            {
                Close();
            }
        }

        private void AboutMI_Click_1(object sender, RoutedEventArgs e)
        {
            var aboutWin = new AboutWindow { Owner = this };
            aboutWin.ShowDialog();
        }

        private void SettingMI_Click_1(object sender, RoutedEventArgs e)
        {
            var settingWindow = new SettingWindow { Owner = this };
            settingWindow.ShowDialog();
        }

        private void AddEditJSCmds_Click_1(object sender, RoutedEventArgs e)
        {
            var jsWindow = new JavaScriptAddRemove { Owner = this };
            jsWindow.ShowDialog();
        }

        private void ClearLogsMI_Click(object sender, RoutedEventArgs e)
        {
            //TODO: CLEAR LOG 
        }

        private void BackupRestoreMI_Click(object sender, RoutedEventArgs e)
        {
            //TODO: RESTORE
            //var window = new BackupRestoreWindow { Owner = this };
          //  window.ShowDialog();
        }
    }
    public class ContentToMarginConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness(0, 0, -((ContentPresenter)value).ActualHeight, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ContentToPathConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ps = new PathSegmentCollection(4);
            var cp = (ContentPresenter)value;
            var h = cp.ActualHeight > 10 ? 1.4 * cp.ActualHeight : 10;
            var w = cp.ActualWidth > 10 ? 1.25 * cp.ActualWidth : 10;
            ps.Add(new LineSegment(new Point(1, 0.7 * h), true));
            ps.Add(new BezierSegment(new Point(1, 0.9 * h), new Point(0.1 * h, h), new Point(0.3 * h, h), true));
            ps.Add(new LineSegment(new Point(w, h), true));
            ps.Add(new BezierSegment(new Point(w + 0.6 * h, h), new Point(w + h, 0), new Point(w + h * 1.3, 0), true));
            var figure = new PathFigure(new Point(1, 0), ps, false);
            var geometry = new PathGeometry();
            geometry.Figures.Add(figure);

            return geometry;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
