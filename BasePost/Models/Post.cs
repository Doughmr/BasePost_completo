namespace muitosparamuitos.Models
{
    public class Post
    {
        public int Id { get; set; }

        public List<PostTag> Tags { get; set; } = new();


    }
}
