using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Customer
{
    public class CustomerQueue : MonoBehaviour
    {
        private List<Customer> customers;

        const int maxSize = 12;
        Vector3 customerInitPos;

        [SerializeField] private RestaurantController m_restaurant;

        [SerializeField] private GameObject customerPrefab;
        [SerializeField] private GameObject otherCustomer;
        // Start is called before the first frame update
        void Start()
        {
            customers = new List<Customer>();

            customerInitPos = new Vector3(-5, 1, -15);
        }

        public void MoveToCounter()
        {
            bool isFirst = true;
            foreach (Customer customer in customers)
            {
                if (isFirst)
                {
                    customer.IsFirstCustomer = true;
                    isFirst = false;
                }
                customer.MoveToCounter();
            }
        }

        public void AddNewCustomer()
        {
            if (customers.Count < maxSize)
            {
                Vector3 customerPos = new Vector3(-5, 1, 10 - (customers.Count + 1) * Constant.customerDistance);
                GameObject customer = Instantiate(customerPrefab, customerInitPos, Quaternion.identity);
                customer.GetComponent<Customer>().Init(this, customerPos, customers.Count == 0);
                customer.transform.parent = transform;
                customers.Add(customer.GetComponent<Customer>());
            }
        }

        public int GetFirstCustomerBurgerQuantity()
        {
            if (customers.Count == 0)
            {
                return 0;
            }
            if (customers[0].State == CustomerState.WAITING_BURGER)
            {
                return customers[0].GetRestBurgersNeedQuantity();
            }
            return 0;
        }

        public void SellBurger(List<GameObject> burgers)
        {
            if (customers.Count > 0)
            {
                customers[0].BuyBurger(burgers);
            }
        }
        
        public void PopFirstCustomer()
        {
            Customer customer = customers[0];
            customer.transform.parent = otherCustomer.transform;
            customers.RemoveAt(0);
            MoveToCounter();
        }

        public Table.Table FindTableForCustomer()
        {
            Table.Table table = m_restaurant.FindTableForCustomer();
            if (table != null)
            {
                PopFirstCustomer();
            }
            return table;
        }

        public bool GiveTableToCustomer(Table.Table table)
        {
            if (customers.Count > 0)
            {
                if (customers[0].GetTable(table))
                {
                    PopFirstCustomer();
                    return true;
                }
            }
            return false;
        }
    }
}
