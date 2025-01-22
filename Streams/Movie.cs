using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    public class Movie : Video
    {
        public string Director { get; }

        public Movie(int id, string title, string genre, int duration, string diractor)
            :base(id, title, genre, duration)
        {
            Director = diractor;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Movie] Title: {Title}, Genre: {Genre}, Duration: {Duration} mins, Diractor: {Director}, Id: {Id}");

        }
    }
}
