using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameLibrary.DAL;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.Controllers
{
    public class VideoGameController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            // instantiate a repository
            VideoGameRepository videoGameRepository = new VideoGameRepository();

            // create a distinct list of dates for the date filter
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
            return View(videoGames);
        }

        [HttpPost]
        public ActionResult Index(string searchCriteria, string yearFilter)
        {
            // instantiate a repository
            VideoGameRepository videoGameRepository = new VideoGameRepository();

            // create a distinct list of dates for the dates filter
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

            // if posted with a filter on release date
            if (yearFilter != "" || yearFilter == null)
            {
                videoGames = videoGames.Where(v => v.ReleaseYear == yearFilter);
            }

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

            // get a distinct list of dates
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

        // GET: VideoGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoGame/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoGame/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VideoGame/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VideoGame/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VideoGame/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
