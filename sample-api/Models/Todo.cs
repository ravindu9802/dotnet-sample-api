using System.ComponentModel.DataAnnotations;

namespace sample_api.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
