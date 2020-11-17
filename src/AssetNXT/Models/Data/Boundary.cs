﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AssetNXT.Models.Data
{
    public class Boundary
    {
        [BsonElement]
        public double Radius { get; set; }

        [BsonElement]
        public string Colour { get; set; }

        [BsonElement]
        public Location Location { get; set; }
    }
}
