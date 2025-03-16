using System.ComponentModel.DataAnnotations;

namespace TicketingSolution.Domain.BaseModels
{
    public abstract class ServiceBookingBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Family { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]

        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
        {
            if (Date <= DateTime.Now.Date)
            {
                yield return new ValidationResult("Date Must Be in Future" ,new[] { nameof(Date) });

            }
        }

    }
}