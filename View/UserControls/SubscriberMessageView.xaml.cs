﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Base.Enumerations;
using Base.Events;

namespace View.UserControls
{
    /// <summary>
    /// Interaction logic for SubscriberMessageView.xaml
    /// </summary>
    public partial class SubscriberMessageView : UserControl
    {
        public static readonly DependencyProperty FilterLevelProperty = DependencyProperty.Register(nameof(FilterLevel), typeof(Base.Enumerations.ErrorLevel), typeof(SubscriberMessageView), new PropertyMetadata(Base.Enumerations.ErrorLevel.Unassigned, FilterLevelChangedCallback));
        public static readonly DependencyProperty SenderTypeFilterProperty = DependencyProperty.Register(nameof(SenderTypeFilter), typeof(System.Type), typeof(SubscriberMessageView), new PropertyMetadata(null, SenderTypeFilterChangedCallback));
        public static readonly DependencyProperty MessageTypeFilterProperty = DependencyProperty.Register(nameof(MessageTypeFilter), typeof(System.Type), typeof(SubscriberMessageView), new PropertyMetadata(null, MessageTypeFilterChangedCallback));
        public static readonly DependencyProperty MessageCountProperty = DependencyProperty.Register(nameof(MessageCount), typeof(int), typeof(SubscriberMessageView), new PropertyMetadata(100, MessageCountChangedCallback));

        private ViewModel.Implementations.SubscriberMessageViewModel _vm = new ViewModel.Implementations.SubscriberMessageViewModel();
        public int MessageCount
        {
            get { return (int)GetValue(MessageCountProperty); }
            set { SetValue(MessageCountProperty, value); }
        }
        public ErrorLevel FilterLevel
        {
            get
            {
                return (Base.Enumerations.ErrorLevel)GetValue(FilterLevelProperty);
            }
            set
            {
                SetValue(FilterLevelProperty, value);
            }
        }
        public Type SenderTypeFilter
        {
            get
            {
                return (Type)GetValue(SenderTypeFilterProperty);
            }
            set
            {
                SetValue(SenderTypeFilterProperty, value);
            }
        }
        public Type MessageTypeFilter
        {
            get
            {
                return (Type)GetValue(MessageTypeFilterProperty);
            }
            set
            {
                SetValue(MessageTypeFilterProperty, value);
            }
        }
        public SubscriberMessageView()
        {
            InitializeComponent();
            DataContext = _vm;
            _vm.FilterLevel = FilterLevel;
            _vm.SenderTypeFilter = SenderTypeFilter;
            _vm.MessageTypeFilter = MessageTypeFilter;
            Base.Implementations.MessageHub.Subscribe(_vm);
        }
        private static void FilterLevelChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SubscriberMessageView v = d as SubscriberMessageView;
            v._vm.FilterLevel = v.FilterLevel;
        }
        private static void SenderTypeFilterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SubscriberMessageView v = d as SubscriberMessageView;
            System.Diagnostics.Debugger.Break();
            v._vm.SenderTypeFilter = v.SenderTypeFilter;
        }
        private static void MessageTypeFilterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SubscriberMessageView v = d as SubscriberMessageView;
            v._vm.MessageTypeFilter = v.MessageTypeFilter;
        }
        private static void MessageCountChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SubscriberMessageView v = d as SubscriberMessageView;
            v._vm.MessageCount = v.MessageCount;
        }
    }
}
