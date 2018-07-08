using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Weather.Models
{
    public class Region : INotifyPropertyChanged
    {
        private bool isSelected;
        private bool isExpanded;

        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }

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
                isSelected = value;
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
