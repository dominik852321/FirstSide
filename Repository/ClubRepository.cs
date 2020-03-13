using FirstSide.Interface;
using FirstSide.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSide.Repository
{
    public class ClubRepository: IClubRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClubRepository(AppDbContext app)
        {
            _appDbContext = app;
        }

        public IEnumerable<Club> GetClubs()
        {
            var result = _appDbContext.Clubs.Include(s => s.Photos)
                                            .Include(s => s.User)
                                            .Include(s => s.EventClubs);
            return result;
        }
        public IEnumerable<Photo> GetPhotos(int clubId)
        {
            var result = _appDbContext.Photos.Where(s => s.ClubId == clubId).ToList();
            return result;
        }



        public Club GetClub(int id)
        {
            var result = _appDbContext.Clubs.Include(s=>s.User)
                                            .Include(s=>s.Photos)
                                            .Include(s=>s.EventClubs)
                                            .FirstOrDefault(s => s.Id == id);
            return result;
        }
        public Photo GetPhoto(int id)
        {
            var result = _appDbContext.Photos.Include(s=>s.Club).FirstOrDefault(s => s.Id == id);
            return result;
        }

        public ApplicationUser GetUser(string id)
        {
            var result = _appDbContext.Users.Include(s => s.Restaurants).Include(s => s.Clubs)
                                            .FirstOrDefault(s => s.Id == id);
            return result;
        }


        public void AddClub(Club model)
        {
            _appDbContext.Clubs.Add(model);
            _appDbContext.SaveChanges();
        }

        public void RemoveClub(int Id)
        {
            var club = _appDbContext.Clubs.FirstOrDefault(s => s.Id == Id);
            _appDbContext.Clubs.Remove(club);
            _appDbContext.SaveChanges();
        }
        public void UpdateClub(Club model)
        {
            _appDbContext.Clubs.Update(model);
            _appDbContext.SaveChanges();
        }



        public void AddPhoto(Photo model)
        {
            _appDbContext.Photos.Add(model);
            _appDbContext.SaveChanges();
        }
        public void RemovePhoto(int id)
        {
            var photo = _appDbContext.Photos.FirstOrDefault(s => s.Id == id);
            _appDbContext.Photos.Remove(photo);
            _appDbContext.SaveChanges();
        }
        public void RemovePhotos(IEnumerable<Photo> photos)
        {
            foreach (var photo in photos)
            {
                _appDbContext.Photos.Remove(photo);
            }
            _appDbContext.SaveChanges();
        }




    }
}
