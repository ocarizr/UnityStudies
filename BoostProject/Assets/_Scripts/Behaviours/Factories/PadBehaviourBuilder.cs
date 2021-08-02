using Behaviours.Interfaces;
using Behaviours.Exceptions;
using Behaviours.Enum;
using Behaviours.Compositions.Pad;

namespace Behaviours.Factories
{
    public struct PadBehaviourBuilder : IBuilder<PadType, IPad>
    {
        public PadType Configuration { get; private set; }

        public void AddConfiguration(PadType capability) => Configuration = capability;

        public IPad Build() => Configuration switch
        {
            PadType.Launch => new LaunchPad(),
            PadType.Landing => new LandingPad(),
            _ => throw new InvalidPadTypeException(Configuration),
        };
    }
}
