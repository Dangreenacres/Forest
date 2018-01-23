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

        public IList<Music_Recording> GetMusicRecordings(string genre)
        {
            return _musicDAO.GetMusicRecordings(genre);
        }

        public Music_Recording GetMusicRecording(int id)
        {
            return _musicDAO.GetMusicRecording(id);
        }

        public void EditMusicRecording(Music_Recording recording)
        {
            _musicDAO.EditMusicRecording(recording);
        }

        public void AddMusicRecording(Music_Recording recording)
        {
            _musicDAO.AddMusicRecording(recording);
        }
    }
}
