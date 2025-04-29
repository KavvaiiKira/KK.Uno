using KK.Uno.Contracts.Enums;

namespace KK.Uno.Server.Factories
{
    public class CardNameFactory : ICardNameFactory
    {
        public Dictionary<CardTypesEnum, string> _cardNames;

        public CardNameFactory()
        {
            _cardNames = new Dictionary<CardTypesEnum, string>()
            {
                { CardTypesEnum.Zero, "Zero" },
                { CardTypesEnum.One, "One" },
                { CardTypesEnum.Two, "Two" },
                { CardTypesEnum.Three, "Three" },
                { CardTypesEnum.Four, "Four" },
                { CardTypesEnum.Five, "Five" },
                { CardTypesEnum.Six, "Six" },
                { CardTypesEnum.Seven, "Seven" },
                { CardTypesEnum.Eight, "Eight" },
                { CardTypesEnum.Nine, "Nine" },
                { CardTypesEnum.PlusTwo, "Draw Two" },
                { CardTypesEnum.Reverse, "Reverse" },
                { CardTypesEnum.Skip, "Skipped" },
                { CardTypesEnum.ColorChange, "Color Change" },
                { CardTypesEnum.PlusFourColorChange, "Draw Four" }
            };
        }

        public string GetName(CardTypesEnum cardType)
        {
            return _cardNames.ContainsKey(cardType) ?
                _cardNames[cardType] :
                throw new NotImplementedException($"Unsupported type of card! Given type: {cardType}");
        }
    }
}
