﻿#pragma checksum "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6E7269BCC602BD2D19FD46EA29A1D3ED4CF2FA3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PP2023_KozlovS_ISP3120.Pages.AuthWindow;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace PP2023_KozlovS_ISP3120.Pages.AuthWindow {
    
    
    /// <summary>
    /// AuthPage
    /// </summary>
    public partial class AuthPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PhoneNumberCorrectTextBlock;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PasswordCorrectTextBlock;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AuthButton;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink RegHyperlink;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PP2023_KozlovS_ISP3120;V1.0.0.0;component/pages/authwindow/authpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PhoneNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
            this.PhoneNumberTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PhoneNumberTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PhoneNumberCorrectTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.PasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 30 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
            this.PasswordTextBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordTextBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PasswordCorrectTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.AuthButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
            this.AuthButton.Click += new System.Windows.RoutedEventHandler(this.AuthButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RegHyperlink = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 49 "..\..\..\..\..\Pages\AuthWindow\AuthPage.xaml"
            this.RegHyperlink.Click += new System.Windows.RoutedEventHandler(this.RegHyperlink_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

