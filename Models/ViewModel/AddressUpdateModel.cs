using System.ComponentModel.DataAnnotations;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models.ViewModel;
public class AddressUpdateModel
{
    public uint Id { get; set; }
    public string Receiver { get; set; }
    public string Phone { get; set; }
    public string Street { get; set; }
    public string Ward { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}