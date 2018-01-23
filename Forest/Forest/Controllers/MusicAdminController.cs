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

        // GET: MusicAdmin/Create
        public ActionResult AddMusicRecording(string Genre)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMusicRecording(Music_Recording recording)
        {
            try
            {
                _musicService.AddMusicRecording(recording);
            }
            catch
            {

            }
            return RedirectToAction("Recordings", new { genre = recording.Genre, controller = "Music" });
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
        public ActionResult Delete(int id, Music_Recording recording)
        {
            try
            {
                Music_Recording _recording;
                _recording = _musicService.GetMusicRecording(recording.Id);
                _musicService.DeleteMusicRecording(_recording);

                return RedirectToAction("Recordings", new { genre = recording.Genre, controller = "Music" });
            }
            catch
            {
                return View();
            }
        }
    }
}
