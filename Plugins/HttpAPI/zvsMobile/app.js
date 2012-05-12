Ext.application({
    name: 'zvsMobile',

    requires: [
        'Ext.MessageBox'
    ],

   profiles: ['Phone', 'Tablet'],
    stores: ['Settings', 'Devices', 'Groups', 'Scenes'],
    views: ['SettingsViewPort'],

    icon: {
        '57': 'resources/icons/Icon.png',
        '72': 'resources/icons/Icon~ipad.png',
        '114': 'resources/icons/Icon@2x.png',
        '144': 'resources/icons/Icon~ipad@2x.png'
    },

    isIconPrecomposed: true,

    startupImage: {
        '320x460': 'resources/startup/320x460.jpg',
        '640x920': 'resources/startup/640x920.png',
        '768x1004': 'resources/startup/768x1004.png',
        '748x1024': 'resources/startup/748x1024.png',
        '1536x2008': 'resources/startup/1536x2008.png',
        '1496x2048': 'resources/startup/1496x2048.png'
    },

    listeners: {
        ShowLoginScreen: function () {
            var settings = zvsMobile.tabPanel.items.items[4];
            settings.items.items[2].fireEvent('loggedOut');

        }
    },
    BaseURL: function () {
        appSettingsStore = Ext.getStore('appSettingsStore');

        var BaseURLSetting = appSettingsStore.findRecord('SettingName', 'BaseURL');
        if (BaseURLSetting === null) {
            return '';
        }
        else {
            return BaseURLSetting.data.Value;
        }
    },
    SetStoreProxys: function () {
        DeviceStore = Ext.getStore('DeviceStore');
        DeviceStore.setProxy({
            type: 'jsonp',
            url: zvsMobile.app.BaseURL() + '/Devices/',
            extraParams: {
                u: Math.random()
            },
            reader: {
                type: 'json',
                rootProperty: 'devices',
                idProperty: 'id',
                successProperty: 'success'
            },
            callbackParam: 'callback'
        });
        
        GroupStore = Ext.getStore('GroupStore');
        GroupStore.setProxy({
            type: 'jsonp',
            url: zvsMobile.app.BaseURL() + '/Groups/',
            extraParams: {
                u: Math.random()
            },
            reader: {
                type: 'json',
                rootProperty: 'groups',
                idProperty: 'id',
                successProperty: 'success'
            },
            callbackParam: 'callback'
        });

        SceneStore = Ext.getStore('SceneStore');
        SceneStore.setProxy({
            type: 'scripttag',
            url: zvsMobile.app.BaseURL() + '/Scenes/',
            extraParams: {
                u: Math.random()
            },
            reader: {
                type: 'json',
                rootProperty: 'scenes',
                idProperty: 'id',
                successProperty: 'success'
            },

            callbackParam: 'callback'
        });
    },

    launch: function() {
        // Destroy the #appLoadingIndicator element
        Ext.fly('appLoadingIndicator').destroy();

        // Initialize the main view
        Ext.Viewport.add(Ext.create('zvsMobile.view.Main'));
    },

    onUpdated: function() {
        Ext.Msg.confirm(
            "Application Update",
            "This application has just successfully been updated to the latest version. Reload now?",
            function(buttonId) {
                if (buttonId === 'yes') {
                    window.location.reload();
                }
            }
        );
    }
});