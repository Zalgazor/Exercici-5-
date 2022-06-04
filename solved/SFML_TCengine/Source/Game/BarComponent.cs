using System;
using TCEngine;

namespace TCGame
{
    
    class BarComponent : BaseComponent
    {
        private const int MAX_PERCENTAGE = 100;
        private int m_BarPercentage;
        BarType m_Type;

        public BarComponent(BarType type)
        {
            m_Type = type;
            m_BarPercentage = MAX_PERCENTAGE;
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public int GetBarPercentage()
        {
            return m_BarPercentage;
        }

        public void IncreasePercentage(int _amount)
        {
            m_BarPercentage = Math.Min(m_BarPercentage + _amount, MAX_PERCENTAGE);
        }

        public void DecreasePercentage(int _amount)
        {
            m_BarPercentage = Math.Max(m_BarPercentage - _amount, 0);
        }

        public override object Clone()
        {
            BarComponent clonedComponent = new BarComponent(m_Type);
            return clonedComponent;
        }
    }

    public enum BarType
    {
        Salud,
        Felicidad,
        Sociabilidad,
        Adiccion,
    }
}
