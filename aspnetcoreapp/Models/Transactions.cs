using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


public class Transaction {
    // public Transaction() {
    //     User = new User(); // Initialize navigation property
    //     Category = new Category(); // Initialize navigation property
    // }
   
    [Key]
    public int Id { get; set; }  // Primary Key

    [Required]
    public int UserId { get; set; }  // Foreign Key to Users table

    [ForeignKey("UserId")]
    public User? User { get; set; }  // Navigation property to User

    [Required]
    public int CategoryId { get; set; }  // Foreign Key to Categories table

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }  // Navigation property to Category

    [Required]
    public string? Type { get; set; }  // Income/Expense

    [Required]
    [Column(TypeName = "decimal(18,2)")]  // Adjust precision and scale as needed
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime Date { get; set; }
}