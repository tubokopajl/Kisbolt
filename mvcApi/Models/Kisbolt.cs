using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mvcApi.Models
{
    public class Kisbolt
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]

        public string Nev { get; set; }
        [Required]

        public string Kategoria { get; set; }
        [Required]

        public int Ar { get; set; }
        [Required]

        public int Keszlet { get; set; } //db
    }
}
