using System.ComponentModel.DataAnnotations;

public class User {
    [Key]
    public int Id { get; set; }

    [Required]
    public int ReportId { get; set; }

    [ForeignKey("ReportId")]
    public Report? Report { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get;  set; }
}