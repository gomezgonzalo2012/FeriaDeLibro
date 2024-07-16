using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Interfaces
{
    public interface IImageUploadService
    {
        Task<string> SaveImage(IFormFile image);
    }

}
