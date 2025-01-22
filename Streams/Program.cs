namespace Streams
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        void Start()
        {
            //List<Video> videos = new List<Video>
            //{
            //    new Movie(1, "Groundhog Day", "Comedy", 101, "Harold Ramis"),
            //    new Movie(2, "The Godfather", "Crime", 175, "Francis Ford Coppola"),
            //    new TVEpisode(3, "The Office", "Comedy", 25, 4, 13),
            //    new TVEpisode(4, "The Bear", "Drama", 22, 2, 7)

            //};

            //foreach (Video video in videos)
            //{
            //    video.DisplayInfo();
            //}

            var service = new StreamingService();

            service.AddVideo(new Movie(1, "Groundhog Day", "Comedy", 101, "Harold Ramis"));
            service.AddVideo(new Movie(2, "The Godfather", "Crime", 175, "Francis Ford Coppola"));
            service.AddVideo(new TVEpisode(3, "The Office", "Comedy", 25, 4, 13));
            service.AddVideo(new TVEpisode(4, "The Bear", "Drama", 22, 2, 7));

            //service.WatchVideo(1);
            //service.WatchVideo(3);

            //service.DisplayReport();

            var saver = new VideoSaver("videos.txt");
            saver.Save(service.GetLibrary());

            var loadedService = saver.Load();
            foreach (var video in loadedService.GetLibrary())
            {
                Console.WriteLine($"{video.GetType().Name}: {video.Title}");
            }

            try
            {
                var video = loadedService.GetVideoById(999);

            }
            catch (VideoNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
