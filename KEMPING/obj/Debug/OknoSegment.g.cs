﻿#pragma checksum "..\..\OknoSegment.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9A3AA8372DFB2F661E40A7D41D4DE3C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KEMPING;
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


namespace KEMPING {
    
    
    /// <summary>
    /// OknoSegment
    /// </summary>
    public partial class OknoSegment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\OknoSegment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtImie;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\OknoSegment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNazw;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\OknoSegment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtDat1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\OknoSegment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajKlienta;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\OknoSegment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWylaczSegment;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\OknoSegment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelDodano;
        
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
            System.Uri resourceLocater = new System.Uri("/KEMPING;component/oknosegment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OknoSegment.xaml"
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
            
            #line 8 "..\..\OknoSegment.xaml"
            ((KEMPING.OknoSegment)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtImie = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\OknoSegment.xaml"
            this.txtImie.GotFocus += new System.Windows.RoutedEventHandler(this.zaznaczenie_1);
            
            #line default
            #line hidden
            
            #line 12 "..\..\OknoSegment.xaml"
            this.txtImie.IsMouseCapturedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.zaznaczenie_2);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtNazw = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\OknoSegment.xaml"
            this.txtNazw.GotFocus += new System.Windows.RoutedEventHandler(this.zaznaczenie_1);
            
            #line default
            #line hidden
            
            #line 13 "..\..\OknoSegment.xaml"
            this.txtNazw.IsMouseCapturedChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.zaznaczenie_2);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtDat1 = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.btnDodajKlienta = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\OknoSegment.xaml"
            this.btnDodajKlienta.Click += new System.Windows.RoutedEventHandler(this.btnDodajKlienta_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnWylaczSegment = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\OknoSegment.xaml"
            this.btnWylaczSegment.Click += new System.Windows.RoutedEventHandler(this.btnWylaczSegment_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.labelDodano = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

