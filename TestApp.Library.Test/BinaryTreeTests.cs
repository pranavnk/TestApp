using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Library.Test
{
    [TestFixture]
    public class BinaryTreeTests
    {
        // Checks if tree is generated
        [Test]
        public void GeneratesTree()
        {
            BinaryTree tree = new BinaryTree(2);
            Assert.AreEqual(2, tree.Depth);
        }
    }
}
