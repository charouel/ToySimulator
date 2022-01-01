using System;
using ToySimulator.Analyzer;
using ToySimulator.Board;
using ToySimulator.Toy;

namespace ToySimulator
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            const string description =
@"
  Welcome!
  1: PLACE X,Y,F (Where X and Y are integers and F must be either NORTH, SOUTH, EAST or WEST)
  2: REPORT ,  LEFT , RIGHT, MOVE, EXIT";

            ITable table = new Table(5, 5);
            IAnalyzerInput analyzer = new AnalyzerInput();
            IRobot robot = new Robot();

            var simulator = new Behaviours.Behaviour(robot, table, analyzer);

            var stopApplication = false;
            Console.WriteLine(description);
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        var output = simulator.ProcessCommand(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
