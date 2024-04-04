namespace firstapp.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Vote
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // Now directly a string for simplicity


        [BsonElement("Topic")]
        public string Topic { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }


        [BsonElement("Options")]
        public List<Option> Options { get; set; }
    }

    public class Option
    {
        [BsonElement("optionText")]
        public string OptionText { get; set; } // Renamed for clarity

        [BsonElement("votes")]
        public int Votes { get; set; } // Changed to int
    }
}
