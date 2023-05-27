namespace muitosparamuitos.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public List<PostTag> Tags { get; set; } = new();

    }
}
