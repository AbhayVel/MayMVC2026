using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTExampleApi.Entitties
{

    [Table("RoleTable")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }


        [Required]
        [Column("RoleName", TypeName = "Varchar(100)")]
        public string? RoleName { get; set; }

        public List<UserData> Users { get; set; }
    }
}
