﻿#pragma checksum "..\..\..\..\..\Windows\Страницы MainMenu\Transfer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B56C42D8934425C05C8F42E6ED7F8BD22DD5218C"
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


namespace BankApplication.Windows.Страницы_MainMenu {
    
    
    /// <summary>
    /// Transfer
    /// </summary>
    public partial class Transfer : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\Windows\Страницы MainMenu\Transfer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem itemPhone;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Windows\Страницы MainMenu\Transfer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem itemAccount;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Windows\Страницы MainMenu\Transfer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frameTransfer;
        
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
                    "8b%20mainmenu/transfer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Страницы MainMenu\Transfer.xaml"
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
            this.itemPhone = ((System.Windows.Controls.ComboBoxItem)(target));
            
            #line 28 "..\..\..\..\..\Windows\Страницы MainMenu\Transfer.xaml"
            this.itemPhone.Selected += new System.Windows.RoutedEventHandler(this.ItemPhone_Selected);
            
            #line default
            #line hidden
            return;
            case 2:
            this.itemAccount = ((System.Windows.Controls.ComboBoxItem)(target));
            
            #line 29 "..\..\..\..\..\Windows\Страницы MainMenu\Transfer.xaml"
            this.itemAccount.Selected += new System.Windows.RoutedEventHandler(this.ItemAccount_Selected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.frameTransfer = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

