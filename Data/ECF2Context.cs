using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECF2.Models;

namespace ECF2.Data
{
    public class ECF2Context : DbContext
    {
        public ECF2Context (DbContextOptions<ECF2Context> options)
            : base(options)
        {
        }

        public DbSet<ECF2.Models.Event> Event { get; set; } = default!;
        public DbSet<ECF2.Models.User> User { get; set; } = default!;
        public DbSet<ECF2.Models.UserEvent> UserEvent { get; set; } = default!;
    }
}
