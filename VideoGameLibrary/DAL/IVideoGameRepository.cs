using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.DAL
{
    public interface IVideoGameRepository
    {
        IEnumerable<VideoGame> SelectAll();
        VideoGame SelectOne(int id);
        void Insert(VideoGame videogame);
        void Update(VideoGame videogame);
        void Delete(int id);
    }
}
