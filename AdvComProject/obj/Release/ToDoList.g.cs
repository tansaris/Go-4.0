﻿

#pragma checksum "\\psf\home\documents\visual studio 2013\Projects\AdvComProject\AdvComProject\ToDoList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1A5E17663D5387703F4718431E3BAC55"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdvComProject
{
    partial class ToDoList : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 39 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.addtaskbutton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 70 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.savetask_click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 88 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.text_edit;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 100 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.text_edit;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 112 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.text_edit;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 124 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.text_edit;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 191 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.date_change;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 203 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.date_change2;
                 #line default
                 #line hidden
                break;
            case 9:
                #line 215 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.date_change3;
                 #line default
                 #line hidden
                break;
            case 10:
                #line 225 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.date_change4;
                 #line default
                 #line hidden
                break;
            case 11:
                #line 235 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.DatePicker)(target)).DateChanged += this.date_change5;
                 #line default
                 #line hidden
                break;
            case 12:
                #line 286 "..\..\ToDoList.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.back_button_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


