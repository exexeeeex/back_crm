using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRM_SYSTEM.DAL.ViewModel
{
    public class LoginViewModel
    {
        [JsonPropertyName("username")]
        public string Email { get; set; } = null!;
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
}
