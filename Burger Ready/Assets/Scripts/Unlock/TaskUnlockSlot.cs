using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using BurgerReady.Restaurant.Table;

namespace BurgerReady.UnlockBT
{
    public class TaskUnlockSlot : Node
    {
        private TableManager m_tableManager;

        public TaskUnlockSlot(TableManager tableManager)
        {
            m_tableManager = tableManager;
        }

        public override NodeState Tick()
        {
            m_tableManager.OpenNewSlot();
            return NodeState.RUNNING;
        }
    }
}
