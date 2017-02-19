namespace Santase.Logic.RoundStates
{
    using Santase.Logic.PlayerActionValidate.Contracts;

    public abstract class BaseRoundState : IBaseRoundState
    {
        protected BaseRoundState(IStateManager round)
        {
            this.Round = round;
        }

        public abstract bool CanAnnounce20Or40 { get; }

        public abstract bool CanClose { get; }

        public abstract bool CanChangeTrump { get; }

        public abstract bool ShouldObserveRules { get; }

        public abstract bool ShouldDrawCard { get; }

        protected IStateManager Round { get; }

        internal abstract void PlayHand(int cardsLeftInDeck);

        internal void Close()
        {
            if (this.CanClose)
            {
                this.Round.SetState(new FinalRoundState(this.Round));
            }
        }
    }
}
