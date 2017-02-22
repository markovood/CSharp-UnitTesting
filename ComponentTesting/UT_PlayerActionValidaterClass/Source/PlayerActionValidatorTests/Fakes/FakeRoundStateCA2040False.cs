namespace PlayerActionValidatorTests.Fakes
{
    using System;
    using Santase.Logic.RoundStates;

    public class FakeRoundStateCA2040False : BaseRoundState
    {
        public FakeRoundStateCA2040False(IStateManager round) : base(round)
        {
        }

        public override bool CanAnnounce20Or40
        {
            get
            {
                return false;
            }
        }

        public override bool CanChangeTrump
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanClose
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ShouldDrawCard
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ShouldObserveRules
        {
            get
            {
                return false;
            }
        }

        internal override void PlayHand(int cardsLeftInDeck)
        {
            throw new NotImplementedException();
        }
    }
}
