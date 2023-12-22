using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;


public class GameType
{
    public const uint Software = 0;
    public const uint Disc = 1;
    public static string Get(uint type)
    {
        return type == Software ? "Software" : "Disc";
    }
}