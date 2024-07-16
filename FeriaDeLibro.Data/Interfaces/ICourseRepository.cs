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
       Task <Course> GetCourseById(int id);
        Task <ICollection<Course>> GetAllCourses();
    }
}
