using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Table
{
    public class TableManager : MonoBehaviour
    {
        private List<TableSlot> tableSlots;
        private List<Table> emptyTables;

        [SerializeField] private RestaurantController restaurant;
        [SerializeField] private List<Vector3> tableSlotsPos;
        [SerializeField] private GameObject tableSlotPrefab;
        // Start is called before the first frame update
        void Start()
        {
            tableSlots = new List<TableSlot>();
            emptyTables = new List<Table>();

            GameObject table = Instantiate(tableSlotPrefab, tableSlotsPos[0], Quaternion.identity);
            table.GetComponent<TableSlot>().Init(this, 0);
            table.transform.parent = transform;
            table.GetComponent<TableSlot>().ConfigSetToTableSlot();
            tableSlots.Add(table.GetComponent<TableSlot>());

            emptyTables.Add(tableSlots[0].GetComponent<TableSlot>().GetTable());
        }

        public Table FindTableForCustomer()
        {
            if (emptyTables.Count == 0)
            {
                return null;
            }
            Table result = emptyTables[0];
            emptyTables.RemoveAt(0);
            return result;
        }

        public void ReceiveEmptyTable(Table table)
        {
            emptyTables.Add(table);
            if (emptyTables.Count == 1)
            {
                NotifyEmptyTable();
            }
        }

        public void NotifyEmptyTable()
        {
            if (restaurant.GiveTableToCustomer(emptyTables[0]))
            {
                emptyTables.RemoveAt(0);
            }
        }

        public void OpenNewSlot()
        {
            int idx = tableSlots.Count;
            GameObject table = Instantiate(tableSlotPrefab, tableSlotsPos[idx], Quaternion.identity);
            table.GetComponent<TableSlot>().Init(this, idx);
            table.transform.parent = transform;
            tableSlots.Add(table.GetComponent<TableSlot>());
        }
    }
}
