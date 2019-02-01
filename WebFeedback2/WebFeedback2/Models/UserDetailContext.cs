using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFeedback2.Models
{
    public class UserDetailContext : DbContext
    {
        public UserDetailContext(DbContextOptions<UserDetailContext> options) : base(options)
        {

        }

        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<MessageDetail> MessageDetail { get; set; }
        public DbSet<ThemeDetail> ThemeDetail { get; set; }

    }
}