using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data;
using Forest.Data.IDAO;
using Forest.Data.DAO;

namespace Forest.Services.Service
{
    public class MusicService : Forest.Services.IService.IMusicService
    {
        private IMusicDAO _musicDAO;

        public MusicService()
        {
            _musicDAO = new MusicDAO();
        }

        public IList<Music_Category> GetMusicCategories()
        {
            return _musicDAO.GetMusicCategories();
        }
    }
}
