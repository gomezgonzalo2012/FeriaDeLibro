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
        string SaveImage( IFormFile image);
        IFormFile GetImage(string filePath);
    }

}
