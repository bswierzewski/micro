using System.ComponentModel.DataAnnotations;
using Core.Entities.Enums;

namespace Backend.Dtos
{
    public class AddressToCreateDto
    {
        [Required]
        public string Label { get; set; }

        [Required]
        public AddressType AddressType { get; set; }
    }
}