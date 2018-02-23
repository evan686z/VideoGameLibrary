using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameLibrary.DAL;
using VideoGameLibrary.Models;
using PagedList;

namespace VideoGameLibrary.Controllers
{
    public class VideoGameController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder, int? page)
        {
            // instantiate a repository
            VideoGameRepository videoGameRepository = new VideoGameRepository();

            // create a distinct list of years for the years filter
            ViewBag.Years = ListOfYears();

            // return the data context as an enumerable
            IEnumerable<VideoGame> videoGames;
            using (videoGameRepository)
            {
                videoGames = videoGameRepository.SelectAll() as IList<VideoGame>;
            }

            // sort by name unless posted as a new sort
            // *Note* don't need .ToList() ?... videoGames = videoGames.ToList().OrderBy(v => v.ReleaseDate);
            switch (sortOrder)
            {
                case "ReleaseDate":
                    videoGames = videoGames.OrderBy(v => v.ReleaseYear);
                    break;
                default:
                    videoGames = videoGames.OrderBy(v => v.Name);
                    break;
            }

            // set parameters and paginate the video game list
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            videoGames = videoGames.ToPagedList(pageNumber, pageSize);

            return View(videoGames);
        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string yearFilter, int? page)
        {
            // instantiate a repository
            VideoGameRepository videoGameRepository = new VideoGameRepository();

            // create a distinct list of years for the years filter
            ViewBag.Years = ListOfYears();

            // return the data context as an enumerable
            IEnumerable<VideoGame> videoGames;
            using (videoGameRepository)
            {
                videoGames = videoGameRepository.SelectAll() as IList<VideoGame>;
            }

            // if posted with a search on video game name
            if (searchCriteria != null)
            {
                videoGames = videoGames.Where(v => v.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            // if posted with a filter on release year
            if (yearFilter != "" || yearFilter == null)
            {
                videoGames = videoGames.Where(v => v.ReleaseYear == yearFilter);
            }

            // set parameters and paginate the video game list
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            videoGames = videoGames.ToPagedList(pageNumber, pageSize);

            return View(videoGames);
        }

        [NonAction]
        private IEnumerable<string> ListOfYears()
        {
            // instantiate a repository
            VideoGameRepository videoGameRepository = new VideoGameRepository();

            // return the data context as an enumerable
            IEnumerable<VideoGame> videoGames;
            using (videoGameRepository)
            {
                videoGames = videoGameRepository.SelectAll() as IList<VideoGame>;
            }

            // get a distinct list of years
            var dates = videoGames.Select(v => v.ReleaseYear).Distinct().OrderBy(x => x);

            return dates;
        }

        // GET: VideoGame/Details/5
        public ActionResult Details(int id)
        {
            // instantiate a repository
            VideoGameRepository videoGameRepository = new VideoGameRepository();
            VideoGame videoGame = new VideoGame();

            // get a videoGame that has the matching id
            using (videoGameRepository)
            {
                videoGame = videoGameRepository.SelectOne(id);
            }

            return View(videoGame);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VideoGame videoGame)
        {
            try
            {
                VideoGameRepository videoGameRepository = new VideoGameRepository();

                using (videoGameRepository)
                {
                    videoGameRepository.Insert(videoGame);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO: add view for error message
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            VideoGameRepository videoGameRepository = new VideoGameRepository();
            VideoGame videoGame = new VideoGame();

            using (videoGameRepository)
            {
                videoGame = videoGameRepository.SelectOne(id);
            }
            return View(videoGame);
        }

        [HttpPost]
        public ActionResult Edit(VideoGame videoGame)
        {
            try
            {
                VideoGameRepository videoGameRepository = new VideoGameRepository();

                using (videoGameRepository)
                {
                    videoGameRepository.Update(videoGame);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                // TODO: add view for error message
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            VideoGameRepository videoGameRepository = new VideoGameRepository();
            VideoGame videoGame = new VideoGame();

            using (videoGameRepository)
            {
                videoGame = videoGameRepository.SelectOne(id);
            }
            return View(videoGame);
        }

        [HttpPost]
        public ActionResult Delete(int id, VideoGame videoGame)
        {
            try
            {
                VideoGameRepository videoGameRepository = new VideoGameRepository();

                using (videoGameRepository)
                {
                    videoGameRepository.Delete(id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                // TODO: add view for error message
                return View();
            }
        }
    }
}
