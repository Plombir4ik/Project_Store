// Updated by XamlIntelliSenseFileGenerator 21.01.2021 12:19:19
#pragma checksum "..\..\Entrance.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1D226FAEB5AB72796ACEF303E4363289C6B91E92E2D87DA1E60E18200121108F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Project_Store
{


    /// <summary>
    /// Entrance
    /// </summary>
    public partial class Entrance : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 13 "..\..\Entrance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Ellipse1;

#line default
#line hidden


#line 14 "..\..\Entrance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Ellipse2;

#line default
#line hidden


#line 15 "..\..\Entrance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Ellipse3;

#line default
#line hidden


#line 16 "..\..\Entrance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LoginTextBox;

#line default
#line hidden


#line 17 "..\..\Entrance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordTextBox;

#line default
#line hidden


#line 19 "..\..\Entrance.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Error;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project_Store;component/entrance.xaml", System.UriKind.Relative);

#line 1 "..\..\Entrance.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Autorization = ((Project_Store.Entrance)(target));
                    return;
                case 2:
                    this.Ellipse1 = ((System.Windows.Shapes.Ellipse)(target));
                    return;
                case 3:
                    this.Ellipse2 = ((System.Windows.Shapes.Ellipse)(target));
                    return;
                case 4:
                    this.Ellipse3 = ((System.Windows.Shapes.Ellipse)(target));
                    return;
                case 5:
                    this.LoginTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.PasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
                    return;
                case 7:

#line 18 "..\..\Entrance.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEntrance);

#line default
#line hidden
                    return;
                case 8:
                    this.Error = ((System.Windows.Controls.Label)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Window Autorization;
    }
}

