﻿#pragma checksum "..\..\MainTovar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "53948B3B349621900AD303B4B44516296DDDA57480644DD4550CDAB008DDA072"
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
    /// MainTovar
    /// </summary>
    public partial class MainTovar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\MainTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Товари;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Товари_Copy;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Товари_Copy1;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainTovar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Товари_Copy2;
        
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
            System.Uri resourceLocater = new System.Uri("/Project_Store;component/maintovar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainTovar.xaml"
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
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\MainTovar.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Товари = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\MainTovar.xaml"
            this.Товари.Click += new System.Windows.RoutedEventHandler(this.AddTovar);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Товари_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MainTovar.xaml"
            this.Товари_Copy.Click += new System.Windows.RoutedEventHandler(this.MainTovar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Товари_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainTovar.xaml"
            this.Товари_Copy1.Click += new System.Windows.RoutedEventHandler(this.MainTovar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Товари_Copy2 = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\MainTovar.xaml"
            this.Товари_Copy2.Click += new System.Windows.RoutedEventHandler(this.toMainWindow);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

