using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Library;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // generate binary tree with specified depth
            int depth = 4;
            BinaryTree tree = new BinaryTree(depth);

            // Predict which leaf node will be empty
            Console.WriteLine("Prediction of empty leaf node: {0}", tree.GetLastReceivingNodeName());
            Console.ReadKey();


            int ballCount = 15;
            for (int i = 0; i < ballCount; i++)
            {
                Ball ball = new Ball(i + 1);
                tree.PassBall(ball);
            }
            Console.WriteLine("Passed {0} balls throught the tree", ballCount.ToString());
            Console.ReadKey();

            var lastNode = tree.RootNode.GetLastReceivingNode();
            Console.WriteLine("The node {0} has {1} number of balls", lastNode.Name, lastNode.Balls.Count.ToString());
            Console.ReadKey();
        }
    }
}
