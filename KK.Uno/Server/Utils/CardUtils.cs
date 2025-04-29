using KK.Uno.Contracts.Enums;

namespace KK.Uno.Server.Utils
{
    public class CardUtils
    {
        public static List<CardTypesEnum> BaseDeck = new List<CardTypesEnum>()
        {
            CardTypesEnum.Zero,
            CardTypesEnum.One,      CardTypesEnum.One,
            CardTypesEnum.Two,      CardTypesEnum.Two,
            CardTypesEnum.Three,    CardTypesEnum.Three,
            CardTypesEnum.Four,     CardTypesEnum.Four,
            CardTypesEnum.Five,     CardTypesEnum.Five,
            CardTypesEnum.Six,      CardTypesEnum.Six,
            CardTypesEnum.Seven,    CardTypesEnum.Seven,
            CardTypesEnum.Eight,    CardTypesEnum.Eight,
            CardTypesEnum.Nine,     CardTypesEnum.Nine,
            CardTypesEnum.PlusTwo,  CardTypesEnum.PlusTwo,
            CardTypesEnum.Reverse,  CardTypesEnum.Reverse,
            CardTypesEnum.Skip,     CardTypesEnum.Skip,
            CardTypesEnum.ColorChange,
            CardTypesEnum.PlusFourColorChange,
        };

        public static string GetCardImagePath(string collectionName, CardTypesEnum cardType, CardColorsEnum cardColor)
        {
            return Path.Combine(
                Environment.CurrentDirectory,
                "CardCollectionImages",
                collectionName,
                cardColor.ToString(),
                $"{cardType.ToString()}.png");
        }

        public static byte[] GetCardImageAsByteArrayByPath(string imagePath)
        {
            var imageBytes = File.ReadAllBytes(imagePath);

            return imageBytes;
        }
    }
}
