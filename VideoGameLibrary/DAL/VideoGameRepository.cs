using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.DAL
{
    public class VideoGameRepository : IVideoGameRepository, IDisposable
    {
        private List<VideoGame> _videoGames;

        public VideoGameRepository()
        {
            VideoGameXmlDataService videoGameXmlDataService = new VideoGameXmlDataService();

            using (videoGameXmlDataService)
            {
                _videoGames = videoGameXmlDataService.Read() as List<VideoGame>;
            }
        }

        public IEnumerable<VideoGame> SelectAll()
        {
            return _videoGames;
        }

        public VideoGame SelectOne(int id)
        {
            VideoGame selectedVideoGame = _videoGames.Where(p => p.Id == id).FirstOrDefault();

            return selectedVideoGame;
        }

        public void Insert(VideoGame videoGame)
        {
            videoGame.Id = NextIdValue();
            _videoGames.Add(videoGame);

            Save();
        }

        private int NextIdValue()
        {
            int currentMaxId = _videoGames.OrderByDescending(v => v.Id).FirstOrDefault().Id;

            return currentMaxId;
        }

        public void Update(VideoGame updateVideoGame)
        {
            var oldVideoGame = _videoGames.Where(v => v.Id == updateVideoGame.Id).FirstOrDefault();

            if (oldVideoGame != null)
            {
                _videoGames.Remove(oldVideoGame);
                _videoGames.Add(updateVideoGame);
            }

            Save();
        }

        public void Delete(int id)
        {
            var videoGame = _videoGames.Where(v => v.Id == id).FirstOrDefault();

            if (videoGame != null)
            {
                _videoGames.Remove(videoGame);
            }

            Save();
        }

        public void Save()
        {
            VideoGameXmlDataService videoGameXmlDataService = new VideoGameXmlDataService();

            using (videoGameXmlDataService)
            {
                videoGameXmlDataService.Write(_videoGames);
            }
        }

        public void Dispose()
        {
            _videoGames = null;
        }
    }
}