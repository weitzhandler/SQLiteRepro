using System;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp4
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");

      using var context = new Context();
      context.Database.EnsureCreated();
    }
  }

  class Context : DbContext
  {
    public DbSet<Model> Models { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var model = modelBuilder.Entity<Model>();
      model.Property(m => m.Id).ValueGeneratedOnAdd();
      model.HasData(new Model { Id = 1, Value = "Lorem ipsum dolor sit amet" });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=App.db");
    }
  }

  class Model
  {
    public int Id { get; set; }
    public string Value { get; set; }
  }


}
