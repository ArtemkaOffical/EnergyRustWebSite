using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyRust.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnergyRust.Areas.Identity.Data
{
    public class EnergyRustIdentityDbContext : IdentityDbContext<IdentityUser>
    {
       
        public EnergyRustIdentityDbContext(DbContextOptions<EnergyRustIdentityDbContext> options)
            : base(options)
        {
            
           //Database.EnsureDeleted();
         //  Database.EnsureCreated();
           
        }

        public DbSet<BabyFT> BabyFT { get; set; }
       
        public DbSet<PartyTime> PartyTimes { get; set; }
        public DbSet<PartyTimeCategory> PartyTimeCategories { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<ItemDefinitions> ItemDefinitions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<EAC> EAC { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<PromoCodeActivation> PromoCodeActivations { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}
