using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCorePicture.Data
{
    public class PictureRepository
    {
        string _connectionString;
        public PictureRepository(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        public List<Picture> GetPictures()
        {   
            using (var context = new PictureContext(_connectionString))
            {
                return context.Picture.OrderBy(p=>p.Date).ToList();
            }
        }
        public void AddPicture(Picture picture)
        {
            using (var context = new PictureContext(_connectionString))
            {
                context.Picture.Add(picture);
                context.SaveChanges();
            }
        }
        public Picture GetPictureById(int Id)
        {
            using (var context = new PictureContext(_connectionString))
            {
                return context.Picture.FirstOrDefault(p => p.Id == Id);
            }
        }
        public void AddLike(int Id)
        {
            using (var context = new PictureContext(_connectionString))
            {
                context.Picture.FirstOrDefault(p => p.Id == Id).Likes++;
                context.SaveChanges();
            }
        }
        public int GetLikesCount(int Id)
        {
            using (var context = new PictureContext(_connectionString))
            {
                return context.Picture.FirstOrDefault(p => p.Id == Id).Likes;
            }
        }
    }
}
