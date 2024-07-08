using FeriaDeLibro.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Interfaces
{
    public interface ICourseService
    {
        Course GetCourseById(int id);
        ICollection<Course> GetAllCourses();
    }
}
