using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Models
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> zdjecia();

        void DodajZdjecie(Photo photo);
    }
}
