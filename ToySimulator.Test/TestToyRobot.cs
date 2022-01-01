using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToySimulator.Analyzer;
using ToySimulator.Toy;

namespace ToySimulator.Test
{
    [TestClass]
    public class TestToyRobot
    {
        [TestMethod]
        public void TestValidToyPositionAndDirection()
        {
            var position = new Position(3, 3);
            var robot = new Robot();
            robot.Place(position, Direction.North);

            // assert
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            Assert.AreEqual(Direction.North, robot.Direction);
        }

        /// <summary>
        /// Test toy turn left
        /// </summary>
        [TestMethod]
        public void TestValidToyTurnLeft()
        {
            var robot = new Robot { Direction = Direction.West, Position = new Position(2, 2) };
            robot.RotateLeft();

            // assert
            Assert.AreEqual(Direction.South,robot.Direction);
        }

        /// <summary>
        /// Test toy turn right
        /// </summary>
        [TestMethod]
        public void TestValidToyTurnRight()
        {
            var robot = new Robot { Direction = Direction.West, Position = new Position(2, 2) };
            robot.RotateRight();

            // assert
            Assert.AreEqual(Direction.North, robot.Direction);
        }


        /// <summary>
        /// Test move
        /// </summary>
        [TestMethod]
        public void TestValidToyMove()
        {
            var robot = new Robot { Direction = Direction.East, Position = new Position(3, 1) };
            var nextPosition = robot.GetNextPosition();

            // assert
            Assert.AreEqual(4, nextPosition.X);
            Assert.AreEqual(1, nextPosition.Y);
        }    

    }
}
