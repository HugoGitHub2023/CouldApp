using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Assignment1V1.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace Assignment1V1.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime Birthday { get; set; }

    public string? CellPhone { get; set; }

    public string? Scholarship { get; set; }

    public List<Product>? Products { get; set; }

}

