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
    
    public partial class program_options : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
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
    
    	private string _value;
        public string value {
    		get { 
    			return _value;
    		} 
    		set {
    			if (value != _value){
    			    string old = _value;
    				BeforevalueChange(old, value);
    				_value = value;
    			    NotifyPropertyChanged("value");
    				AftervalueChange(old, value);
    			}
    		}
    	 } 
    
    	partial void BeforevalueChange(string oldValue, string newValue);
    	partial void AftervalueChange(string oldValue, string newValue);
    }
}
