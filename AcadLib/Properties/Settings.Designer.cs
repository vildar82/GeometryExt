﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcadLib.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=VPP-SQL04;Initial Catalog=CAD_REVIT_STATISTICS;User ID=CAD_AllUsers;P" +
            "assword=qwerty!2345")]
        public string SAPRConnectionString {
            get {
                return ((string)(this["SAPRConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=VPP-SQLTEST02;Initial Catalog=SR_IRA_AR_DECOR;Persist Security Info=T" +
            "rue;User ID=sa;Password=VPP-SQLTEST02")]
        public string SR_IRA_AR_DECORConnectionString {
            get {
                return ((string)(this["SR_IRA_AR_DECORConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UpgradeRequired {
            get {
                return ((bool)(this["UpgradeRequired"]));
            }
            set {
                this["UpgradeRequired"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int PaletteStyle {
            get {
                return ((int)(this["PaletteStyle"]));
            }
            set {
                this["PaletteStyle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public double PaletteImageSize {
            get {
                return ((double)(this["PaletteImageSize"]));
            }
            set {
                this["PaletteImageSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("11")]
        public double PaletteFontSize {
            get {
                return ((double)(this["PaletteFontSize"]));
            }
            set {
                this["PaletteFontSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public double PalettePropsNameWidth {
            get {
                return ((double)(this["PalettePropsNameWidth"]));
            }
            set {
                this["PalettePropsNameWidth"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public double PalettePropsHelpHeight {
            get {
                return ((double)(this["PalettePropsHelpHeight"]));
            }
            set {
                this["PalettePropsHelpHeight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool PalettePropsHelpVisible {
            get {
                return ((bool)(this["PalettePropsHelpVisible"]));
            }
            set {
                this["PalettePropsHelpVisible"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"metadata=res://*/Model.User.DB.Users.csdl|res://*/Model.User.DB.Users.ssdl|res://*/Model.User.DB.Users.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=vpp-sql04;initial catalog=CAD_AutoCAD;persist security info=True;user id=CAD_AllUsers;password=qwerty!2345;MultipleActiveResultSets=True;App=EntityFramework&quot;"" providerName=""System.Data.EntityClient")]
        public string EFAutocadUsersConStr {
            get {
                return ((string)(this["EFAutocadUsersConStr"]));
            }
        }
    }
}
