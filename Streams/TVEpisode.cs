using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    public class TVEpisode : Video
    {
        public int SeasonNumber { get;}
        public int EpisodeNumber { get; }

        public TVEpisode(int id, string title, string genre, int duration, int seasonNumber, int episodeNumber)
            : base(id, title, genre, duration)
        {
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[TV Episode] Title: {Title}, Genre: {Genre}, Duration: {Duration} mins, Season: {4}, EpisodeNumber: {EpisodeNumber}, ID: {Id}");
        }




    }
}
