using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{

    //Page, Form 

     
    public partial class Employee   : IValidatableObject
    {

        public int Id { get; set; }


        [MaxLength(50)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Required]

        [GenderValidation()]
        public string Gender { get; set; }

        [Range(18, 65)]
        [Required]
        public int Age { get; set; }


       
     public bool   CanMarry { get; set; }


        public Nullable<int> DepartmentId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age < 18)
            {
               yield return new ValidationResult("Age must be at least 18.", new[] { nameof(Age) });
            }
            if (CanMarry)
            {

                if ("M" == Gender)
                {

                }
             //   if (Gender.Equals("M", StringComparison.OrdinalIgnoreCase))

                if ("M".Equals(Gender, StringComparison.OrdinalIgnoreCase))
                {
                    if (Age < 21)
                    {
                        yield return new ValidationResult("Male Age must be at least 21 for marry.", new[] { nameof(Age) });

                    }
                }
            }
               
        }
    }



    public class User
    {
        public int Id { get; set; }


        [MaxLength(50)]
        [MinLength(3)] 
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }


        public virtual void Show()
        {
                Console.WriteLine("I am in Parent");
        }


        public User GetUser(int id)
        {
            return new User { Id = id, Name = "John Doe" };
        }
    }
}
