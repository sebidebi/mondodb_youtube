using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;

namespace mongodb_youtube
{
    public class VideoDAO
    {
        public List<Video> GetAllVideos()
        {
            MongoClient dbClient = new MongoClient("mongodb://root:example@192.168.202.128:27017");
            IMongoDatabase db = dbClient.GetDatabase("youtube");
            var vids = db.GetCollection<BsonDocument>("videos");
            var documents = vids.Find(new BsonDocument()).ToList();

            List<Video> videos = new List<Video>();
            foreach (BsonDocument doc in documents)
            {
                //System.Console.WriteLine(doc.ToString());
                Video v = new Video(doc["title"].ToString(), doc["description"].ToString());
                videos.Add(v);
            }

            /*videos.Add(new Video("et", "old"));
            videos.Add(new Video("bugs bunny", "older"));*/
          
            return videos;
        }
        public List<Video> SearchVideos()
        {
            string title = "";

            Console.WriteLine("name of the video?");
            title = Console.ReadLine().ToString();
            MongoClient dbClient = new MongoClient("mongodb://root:example@192.168.202.128:27017");
            IMongoDatabase db = dbClient.GetDatabase("youtube");
            var vids = db.GetCollection<BsonDocument>("videos");
            var documents = vids.Find(new BsonDocument()).ToList();

            List<Video> videos = new List<Video>();
            foreach (BsonDocument doc in documents)
            {
                if (doc["title"].ToString() == title)
                {
                    Video v = new Video(doc["title"].ToString(), doc["description"].ToString());
                    videos.Add(v);
                }
            }
            return videos;
        }
        public void InsertVideos()
        {
            string title = "";
            string description = "";

            Console.WriteLine("name of the video?");
            title = Console.ReadLine().ToString();

            Console.WriteLine("description of the video?");
            description = Console.ReadLine().ToString();

            MongoClient dbClient = new MongoClient("mongodb://root:example@192.168.202.128:27017");
            IMongoDatabase db = dbClient.GetDatabase("youtube");
            var vids = db.GetCollection<BsonDocument>("videos");

            Video insertvideo = new Video(title, description);
            BsonDocument document = insertvideo.ToBsonDocument();
            vids.InsertOneAsync(document);
        }
        public void DeleteVideos()
        {
            Console.WriteLine("name of the video to delete?");
            string title = Console.ReadLine();
            MongoClient dbClient = new MongoClient("mongodb://root:example@192.168.202.128:27017");
            IMongoDatabase db = dbClient.GetDatabase("youtube");
            var vids = db.GetCollection<BsonDocument>("videos");

            var documents = vids.Find(new BsonDocument()).ToList();
             foreach (BsonDocument doc in documents)
             {
                 if (doc["title"].ToString() == title)
                 {
                     string description = doc["description"].ToString();
                     vids.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("title", title));
                     break;
                 }
             }
        }
    }
}
