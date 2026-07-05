using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTExampleApi.Entitties
{

    [Table("RoleTable")]
    public class Role  : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
       

        [Required]
        [Column("RoleName", TypeName = "Varchar(100)")]
        public string? RoleName { get; set; }

       // public ICollection<UserData>? Users { get; set; }
    }
}
