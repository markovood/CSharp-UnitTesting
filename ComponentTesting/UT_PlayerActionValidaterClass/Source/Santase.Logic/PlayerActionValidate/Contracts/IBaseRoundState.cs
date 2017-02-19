namespace Santase.Logic.PlayerActionValidate.Contracts
{
    public interface IBaseRoundState
    {
        bool CanAnnounce20Or40 { get; }

        bool CanClose { get; }

        bool CanChangeTrump { get; }

        bool ShouldObserveRules { get; }

        bool ShouldDrawCard { get; }
    }
}
