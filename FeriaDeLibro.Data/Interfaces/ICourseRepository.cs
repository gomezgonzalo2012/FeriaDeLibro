using FeriaDeLibro.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Data.Interfaces
{
    public interface ICourseRepository
    {
        Course GetCourseById(int id);
        ICollection<Course> GetAllCourses();
    }
}
