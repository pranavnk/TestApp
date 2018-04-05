using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Library
{
    public class Node
    {
        public string Name;
        public readonly GateStates GateState;
        public Node Left;
        public Node Right;
        public readonly bool IsLeaf;
        public readonly List<Ball> Balls;


        // Constructor for non-leaf node
        public Node(GateStates gateState, Node left, Node right)
        {
            if (gateState == GateStates.Undefined)
            {
                throw new ArgumentException("A non-leaf node cannot have 'Undefined' gate state");
            }
            GateState = gateState;
            Left = left;
            Right = right;
            IsLeaf = false;
            Balls = null;
        }

        // Constructor for leaf node
        public Node(string name)
        {
            Name = name;
            GateState = GateStates.Undefined;
            Left = null;
            Right = null;
            IsLeaf = true;
            Balls = new List<Ball>();
        }

        // Method to get last receiving node
        public Node GetLastReceivingNode()
        {
            Node lastNode = this;
            if (!IsLeaf)
            {
                lastNode = GateState == GateStates.LeftOpen ? Right.GetLastReceivingNode() : Left.GetLastReceivingNode();
            }
            return lastNode;
        }

        // Passes the ball forward if this node is non-leaf node
        // else stores the ball in balls collection
        public void PassBall(Ball ball)
        {
            if (IsLeaf)
            {
                Balls.Add(ball);
                
            }
            else
            {
                if (GateState == GateStates.LeftOpen)
                {
                    Left.PassBall(ball);
                }
                else
                {
                    Right.PassBall(ball);
                }
            }
        }
    }
}
