using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Counter
{
    public class CounterTray : MonoBehaviour
    {
        private Stack<GameObject> m_burgers;

        // Start is called before the first frame update
        void Start()
        {
            m_burgers = new Stack<GameObject>();
        }

        public void TakeBurger(List<GameObject> burgers)
        {
            foreach (GameObject burger in burgers)
            {
                burger.transform.position = transform.position + m_burgers.Count * Constant.burgerHeight * Vector3.up;
                burger.transform.parent = transform;
                m_burgers.Push(burger);
            }
        }

        public List<GameObject> SellBurger(int nBurgerSell)
        {
            int n = nBurgerSell < m_burgers.Count ? nBurgerSell : m_burgers.Count;
            List<GameObject> result = new List<GameObject>();
            for (int i = 0; i < n; i++)
            {
                GameObject burger = m_burgers.Peek();
                burger.transform.SetParent(null, false);
                result.Add(burger);
                m_burgers.Pop();
            }
            return result;
        }
    }
}
