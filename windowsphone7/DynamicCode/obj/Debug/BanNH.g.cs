﻿#pragma checksum "D:\BAI TAP LAP TRINH\WinPhone7\DynamicCode\BanNH.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B6AECE2D5C29FADE6D978C47DA76717E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Expression.Interactivity.Core;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace DynamicCode {
    
    
    public partial class BanNH : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.VisualStateGroup VisiualGroup;
        
        internal System.Windows.VisualState VisualStateLoaded;
        
        internal System.Windows.VisualState VisualStateVisible;
        
        internal System.Windows.VisualState VisualStateCollapsed;
        
        internal System.Windows.Shapes.Rectangle rect_HeThongBan;
        
        internal System.Windows.Controls.TextBlock text_HeThongBan;
        
        internal Microsoft.Expression.Interactivity.Core.GoToStateAction LoadPage;
        
        internal System.Windows.Controls.ScrollViewer ScrollViewTable;
        
        internal System.Windows.Controls.Grid LayoutTable;
        
        internal Microsoft.Expression.Interactivity.Core.GoToStateAction Visible;
        
        internal System.Windows.Controls.Grid Grid_Messagebox;
        
        internal System.Windows.Shapes.Rectangle rectangle;
        
        internal System.Windows.Controls.ListBox list_ChooseOptionBan;
        
        internal System.Windows.Controls.TextBox text_DanhMuc;
        
        internal System.Windows.Controls.Button button;
        
        internal Microsoft.Expression.Interactivity.Core.GoToStateAction Collapsed;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/DynamicCode;component/BanNH.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.VisiualGroup = ((System.Windows.VisualStateGroup)(this.FindName("VisiualGroup")));
            this.VisualStateLoaded = ((System.Windows.VisualState)(this.FindName("VisualStateLoaded")));
            this.VisualStateVisible = ((System.Windows.VisualState)(this.FindName("VisualStateVisible")));
            this.VisualStateCollapsed = ((System.Windows.VisualState)(this.FindName("VisualStateCollapsed")));
            this.rect_HeThongBan = ((System.Windows.Shapes.Rectangle)(this.FindName("rect_HeThongBan")));
            this.text_HeThongBan = ((System.Windows.Controls.TextBlock)(this.FindName("text_HeThongBan")));
            this.LoadPage = ((Microsoft.Expression.Interactivity.Core.GoToStateAction)(this.FindName("LoadPage")));
            this.ScrollViewTable = ((System.Windows.Controls.ScrollViewer)(this.FindName("ScrollViewTable")));
            this.LayoutTable = ((System.Windows.Controls.Grid)(this.FindName("LayoutTable")));
            this.Visible = ((Microsoft.Expression.Interactivity.Core.GoToStateAction)(this.FindName("Visible")));
            this.Grid_Messagebox = ((System.Windows.Controls.Grid)(this.FindName("Grid_Messagebox")));
            this.rectangle = ((System.Windows.Shapes.Rectangle)(this.FindName("rectangle")));
            this.list_ChooseOptionBan = ((System.Windows.Controls.ListBox)(this.FindName("list_ChooseOptionBan")));
            this.text_DanhMuc = ((System.Windows.Controls.TextBox)(this.FindName("text_DanhMuc")));
            this.button = ((System.Windows.Controls.Button)(this.FindName("button")));
            this.Collapsed = ((Microsoft.Expression.Interactivity.Core.GoToStateAction)(this.FindName("Collapsed")));
        }
    }
}

