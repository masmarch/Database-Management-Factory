﻿#pragma checksum "..\..\edit_cus.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A5C7699C625C6DCF64BB5B765093BD6F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Datafactory;
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


namespace Datafactory {
    
    
    /// <summary>
    /// edit_cus
    /// </summary>
    public partial class edit_cus : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label head;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cname;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox address;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button done;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button show;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton emp1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton emp2;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\edit_cus.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton emp3;
        
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
            System.Uri resourceLocater = new System.Uri("/Datafactory;component/edit_cus.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\edit_cus.xaml"
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
            this.head = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.userid = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.done = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\edit_cus.xaml"
            this.done.Click += new System.Windows.RoutedEventHandler(this.done_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.show = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\edit_cus.xaml"
            this.show.Click += new System.Windows.RoutedEventHandler(this.show_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.emp1 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\edit_cus.xaml"
            this.emp1.Checked += new System.Windows.RoutedEventHandler(this.emp1_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.emp2 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\edit_cus.xaml"
            this.emp2.Checked += new System.Windows.RoutedEventHandler(this.emp2_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.emp3 = ((System.Windows.Controls.RadioButton)(target));
            
            #line 23 "..\..\edit_cus.xaml"
            this.emp3.Checked += new System.Windows.RoutedEventHandler(this.emp3_Checked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
