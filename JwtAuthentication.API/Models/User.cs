using System.Text.Json.Serialization;

namespace JwtAuthentication.API.Models
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
