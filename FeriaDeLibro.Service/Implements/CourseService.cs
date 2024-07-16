using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Entities.Models;
using FeriaDeLibro.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Implements
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ICollection<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAllCourses();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _courseRepository.GetCourseById(id);
        }
    }
}
