using Forest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    public class MusicAdminController : Controller
    {
        private Services.IService.IMusicService _musicService;
        public MusicAdminController()
        {
            _musicService = new Services.Service.MusicService();
        }

        // GET: MusicAdmin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        // GET: MusicAdmin/Details/5
        public ActionResult EditMusicRecording(int id)
        {
            return View(_musicService.GetMusicRecording(id));
        }

        [HttpPost]
        public ActionResult EditMusicRecording(int id, Music_Recording recording)
        {
            try
            {
                _musicService.EditMusicRecording(recording);
            }
            catch
            {

            }
            return RedirectToAction("Recordings", new { genre = recording.Genre, controller = "Music" });
        }

        // GET: MusicAdmin/Create
        public ActionResult AddMusicRecording(string genre, Music_Recording recording)
        {
            _musicService.AddMusicRecording(recording);
            return View();
        }

        // POST: MusicAdmin/Create
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

        // GET: MusicAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusicAdmin/Edit/5
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

        // GET: MusicAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusicAdmin/Delete/5
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
