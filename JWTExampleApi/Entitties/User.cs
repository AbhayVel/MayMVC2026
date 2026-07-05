using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWTExampleApi.Entitties
{
    public interface IEntity
    {
        int Id { get; set; }
    }

    [Table("UserTable")]
    public class UserData   : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        [Column("Name",TypeName ="Varchar(100)")]
        public string? UserName { get; set; }

        [Required]
        [Column("Password", TypeName = "Varchar(100)")]
        public string? Password { get; set; }


        [Required]

        public int RoleID { get; set; }


        //[Required]
      //  [ForeignKey("RoleID")]
       
        public Role? Role { get; set; }


        [NotMapped]
        public int? MyProperty { get; set; }
    }
}
