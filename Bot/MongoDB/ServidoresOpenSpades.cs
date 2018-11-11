using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuickType
{
    public partial class Server {
        [BsonId]
        public ObjectId _id;

        [BsonElement("jogo")]
        public string Jogo { get; set; }

        [BsonElement("players"), BsonRepresentation(BsonType.String)]
        public long Players { get; set; }

        [BsonElement("max_join"), BsonRepresentation(BsonType.String)]
        public long MaxJoin { get; set; }

        [BsonElement("gamemode")]
        public string Gamemode { get; set; }

        [BsonElement("version")]
        public string Version { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; }
    }
}
