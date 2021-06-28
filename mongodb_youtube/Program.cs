using System;
using System.Collections.Generic;

namespace mongodb_youtube
{
    public class Program
    {
        public static void Main(string[] args)
        {
            VideoDAO dao = new VideoDAO();
            Menu();
            while (true)
            {
                try
                {
                    int selection = Convert.ToInt32(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:
                            System.Console.WriteLine("Show all");
                            List<Video> videos = dao.GetAllVideos();
                            foreach (var video in videos)
                            {
                                System.Console.WriteLine(video.title + " - " + video.description);
                            }
                            Menu();
                            break;
                        case 2:
                            System.Console.WriteLine("Search");
                            List<Video> videos1 = dao.SearchVideos();
                            foreach (var video in videos1)
                            {
                                System.Console.Write(video.title + " - " + video.description);
                            }
                            System.Console.WriteLine("");
                            Menu();
                            break;
                        case 3:
                            System.Console.WriteLine("Insert");
                            dao.InsertVideos();
                            Menu();
                            break;
                        case 4:
                            System.Console.WriteLine("Delete");
                            dao.DeleteVideos();
                            Menu();
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            void Menu()
            {
                System.Console.WriteLine("..............");
                System.Console.WriteLine("1. Show all");
                System.Console.WriteLine("2. Search");
                System.Console.WriteLine("3. Insert video");
                System.Console.WriteLine("4. Delete video");
                System.Console.WriteLine("..............");
            }
        }
    }
}
