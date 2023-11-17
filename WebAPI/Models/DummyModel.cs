namespace WebAPI.Models
{
    public class DummyModel : IValidatableObject
    {
        [Display(ResourceType = typeof(DisplayNameResource), Name = "FirstName")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MaxLengthError")]
        public string FirstName { get; set; } = null!;

        [Display(ResourceType = typeof(DisplayNameResource), Name = "FirstName")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [StringLength(32, MinimumLength = 3, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MaxLengthError")]
        public string LastName { get; set; } = null!;

        [Display(ResourceType = typeof(DisplayNameResource), Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(128, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MaxLengthError")]
        public string Email { get; set; } = null!;

        [JsonIgnore]
        public string FullName { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email.Contains("dummy"))
                yield return new ValidationResult(string.Format(
                    ErrorMessageResource.DummyIsForbidenError, DisplayNameResource.Email));
        }
    }
}