using System.Collections;
using System.Collections.Generic;

namespace Player
{
    public class Level
    {
        private int m_level;
        private int m_exp;
        public Level()
        {
            m_level = 1;
            m_exp = 0;
        }
        public void GainExp(int exp)
        {
            m_exp += exp;
        }
    }
}
