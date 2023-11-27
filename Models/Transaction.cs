using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("transaction")]
[Index("TransInfoId", Name = "FK_Info_Trans")]
[Index("UserId", Name = "FK_User_Trans")]
public partial class Transaction
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("transInfoID", TypeName = "int(11) unsigned")]
    public uint TransInfoId { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }

    [Column("userID", TypeName = "int(10) unsigned")]
    public uint UserId { get; set; }

    [ForeignKey("TransInfoId")]
    [InverseProperty("Transactions")]
    public virtual TransactionInfomation TransInfo { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Transactions")]
    public virtual Aspnetuser User { get; set; } = null!;
}
