using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
   
    public class PhotoRepository: IPhotoRepository
    {
        private readonly AppDbContext _appDbContext;

        public PhotoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Photo> zdjecia()
        {
            return _appDbContext.Photos;
        }

        public void DodajZdjecie(Photo photo)
        {
            _appDbContext.Photos.Add(photo);
            _appDbContext.SaveChanges();
        }
    }
}
