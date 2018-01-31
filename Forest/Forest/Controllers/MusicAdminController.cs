using Forest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MusicAdminController : ApplicationController
    {
        public MusicAdminController()
        {

        }

        // GET: MusicAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusicAdmin/Create
        [HttpGet]
        public ActionResult AddMusicRecording(string selectedGenre)
        {
            List<SelectListItem> genreList = new List<SelectListItem>();
            foreach(var item in _musicService.GetMusicCategories())
            {
                genreList.Add(
                    new SelectListItem()
                    {
                        Text = item.Genre,
                        Value = item.Id.ToString(),
                        Selected = (item.Genre == (selectedGenre) ? true : false)
                    }
                );
            }
            ViewBag.genreList = genreList;
            return View();
        }

        [HttpPost]
        public ActionResult AddMusicRecording(string Genre, Music_Recording recording)
        {
            try
            {
                _musicService.AddMusicRecording(recording);
                return RedirectToAction("Recordings", new { genre = recording.Genre, controller = "Music" });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddMusicCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMusicCategory(Music_Category category)
        {
            try
            {
                _musicService.AddMusicCategory(category);
                return RedirectToAction("Categories", new { controller = "Music" });
            }
            catch
            {
                return View();
            }
        }

        // GET: MusicAdmin/Edit/5
        [HttpGet]
        public ActionResult EditMusicRecording(int id)
        {
            return View(_musicService.GetMusicRecording(id));
        }

        // POST: MusicAdmin/Edit/5
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

        // GET: MusicAdmin/Delete/5
        [HttpGet]
        public ActionResult DeleteMusicRecording(int id)
        {
            return View(_musicService.GetMusicRecording(id));
        }

        // POST: MusicAdmin/Delete/5
        [HttpPost]
        public ActionResult DeleteMusicRecording(Music_Recording recording)
        {
            try
            {
                Music_Recording _recording;
                _recording = _musicService.GetMusicRecording(recording.Id);
                _musicService.DeleteMusicRecording(_recording);

                return RedirectToAction("Recordings", new { genre = _recording.Genre, controller = "Music" });
            }
            catch
            {
                return View();
            }
        }
    }
}
