using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallyControllerSimplificado.Classes
{
    public class FuzzyPhenomena
    {
        private int valorMaximoDeEntrada;
        private int valorMinimoDeEntrada;
        private int m;
        private int n;
        private int limiteInferiorNormal;
        private int puntoMedioNormal;
        private int limiteSuperiorNormal;

        public FuzzyPhenomena()
        {
            valorMaximoDeEntrada = 0;
            valorMinimoDeEntrada = 255;
        }

        string GetFuzzySymbolGivenSymbolIndex(int symbolIndex)
        {
            switch (symbolIndex)
            {
                case 0: return ".";
                case 1: return "o";
                case 2: return "*";
                default: return "?";
            }
        }

        int SearchTheMaximum(int[] valores, int longitud, ref int indice)
        {
            int valorTemporal = 0;
            indice = 0;
            for (var i = 0; i < longitud; i++)
            {
                if (valores[i] > valorTemporal)
                {
                    valorTemporal = valores[i];
                    indice = i;
                }
            }
            return valorTemporal;
        }

        public int GetFuzzyPhenomena(int inputValue, ref int descriptionIndex, string[] descriptions)
        {
            ObtenerRangosDinamicamente(inputValue);
            CalcularFuncionesDePertenencia();

            var outputValues = new int[3];
            outputValues[0] = Small(inputValue); //crece poco '·'
            outputValues[1] = Normal(inputValue); //crece medio 'o'
            outputValues[2] = Big(inputValue); //crece mucho '*'

            int symbolIndex = 0;
            int maximumValue = SearchTheMaximum(outputValues, 3, ref symbolIndex);
            string symbol = GetFuzzySymbolGivenSymbolIndex(symbolIndex);
            descriptions[descriptionIndex++] = symbol;

            descriptions[descriptionIndex++] = maximumValue.ToString();
            return maximumValue;
        }

        void ObtenerRangosDinamicamente(int valor)
        {
            if (valor > valorMaximoDeEntrada)
            {
                valorMaximoDeEntrada = valor;
            }
            else if (valor < valorMaximoDeEntrada)
            {
                valorMinimoDeEntrada = valor;
            }
        }

        void CalcularFuncionesDePertenencia()
        {
            n = 255;

            if(valorMaximoDeEntrada == valorMinimoDeEntrada)
            {
                m = (2 * 255) / valorMaximoDeEntrada;
                limiteInferiorNormal = valorMaximoDeEntrada / 4;
            }
            else
            {
                m = (2 * 255) / (valorMaximoDeEntrada - valorMinimoDeEntrada);
                limiteInferiorNormal = (valorMaximoDeEntrada - valorMinimoDeEntrada) / 4;
            }
            
            puntoMedioNormal = 2 * limiteInferiorNormal;
            limiteSuperiorNormal = 3 * limiteInferiorNormal;
        }

        int Small(int valor)
        {
            if (valor < puntoMedioNormal)
            {
                return (n - (m * valor));
            }
            return 0;
        }

        int Normal(int valor)
        {
            if(valor > limiteInferiorNormal && valor<= puntoMedioNormal)
            {
                return ((m * valor)-n);
            }
            else if (valor > puntoMedioNormal && valor < limiteSuperiorNormal)
            {
                return ((3 * n) - (2 * m * valor));
            }
            return 0;
        }

        int Big(int valor)
        {
            if (valor > puntoMedioNormal && valorMaximoDeEntrada != puntoMedioNormal)
            {
                return (255*(valor- puntoMedioNormal)/(valorMaximoDeEntrada - puntoMedioNormal));
            }
            return 0;
        }
    }
}
