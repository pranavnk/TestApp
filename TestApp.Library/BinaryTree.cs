using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Library
{
    public class BinaryTree
    {
        public Node RootNode;
        protected string LastName;
        public readonly int Depth;

        // Generates nodes up to the depth specified
        public BinaryTree(int depth)
        {
            Depth = depth;
            LastName = string.Empty;
            RootNode = GenerateNodes(Depth);
        }

        // Pass ball through all nodes
        public void PassBall(Ball ball)
        {
            RootNode.PassBall(ball);
        }

        // Method to get last receiving node
        public string GetLastReceivingNodeName()
        {
            Node lastNode = RootNode.GetLastReceivingNode();
            return lastNode.Name;
        }

        // Helper recursive method to generate nodes
        protected Node GenerateNodes(int depth)
        {
            Node rootNode;
            if (depth == 0)
            {
                LastName = LastName.Length == 0 ? "A" : LastName;
                var lastChar = LastName[LastName.Length - 1];
                if (lastChar == char.Parse("Z"))
                {
                    LastName = string.Concat(LastName, "A");
                }
                else
                {
                    LastName = string.Concat(LastName.Substring(0, LastName.Length - 1), (char)(((int)lastChar) + 1));
                }
                rootNode = new Node(LastName);
            }
            else
            {
                var leftNode = GenerateNodes(depth - 1);
                var rightNode = GenerateNodes(depth - 1);
                var gateState = new Random().Next(2) > 0 ? GateStates.RightOpen : GateStates.LeftOpen;
                rootNode = new Node(gateState, leftNode, rightNode);
            }
            return rootNode;
        }


    }
}
