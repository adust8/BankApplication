﻿#pragma checksum "..\..\..\..\..\..\Windows\Страницы MainMenu\Способы платежа\FromAccount.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F6A988AFEE02C19A41D9139F2D60BA169CB2C057"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace BankApplication.Windows.Страницы_MainMenu.Способы_платежа {
    
    
    /// <summary>
    /// FromAccount
    /// </summary>
    public partial class FromAccount : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\..\Windows\Страницы MainMenu\Способы платежа\FromAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox accountNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\..\Windows\Страницы MainMenu\Способы платежа\FromAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sumTextBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\..\Windows\Страницы MainMenu\Способы платежа\FromAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button putMoneyButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BankApplication;component/windows/%d0%a1%d1%82%d1%80%d0%b0%d0%bd%d0%b8%d1%86%d1%" +
                    "8b%20mainmenu/%d0%a1%d0%bf%d0%be%d1%81%d0%be%d0%b1%d1%8b%20%d0%bf%d0%bb%d0%b0%d1" +
                    "%82%d0%b5%d0%b6%d0%b0/fromaccount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Windows\Страницы MainMenu\Способы платежа\FromAccount.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 15 "..\..\..\..\..\..\Windows\Страницы MainMenu\Способы платежа\FromAccount.xaml"
            ((BankApplication.Windows.Страницы_MainMenu.Способы_платежа.FromAccount)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.accountNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.sumTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.putMoneyButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\..\..\Windows\Страницы MainMenu\Способы платежа\FromAccount.xaml"
            this.putMoneyButton.Click += new System.Windows.RoutedEventHandler(this.putMoneyButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

