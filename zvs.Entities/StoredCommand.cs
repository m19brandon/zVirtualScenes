﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zvs.Entities
{
    [Table("StoredCommands", Schema = "ZVS")]
    public partial class StoredCommand : INotifyPropertyChanged
    {
        public int StoredCommandId { get; set; }

        private Device _Device;
        public virtual Device Device
        {
            get
            {
                return _Device;
            }
            set
            {
                if (value != _Device)
                {
                    _Device = value;
                    NotifyPropertyChanged("ActionDescription");
                    NotifyPropertyChanged("ActionableObject");
                    NotifyPropertyChanged("Device");
                    NotifyPropertyChanged("Summary");
                }
            }
        }

        public virtual DeviceValueTrigger DeviceValueTrigger { get; set; }
        public virtual SceneCommand SceneCommand { get; set; }
        public virtual ScheduledTask ScheduledTask { get; set; }

        private Command _Command;
        [Required]
        public virtual Command Command
        {
            get
            {
                return _Command;
            }
            set
            {
                if (value != _Command)
                {
                    _Command = value;
                    NotifyPropertyChanged("ActionDescription");
                    NotifyPropertyChanged("ActionableObject");
                    NotifyPropertyChanged("Command");
                    NotifyPropertyChanged("Summary");
                }
            }
        }

        private string _Argument;
        [StringLength(512)]
        public string Argument
        {
            get
            {
                return _Argument;
            }
            set
            {
                if (value != _Argument)
                {
                    _Argument = value;
                    NotifyPropertyChanged("Argument");
                    NotifyPropertyChanged("ActionDescription");
                    NotifyPropertyChanged("Summary");

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Summary
        {
            get
            {
                return string.Format("{0} '{1}'", this.ActionableObject, this.ActionDescription);
            }
        }

        public string ActionableObject
        {
            get
            {
                if (this.Command is BuiltinCommand)
                {
                    return this.Command.Name;
                }
                else if (this.Command is DeviceCommand ||
                         this.Command is DeviceTypeCommand)
                {
                    if (Device != null)
                        return Device.Name;
                }
                else if (this.Command is JavaScriptCommand)
                {
                    return "Execute JavaScript";
                }
                return string.Empty;
            }
        }

        public string ActionDescription
        {
            get
            {
                using (zvsContext context = new zvsContext())
                {
                    if (this.Command is BuiltinCommand)
                    {
                        BuiltinCommand bc = (BuiltinCommand)this.Command;
                        if (bc != null)
                        {
                            switch (bc.UniqueIdentifier)
                            {
                                case "REPOLL_ME":
                                    {
                                        int d_id = 0;
                                        int.TryParse(this.Argument, out d_id);

                                        Device device_to_repoll = context.Devices.FirstOrDefault(d => d.DeviceId == d_id);
                                        if (device_to_repoll != null)
                                            return device_to_repoll.Name;

                                        break;
                                    }
                                case "GROUP_ON":
                                case "GROUP_OFF":
                                    {
                                        int g_id = 0;
                                        int.TryParse(this.Argument, out g_id);
                                        Group g = context.Groups.FirstOrDefault(gr => gr.GroupId == g_id);

                                        if (g != null)
                                            return g.Name;
                                        break;
                                    }
                                case "RUN_SCENE":
                                    {
                                        int SceneId = 0;
                                        int.TryParse(this.Argument, out SceneId);

                                        Scene Scene = context.Scenes.FirstOrDefault(d => d.SceneId == SceneId);
                                        if (Scene != null)
                                            return Scene.Name;
                                        break;
                                    }
                            }
                        }
                        return this.Argument;
                    }
                    else if (this.Command is DeviceCommand)
                    {
                        DeviceCommand bc = (DeviceCommand)this.Command;
                        if (bc != null)
                        {
                            switch (bc.ArgumentType)
                            {
                                case DataType.NONE:
                                    return bc.Name;
                                case DataType.SHORT:
                                case DataType.STRING:
                                case DataType.LIST:
                                case DataType.INTEGER:
                                case DataType.DECIMAL:
                                case DataType.BYTE:
                                case DataType.BOOL:
                                    return string.Format("{0} to '{1}'", bc.Name, this.Argument);
                            }
                        }

                    }
                    else if (this.Command is DeviceTypeCommand)
                    {
                        DeviceTypeCommand bc = (DeviceTypeCommand)this.Command;
                        if (bc != null)
                        {
                            switch (bc.ArgumentType)
                            {
                                case DataType.NONE:
                                    return bc.Name;
                                case DataType.SHORT:
                                case DataType.STRING:
                                case DataType.LIST:
                                case DataType.INTEGER:
                                case DataType.DECIMAL:
                                case DataType.BYTE:
                                case DataType.BOOL:
                                    return string.Format("{0} to '{1}'", bc.Name, this.Argument);
                            }
                        }
                    }
                    else if (this.Command is JavaScriptCommand)
                    {
                        JavaScriptCommand JSCmd = (JavaScriptCommand)this.Command;
                        return string.Format("{0} '{1}'", JSCmd.Name, JSCmd.Script);
                    }
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Helper to find where the stored command is used and remove its use.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sc"></param>
        public static void RemoveDependencies(zvsContext context, StoredCommand sc)
        {
            if (sc.ScheduledTask != null)
            {
                sc.ScheduledTask.isEnabled = false;
                sc.ScheduledTask = null;
            }

            if (sc.DeviceValueTrigger != null)
            {
                sc.DeviceValueTrigger.isEnabled = false;
                sc.DeviceValueTrigger = null;
            }

           // if (sc.SceneCommand != null)
           //     context.SceneCommands.Local.Remove(sc.SceneCommand);



            foreach (SceneCommand sceneCommand in context.SceneCommands.Where(o => o.StoredCommand.StoredCommandId == sc.StoredCommandId))
            {
                context.SceneCommands.Local.Remove(sceneCommand);
            }
            context.SaveChanges();
        }
    }
}