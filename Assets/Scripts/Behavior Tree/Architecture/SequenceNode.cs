using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTArchitecture {
    public class SequenceNode : Node
    {
        public SequenceNode() : base() { }

        public SequenceNode(List<Node> children) : base(children) { }

        public override NodeState Evaluate() {

            foreach (Node node in children) {
                switch (node.Evaluate()) {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = NodeState.SUCCESS;
            return state; 
        }
    }
}

