using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Library.Test
{
    [TestFixture]
    public class NodeTests
    {
        [Test]
        public void CreatesLeafNode()
        {
            Node node = new Node("A");
            Assert.AreEqual(true, node.IsLeaf);
        }

        [Test]
        public void CreatesNonLeafNode()
        {
            Node node = new Node(GateStates.LeftOpen, new Node("A"), new Node("B"));
            Assert.AreEqual(false, node.IsLeaf);
        }

        [Test]
        public void GetsLastNode()
        {
            Node rootNode = GenerateSampleNodes();
            Node lastNode = rootNode.GetLastReceivingNode();
            Assert.AreEqual("D", lastNode.Name);
        }

        protected Node GenerateSampleNodes()
        {
            Node firstNode = new Node(GateStates.LeftOpen, new Node("A"), new Node("B"));
            Node secondNode = new Node(GateStates.LeftOpen, new Node("C"), new Node("D"));
            Node rootNode = new Node(GateStates.LeftOpen, firstNode, secondNode);
            return rootNode;
        }

        [Test]
        public void PasesABall()
        {
            Node rootNode = GenerateSampleNodes();
            rootNode.PassBall(new Ball(1));
            Assert.AreEqual(1, rootNode.Left.Left.Balls.Count);
        }
    }
}
