using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestTask_Weather.Models;

namespace TestTask_Weather
{
    public class SelectableTreeView : TreeView
    {
        public SelectableTreeView()
            : base()
        {
            this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(ItemChangedHandler);
        }

        private void ItemChangedHandler(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (SelectedItem != null && SelectedItem is Region)
            {
                SetValue(SelectedItem_Property, SelectedItem);
            }
        }

        public object SelectedItem_
        {
            get
            {
                return (object)GetValue(SelectedItem_Property);
            }
            set
            {
                SetValue(SelectedItem_Property, value);
            }
        }
        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register("SelectedItem_", typeof(object), typeof(SelectableTreeView), new UIPropertyMetadata(null));
    }
}
