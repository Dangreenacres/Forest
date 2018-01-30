using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest.Data.BEANS
{
    class MusicBEAN
    {
        public int Id { get; set; }
        public string Artists { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Image_Name { get; set; }
        public Nullable<int> Num_Tracks { get; set; }
        public double Price { get; set; }
        public System.DateTime Released { get; set; }
        public string Url { get; set; }
        public MusicBEAN() { }
    }
}
