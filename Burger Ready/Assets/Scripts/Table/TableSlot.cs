using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Table
{
    public class TableSlot : MonoBehaviour
    {
        private TableManager m_tableManager;
        private int m_unlockCost;
        [SerializeField] private GameObject tableUnlockSlotPrefab;
        [SerializeField] private GameObject tablePrefab;
        private GameObject child;

        public void Init(TableManager tableManager, int idx)
        {
            child = null;
            m_tableManager = tableManager;
            m_unlockCost = Constant.unlockTableCost[idx];
            SetToTableUnlockSlot();
        }

        public void SetToTableUnlockSlot()
        {
            child = Instantiate(tableUnlockSlotPrefab, transform.position + Vector3.up * 0.09f, Quaternion.identity);
            child.GetComponent<TableUnlockSlot>().Init(m_unlockCost);
            child.transform.parent = transform;
        }

        public void SetToTableSlot()
        {
            if (child.GetComponent<TableUnlockSlot>() != null)
            {
                Destroy(GetComponent<BoxCollider>());
                child.GetComponent<TableUnlockSlot>().Unlock();
                child = Instantiate(tablePrefab, transform.position, Quaternion.identity);
                child.GetComponent<Table>().Init(m_tableManager);
                child.transform.parent = transform;
                m_tableManager.ReceiveEmptyTable(child.GetComponent<Table>());
            }
        }

        public void ConfigSetToTableSlot()
        {
            Destroy(GetComponent<BoxCollider>());
            if (child != null && child.GetComponent<TableUnlockSlot>() != null)
            {
                child.GetComponent<TableUnlockSlot>().ConfigUnlock();
            }
            child = Instantiate(tablePrefab, transform.position, Quaternion.identity);
            child.GetComponent<Table>().Init(m_tableManager);
            child.transform.parent = transform;
        }

        public Table GetTable()
        {
            return child.GetComponent<Table>();
        }

        public int UnlockCost { get { return m_unlockCost; } }
    }
}
