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

            // return the data context as an enumerable
            IEnumerable<VideoGame> videoGames;
            using (videoGameRepository)
            {
                videoGames = videoGameRepository.SelectAll() as IList<VideoGame>;
            }

            return View(videoGames);
        }

        // GET: VideoGame/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
