using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.DAL
{
    public interface IVideoGameDataServices
    {
        List<VideoGame> Read();
        void Write(List<VideoGame> VideoGames);
    }
}