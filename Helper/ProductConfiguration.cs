using managementorderapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.ObjectModel;

namespace managementorderapi.Helper
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                 new Product() {Id = 1,  Description = "Palmolive gold live", Name = "palmolive", Price = 200.00M, Stock = 100, ProductImages = new Collection<ProductImage>() },
                new Product() { Id = 2, Description = "Colgate gold premium", Name = "Colgate", Price = 400.00M, Stock = 150, ProductImages = new Collection<ProductImage>() }
                );
        }
    }
}
