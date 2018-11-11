using MongoDB.Driver;

namespace Wall_E.Bot
{
    public class MangoDB {
        public MongoClient getMongo() {
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
            return client;
        }
    }
}