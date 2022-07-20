using System.ComponentModel.DataAnnotations;

namespace SampleApp.Component.Models;

public class ValidationTestModel
{
    [Required]
    public string RequiredField { get; set; } = "";

    [StringLength(maximumLength: 10)]
    public string StringLenField { get; set; } = "";
}
