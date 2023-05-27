using System.ComponentModel.DataAnnotations;

namespace muitosparamuitos.Models
{
    public class PostTag
    {
        [Key]
        public int PostsId { get; set; }
        public int TagsId { get; set; }
        public Post? Post { get; set; }
        public Tag? Tag { get; set; } 
    }
}
