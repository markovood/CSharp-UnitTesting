namespace Santase.Logic.PlayerActionValidate.Contracts
{
    using Santase.Logic.Cards;
    using Santase.Logic.Players;

    public interface IPlayerAction
    {
        PlayerActionType Type { get; }

        Card Card { get; }

        Announce Announce { get; set; }
    }
}
