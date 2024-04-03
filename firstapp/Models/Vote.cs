namespace firstapp.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Vote
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

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
