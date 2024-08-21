using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerReady.UI
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private RectTransform m_levelRt;
        [SerializeField] private RectTransform m_level_expRt;
        [SerializeField] private Text m_level_exp_textTxt;
        [SerializeField] private RectTransform m_level_levelRt;
        [SerializeField] private Text m_level_level_textTxt;
        // Start is called before the first frame update
        void Awake()
        {
            m_levelRt.anchoredPosition = new Vector2(-Screen.width * 0.2f, -Screen.height / 12);

            m_level_expRt.sizeDelta = new Vector2(Screen.width * 0.3f, Screen.height / 38);

            m_level_exp_textTxt.fontSize = Screen.height / 44;

            m_level_levelRt.anchoredPosition = new Vector2(-Screen.width * 0.15f, 0);
            m_level_levelRt.sizeDelta = new Vector2(Screen.height / 12, Screen.height / 12);

            m_level_level_textTxt.fontSize = Screen.height / 33;
        }
    }
}
