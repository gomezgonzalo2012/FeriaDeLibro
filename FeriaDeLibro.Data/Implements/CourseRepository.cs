using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ICollection<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x=> x.CourseId == id);
        }
    }
}
