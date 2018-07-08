using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Weather.Models
{
    public class Country : INotifyPropertyChanged
    {
        private bool isSelected;
        private bool isExpanded = true;

        public ObservableCollection<Region> Regions { get; set; }

        public string Name { get; set; }

        public Country()
        {
            Regions = new ObservableCollection<Region>();
        }

        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }

            set
            {
                isExpanded = value;
                this.OnPropertyChanged("IsExpanded");
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                if (value)
                    IsExpanded = !IsExpanded;

                isSelected = false;
                this.OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
