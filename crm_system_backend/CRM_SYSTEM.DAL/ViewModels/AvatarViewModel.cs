using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CRM_SYSTEM.DAL.ViewModels
{
    public class AvatarViewModel
    {
        [JsonPropertyName("username")]
        public string Email { get; set; } = null!;
        [JsonPropertyName("base64string")]
        public string? Avatar64 { get; set; }
    }
}
