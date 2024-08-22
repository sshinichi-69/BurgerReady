using BurgerReady.Restaurant.Table;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerReady.Restaurant.Customer
{
    public enum CustomerState
    {
        COMING,
        WAITING_BURGER,
        WAITING_TABLE,
        MOVING_TO_TABLE,
        EATING,
        LEAVING
    }

    public class Customer : MonoBehaviour
    {
        int m_nBurgerNeed;
        Stack<GameObject> m_burgers;
        CustomerState m_state;
        bool m_isFirstCustomer;
        Table.Table m_table;
        CustomerQueue m_customerQueue;

        float m_speed = 1f;
        Queue<Vector3> m_goalPos;

        Animator m_animator;

        [SerializeField] GameObject m_tray;
        [SerializeField] GameObject m_dialogueUi;
        [SerializeField] Text m_nRestBurgerNeedText;
        // Start is called before the first frame update
        void Start()
        {
            m_state = CustomerState.COMING;
            m_burgers = new Stack<GameObject>();
            m_animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            switch (m_state)
            {
                case CustomerState.COMING:
                    if (m_goalPos.Count > 0)
                    {
                        if (Method.IsEqual(transform.position, m_goalPos.Peek()))
                        {
                            if (m_isFirstCustomer)
                            {
                                m_state = CustomerState.WAITING_BURGER;
                                m_animator.Play("Base Layer.CustomerWaitBurger");
                                m_nBurgerNeed = Random.Range(1, GameManager.Instance.PlayerLevel.Value + 1);
                                m_nRestBurgerNeedText.text = m_nBurgerNeed.ToString();
                                m_goalPos.Clear();
                            }
                        }
                        else
                        {
                            transform.Translate(m_speed * Time.deltaTime * Vector3.forward);
                        }
                    }
                    break;
                case CustomerState.WAITING_BURGER:
                    break;
                case CustomerState.WAITING_TABLE:
                    break;
                case CustomerState.MOVING_TO_TABLE:
                    if (m_goalPos.Count == 0)
                    {
                        m_state = CustomerState.EATING;
                        Sit();
                    }
                    else
                    {
                        gameObject.transform.LookAt(m_goalPos.Peek());
                        transform.Translate(m_speed * Time.deltaTime * Vector3.forward);
                        if (Method.IsEqual(transform.position, m_goalPos.Peek()))
                        {
                            m_goalPos.Dequeue();
                        }
                    }
                    break;
                case CustomerState.EATING:
                    break;
                case CustomerState.LEAVING:
                    if (Method.IsEqual(transform.position, m_goalPos.Peek()))
                    {
                        Destroy(gameObject);
                    }
                    else
                    {
                        gameObject.transform.LookAt(m_goalPos.Peek());
                        transform.Translate(m_speed * Time.deltaTime * Vector3.forward);
                    }
                    break;
            }
        }

        public void Init(CustomerQueue customerQueue, Vector3 standPosition, bool isFirstCustomer)
        {
            m_customerQueue = customerQueue;
            m_nBurgerNeed = 1;

            m_goalPos = new Queue<Vector3>();
            m_goalPos.Enqueue(standPosition);

            m_isFirstCustomer = isFirstCustomer;
        }

        public void MoveToCounter()
        {
            Vector3 newGoal = m_goalPos.Peek() + Vector3.forward * Constant.customerDistance;
            m_goalPos.Enqueue(newGoal);
            m_goalPos.Dequeue();
        }

        public void BuyBurger(List<GameObject> burgers)
        {
            if (m_state == CustomerState.WAITING_BURGER) {
                foreach (GameObject burger in burgers)
                {
                    burger.transform.position = m_tray.transform.position + m_burgers.Count * Constant.burgerHeight * Vector3.up;
                    burger.transform.parent = m_tray.transform;
                    m_burgers.Push(burger);
                }
                GameManager.Instance.GainGoldByBurgerSell(burgers.Count);
                m_nRestBurgerNeedText.text = (m_nBurgerNeed - m_burgers.Count).ToString();
                if (m_burgers.Count == m_nBurgerNeed)
                {
                    m_state = CustomerState.WAITING_TABLE;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    m_animator.Play("Base Layer.CustomerWaitTable");
                    FindTable();
                }
            }
        }

        public void FindTable()
        {
            Table.Table table = m_customerQueue.FindTableForCustomer();
            if (table != null)
            {
                SwitchStateToMovingToTable(table);
            }
        }

        public bool GetTable(Table.Table table)
        {
            // return true if the customer get the table, otherwise return false;
            if (m_state == CustomerState.WAITING_TABLE)
            {
                SwitchStateToMovingToTable(table);
                return true;
            }
            return false;
        }

        public void SwitchStateToMovingToTable(Table.Table table)
        {
            m_table = table;
            m_table.CustomerSit(this);
            m_state = CustomerState.MOVING_TO_TABLE;
            m_animator.Play("Base Layer.CustomerMoveToTable");
            SetPathToTable();
        }

        public void SetPathToTable()
        {
            if (m_table == null)
            {
                return;
            }
            Vector3 tablePos = m_table.transform.position;
            m_goalPos.Enqueue(new Vector3(tablePos.x - 2.5f, transform.position.y, transform.position.z));
            m_goalPos.Enqueue(new Vector3(tablePos.x - 2.5f, transform.position.y, tablePos.z));
            m_goalPos.Enqueue(new Vector3(tablePos.x - 2.4f, transform.position.y, tablePos.z));
        }

        public int GetRestBurgersNeedQuantity()
        {
            return m_nBurgerNeed - m_burgers.Count;
        }

        public void Sit()
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            transform.position = m_table.transform.position + new Vector3(0, 1, 1.27f);
            m_animator.Play("Base Layer.CustomerEat");
            StartCoroutine(Eat());
        }

        public IEnumerator Eat()
        {
            yield return new WaitForSeconds(3);
            GameObject burger = m_burgers.Pop();
            Destroy(burger);
            if (m_burgers.Count == 0)
            {
                LeaveTable();
                m_state = CustomerState.LEAVING;
                GameManager.Instance.GainExpPerCustomerAte(Constant.expGainByCustomerAte);
                m_animator.Play("Base Layer.CustomerLeave");
            }
            else
            {
                StartCoroutine(Eat());
            }
        }

        public void LeaveTable()
        {
            transform.position = new Vector3(m_table.transform.position.x - 2.5f, transform.position.y, m_table.transform.position.z);
            m_goalPos.Enqueue(new Vector3(m_table.transform.position.x - 2.5f, transform.position.y, -15f));
            m_table.CustomerLeave();
        }

        public CustomerState State { get { return m_state; } }
        public int NBurgerNeed { get { return m_nBurgerNeed; } }
        public bool IsFirstCustomer { get { return m_isFirstCustomer; } set { m_isFirstCustomer = value; } }
    }
}
