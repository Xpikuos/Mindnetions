using System;
using System.Collections.Generic;
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

namespace BallyControllerSimplificado.Cara
{
    /// <summary>
    /// Lógica de interacción para Ojo.xaml
    /// </summary>
    public partial class Ojo : UserControl
    {
        public OjoBinding OjoParameters;
        public Ojo()
        {
            InitializeComponent();
            OjoParameters = new OjoBinding();
            this.DataContext = OjoParameters;
        }
    }
}
