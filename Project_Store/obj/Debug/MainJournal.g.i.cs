﻿#pragma checksum "..\..\MainJournal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F8CA4E7B4BC8B7287E8053D83C35CE4F94703A831AE6A8F56A7159900CD5FBA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_Store;
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


namespace Project_Store {
    
    
    /// <summary>
    /// MainJournal
    /// </summary>
    public partial class MainJournal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridJournal;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ramka;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Settings;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonSearchID;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonSearchName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton ButtonSearchManufacturer;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Оновити;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Звіти;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ГоловнеМеню;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\MainJournal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock log;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project_Store;component/mainjournal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainJournal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DataGridJournal = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\MainJournal.xaml"
            this.DataGridJournal.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGridJournal_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ramka = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.Settings = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\MainJournal.xaml"
            this.Settings.Click += new System.Windows.RoutedEventHandler(this.Settings_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonSearchID = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.ButtonSearchName = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.ButtonSearchManufacturer = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            
            #line 43 "..\..\MainJournal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSearchTovar);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SearchBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\MainJournal.xaml"
            this.SearchBox.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SearchBox_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 50 "..\..\MainJournal.xaml"
            this.SearchBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.ToSearch);
            
            #line default
            #line hidden
            
            #line 50 "..\..\MainJournal.xaml"
            this.SearchBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Оновити = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\MainJournal.xaml"
            this.Оновити.Click += new System.Windows.RoutedEventHandler(this.Update);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Звіти = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\MainJournal.xaml"
            this.Звіти.Click += new System.Windows.RoutedEventHandler(this.ToZvits);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ГоловнеМеню = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\MainJournal.xaml"
            this.ГоловнеМеню.Click += new System.Windows.RoutedEventHandler(this.ToMainWindow);
            
            #line default
            #line hidden
            return;
            case 12:
            this.log = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

