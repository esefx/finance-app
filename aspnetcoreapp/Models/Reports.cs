using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Transactions;

public class Report {
    [Key]
    public int Id { get; set;}

    [Required]
    public int UserId { get; set;}

    [ForeignKey("UserId")]
    public User? User { get; set;}

    [Required]
    public int TransactionId { get; set;}

    [ForeignKey("TransactionId")]
    public Transaction Transaction { get; set;}

    public decimal ExpenseTotal { get; set;}

    public decimal IncomeTotal { get; set;}

    public decimal NetWorth { get; set;}

    public DateTime? Date { get; set;}
    
    public string? Description { get; set;}

    public ICollection<ReportTransaction> ReportTransactions { get; set; }
}