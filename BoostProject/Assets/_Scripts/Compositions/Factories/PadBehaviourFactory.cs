using System;
using Compositions.Behaviours;
using Compositions.Enum;
using Interfaces.Level;

namespace Compositions.Factories
{
    public static class PadBehaviourFactory
    {
        public static IPad Build(PadType type) => type switch
        {
            PadType.Launch => new LaunchPad(),
            PadType.Landing => new LandingPad(),
            _ => throw new InvalidPadTypeException(type),
        };
    }

    public class InvalidPadTypeException : Exception
    {
        public InvalidPadTypeException() 
            : base("Invalid type of Pad. Cannot fabricate the behaviour") 
        { }
        public InvalidPadTypeException(PadType type) 
            : base($"Invalid type of Pad. Cannot fabricate the behaviour. Type provided: [{type}]") 
        { }
        public InvalidPadTypeException(string message) 
            : base($"Invalid type of Pad.Cannot fabricate the behaviour. Message: {message}") 
        { }
        public InvalidPadTypeException(string message, Exception innerException)
            : base($"Invalid type of Pad.Cannot fabricate the behaviour. Message: {message}", innerException)
        { }
    }
}
