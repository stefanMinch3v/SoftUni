using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Cat
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 50)]
        public int Age { get; set; }
    }
}
