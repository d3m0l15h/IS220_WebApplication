using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("transaction_type")]
public partial class TransactionType
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [InverseProperty("Type")]
    public virtual ICollection<TransactionInfomation> TransactionInfomations { get; set; } = new List<TransactionInfomation>();
}
