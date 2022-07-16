using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiForReal.Models;

namespace WebApiForReal.Data
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        void CreateStudent(Student student);
        bool SaveChanges();

        void UpdateStudent(Student student);
        void DeleteStudent(Student student);

    }
}
