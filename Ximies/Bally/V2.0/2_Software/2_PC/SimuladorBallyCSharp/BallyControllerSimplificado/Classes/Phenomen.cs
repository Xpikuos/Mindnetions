using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallyControllerSimplificado.Classes
{
    class Phenomen
    {
        public int Size { get; set; }

        private string[] _descriptions;
        private string _sensorId;
        
        private int _valorAnteriorSensor;

        private FuzzyPhenomena _inputFuzzyPhenomena;
        private FuzzyPhenomena _changeFuzzyPhenomena;
        private FuzzyPhenomena _durationFuzzyPhenomena;

        public Phenomen(string idDelSensor)
        {
            _sensorId = idDelSensor;
            _valorAnteriorSensor = 0;

            _inputFuzzyPhenomena = new FuzzyPhenomena();
            _changeFuzzyPhenomena = new FuzzyPhenomena();
            _durationFuzzyPhenomena = new FuzzyPhenomena();
        }

        int SearchTheMaximum(int[] valores, int longitud, ref int indice)
        {
            int valorTemporal = 0;
            for (int i = 0; i < longitud; i++)
            {
                if (valores[i] > valorTemporal)
                {
                    valorTemporal = valores[i];
                    indice = i;
                }
            }
            return valorTemporal;
        }

        string GetChangingSymbolGivenSymbolIndex(int symbolIndex)
        {
            switch (symbolIndex)
            {
                case 0: return "↑";
                case 1: return "≡";
                case 2: return "↓";
                default: return "?";
            }
        }



        int ChangingPhenomena(int inputValue, ref int descriptionIndex)
        {
            var outputValues= new int[3];
            outputValues[0] = Increase(inputValue); //crece ↑
            outputValues[1] = Holds(inputValue); //se mantiene ≡ 
            outputValues[2] = Decrease(inputValue); //decrece ↓
    
            int symbolIndex = 0;
            int maximumValue = SearchTheMaximum(outputValues, 3, ref symbolIndex);
            string symbol = GetChangingSymbolGivenSymbolIndex(symbolIndex);
            _descriptions[descriptionIndex++] = symbol;

            _descriptions[descriptionIndex++] = maximumValue.ToString();

            _valorAnteriorSensor = inputValue;
            return maximumValue;
        }

        int DurationPhenomenon(int inputValue, ref int descriptionIndex)
        {
            _descriptions[descriptionIndex++] = "T";
            int duration = Duration(inputValue);
            _descriptions[descriptionIndex++] = duration.ToString();
            return duration;
        }

        int HeaderDescription(int inputValue, ref int descriptionIndex)
        {
            _descriptions[descriptionIndex++] = _sensorId;
            _descriptions[descriptionIndex++] = inputValue.ToString();
            return inputValue;
        }

        public string[] PhenomenologicDescription(uint level, int inputValue, bool putValuesInDescription, bool composition)
        {
            int descriptionIndex = 0;
            int previousValue = 0;
            switch (level)
            {
                case 0:
                    Size = 2;
                    _descriptions = new string[Size];
                    HeaderDescription(inputValue, ref descriptionIndex);
                    break;
                case 1:
                    Size = 4;
                    _descriptions = new string[Size];
                    previousValue = HeaderDescription(inputValue, ref descriptionIndex);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    _inputFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    break;
                case 2:
                    Size = 6;
                    _descriptions = new string[Size];
                    previousValue = HeaderDescription(inputValue, ref descriptionIndex);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    previousValue = _inputFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    if(composition)
                    {
                        ChangingPhenomena(previousValue, ref descriptionIndex);
                    }
                    else
                    {
                        ChangingPhenomena(inputValue, ref descriptionIndex);
                    }
                    break;
                case 3:
                    Size = 8;
                    _descriptions = new string[Size];
                    previousValue = HeaderDescription(inputValue, ref descriptionIndex);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    previousValue = _inputFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    if (composition)
                    {
                        previousValue = ChangingPhenomena(previousValue, ref descriptionIndex);
                    }
                    else
                    {
                        previousValue = ChangingPhenomena(inputValue, ref descriptionIndex);
                    }
                    if (previousValue == 0) break;
                    _changeFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    break;
                case 4:
                    Size = 10;
                    _descriptions = new string[Size];
                    previousValue = HeaderDescription(inputValue, ref descriptionIndex);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    previousValue = _inputFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    if (composition)
                    {
                        previousValue = ChangingPhenomena(previousValue, ref descriptionIndex);
                    }
                    else
                    {
                        previousValue = ChangingPhenomena(inputValue, ref descriptionIndex);
                    }
                    if (previousValue == 0) break;
                    previousValue = _changeFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    if (previousValue == 0) break;
                    DurationPhenomenon(previousValue, ref descriptionIndex);
                    break;
                case 5:
                    Size = 10;//12
                    _descriptions = new string[Size];
                    previousValue = HeaderDescription(inputValue, ref descriptionIndex);
                    if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    //previousValue = _inputFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    //if (previousValue == 0) { _valorAnteriorSensor = inputValue; break; }
                    if (composition)
                    {
                        previousValue = ChangingPhenomena(previousValue, ref descriptionIndex);
                    }
                    else
                    {
                        previousValue = ChangingPhenomena(inputValue, ref descriptionIndex);
                    }
                    if (previousValue == 0) break;
                    previousValue = _changeFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    if (previousValue == 0) break;
                    previousValue = DurationPhenomenon(previousValue, ref descriptionIndex);
                    if (previousValue == 0) break;
                    _durationFuzzyPhenomena.GetFuzzyPhenomena(previousValue, ref descriptionIndex, _descriptions);
                    break;
            }

            previousValue = Convert.ToInt32(_descriptions[descriptionIndex - 1]);
            if (previousValue == 0)
            {
                Size -= 2;
            }

            if (!putValuesInDescription)
            {
                var descriptionOnlyWithSymbols = new string[Size / 2];
                int i = 0;
                while (i < Size/2)
                {
                    descriptionOnlyWithSymbols[i] = _descriptions[i * 2];
                    i++;
                }
                _descriptions = descriptionOnlyWithSymbols;
            }

            return _descriptions;
        }

        int Increase(int sensorActualValue)
        {
            int diferencia = sensorActualValue - _valorAnteriorSensor;
            if (diferencia > 0)
            {
                return diferencia;
            }
            else
            {
                return 0;
            }
        }

        int Holds(int sensor)
        {
            if (sensor != _valorAnteriorSensor)
            {
                return 0;
            }
            else
            {
                return sensor;
            }
        }

        int Decrease(int valorActualDelSensor)
        {
            int diferencia = _valorAnteriorSensor - valorActualDelSensor;
            if (diferencia > 0)
            {
                return diferencia;
            }
            else
            {
                return 0;
            }
        }

        int Duration(int valor)
        {
            return 0;
        }
    }
}
