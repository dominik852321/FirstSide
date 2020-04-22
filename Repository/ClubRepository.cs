using FirstSide.Interface;
using FirstSide.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Club>> GetClubs()
        {
            var result = await _appDbContext.Clubs.Include(s => s.Photos).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Photo>> GetPhotos(int clubId)
        {
            var result = await _appDbContext.Photos.Where(s => s.ClubId == clubId).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<Club>> SearchClub(string ClubName, string ClubCity)
        {
            var result = from x in _appDbContext.Clubs select x;

            if(!string.IsNullOrEmpty(ClubName) && !string.IsNullOrEmpty(ClubCity))
            {
                result = result.Where(x => x.Name.Contains(ClubName) || x.City.Contains(ClubCity));
            }
            if(!string.IsNullOrEmpty(ClubName))
            {
                result = result.Where(x => x.Name.Contains(ClubName));
            }
            if(!string.IsNullOrEmpty(ClubCity))
            {
                result = result.Where(x => x.City.Contains(ClubCity));
            }
            return await result.AsNoTracking().ToListAsync();
        }


        public async Task<Club> GetClub(int id)
        {
            var result = await _appDbContext.Clubs.Include(s=>s.User)
                                            .Include(s=>s.Photos)
                                            .Include(s=>s.EventClubs)
                                            .FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }
        public async Task<Photo> GetPhoto(int id)
        {
            var result = await _appDbContext.Photos.Include(s=>s.Club).FirstOrDefaultAsync(s => s.Id == id);
            return result;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            var result = await _appDbContext.Users.Include(s => s.Restaurants).Include(s => s.Clubs)
                                            .FirstOrDefaultAsync(s => s.Id == id);
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
