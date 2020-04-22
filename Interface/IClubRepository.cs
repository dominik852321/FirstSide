using FirstSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Interface
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetClubs();
        Task<IEnumerable<Photo>> GetPhotos(int clubId);
        Task<IEnumerable<Club>> SearchClub(string ClubName, string ClubCity);

        Task<Club> GetClub(int id);
        Task<Photo> GetPhoto(int id);
        Task<ApplicationUser> GetUser(string id);

        

        void AddClub(Club model);
        void UpdateClub(Club model);
        void RemoveClub(int Id);


        void AddPhoto(Photo model);
        void RemovePhoto(int id);
        void RemovePhotos(IEnumerable<Photo> photos);
    }
}
