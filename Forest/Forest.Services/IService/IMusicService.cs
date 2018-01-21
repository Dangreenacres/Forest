using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.IService
{
    public interface IMusicService
    {
        IList<Data.Music_Category> GetMusicCategories();
        IList<Data.Music_Recording> GetMusicRecordings(string genre);
    }
}
