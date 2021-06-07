using System;
using System.Collections.Generic;
using System.Text;

namespace mongodb_youtube
{
    public class videoDAO
    {
        public List<video> getAllVideos()
        {
            List<video> videos = new List<video>();
            //mongodb

            videos.Add(new video("et", "old"));
            videos.Add(new video("bugs bunny", "older"));
            return videos;
        }
    }
}
