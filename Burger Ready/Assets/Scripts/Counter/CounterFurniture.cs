using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerReady.Restaurant.Counter
{
    public class CounterFurniture : MonoBehaviour
    {
        [SerializeField] private GameObject m_trayPrefab;
        // Start is called before the first frame update
        void Start()
        {
            SetupTray();
        }

        void SetupTray()
        {
            Vector3 originTrayPosition = transform.position + new Vector3(-2.5f, 1.27f, -0.72f);
            for (int i = 0; i < 20; i++)
            {
                GameObject tray = Instantiate(m_trayPrefab, originTrayPosition + 0.05f * (i + 1) * Vector3.up, Quaternion.identity);
                tray.transform.parent = transform;
            }
        }
    }
}
