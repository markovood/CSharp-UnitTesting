namespace Santase.Logic.PlayerActionValidate.Contracts
{
    using Santase.Logic.Cards;
    using Santase.Logic.RoundStates;

    public interface IPlayerTurnContext
    {
        BaseRoundState State { get; set; }

        Card TrumpCard { get; set; }

        int CardsLeftInDeck { get; }

        Card FirstPlayedCard { get; set; }

        Announce FirstPlayerAnnounce { get; set; }

        int FirstPlayerRoundPoints { get; set; }

        Card SecondPlayedCard { get; set; }

        int SecondPlayerRoundPoints { get; set; }

        bool IsFirstPlayerTurn { get; }
    }
}
