﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Services.IService
{
    public interface IMusicService
    {
        IList<Forest.Data.Music_Category> GetMusicCategories();

    }
}
