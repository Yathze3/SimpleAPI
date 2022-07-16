using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiForReal.Models;

namespace WebApiForReal.Data
{
    public class MockStudentRepo : IStudentRepository
    {
        public IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>
            {
                new Student{ Id = 1, Name = "Adrian", Surname = "Andal", Age = 23 },
                new Student{ Id = 2, Name = "Macy Janine", Surname = "Pamaranglas", Age = 21 },
                new Student{  Id = 3, Name = "Adie", Surname = "Andal", Age = 1 }
            };
            return students;
        }
        public Student GetStudentById(int id)
        {
            return new Student() { Id = 1, Name = "Adrian", Surname = "Andal", Age = 23 };
        }

        public void CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
