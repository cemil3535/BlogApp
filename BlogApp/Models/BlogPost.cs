using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class BlogPost
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="baslik gereklidir.")]
        [StringLength(100, ErrorMessage ="100 karakterden fazla olamaz.")]
        public string Title { get; set; }


        [Required(ErrorMessage ="Icerik gereklidir.")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
