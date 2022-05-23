using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHOPDienThoai.Models;

namespace SHOPDienThoai.Data
{
    public class SHOPDienThoaiContext : DbContext
    {
        public SHOPDienThoaiContext (DbContextOptions<SHOPDienThoaiContext> options)
            : base(options)
        {
        }

        public DbSet<SHOPDienThoai.Models.DienThoai> DienThoai { get; set; }
    }
}
