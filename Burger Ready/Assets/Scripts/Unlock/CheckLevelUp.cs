using BehaviorTree;
using BurgerReady.Player;
using System.Collections;
using UnityEngine;

namespace BurgerReady.UnlockBT
{
    public class CheckLevelUp : Node
    {
        private int m_currentLevel;
        private Level m_playerLevel;
        private int m_levelCheck;
        private bool m_isLeveledUp;

        public CheckLevelUp(Level playerLevel, int levelCheck = -1)
        {
            m_currentLevel = playerLevel.Value;
            m_playerLevel = playerLevel;
            m_levelCheck = levelCheck;
            m_isLeveledUp = false;
        }

        public override NodeState Tick()
        {
            if (!m_isLeveledUp)
            {
                if (m_levelCheck == 1)
                {
                    m_isLeveledUp = true;
                    return NodeState.SUCCESS;
                }
                if (m_playerLevel.Value > m_currentLevel)
                {
                    m_currentLevel = m_playerLevel.Value;
                    if (m_levelCheck == -1 && m_currentLevel >= 4)
                    {
                        return NodeState.SUCCESS;
                    }
                    if (m_levelCheck == m_currentLevel)
                    {
                        m_isLeveledUp = true;
                        return NodeState.SUCCESS;
                    }
                }
            }
            return NodeState.FAILURE;
        }
    }
}
