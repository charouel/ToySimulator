using System;
using ToySimulator.Board;
using ToySimulator.Toy;

namespace ToySimulator.Analyzer
{
    public class AnalyzerInput : IAnalyzerInput
    {
        // this method takes a string array and compares the first element to the list of commands
        // if the command doesn't exist then an error is thrown, otherwise the command is returned
        public Command ParseCommand(string[] rawInput)
        {
            Command command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Command error; the authorized commands: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");          
            return command;
        }

        // Extracts the parameters from the user input and returns it       
        public PlaceCommandParameter ParseCommandParameter( string[] input)
        {
            var thisPlaceCommandParameter = new PlaceCommandParameterParser();     
            return thisPlaceCommandParameter.ParseParameters(input);
        }     
    }



}
