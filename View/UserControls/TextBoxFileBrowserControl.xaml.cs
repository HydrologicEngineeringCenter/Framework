﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace HEC.MVVMFramework.View.UserControls
{
    public partial class TextBoxFileBrowserControl : UserControl
    {
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register("Path", typeof(string), typeof(TextBoxFileBrowserControl), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(PathChangedCallBack)));
        public static readonly DependencyProperty CheckFileExistsProperty = DependencyProperty.Register(nameof(CheckFileExists), typeof(bool), typeof(TextBoxFileBrowserControl), new PropertyMetadata(false));
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register(nameof(Filter), typeof(string), typeof(TextBoxFileBrowserControl), new PropertyMetadata("Text Files|*.txt"));
        public static readonly DependencyProperty IsOpenDialogProperty = DependencyProperty.Register(nameof(IsOpenDialog), typeof(bool), typeof(TextBoxFileBrowserControl), new PropertyMetadata(true));
        public static readonly DependencyProperty FileDialogTitleProperty = DependencyProperty.Register(nameof(FileDialogTitle), typeof(string), typeof(TextBoxFileBrowserControl), new PropertyMetadata("Title was not set"));
        public static readonly DependencyProperty MultiSelectProperty = DependencyProperty.Register(nameof(MultiSelect), typeof(bool), typeof(TextBoxFileBrowserControl), new PropertyMetadata(false));

        public TextBoxFileBrowserControl()
        {
            InitializeComponent();
        }
        public string Path
        {
            get { return Convert.ToString(GetValue(PathProperty)); }
            set { SetValue(PathProperty, value);}
        }
        public bool CheckFileExists
        {
            get { return Convert.ToBoolean(GetValue(CheckFileExistsProperty)); }
            set { SetValue(CheckFileExistsProperty, value); }
        }
        public bool IsOpenDialog
        {
            get { return Convert.ToBoolean(GetValue(IsOpenDialogProperty)); }
            set { SetValue(PathProperty, value); }
        }
        public string Filter
        {
            get { return Convert.ToString(GetValue(FilterProperty)); }
            set { SetValue(PathProperty, value); }
        }
        public string FileDialogTitle
        {
            get { return Convert.ToString(GetValue(FileDialogTitleProperty)); }
            set { SetValue(PathProperty, value); }
        }
        public bool MultiSelect
        {
            get { return (bool)GetValue(MultiSelectProperty); }
            set { SetValue(MultiSelectProperty, value); }
        }
        private static void PathChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TextBoxFileBrowserControl owner = sender as TextBoxFileBrowserControl;
            string p = e.NewValue.ToString();
            owner.Path = p;
            owner.TextBox.Text = p;
        }

        private void OpenBrowser(object sender, RoutedEventArgs e)
        {
            if (IsOpenDialog)
            {
                Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
                fileDialog.Filter = Filter;
                fileDialog.Multiselect = MultiSelect;
                fileDialog.CheckFileExists = CheckFileExists;
                fileDialog.Title = FileDialogTitle;
                fileDialog.ShowDialog();
                Path = fileDialog.FileName;

            }
            else
            {
                Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();
                fileDialog.Title = FileDialogTitle ;
                fileDialog.Filter = Filter;
                fileDialog.ShowDialog();
                Path = fileDialog.FileName;
            }
        }
    }
}
