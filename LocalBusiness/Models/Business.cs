using System.ComponentModel.DataAnnotations;

namespace LocalBusiness.Models
{
  public class Business
  {
    public int BusinessId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    [Range(10,10, ErrorMessage = "Phone number must have 10 digits.")]
    public int PhoneNumber { get; set; }
    public string Website { get; set; }
    public string Hours { get; set; }

  }
}