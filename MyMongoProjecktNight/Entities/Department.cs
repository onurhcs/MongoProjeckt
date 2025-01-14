﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMongoProjecktNight.Entities
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
