using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Entities.Errors
{
    public class Result<T>
    {
        public T? Value { get; }
        public bool IsSucces {  get; }
        public string? ErrorMessage {  get; }

        private Result(T? value, bool isSucces, string? error)
        {
            Value = value;
            IsSucces = isSucces;
            ErrorMessage= error;
        }

        // metodo para crear objeto result y setear campos
        public static Result<T> Success(T? value) => new Result<T> (value, true, null);
        // metodo para asignar un mensaje de error y un valor
        public static Result<T> Failed(T value, string error) => new Result<T>(value, false, error);
        // metodo solo para asignar mensaje de error
        public static Result<T> Failed( string error) => new Result<T>(default, false, error);
    }
}
