using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("aspnetusers")]
[Index("Email", Name = "EMAIL", IsUnique = true)]
[Index("Normalizedemail", Name = "EMAILINDEX")]
[Index("Normalizedusername", Name = "USERNAMEINDEX", IsUnique = true)]
public partial class Aspnetuser : IdentityUser<uint>
{
    [Key]
    [Column("ID", TypeName = "int(10) unsigned")]
    public override uint Id { get; set; }

    [Column("EMAIL")]
    [StringLength(256)]
    public override string? Email { get; set; }

    [Column("FIRSTNAME")]
    [StringLength(50)]
    public string? Firstname { get; set; }

    [Column("LASTNAME")]
    [StringLength(50)]
    public string? Lastname { get; set; }

    [Column("PHONE")]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("BIRTH")]
    public DateOnly? Birth { get; set; }

    [Column("ROLE", TypeName = "tinyint(4)")]
    public sbyte Role { get; set; }

    [Column("CREATED", TypeName = "datetime")]
    public DateTime Created { get; set; }

    [Column("MODIFIED", TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Column("CASH", TypeName = "double(13,2)")]
    public double Cash { get; set; }

    [Column("STATUS")]
    [StringLength(10)]
    public string Status { get; set; } = null!;

    [Column("AVATARPATH", TypeName = "tinytext")]
    public string? Avatarpath { get; set; }

    [Column("NORMALIZEDUSERNAME")]
    [StringLength(256)]
    public string? Normalizedusername { get; set; }

    [Column("NORMALIZEDEMAIL")]
    [StringLength(256)]
    public string? Normalizedemail { get; set; }

    [Column("EMAILCONFIRMED")]
    public bool Emailconfirmed { get; set; }

    [Column("PASSWORDHASH")]
    public string? Passwordhash { get; set; }

    [Column("SECURITYSTAMP")]
    public string? Securitystamp { get; set; }

    [Column("CONCURRENCYSTAMP")]
    public string? Concurrencystamp { get; set; }

    [Column("PHONENUMBER")]
    public string? Phonenumber { get; set; }

    [Column("PHONENUMBERCONFIRMED")]
    public bool Phonenumberconfirmed { get; set; }

    [Column("TWOFACTORENABLED")]
    public bool Twofactorenabled { get; set; }

    [Column("LOCKOUTEND")]
    [MaxLength(6)]
    public DateTime? Lockoutend { get; set; }

    [Column("LOCKOUTENABLED")]
    public bool Lockoutenabled { get; set; }

    [Column("ACCESSFAILEDCOUNT", TypeName = "int(11)")]
    public int Accessfailedcount { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [InverseProperty("User")]
    public virtual ICollection<Aspnetuserclaim> Aspnetuserclaims { get; set; } = new List<Aspnetuserclaim>();

    [InverseProperty("User")]
    public virtual ICollection<Aspnetuserlogin> Aspnetuserlogins { get; set; } = new List<Aspnetuserlogin>();

    [InverseProperty("User")]
    public virtual ICollection<Aspnetusertoken> Aspnetusertokens { get; set; } = new List<Aspnetusertoken>();

    [InverseProperty("UidNavigation")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [InverseProperty("User")]
    public virtual ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();

    [ForeignKey("Userid")]
    [InverseProperty("Users")]
    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    [ForeignKey("Userid")]
    [InverseProperty("Users")]
    public virtual ICollection<Aspnetrole> Roles { get; set; } = new List<Aspnetrole>();
}
