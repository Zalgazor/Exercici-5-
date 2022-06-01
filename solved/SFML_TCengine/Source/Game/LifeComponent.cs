using System;
using TCEngine;

namespace TCGame
{
    public class LifeComponent : BaseComponent
    {

        private const int DEFAULT_MAX_HEALTH = 100;

        private int m_MaxHealth;
        private int m_CurrentHealth;

        public int CurrentHealth
        {
            get => m_CurrentHealth;
        }

        public override EComponentUpdateCategory GetUpdateCategory()
        {
            return EComponentUpdateCategory.Update;
        }

        public LifeComponent()
        {
            m_MaxHealth = DEFAULT_MAX_HEALTH;
            m_CurrentHealth = m_MaxHealth;
        }

        public LifeComponent(int _maxHealth)
        {
            m_MaxHealth = _maxHealth;
            m_CurrentHealth = m_MaxHealth;
        }

        public override void Update(float _dt)
        {
            base.Update(_dt);
            
            if( m_CurrentHealth <= 0)
            {
                Owner.Destroy();
            }
        }

        public void IncreaseHealth(int _amount)
        {
            m_CurrentHealth = Math.Min(m_CurrentHealth + _amount, m_MaxHealth);
        }

        public void DecreaseHealth(int _amount)
        {
            m_CurrentHealth = Math.Max(m_CurrentHealth - _amount, 0);
        }

        public override object Clone()
        {
            LifeComponent clonedComponent = new LifeComponent(m_MaxHealth);
            return clonedComponent;
        }
    }
}
