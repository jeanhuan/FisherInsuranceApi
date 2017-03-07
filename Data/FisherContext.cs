using Microsoft.EntityFrameworkCore;
using FisherInsuranceApi.Models;


namespace FisherInsuranceApi.Data {

    public class FisherContext : DbContext {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
        
        string connection = "User ID=amis3610;Password=3610;Host=localhost;Port=5432;Database=fisher-insurance;Pooling=true;"; 
        
        optionsBuilder.UseNpgsql(connection); 
        
        }

    public DbSet<Claim> Claims { get; set; } 

    public DbSet<Quote> Quotes { get; set; }


    }

    

    


}