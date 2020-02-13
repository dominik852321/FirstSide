namespace FirstSide.Models
{
    public class EventRestaurant
    {
        
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
