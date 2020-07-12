using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BallyControllerSimplificado.Cara
{
    public class BocaBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private double _s;
        private double _t;
        private double _u;
        private double _v;
        private double _w;

        public double S
        {
            get => _s;
            set
            {
                _s = value;
                OnPropertyChanged();
            }
        }

        public double T
        {
            get => _t;
            set
            {
                _t = value;
                OnPropertyChanged();
            }
        }

        public double U
        {
            get => _u;
            set
            {
                _u = value;
                OnPropertyChanged();
            }
        }

        public double V
        {
            get => _v;
            set
            {
                _v = value;
                OnPropertyChanged();
            }
        }

        public double W
        {
            get => _w;
            set
            {
                _w = value;
                OnPropertyChanged();
            }
        }

    }
}
