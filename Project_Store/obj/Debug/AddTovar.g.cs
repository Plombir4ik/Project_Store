﻿#pragma checksum "..\..\AddTovar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4907015E24CBED17E79A32300B8506C535C84C099CDD89690F23CFE740F0FFF5"
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
    /// AddTovar
    /// </summary>
    public partial class AddTovar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button КнопкаДодатиТовар;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button КнопкаСкасувати;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BoxTypeOF;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox BoxManufacturer;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxSpecifications;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxDescription;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxNumber;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxPurchasePrice;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxSellingPrice;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BoxName;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Label;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_Store;component/addtovar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddTovar.xaml"
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
            
            #line 10 "..\..\AddTovar.xaml"
            this.КнопкаДодатиТовар.Click += new System.Windows.RoutedEventHandler(this.BtnAddTovar);
            
            #line default
            #line hidden
            return;
            case 2:
            this.КнопкаСкасувати = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\AddTovar.xaml"
            this.КнопкаСкасувати.Click += new System.Windows.RoutedEventHandler(this.BtnCancel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BoxTypeOF = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\AddTovar.xaml"
            this.BoxTypeOF.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.OnComboboxTextChanged));
            
            #line default
            #line hidden
            return;
            case 4:
            this.BoxManufacturer = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\AddTovar.xaml"
            this.BoxManufacturer.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.OnComboboxTextChanged2));
            
            #line default
            #line hidden
            
            #line 13 "..\..\AddTovar.xaml"
            this.BoxManufacturer.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BoxManufacturer_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BoxSpecifications = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.BoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BoxNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.BoxPurchasePrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.BoxSellingPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.BoxName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.Label = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

