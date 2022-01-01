using ToySimulator.Toy;

namespace ToySimulator.Analyzer
{
    public interface IAnalyzerInput
    {
        Command ParseCommand(string[] rawInput);   
        PlaceCommandParameter ParseCommandParameter(string[] input);
    }
}
