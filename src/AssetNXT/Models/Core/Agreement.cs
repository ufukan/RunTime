﻿using System.Data;
using AssetNXT.Repository.Service;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AssetNXT.Models.Core
{
    [BsonCollection("agreement_constrains")]
    public class Agreement : Constrain
    {
        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public double TemperatureMin { get; set; }

        [BsonElement]
        public double TemperatureMax { get; set; }

        [BsonElement]
        public double HumidityMin { get; set; }

        [BsonElement]
        public double HumidityMax { get; set; }

        [BsonElement]
        public double PressureMin { get; set; }

        [BsonElement]
        public double PressureMax { get; set; }
    }
}