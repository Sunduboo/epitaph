using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTArchitecture {
    public abstract class BehaviorTree : MonoBehaviour
    {
        private Node root = null;
        // Start is called before the first frame update
        protected void Start()
        {
            root = SetupTree();
        }

        // Update is called once per frame
        private void Update()
        {
            if (root != null) {
                root.Evaluate();
            }
        }

        protected abstract Node SetupTree();
    }

}
