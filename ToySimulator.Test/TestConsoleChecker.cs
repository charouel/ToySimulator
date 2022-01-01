using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToySimulator.Analyzer;
using ToySimulator.Toy;

namespace ToySimulator.Test
{
    [TestClass]
    public class TestConsoleChecker
    {
        /// <summary>
        /// Test valid place command
        /// </summary>
        [TestMethod]
        public void TestValidPlaceCommand()
        {
            // arrange
            var analyzerInput = new AnalyzerInput();
            string[] rawInput = "PLACE".Split(' ');

            // act
            var command = analyzerInput.ParseCommand(rawInput);

            // assert
            Assert.AreEqual(Command.Place, command);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Command error; the authorized commands: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT")]
        public void TestInvalidPlaceCommand()
        {
            var analyzerInput = new AnalyzerInput();
            string[] rawInput = "PLACETOY".Split(' ');
            analyzerInput.ParseCommand(rawInput);
        }

        /// <summary>
        /// Test a full place command with valid parameters
        /// </summary>
        [TestMethod]
        public void TestValidPlaceCommandAndParams()
        {
            var analyzerInput = new AnalyzerInput();
            string[] rawInput = "PLACE 3,4,South".Split(' ');

            var placeCommandParameter = analyzerInput.ParseCommandParameter(rawInput);

            // assert
            Assert.AreEqual(3, placeCommandParameter.Position.X);
            Assert.AreEqual(4, placeCommandParameter.Position.Y);
            Assert.AreEqual(Direction.South, placeCommandParameter.Direction);
        }

        /// <summary>
        /// Test a place command with an incomplete parameter
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Incomplete command. Command format: PLACE X,Y,F")]

        public void TestInvalidPlaceCommandAndParams()
        {
            var analyzerInput = new AnalyzerInput();
            string[] rawInput = "PLACE 3,1 NORTH".Split(' ');
            analyzerInput.ParseCommandParameter(rawInput);
        }

        /// <summary>
        /// Test a place command with an invalid direction
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid direction. Directions is: NORTH|EAST|SOUTH|WEST")]

        public void TestInvalidPlaceDirection()
        {
            // arrange
            var paramParser = new PlaceCommandParameterParser();
            string[] rawInput = "PLACE 2,4,OneDirection".Split(' ');
            paramParser.ParseParameters(rawInput);
        }
    }
}
