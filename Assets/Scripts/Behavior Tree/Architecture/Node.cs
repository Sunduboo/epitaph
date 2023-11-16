using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// generic node class for behavior tree AI behavior

namespace BTArchitecture {

    public enum NodeState {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        protected NodeState state;
        public Node parent;
        protected List<Node> children = new List<Node>();

        private Dictionary<string, object> dataContext = new Dictionary<string, object>();

        public Node() {
            parent = null;
        }

        public Node(List<Node> children) {
            foreach (Node child in children) {
                Attach(child);
            }
        }

        private void Attach(Node node) {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() {
            return NodeState.FAILURE;
        }

        public void SetData(string key, object value) {
            dataContext[key] = value;
        }

        public object GetData(string key) {
            object value = null;
            if (dataContext.TryGetValue(key, out value)) {
                return value;
            }

            Node curr = parent;
            while (curr != null) {
                value = curr.GetData(key);
                if (value != null) {
                    return value;
                }
                curr = curr.parent;
            }
            return null;
        }

        public object ClearData(string key) {
            object value = null;
            if (dataContext.TryGetValue(key, out value)) {
                dataContext.Remove(key);
                return value;
            }

            Node curr = parent;
            while (curr != null) {
                value = curr.ClearData(key);
                if (value != null) {
                    return value;
                }
                curr = curr.parent;
            }
            return null;
        }



    }

}
