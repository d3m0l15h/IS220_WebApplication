using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("transaction_infomation")]
[Index("GameId", Name = "FK_Game_Trans")]
[Index("TypeId", Name = "Fk_Type_Trans")]
public partial class TransactionInfomation
{
    [Key]
    [Column("id")]
    public uint Id { get; set; }

    [Column("typeID")]
    public uint TypeId { get; set; }

    [Column("amount")]
    public int Amount { get; set; }

    [Column("gameID")]
    public uint? GameId { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("TransactionInfomations")]
    public virtual Game? Game { get; set; }

    [InverseProperty("TransInfo")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [ForeignKey("TypeId")]
    [InverseProperty("TransactionInfomations")]
    public virtual TransactionType Type { get; set; } = null!;
}
