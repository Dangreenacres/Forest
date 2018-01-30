using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forest.Data;
using Forest.Services;

namespace Forest.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public Services.Service.MusicService _musicService;
        // GET: Application
        public ApplicationController()
        {
            _musicService = new Services.Service.MusicService();
            ViewBag.genres = _musicService.GetMusicCategories();
        }
    }
}