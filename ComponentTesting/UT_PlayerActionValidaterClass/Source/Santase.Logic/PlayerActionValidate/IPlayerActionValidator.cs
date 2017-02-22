namespace Santase.Logic.PlayerActionValidate
{
    using System.Collections.Generic;

    using Santase.Logic.Cards;
    using Contracts;
    using Santase.Logic.Players;

    public interface IPlayerActionValidator
    {
        bool IsValid(IPlayerAction action, IPlayerTurnContext context, ICollection<Card> playerCards);

        ICollection<Card> GetPossibleCardsToPlay(IPlayerTurnContext context, ICollection<Card> playerCards);
    }
}
