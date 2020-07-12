using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BallyControllerSimplificado.Cara
{
    public class OjoBinding : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private double _a;
        private double _b;
        private double _c;
        private double _d;
        private double _e;
        private double _f;
        private double _g;
        private double _h=29;
        private double _k;
        private double _m=25;
        private double _n;
        private double _o;
        private double _p;
        private double _q;
        private double _r;
        private double _s;
        private double _t;

        public double A
        {
            get => _a;
            set
            {
                _a = value;
                OnPropertyChanged();
            }
        }

        public double B
        {
            get => _b;
            set
            {
                _b = value;
                OnPropertyChanged();
            }
        }

        public double C
        {
            get => _c;
            set
            {
                _c = value;
                OnPropertyChanged();
            }
        }

        public double D
        {
            get => _d;
            set
            {
                _d = value;
                OnPropertyChanged();
            }
        }

        public double E
        {
            get => _e;
            set
            {
                _e = value;
                OnPropertyChanged();
            }
        }

        public double F
        {
            get => _f;
            set
            {
                _f = value;
                OnPropertyChanged();
            }
        }

        public double G
        {
            get => _g;
            set
            {
                _g = value;
                OnPropertyChanged();
            }
        }

        public double H
        {
            get => _h;
            set
            {
                _h = value;
                OnPropertyChanged();
            }
        }

        public double K
        {
            get => _k;
            set
            {
                _k = value;
                OnPropertyChanged();
            }
        }

        public double M
        {
            get => _m;
            set
            {
                _m = value;
                OnPropertyChanged();
            }
        }

        public double N
        {
            get=> _n;
            set
            {
                _n = value;
                OnPropertyChanged();
            }
        }

        public double O
        {
            get => _o;
            set
            {
                _o = value;
                OnPropertyChanged();
            }
        }

        public double P
        {
            get => _p;
            set
            {
                _p = value;
                OnPropertyChanged();
            }
        }

        public double Q
        {
            get => _q;
            set
            {
                _q = value;
                OnPropertyChanged();
            }
        }

        public double R
        {
            get => _r;
            set
            {
                _r = value;
                OnPropertyChanged();
            }
        }

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
    }
}
