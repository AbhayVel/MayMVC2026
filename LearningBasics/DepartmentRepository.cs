using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningBasics
{
    public class DepartmentRepository : IDepartmentRepository
    {

        public int Count { get; set; }
        public Department GetDepartmentById(int id)
        {
            Count++;
            Console.WriteLine($"GetDepartmentById  {Count}");

            // Simulate fetching department from a database
            return new Department { Id = id, Name = "HR" };
        }
    }
}
