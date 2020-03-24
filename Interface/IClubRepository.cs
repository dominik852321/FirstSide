using FirstSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Interface
{
    public interface IClubRepository
    {
        IEnumerable<Club> GetClubs();
        IEnumerable<Photo> GetPhotos(int clubId);
        IEnumerable<Club> SearchClub(string ClubName, string ClubCity);

        Club GetClub(int id);
        Photo GetPhoto(int id);
        ApplicationUser GetUser(string id);

        

        void AddClub(Club model);
        void UpdateClub(Club model);
        void RemoveClub(int Id);


        void AddPhoto(Photo model);
        void RemovePhoto(int id);
        void RemovePhotos(IEnumerable<Photo> photos);
    }
}
