using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_TCengine.Source.Game
{
    class LifeBar
    {
        private const int MAX_PERCENTAGE = 100;
        int barPercentage;
        BarType type;


        public LifeBar(BarType type)
        {
            this.type = type;
            barPercentage = MAX_PERCENTAGE;
        }

        public int GetBarPercentage()
        {
            return barPercentage;
        }

        public void IncreasePercentage(int _amount)
        {
            barPercentage = Math.Min(barPercentage + _amount, MAX_PERCENTAGE);
        }

        public void DecreaseHealth(int _amount)
        {
            barPercentage = Math.Max(barPercentage - _amount, 0);
        }
    }

    public enum BarType
    {
        Salud,
        Felicidad,
        Sociabilidad,
        Adicción,
    }
}
