﻿#pragma checksum "..\..\..\..\DeviceControls\DeviceListItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E8534DC56EFF42F19B8AC6CDC177B900"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace zVirtualScenes_WPF.DeviceControls {
    
    
    /// <summary>
    /// DeviceListItem
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class DeviceListItem : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IconImg;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NodeIDtxt;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Nametxt;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Groupstxt;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Typetxt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar LevelBar;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Leveltxt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateUpdatedtxt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/zVirtualScenes_WPF;component/devicecontrols/devicelistitem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
            ((zVirtualScenes_WPF.DeviceControls.DeviceListItem)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\..\DeviceControls\DeviceListItem.xaml"
            ((zVirtualScenes_WPF.DeviceControls.DeviceListItem)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.UserControl_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IconImg = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.NodeIDtxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Nametxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Groupstxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.Typetxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.LevelBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 8:
            this.Leveltxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DateUpdatedtxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

