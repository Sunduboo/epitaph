using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTArchitecture {
    public class SelectorNode : Node
    {
        public SelectorNode() : base() { }

        public SelectorNode(List<Node> children) : base(children) { }

        public override NodeState Evaluate() {

            foreach (Node node in children) {
                switch (node.Evaluate()) {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        continue;
                    default:
                        continue;

                }
            }
            state = NodeState.FAILURE;
            return state; 
        }
    }
}

