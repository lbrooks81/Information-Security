﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InfoSecLab.Models;

[Table("USER_LOGIN")]
[Index("UserId", Name = "USER_ID_FK_idx")]
public partial class UserLogin
{
    [Key]
    [Column("USER_LOGIN_ID")]
    public uint UserLoginId { get; set; }

    [Column("USER_ID")]
    public uint UserId { get; set; }

    [Column("USER_LOGIN_TOKEN")]
    [StringLength(64)]
    public string UserLoginToken { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserLogins")]
    public virtual User User { get; set; } = null!;
}