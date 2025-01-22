using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    public class VideoSaver
    {

        private string FilePath;

        public VideoSaver(string filePath)
        {
            FilePath = filePath;
        }

        public void Save(List<Video> videos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath))
                {
                    foreach (var video in videos)
                    {
                        string videoData = $"{video.GetType().Name}, {video.Id},{video.Title},{video.Genre},{video.Duration}";
                        if (video is Movie movie)
                        {
                            videoData += $",{movie.Director}";

                        }
                        else if (video is TVEpisode episode)
                        {
                            videoData += $",{episode.SeasonNumber},{episode.EpisodeNumber}";
                        }
                        file.WriteLine(videoData);
                        Console.WriteLine($"Saving: {video.Title}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving video list: {ex.Message}");
            }
        }

        public StreamingService Load()
        {
            var service = new StreamingService();
            try
            {
                if (File.Exists(FilePath))
                {
                    using (System.IO.StreamReader file = new System.IO.StreamReader(FilePath))
                    {
                        string line;
                        while ((line = file.ReadLine())!= null)
                        {
                            var data = line.Split(",");
                            string type = data[0];
                            int id = int.Parse(data[1]);
                            string title = data[2];
                            string gender = data[3];
                            int duration = int.Parse(data[4]);

                            Video video = null;

                            if (type == "Movie")
                            {
                                string director = data[5];
                                video = new Movie(id, title, gender, duration, director);
                            }
                            else if (type == "TVEpisode")
                            {
                                int sezonNumber = int.Parse(data[5]);
                                int episodeNumber = int.Parse(data[6]);
                                video = new TVEpisode(id, title, gender, duration, sezonNumber, episodeNumber);
                            }
                            service.AddVideo(video);

                            Console.WriteLine($"Loaded: {video.Title}");

                        }
                    }

                }
                else
                {
                    Console.WriteLine($"File not Found: {FilePath}");
                }
            }   
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading video list: {ex.Message}");
            }
            return service;
        }
    }
}
