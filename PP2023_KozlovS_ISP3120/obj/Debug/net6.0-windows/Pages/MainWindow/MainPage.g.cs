﻿#pragma checksum "..\..\..\..\..\Pages\MainWindow\MainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1C5CF5E11212552E7382FFB15F27C56E3785E1E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PP2023_KozlovS_ISP3120.Pages.MainWindow;
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


namespace PP2023_KozlovS_ISP3120.Pages.MainWindow {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 44 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FilterComboBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddProductButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ProductsItemsControl;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FilterOrdersComboBox;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchOrdersTextBox;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl OrdersItemsControl;
        
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
            System.Uri resourceLocater = new System.Uri("/PP2023_KozlovS_ISP3120;component/pages/mainwindow/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
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
            
            #line 10 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((PP2023_KozlovS_ISP3120.Pages.MainWindow.MainPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FilterComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 49 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            this.FilterComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FilterComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 54 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            this.SearchTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddProductButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            this.AddProductButton.Click += new System.Windows.RoutedEventHandler(this.AddProductButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProductsItemsControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 8:
            this.FilterOrdersComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 138 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            this.FilterOrdersComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.FilterOrdersComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SearchOrdersTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 143 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            this.SearchOrdersTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchOrdersTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.OrdersItemsControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 82 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.EditProductButton_Loaded);
            
            #line default
            #line hidden
            
            #line 83 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditProductButton_Click);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 91 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.BuyProductButton_Loaded);
            
            #line default
            #line hidden
            
            #line 92 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BuyProductButton_Click);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 160 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.AcceptOrderButton_Loaded);
            
            #line default
            #line hidden
            
            #line 161 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AcceptOrderButton_Click);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 167 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.DeclineOrderButton_Loaded);
            
            #line default
            #line hidden
            
            #line 168 "..\..\..\..\..\Pages\MainWindow\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeclineOrderButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

