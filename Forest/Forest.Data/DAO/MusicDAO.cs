using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forest.Data.IDAO;
using Forest.Data.BEANS;

namespace Forest.Data.DAO
{
    public class MusicDAO : IMusicDAO
    {
        private ForestEntities _context;
        public MusicDAO()
        {
            _context = new ForestEntities();
        }

        public IList<Music_Category> GetMusicCategories()
        {
            IQueryable<Music_Category> _categories;
            _categories = from category
                          in _context.Music_Category
                          select category;
            return _categories.ToList();
        }

        public void AddMusicCategory(Music_Category category)
        {
            _context.Music_Category.Add(category);
            _context.SaveChanges();
        }

        public IList<MusicBEAN> GetMusicRecordings(int genre)
        {
            IQueryable<MusicBEAN> _musicBEANs = from recs in _context.Music_Recording
                                                from cats in _context.Music_Category
                                                where recs.Genre == cats.Id
                                                where cats.Id == genre
                                                select new MusicBEAN
                                                {
                                                    Id = recs.Id,
                                                    Artist = recs.Artist,
                                                    Title = recs.Title,
                                                    Genre = cats.Genre,
                                                    Image_Name = recs.Image_Name,
                                                    Num_Tracks = recs.Num_Tracks,
                                                    Price = recs.Price,
                                                    Stock_Count = recs.Stock_Count,
                                                    Released = recs.Released
                                                    //Url = recs.Url
                                                };
            return _musicBEANs.ToList();
        }

        public Music_Recording GetMusicRecording(int id)
        {
            IQueryable<Music_Recording> _recording;
            _recording = from recording
                         in _context.Music_Recording
                         where recording.Id == id
                         select recording;
            return _recording.ToList().First();
        }

        public void EditMusicRecording(Music_Recording recording)
        {
            Music_Recording record = GetMusicRecording(recording.Id);

            record.Artist = recording.Artist;
            record.Genre = recording.Genre;
            record.Image_Name = recording.Image_Name;
            record.Num_Tracks = recording.Num_Tracks;
            record.Price = recording.Price;
            record.Released = recording.Released;
            record.Stock_Count = recording.Stock_Count;
            record.Title = recording.Title;
            //record.Url = recording.Url;
            _context.SaveChanges();
        }

        public void AddMusicRecording(Music_Recording recording)
        {
            _context.Music_Recording.Add(recording);
            _context.SaveChanges();
        }

        public void DeleteMusicRecording(Music_Recording recording)
        {
            _context.Music_Recording.Remove(recording);
            _context.SaveChanges();
        }
    }
}
