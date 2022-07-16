using WebApiForReal.Models;

namespace WebApiForReal.Data
{
    public class SqlStudentRepo : IStudentRepository
    {
        private readonly StudentContext _context;

        public SqlStudentRepo(StudentContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            if(student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
             _context.Students.Add(student);    
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _context.Students.Remove(student);
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student student)
        {
            //
        }
    }
}
