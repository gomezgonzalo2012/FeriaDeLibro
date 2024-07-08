using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Data.Implements
{
    public class CourseRepository : ICourseRepository
    {
        private readonly FeriaDeLibroContext _context;
        public CourseRepository(FeriaDeLibroContext context) {
            _context = context;

        }
        public ICollection<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(x=> x.CourseId == id);
        }
    }
}
