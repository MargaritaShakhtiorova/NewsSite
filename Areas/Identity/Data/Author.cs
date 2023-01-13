using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Diploma_v1._1.Models;

namespace Diploma_v1._1.Areas.Identity.Data;

public class Author : IdentityUser
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public List<News> NewsList { get; set; }
}