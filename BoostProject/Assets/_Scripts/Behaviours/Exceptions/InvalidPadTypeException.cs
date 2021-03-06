using System;
using Behaviours.Enum;

namespace Behaviours.Exceptions
{
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
