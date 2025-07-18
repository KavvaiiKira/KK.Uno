﻿namespace KK.Uno.Server.EF.Entities
{
    public class CardCollectionEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<CardEntity> Cards { get; set; } = new List<CardEntity>();

        public ICollection<UserCardCollectionEntity> UserCardCollections { get; set; } = new List<UserCardCollectionEntity>();
    }
}
