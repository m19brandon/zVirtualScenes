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
    
    public partial class scene_property_option : INotifyPropertyChanged
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
    
    	private int _scene_property_id;
        public int scene_property_id {
    		get { 
    			return _scene_property_id;
    		} 
    		set {
    			if (value != _scene_property_id){
    			    int old = _scene_property_id;
    				Beforescene_property_idChange(old, value);
    				_scene_property_id = value;
    			    NotifyPropertyChanged("scene_property_id");
    				Afterscene_property_idChange(old, value);
    			}
    		}
    	 } 
    
    	partial void Beforescene_property_idChange(int oldValue, int newValue);
    	partial void Afterscene_property_idChange(int oldValue, int newValue);
    
    	private string _options;
        public string options {
    		get { 
    			return _options;
    		} 
    		set {
    			if (value != _options){
    			    string old = _options;
    				BeforeoptionsChange(old, value);
    				_options = value;
    			    NotifyPropertyChanged("options");
    				AfteroptionsChange(old, value);
    			}
    		}
    	 } 
    
    	partial void BeforeoptionsChange(string oldValue, string newValue);
    	partial void AfteroptionsChange(string oldValue, string newValue);
    
    
    	private scene_property _scene_property;
        public virtual scene_property scene_property {
    		get { 
    			return _scene_property;
    		} 
    		set {
    			if (value != _scene_property){
    			    scene_property old = _scene_property;
    				Beforescene_propertyChange(old, value);
    				_scene_property = value;
    			    NotifyPropertyChanged("scene_property");
    				Afterscene_propertyChange(old, value);
    			}
    		}
    	 } 
    
    	partial void Beforescene_propertyChange(scene_property oldValue, scene_property newValue);
    	partial void Afterscene_propertyChange(scene_property oldValue, scene_property newValue);
    }
}
