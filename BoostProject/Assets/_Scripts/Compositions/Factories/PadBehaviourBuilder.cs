using Compositions.Enum;
using Compositions.Behaviours;
using Compositions.Exceptions;
using Interfaces.Builders;
using Interfaces.Level;

namespace Compositions.Factories
{
    public struct PadBehaviourBuilder : IBuilder<PadType, IPad>
    {
        public PadType Capability { get; private set; }

        public void AddCapability(PadType capability) => Capability = capability;

        public IPad Build() => Capability switch
        {
            PadType.Launch => new LaunchPad(),
            PadType.Landing => new LandingPad(),
            _ => throw new InvalidPadTypeException(Capability),
        };
    }
}
