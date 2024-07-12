using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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

    public ICollection<Report> Reports { get; set; }
    public ICollection<Transaction> Transactions { get; set;}

}