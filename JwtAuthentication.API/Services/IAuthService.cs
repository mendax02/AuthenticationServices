namespace JwtAuthentication.API.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Used to Authenticate username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool Authenticate(string username, string password);

        bool IsUserExist(string username);
        bool VerifyPassword(string username, string password);
        /// <summary>
        /// Generates the jwt token
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        dynamic GenerateToken(string username);
    }
}
