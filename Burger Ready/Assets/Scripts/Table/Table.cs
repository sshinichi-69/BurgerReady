using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Table
{
    public class Table : MonoBehaviour
    {
        private TableManager m_tableManager;
        private Customer.Customer m_customer;
        // Start is called before the first frame update
        void Start()
        {
            m_customer = null;
        }

        public void Init(TableManager tableManager)
        {
            m_tableManager = tableManager;
        }

        public void CustomerSit(Customer.Customer customer)
        {
            m_customer = customer;
        }

        public void CustomerLeave()
        {
            m_customer = null;
            m_tableManager.ReceiveEmptyTable(this);
        }
    }
}
