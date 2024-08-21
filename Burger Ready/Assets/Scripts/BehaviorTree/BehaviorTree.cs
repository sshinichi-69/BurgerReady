using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public abstract class BehaviorTree : MonoBehaviour
    {
        protected Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
            {
                _root.Tick();
            }
        }

        protected abstract Node SetupTree();
    }
}
