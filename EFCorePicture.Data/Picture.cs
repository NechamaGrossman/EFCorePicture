using System;
using System.Collections.Generic;
using System.Text;

namespace EFCorePicture.Data
{
    public class Picture
    {
        public string Title { get; set; }
        public string PictureURL { get; set; }
        public DateTime Date { get; set; }
        public int Likes { get; set; }
        public int Id { get; set; }
    }
}
