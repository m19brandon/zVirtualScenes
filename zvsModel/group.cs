//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace zVirtualScenesModel
{
    
    public partial class group : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
        public group()
        {
            this.group_devices = new ObservableCollection<group_devices>();
        }
    
    	private int _id;
        public int id {
    		get { 
    			return _id;
    		} 
    		set {
    			if (value != _id){
    			    int old = _id;
    				BeforeidChange(old, value);
    				_id = value;
    			    NotifyPropertyChanged("id");
    				AfteridChange(old, value);
    			}
    		}
    	 } 
    
    	partial void BeforeidChange(int oldValue, int newValue);
    	partial void AfteridChange(int oldValue, int newValue);
    
    	private string _name;
        public string name {
    		get { 
    			return _name;
    		} 
    		set {
    			if (value != _name){
    			    string old = _name;
    				BeforenameChange(old, value);
    				_name = value;
    			    NotifyPropertyChanged("name");
    				AfternameChange(old, value);
    			}
    		}
    	 } 
    
    	partial void BeforenameChange(string oldValue, string newValue);
    	partial void AfternameChange(string oldValue, string newValue);
    
    
    	private ObservableCollection<group_devices> _group_devices;
        public virtual ObservableCollection<group_devices> group_devices {
    		get { 
    			return _group_devices;
    		} 
    		set {
    			if (value != _group_devices){
    			    ObservableCollection<group_devices> old = _group_devices;
    				Beforegroup_devicesChange(old, value);
    				_group_devices = value;
    			    NotifyPropertyChanged("group_devices");
    				Aftergroup_devicesChange(old, value);
    			}
    		}
    	 } 
    
    	partial void Beforegroup_devicesChange(ObservableCollection<group_devices> oldValue, ObservableCollection<group_devices> newValue);
    	partial void Aftergroup_devicesChange(ObservableCollection<group_devices> oldValue, ObservableCollection<group_devices> newValue);
    }
}
