using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Library.Test
{
    [TestFixture]
    public class BallTests
    {
        // Tests if ball is generated
        [Test]
        public void GeneratesBall()
        {
            Ball ball = new Ball(1);
            Assert.AreEqual(1, ball.ID);
        }
    }
}
