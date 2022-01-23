using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCRUDApp.Server.Models
{
    [Table("Person", Schema ="dbo")]
    public class Person
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] 
        public string FirstName { get; set; }
        
        [Required] 
        public string LastName { get; set; }
        
        [Required] 
        public string Email { get;set; }
        
        [Required] 
        public string MobileNo { get; set; }
    }
}
