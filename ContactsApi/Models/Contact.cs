using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public string? Email { get; set; }
        [DataType("varchar(11)")]
        public required string Phone { get; set; }
        public bool Favourite { get; set; }
    }
}
