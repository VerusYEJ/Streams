using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    public abstract class Video : IStreamable
    {
        public int Id { get; }
        public string Title { get; }
        public string Genre { get; }
        public int Duration { get; }

        public Video(int id, string title, string genre, int duration)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Duration = duration;
        }

        public abstract void DisplayInfo();

        public void StartStream()
        {
            Console.WriteLine($"Starting to stream:'{Title}'...");
        }

        public void StopStream()
        {
            Console.WriteLine($"Finished streaming: '{Title}'.");
        }
    }
}
