using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BallyControllerSimplificado.Classes
{
    public class RowForListViewPhenomen
    {
        public int Time { get; set; }
        public int Value 
        { 
            get=> _value;
        }

        public double Min
        {
            get => _min;
        }

        public double Max
        {
            get => _max;
        }
        public ProgressBar ProgressBarForValue { get; set; }
        public string Description { get; set; }
        private int _value;
        private double _min;
        private double _max;
        public RowForListViewPhenomen(double min, double max, double value)
        {
            ProgressBarForValue = new ProgressBar();
            ProgressBarForValue.Width = 200;
            ProgressBarForValue.Minimum = min;
            ProgressBarForValue.Maximum = max;
            ProgressBarForValue.Value = value;
            _min = min;
            _max = max;
            _value = Convert.ToInt32(value);
        }

    }
}
