using KK.Uno.Contracts.Enums;

namespace KK.Uno.Server.Factories
{
    public interface ICardNameFactory
    {
        string GetName(CardTypesEnum cardType);
    }
}
