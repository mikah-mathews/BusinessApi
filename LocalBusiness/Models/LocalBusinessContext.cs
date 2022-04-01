using Microsoft.EntityFrameworkCore;

namespace LocalBusiness.Models
{
  public class LocalBusinessContext : DbContext
  {
    public LocalBusinessContext(DbContextOptions<LocalBusinessContext> options)
      : base(options)
    {      
    }

    public DbSet<Business> Businesses { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Business>()
        .HasData(
          new Business { BusinessId = 1, Name = "Matilda's Dresses", Address = "853 Leonor Points, HipolitoFurt, IL 83006", PhoneNumber = 2278656128, Website = "matildasdresses.com", Hours = "9am to 5pm", GoodsType = "Apparel"},
          new Business { BusinessId = 2, Name = "Rexie's Fossils", Address = "949 Schroeder Meadow, Kirkland, WA 98052", PhoneNumber = 5383392548, Website = "rexiesfossils.com", Hours ="10am to 8pm", GoodsType = "Fossils"},
          new Business { BusinessId = 3, Name = "Miranda's Outdoor Gear", Address = "64347 Jake Bypass, East Garretfort, TX 70158", PhoneNumber = 7898901979, Website = "mirandasoutdoors.com", Hours ="10am to 9pm", GoodsType = "Outdoor recreation"},
          new Business { BusinessId = 4, Name = "Pip and Squeak", Address = "2101 Hermina Plaza Suite 649, Braedenland, WA 86302", PhoneNumber = 5034968358, Website = "pipandsqueaktea.com", Hours ="6am to 5pm", GoodsType = "Tea"},
          new Business { BusinessId = 5, Name = "Bartholomew's Books", Address = "394 Alford Station, East Chanel, CT 64520", PhoneNumber = 3086879381, Website = "bartsbooksandcomics.com", Hours ="9am to 9pm", GoodsType = "Books"}
        );
      }
  }
}