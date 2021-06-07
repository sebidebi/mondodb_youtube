using System;
using System.Collections.Generic;

namespace mongodb_youtube
{
    public class Program
    {
        public  void Main(string[] args)
        {
            videoDAO dao = new videoDAO();
            System.Console.WriteLine("..............");
            System.Console.WriteLine("menu");
            System.Console.WriteLine("1. Alle anzeigen");
            System.Console.WriteLine("2. Suchen");
            System.Console.WriteLine("..............");
            while (true)
            {
                int selection = Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        System.Console.WriteLine("alle anzeigen");
                        List<video> videos = dao.getAllVideos();
                        foreach (var video in videos)
                        {
                            System.Console.WriteLine(video.title + " . " + video.description);
                        }
                        break;
                    case 2:
                        System.Console.WriteLine("Suche");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
