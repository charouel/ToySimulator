using ToySimulator.Analyzer;
using ToySimulator.Board;
using ToySimulator.Toy;


namespace ToySimulator.Behaviours
{
    /// <summary>
    /// This class is used to simulate the behaviour of the toy.
    /// It calls the interfaces from other classes to make a behaviour object.
    /// Methods for this object include processing the string and
    /// rendering the report.
    /// </summary>
    public class Behaviour
    {
        public IRobot Robot { get; set; }
        public ITable Table { get; set; }
        public IAnalyzerInput AnalyzerInput { get; set; }

        public Behaviour(IRobot robot, ITable table, IAnalyzerInput analyzer)
        {
            Robot = robot;
            Table = table;
            AnalyzerInput = analyzer;
        }

        public string ProcessCommand(string[] input)
        {
            var command = AnalyzerInput.ParseCommand(input);
            if (command != Command.Place && Robot.Position == null) return string.Empty;

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = AnalyzerInput.ParseCommandParameter(input);
                    if (Table.IsValidPosition(placeCommandParameter.Position))
                        Robot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    var newPosition = Robot.GetNextPosition();
                    if (Table.IsValidPosition(newPosition))
                        Robot.Position = newPosition;
                    else 
                    {
                        //the movement command must always be valid: 
                        //we do not block the output of the table, but we do a reset
                        Table.ValidateErrorPosition(newPosition);
                        Robot.Position = newPosition;
                    }
                    break;
                case Command.Left:
                    Robot.RotateLeft();
                    break;
                case Command.Right:
                    Robot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", Robot.Position.X,
                Robot.Position.Y, Robot.Direction.ToString().ToUpper());
        }
    }
}
