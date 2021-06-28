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

            int counter = 0;
            bool found = false;
            foreach (BsonDocument doc in documents)
            {
                if (doc["title"].ToString() == title)
                {
                    Video v = new Video(doc["title"].ToString(), doc["description"].ToString());
                    videos.Add(v);
                    found = true;
                }
                counter++;
                if (counter == documents.Count && found == false)
                {
                    Console.WriteLine("video not found!");
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
            System.Console.WriteLine("finsihed");
        }
        public void DeleteVideos()
        {
            Console.WriteLine("name of the video to delete?");
            string title = Console.ReadLine();
            MongoClient dbClient = new MongoClient("mongodb://root:example@192.168.202.128:27017");
            IMongoDatabase db = dbClient.GetDatabase("youtube");
            var vids = db.GetCollection<BsonDocument>("videos");

            var documents = vids.Find(new BsonDocument()).ToList();
            int counter = 0;
            bool found = false;
             foreach (BsonDocument doc in documents)
             {
                 if (doc["title"].ToString() == title)
                 {
                     vids.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("title", title));
                     found = true;
                     System.Console.WriteLine("finished");
                     break;

                }
                counter++;
                if (counter == documents.Count && found == false)
                {
                    Console.WriteLine("video not found!");
                }
            }
        }
    }
}
