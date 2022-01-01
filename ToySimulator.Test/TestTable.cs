using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToySimulator.Board;
using ToySimulator.Toy;

namespace ToySimulator.Test
{
    [TestClass]
    public class TestTable
    {
        [TestMethod]
        public void TestValidBoardPosition()
        {
            ITable squareBoard = new Table(5, 5);
            Position position = new Position(3, 0);
            
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInValidBoardPosition()
        {
            ITable squareBoard = new Table(5, 5);
            Position position = new Position(5, 4);

            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }
    }
}
