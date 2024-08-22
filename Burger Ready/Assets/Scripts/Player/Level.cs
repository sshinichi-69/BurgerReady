using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Player
{
    public class Level : MonoBehaviour
    {
        private int m_level;
        private int m_exp;
        private int m_maxExp;
        public void Start()
        {
            m_level = 1;
            m_exp = 0;
            m_maxExp = Constant.expToLevelUp[m_level - 1];
            StartCoroutine(Initial());
        }

        public void GainExp(int exp)
        {
            m_exp += exp;
            SetExpUi();
            if (m_exp >= m_maxExp)
            {
                if (m_level <= Constant.expToLevelUp.Count)
                {
                    m_level++;
                    if (m_level <= Constant.expToLevelUp.Count)
                    {
                        m_maxExp = Constant.expToLevelUp[m_level - 1];
                    }
                    SetLevelUi();
                    SetMaxExpUi();
                }
                else
                {
                    m_exp = m_maxExp;
                    SetExpUi();
                }
            }
        }

        public void SetLevelUi()
        {
            GameManager.Instance.SetLevelUi(m_level);
        }

        public void SetExpUi()
        {
            GameManager.Instance.SetExpUi(m_exp, m_maxExp, m_level > Constant.expToLevelUp.Count);
        }

        public void SetMaxExpUi()
        {
            GameManager.Instance.SetMaxExpUi(m_maxExp, m_exp, m_level > Constant.expToLevelUp.Count);
        }

        public IEnumerator Initial()
        {
            yield return new WaitForSeconds(0.01f);
            if (GameManager.Instance == null)
            {
                StartCoroutine(Initial());
            }
            else
            {
                SetLevelUi();
                SetMaxExpUi();
                SetExpUi();
            }
        }

        public int Value { get { return m_level; } }
    }
}
