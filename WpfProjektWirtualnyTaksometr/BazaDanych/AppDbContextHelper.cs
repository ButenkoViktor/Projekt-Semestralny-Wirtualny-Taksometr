using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WpfProjektWirtualnyTaksometr.BazaDanych;
public static class DbContextHelper
{
    public static DbContextOptions<AppDbContext> Options { get; } =
        new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=taksometr.db")
            .Options;
}
