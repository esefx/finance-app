using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

public class Category {
    [Key]
    public int Id { get; set;}
    [Required]
    [StringLength(50)]
    public String? Name { get;  set;}
    public ICollection<Transaction> Transactions { get; set;}
    
}