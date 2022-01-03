using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToySimulator.Analyzer;
using ToySimulator.Board;
using ToySimulator.Toy;

namespace ToySimulator.Test
{
    [TestClass]
    public class TestBehaviour
    {
        [TestMethod]
        public void TestValidBehaviourPlace()
        {
            ITable table = new Table(5, 5);
            IAnalyzerInput analyzer = new AnalyzerInput();
            IRobot robot = new Robot();

            var simulator = new Behaviours.Behaviour(robot, table, analyzer);

            simulator.ProcessCommand("PLACE 3,1,South".Split(' '));

            // assert
            Assert.AreEqual(3, simulator.Robot.Position.X);
            Assert.AreEqual(1, simulator.Robot.Position.Y);
            Assert.AreEqual(Direction.South, simulator.Robot.Direction);
        }

        [TestMethod]
        public void TestInvalidBehaviourPlace()
        {
            ITable table = new Table(5, 5);
            IAnalyzerInput analyzer = new AnalyzerInput();
            IRobot robot = new Robot();

            var simulator = new Behaviours.Behaviour(robot, table, analyzer);

            // act
            simulator.ProcessCommand("PLACE 5,1,South".Split(' '));
            // assert
            Assert.IsNull(simulator.Robot.Position);
        }

        [TestMethod]
        public void TestValidBehaviourMove()
        {
            ITable table = new Table(5, 5);
            IAnalyzerInput analyzer = new AnalyzerInput();
            IRobot robot = new Robot();

            var simulator = new Behaviours.Behaviour(robot, table, analyzer);

            // act
            simulator.ProcessCommand("PLACE 4,3,SOUTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 4,2,SOUTH", simulator.GetReport());
        }

        [TestMethod]
        public void TestInvalidBehaviourMove()
        {
            ITable table = new Table(5, 5);
            IAnalyzerInput analyzer = new AnalyzerInput();
            IRobot robot = new Robot();

            var simulator = new Behaviours.Behaviour(robot, table, analyzer);

            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 2,4,NORTH", simulator.GetReport());
        }

        [TestMethod]
        public void TestValidBehaviourReport()
        {
            ITable table = new Table(5, 5);
            IAnalyzerInput analyzer = new AnalyzerInput();
            IRobot robot = new Robot();

            var simulator = new Behaviours.Behaviour(robot, table, analyzer);

            // act
            simulator.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }

    //    [TestMethod]
    //    public void TestValidateErrorPosition()
    //    {
    //        ITable table = new Table(5, 5);
    //        IAnalyzerInput analyzer = new AnalyzerInput();
    //        IRobot robot = new Robot();

    //        var simulator = new Behaviours.Behaviour(robot, table, analyzer);

    //        // act
    //        simulator.ProcessCommand("PLACE 3,4,NORTH".Split(' '));
    //        simulator.ProcessCommand("MOVE".Split(' '));
    //        simulator.ProcessCommand("MOVE".Split(' '));
    //        var output = simulator.ProcessCommand("REPORT".Split(' '));

    //        // assert
    //        Assert.AreEqual("Output: 3,1,NORTH", output);
    //    }
    }
}
