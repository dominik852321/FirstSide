namespace FirstSide.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Zdjecie { get; set; }

        public int? RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public int? ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}
