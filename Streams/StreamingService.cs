using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    public class StreamingService
    {
        private List<Video> Libary { get;  } = new List<Video>();
        private Dictionary<int, bool> WatchStatus {  get; } = new Dictionary<int, bool>();


        public List<Video> GetLibrary()
        { 
         return Libary;
        }
        public void AddVideo(Video video)
        {
            Libary.Add(video);
            WatchStatus[video.Id] = false;
        }

        public Video GetVideoById(int id)
        {
            var video = Libary.FirstOrDefault(v => v.Id == id);
            if (video == null)
                throw new VideoNotFoundException($"Video with id {id} not found"); 
            return video;
        }

        public void WatchVideo(int id)
        {
            var video = GetVideoById(id);
            video.StartStream();
            video.StopStream();
             WatchStatus[video.Id] = true;
        }

        public List<Video> GetWatchedVideos(bool isWatched)
        {
            return Libary.Where(v => WatchStatus[v.Id] == isWatched).ToList();
        }

        public int GetTotalDurationOfVideos(List<Video> videos)
        {
            return videos.Sum(v => v.Duration);
        }

        public void DisplayVideos(List<Video> videos)
        {
            foreach (var video in videos)
            {
                video.DisplayInfo();
            }
        }

        public void DisplayReport()
        {
            var watchedVideos = GetWatchedVideos(true);
            var unWatchedVideos = GetWatchedVideos(false);
            int totalDurationWatchedVideos = GetTotalDurationOfVideos(watchedVideos);
            int totalDurationUnWatchedVideos = GetTotalDurationOfVideos(unWatchedVideos);

            Console.WriteLine($"Streaming service report:\nTotal minutes watched: {totalDurationWatchedVideos}");
            Console.WriteLine("Watched videos:");
            DisplayVideos(watchedVideos);
            Console.WriteLine("Unwatched videos:");
            DisplayVideos(unWatchedVideos);
        }


    }

    [Serializable]
    class VideoNotFoundException : Exception
    {
        public VideoNotFoundException()
        {
        }

        public VideoNotFoundException(string? message) : base(message)
        {
        }

        public VideoNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
