using System;
using Santase.Logic.RoundStates;

namespace PlayerActionValidatorTests.Fakes
{
    public class FakeRoundStateCA2040True : BaseRoundState
    {
        public FakeRoundStateCA2040True(IStateManager round) : base(round)
        {
        }

        public override bool CanAnnounce20Or40
        {
            get
            {
                return true;
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
                throw new NotImplementedException();
            }
        }

        internal override void PlayHand(int cardsLeftInDeck)
        {
            throw new NotImplementedException();
        }
    }
}
