
using FeriaDeLibro.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Service.Implements
{
    public class ImageUploadService : IImageUploadService
    {
        
        public async Task<string> SaveImage(IFormFile image)
        {
            var path = String.Empty;
            var fileName = String.Empty;
               if (image.Length > 0)
            {
                // renombrando el archivo
                // Guid (Global Unique Identifier) genera un numero unico para asegurar que los nombres de imagen sean distintos
                fileName = Guid.NewGuid().ToString()+ ".jpg";
                // Obtener la ruta completa al directorio 'wwwroot/images/incoming'
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "incoming");

                // Asegurarse de que el directorio existe
                //if (!Directory.Exists(directoryPath))
                //{
                //    Directory.CreateDirectory(directoryPath);
                //}

                // Combinar el nombre del archivo con la ruta del directorio
                path = Path.Combine(directoryPath, fileName);
                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
            } 
            return $"/images/incoming/{fileName}";
        }
    }
}
