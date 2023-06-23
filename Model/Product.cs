using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ShopInventory.Model
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; } 
        public int Stock { get; set; }
        public DateTime EspiryDate { get; set; }
        public string Category { get; set; }
    }
}
