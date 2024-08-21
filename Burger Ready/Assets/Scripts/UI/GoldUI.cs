using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerReady.UI
{
    public class GoldUI : MonoBehaviour
    {
        [SerializeField] private RectTransform m_goldRt;
        [SerializeField] private RectTransform m_gold_backgroundRt;
        [SerializeField] private RectTransform m_gold_iconRt;
        [SerializeField] private Text m_gold_textTxt;

        private void Awake()
        {
            m_goldRt.anchoredPosition = new Vector2(Screen.width * 0.15f, -Screen.height / 12);

            m_gold_backgroundRt.sizeDelta = new Vector2(Screen.width * 0.3f, Screen.height / 19);

            m_gold_iconRt.sizeDelta = new Vector2(Screen.height / 12, Screen.height / 12);

            m_gold_textTxt.fontSize = Screen.height / 33;
        }
    }
}
