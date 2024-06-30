namespace FeriaDeLibro.Service.Auth
{
    public interface IPasswordHasher
    {
        byte[] GenerateHashPassword(string password, byte[] salt);
        string HashPassword2Hex(string password, byte[] salt);
        byte[] GenerateSalt();
    }
}
