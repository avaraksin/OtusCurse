using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class User : UserBase
    {        
        public string? firstName { get; init; }
    }
}