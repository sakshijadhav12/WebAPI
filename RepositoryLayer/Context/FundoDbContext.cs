using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Context
{
    public class FundoDbContext : DbContext
    {  
       public FundoDbContext(DbContextOptions option ):base(option)
        {
        }
        public DbSet<UserEntity> User { get; set; }
     }

    
}
