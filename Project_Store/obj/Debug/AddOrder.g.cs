﻿#pragma checksum "..\..\AddOrder.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BFB6317ADF5DBC1FC543464FAF177C34C65A034E1527E89CFE1143B468F399CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    /// AddOrder
    /// </summary>
    public partial class AddOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button КнопкаДодатиТовар;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button КнопкаСкасувати;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PayBox;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberBox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DiscountBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BoxID_C;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BoxID_T;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ID_PBox;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dP;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock log;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\AddOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextLog;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_Store;component/addorder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddOrder.xaml"
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
            this.КнопкаДодатиТовар = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\AddOrder.xaml"
            this.КнопкаДодатиТовар.Click += new System.Windows.RoutedEventHandler(this.BtnAddTovar);
            
            #line default
            #line hidden
            return;
            case 2:
            this.КнопкаСкасувати = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\AddOrder.xaml"
            this.КнопкаСкасувати.Click += new System.Windows.RoutedEventHandler(this.BtnCancel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PayBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\AddOrder.xaml"
            this.PayBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PayBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.NumberBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\AddOrder.xaml"
            this.NumberBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumberBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DiscountBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\AddOrder.xaml"
            this.DiscountBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DiscountBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Label = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.BoxID_C = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\AddOrder.xaml"
            this.BoxID_C.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.BoxID_CTextChanged));
            
            #line default
            #line hidden
            return;
            case 8:
            this.BoxID_T = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\AddOrder.xaml"
            this.BoxID_T.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.BoxID_TTextChanged));
            
            #line default
            #line hidden
            return;
            case 9:
            this.ID_PBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\AddOrder.xaml"
            this.ID_PBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ID_PBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.log = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.TextLog = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

