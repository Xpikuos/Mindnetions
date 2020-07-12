using BallyControllerSimplificado.Cara;
using BallyControllerSimplificado.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BallyControllerSimplificado
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _oldDIzq;
        private double _oldDDer;
        private double _oldEIzq;
        private double _oldEDer;

        private double _oldPIzq;
        private double _oldPDer;
        private double _oldQIzq;
        private double _oldQDer;

        private double _oldKIzq;
        private double _oldKDer;
        private double _oldNIzq;
        private double _oldNDer;

        private Timer _timerToReadInputValuesForPhenomen;
        public ObservableCollection<RowForListViewPhenomen> _listOfRowsForListViewPhenomen;

        public MainWindow()
        {
            InitializeComponent();

            _listOfRowsForListViewPhenomen = new ObservableCollection<RowForListViewPhenomen>();

            _timerToReadInputValuesForPhenomen = new Timer();
            _timerToReadInputValuesForPhenomen.Elapsed += _timerToReadInputValuesForPhenomen_Elapsed;

            ListViewValuesAndPhenomena.ItemsSource = _listOfRowsForListViewPhenomen;

            SliderX.Maximum = 25;
            SliderX.Minimum = -25;
            SliderY.Maximum = 25;
            SliderY.Minimum = -25;

            SliderApertura.Maximum = 25;
            SliderApertura.Minimum = -25;

            SliderDilatacion.Maximum = 100;
            SliderDilatacion.Minimum = 0;

            SliderInclinacionParapadoSuperior.Maximum = 25;
            SliderInclinacionParapadoSuperior.Minimum = -25;

            SliderInclinacionParapadoInferior.Maximum = 25;
            SliderInclinacionParapadoInferior.Minimum = -25;

            SliderAIzq.Maximum = 100;
            SliderAIzq.Minimum = 0;
            SliderBIzq.Maximum = 25;
            SliderBIzq.Minimum = -25;
            SliderCIzq.Maximum = 100;
            SliderCIzq.Minimum = 0;
            SliderDIzq.Maximum = 100;
            SliderDIzq.Minimum = 0;
            SliderEIzq.Maximum = 100;
            SliderEIzq.Minimum = 0;
            SliderFIzq.Maximum = 200;
            SliderFIzq.Minimum = 0;
            SliderGIzq.Maximum = 200;
            SliderGIzq.Minimum = 0;
            SliderHIzq.Maximum = 100;
            SliderHIzq.Minimum = 0;
            SliderKIzq.Maximum = 100;
            SliderKIzq.Minimum = 0;
            SliderMIzq.Maximum = 100;
            SliderMIzq.Minimum = 0;
            SliderNIzq.Maximum = 100;
            SliderNIzq.Minimum = 0;
            SliderOIzq.Maximum = 100;
            SliderOIzq.Minimum = 0;
            SliderPIzq.Maximum = 100;
            SliderPIzq.Minimum = 0;
            SliderQIzq.Maximum = 100;
            SliderQIzq.Minimum = 0;
            SliderRIzq.Maximum = 100;
            SliderRIzq.Minimum = 0;
            SliderSIzq.Maximum = 25;
            SliderSIzq.Minimum = -25;
            SliderTIzq.Maximum = 25;
            SliderTIzq.Minimum = -25;

            SliderADer.Maximum = 100;
            SliderADer.Minimum = 0;
            SliderBDer.Maximum = 25;
            SliderBDer.Minimum = -25;
            SliderCDer.Maximum = 100;
            SliderCDer.Minimum = 0;
            SliderDDer.Maximum = 100;
            SliderDDer.Minimum = 0;
            SliderEDer.Maximum = 100;
            SliderEDer.Minimum = 0;
            SliderFDer.Maximum = 200;
            SliderFDer.Minimum = 0;
            SliderGDer.Maximum = 200;
            SliderGDer.Minimum = 0;
            SliderHDer.Maximum = 100;
            SliderHDer.Minimum = 0;
            SliderKDer.Maximum = 100;
            SliderKDer.Minimum = 0;
            SliderMDer.Maximum = 100;
            SliderMDer.Minimum = 0;
            SliderNDer.Maximum = 100;
            SliderNDer.Minimum = 0;
            SliderODer.Maximum = 100;
            SliderODer.Minimum = 0;
            SliderPDer.Maximum = 100;
            SliderPDer.Minimum = 0;
            SliderQDer.Maximum = 100;
            SliderQDer.Minimum = 0;
            SliderRDer.Maximum = 100;
            SliderRDer.Minimum = 0;
            SliderSDer.Maximum = 25;
            SliderSDer.Minimum = -25;
            SliderTDer.Maximum = 25;
            SliderTDer.Minimum = -25;

            SliderAIzq.Value = 50;
            SliderBIzq.Value = 0;
            SliderCIzq.Value = 50;
            SliderDIzq.Value = 34;
            SliderEIzq.Value = 19;
            SliderFIzq.Value = 100;
            SliderGIzq.Value = 115;
            SliderHIzq.Value = 29;
            SliderKIzq.Value = 46;
            SliderMIzq.Value = 25;
            SliderNIzq.Value = 35;
            SliderOIzq.Value = 67;
            SliderPIzq.Value = 41;
            SliderQIzq.Value = 30;
            SliderRIzq.Value = 70;
            SliderSIzq.Value = 0;
            SliderTIzq.Value = 0;

            SliderADer.Value = 50;
            SliderBDer.Value = 0;
            SliderCDer.Value = 50;
            SliderDDer.Value = 34;
            SliderEDer.Value = 19;
            SliderFDer.Value = 100;
            SliderGDer.Value = 115;
            SliderHDer.Value = 29;
            SliderKDer.Value = 46;
            SliderMDer.Value = 25;
            SliderNDer.Value = 35;
            SliderODer.Value = 67;
            SliderPDer.Value = 41;
            SliderQDer.Value = 30;
            SliderRDer.Value = 70;
            SliderSDer.Value = 0;
            SliderTDer.Value = 0;

            SliderDilatacion.Value = 50;
            SliderInclinacionParapadoSuperior.Value = 0;
            SliderInclinacionParapadoInferior.Value = 0;
        }

        #region Sliders Ojo Izquierdo

        private void SliderAIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).A = SliderAIzq.Value;
        }

        private void SliderBIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).B = SliderBIzq.Value;
        }

        private void SliderCIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).C = SliderCIzq.Value;
        }

        private void SliderDIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldDIzq = SliderDIzq.Value;
            CaraBally.OjoIzquierdo.Iris.Margin = new Thickness(_oldDIzq, 0, 0, SliderEIzq.Value);
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).D = _oldDIzq;
        }

        private void SliderEIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldEIzq = SliderEIzq.Value;
            CaraBally.OjoIzquierdo.Iris.Margin = new Thickness(SliderDIzq.Value, 0, 0, _oldEIzq);
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).E = _oldEIzq;
        }

        private void SliderFIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).F = SliderFIzq.Value;
        }

        private void SliderGIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).G = SliderGIzq.Value;
        }

        private void SliderHIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).H = SliderHIzq.Value;
        }

        private void SliderKIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldKIzq = SliderKIzq.Value;
            CaraBally.OjoIzquierdo.Pupila.Margin = new Thickness(0, 0, _oldKIzq, SliderNIzq.Value);
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).K = _oldKIzq;
        }

        private void SliderMIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).M = SliderMIzq.Value;
        }

        private void SliderNIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldNIzq = SliderNIzq.Value;
            CaraBally.OjoIzquierdo.Pupila.Margin = new Thickness(0, 0, SliderKIzq.Value, _oldNIzq);
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).N = _oldNIzq;
        }

        private void SliderOIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).O = SliderOIzq.Value;
        }

        private void SliderPIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldPIzq = SliderPIzq.Value;
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).P = _oldPIzq;
        }

        private void SliderQIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldQIzq = SliderQIzq.Value;
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).Q = _oldQIzq;
        }

        private void SliderRIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).R = SliderRIzq.Value;
        }

        private void SliderSIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).S = SliderSIzq.Value;
        }

        private void SliderTIzq_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).T = SliderTIzq.Value;
        }

        #endregion Sliders Ojo Izquierdo

        #region Sliders Ojo Derecho

        private void SliderADer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).A = SliderADer.Value;
        }

        private void SliderBDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).B = SliderBDer.Value;
        }

        private void SliderCDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).C = SliderCDer.Value;
        }

        private void SliderDDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldDDer = SliderDDer.Value;
            CaraBally.OjoDerecho.Iris.Margin = new Thickness(_oldDDer, 0, 0, SliderEDer.Value);
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).D = _oldDDer;
        }

        private void SliderEDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldEDer = SliderEDer.Value;
            CaraBally.OjoDerecho.Iris.Margin = new Thickness(SliderDDer.Value, 0, 0, _oldEDer);
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).E = _oldEDer;
        }

        private void SliderFDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).F = SliderFDer.Value;
        }

        private void SliderGDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).G = SliderGDer.Value;
        }

        private void SliderHDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).H = SliderHDer.Value;
        }

        private void SliderKDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldKDer = SliderKDer.Value;
            CaraBally.OjoDerecho.Pupila.Margin = new Thickness(0, 0, _oldKDer, SliderNDer.Value);
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).K = _oldKDer;
        }

        private void SliderMDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).M = SliderMDer.Value;
        }

        private void SliderNDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldNDer = SliderNDer.Value;
            CaraBally.OjoDerecho.Pupila.Margin = new Thickness(0, 0, SliderKDer.Value, _oldNDer);
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).N = _oldNDer;
        }

        private void SliderODer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).O = SliderODer.Value;
        }

        private void SliderPDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldPDer = SliderPDer.Value;
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).P = _oldPDer;
        }

        private void SliderQDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _oldQDer = SliderQDer.Value;
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).Q = _oldQDer;
        }

        private void SliderRDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).R = SliderRDer.Value;
        }

        private void SliderSDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).S = SliderSDer.Value;
        }

        private void SliderTDer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).T = SliderTDer.Value;
        }
 
        #endregion Sliders Ojo Derecho

        #region Sliders Ojos
        private void SliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CaraBally.OjoIzquierdo.Iris.Margin = new Thickness(_oldDIzq + SliderX.Value, 0, 0, _oldEIzq + SliderY.Value);
            CaraBally.OjoDerecho.Iris.Margin = new Thickness(_oldDDer + SliderX.Value, 0, 0, _oldEDer + SliderY.Value);
            //Margin="0,0,46,35"
            CaraBally.OjoIzquierdo.Pupila.Margin = new Thickness(0, 0 , _oldKIzq - SliderX.Value, _oldNIzq + SliderY.Value);
            CaraBally.OjoDerecho.Pupila.Margin = new Thickness(0, 0, _oldKDer - SliderX.Value, _oldNDer + SliderY.Value);
        }

        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CaraBally.OjoIzquierdo.Iris.Margin = new Thickness(_oldDIzq + SliderX.Value, 0, 0, _oldEIzq + SliderY.Value);
            CaraBally.OjoDerecho.Iris.Margin = new Thickness(_oldDDer + SliderX.Value, 0, 0, _oldEDer + SliderY.Value);

            CaraBally.OjoIzquierdo.Pupila.Margin = new Thickness(0, 0, _oldKIzq - SliderX.Value, _oldNIzq + SliderY.Value);
            CaraBally.OjoDerecho.Pupila.Margin = new Thickness(0, 0, _oldKDer - SliderX.Value, _oldNDer + SliderY.Value);
        }

        private void SliderDilatacion_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).H = SliderDilatacion.Value;
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).M = SliderDilatacion.Value;

            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).H = SliderDilatacion.Value;
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).M = SliderDilatacion.Value;
        }

        private void SliderApertura_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CaraBally.OjoIzquierdo.PapadoSuperior.Height = _oldPIzq + SliderApertura.Value;
            CaraBally.OjoDerecho.PapadoSuperior.Height = _oldPDer + SliderApertura.Value;

            CaraBally.OjoIzquierdo.PapadoInferior.Height = _oldQIzq + SliderApertura.Value;
            CaraBally.OjoDerecho.PapadoInferior.Height = _oldQDer + SliderApertura.Value;
        }

        private void SliderInclinacionParapadoSuperior_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).S = SliderSDer.Value + SliderInclinacionParapadoSuperior.Value;
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).S = SliderSIzq.Value - SliderInclinacionParapadoSuperior.Value;
        }

        private void SliderInclinacionParapadoInferior_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((OjoBinding)CaraBally.OjoDerecho.DataContext).T = SliderTDer.Value + SliderInclinacionParapadoInferior.Value;
            ((OjoBinding)CaraBally.OjoIzquierdo.DataContext).T = SliderTIzq.Value - SliderInclinacionParapadoInferior.Value;
        }

        #endregion Sliders Ojos

        #region Sliders Boca
        private void SliderS_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private void SliderT_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    

        private void SliderU_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderV_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderW_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


        }

        #endregion Sliders Boca

        #region Sliders Cuerpo
        private void CaraBally_MouseMove(object sender, MouseEventArgs e)
        {
            var posicion = e.GetPosition(CaraBally);
            SliderX.Value = -15+posicion.X/10;
            SliderY.Value =  15-posicion.Y/10;
        }

        private void SliderCabeza_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderCabezaGiro_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderEsfera_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderBrazoIzquierdo_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderBrazoIzquierdoSubirBajar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private void SliderBrazoDerecho_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderBrazoDerechoSubirBajar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        #endregion Sliders Cuerpo

        #region Phenomena
        private int i = 0;
        private Phenomen _phenomen;

        private void _timerToReadInputValuesForPhenomen_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                var description = _phenomen.PhenomenologicDescription(Convert.ToUInt32(TextBoxLevel.Text), Convert.ToInt32(SliderValueInputForPhenomen.Value),CheckBoxShowValue?.IsChecked==true,CheckBoxComposition?.IsChecked == true);
                var row = new RowForListViewPhenomen(Convert.ToDouble(TextBoxMin.Text), Convert.ToDouble(TextBoxMax.Text), SliderValueInputForPhenomen.Value);
                row.Description = string.Join("",description);
                row.Time = i++;
                _listOfRowsForListViewPhenomen.Insert(0,row);
            });
        }

        private void TextBoxSamplePeriod_TextChanged(object sender, TextChangedEventArgs e)
        {
            var periodTimer = Convert.ToDouble(TextBoxSamplePeriod.Text);
            if (_timerToReadInputValuesForPhenomen != null && periodTimer>0)
            {
                _timerToReadInputValuesForPhenomen.Interval = Convert.ToDouble(periodTimer);
            }
        }

        private void ButtonStartPhenomenSampling_Click(object sender, RoutedEventArgs e)
        {
            _phenomen = new Phenomen(TextBoxSensorId.Text);
            _timerToReadInputValuesForPhenomen?.Start();
        }

        private void ButtonStopPhenomenSampling_Click(object sender, RoutedEventArgs e)
        {
            _timerToReadInputValuesForPhenomen?.Stop();
        }

        private void TextBoxMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            SliderValueInputForPhenomen.Minimum = Convert.ToDouble(TextBoxMin.Text);
            ProgressBarMonitor.Minimum = Convert.ToDouble(TextBoxMin.Text);
        }

        private void TextBoxMax_TextChanged(object sender, TextChangedEventArgs e)
        {
            SliderValueInputForPhenomen.Maximum = Convert.ToDouble(TextBoxMax.Text);
            ProgressBarMonitor.Maximum = Convert.ToDouble(TextBoxMax.Text);
        }

        private void SliderValueInputForPhenomen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ProgressBarMonitor.Value = Convert.ToInt32(SliderValueInputForPhenomen.Value);
        }


        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            _listOfRowsForListViewPhenomen.Clear();
        }


        private void SliderDescriptionLevel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (TextBoxLevel != null)
            {
                TextBoxLevel.Text = Convert.ToInt32(SliderDescriptionLevel.Value).ToString();
            }
        }


        #endregion Phenomena

        #region Save configuration
        private void ButtonDirectory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxConfigurationFile_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonSaveConfiguration_Click(object sender, RoutedEventArgs e)
        {
            //https://csharp.hotexamples.com/es/examples/Accord.Fuzzy/FuzzySet/-/php-fuzzyset-class-examples.html

            //cada valor de cada parámetro supone un centro de una función de pertentencia
            //excepto a las coordenadas de los globos oculares, pupilas e iris
            //que no tienen ninguna función de pertenencia asociada

            //cada vez que checkeo un slider de las emociones básicas
            //y selecciono un radio button (small,normal o big, para el tipo de función de pertenencia que queramos crear)
            //se coloca el slider en su posición correspondiente (a cero, en medio, al máximo)
            //y se miran los valores de los parámetros, creando las funciones de pertenencia "para las salidas (consecuencias)" corresondientes
            //con el siguiente formato: NombreDelParametro_TipoDeFuncionDePertenencia
            //y se crea tb la función de pertenencia "predecesora"con el siguiente formato: NombreDelaEmocionBase_TipoDeFuncionDePertenencia
            //y se generarían las siguientes reglas:
            //
            //if NombreDelaEmocionBase is NombreDelaEmocionBase_TipoDeFuncionDePertenencia => NombreDelParametro0 is NombreDelParametro0_TipoDeFuncionDePertenencia
            //if NombreDelaEmocionBase is NombreDelaEmocionBase_TipoDeFuncionDePertenencia => NombreDelParametro1 is NombreDelParametro1_TipoDeFuncionDePertenencia
            //if NombreDelaEmocionBase is NombreDelaEmocionBase_TipoDeFuncionDePertenencia => NombreDelParametro1 is NombreDelParametro2_TipoDeFuncionDePertenencia
            //...
        }
        #endregion Save configuration
    }
}
