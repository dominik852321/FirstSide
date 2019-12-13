using System.ComponentModel.DataAnnotations;

namespace FirstSide.Models
{
    public class Photo
        {
            [Key]
            public int Id { get; set; }
        
            public string Name { get; set; }
            public string ZdjecieUrl { get; set; }
        
    }
    
}
