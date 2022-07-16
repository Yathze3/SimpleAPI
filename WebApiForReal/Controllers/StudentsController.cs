using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiForReal.Data;
using WebApiForReal.DTOs;
using WebApiForReal.Models;

namespace WebApiForReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var listStudents = _repository.GetStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(listStudents));
        }

        [HttpGet("{id}", Name = "GetAllStudentById")]
        public ActionResult<StudentReadDto> GetAllStudentById(int id)
        {
            var students = _repository.GetStudentById(id);
            if(students != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(students));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel =  _mapper.Map<Student>(studentCreateDto);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);
            return CreatedAtRoute(nameof(GetAllStudentById), new {Id = studentReadDto.Id}, studentReadDto);
            //return Ok(commandReadDto);    
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto studentUpdateDto)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();

            }

            _mapper.Map(studentUpdateDto, student);
            _repository.UpdateStudent(student);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            var studentToPatch = _mapper.Map<StudentUpdateDto>(student);
            patchDoc.ApplyTo(studentToPatch, ModelState);

            if(!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, student);
            _repository.UpdateStudent(student);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();

            }

            _repository.DeleteStudent(student);
            _repository.SaveChanges();

            return NoContent();

        }


    }
}
