using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TicketManager.Models;
using Microsoft.EntityFrameworkCore;
namespace TicketManager.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Ticket> Tickets { get; set; }
    }
}

