using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Categories");


            builder.HasData(new Category { 
                Id = 1, Name="ASP.NET", Description="ASP.NET ile Web Blog Tasarımı",
                IsActive = true,IsDeleted=false, Note="ASP.NET blog kategorisi",
                CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
                ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now
            },
            new Category {
                Id = 2, Name="Yapay Zeka", Description="Yapay Zekanın Getirdiği Avantajlar",
                IsActive = true,IsDeleted=false, Note="Yapay Zeka blog kategorisi",
                CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
                ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now
            },
            new Category {
                Id = 3, Name="Sql Server", Description="Sql Server ile Database İşlemleri",
                IsActive = true,IsDeleted=false, Note="Sql server blog kategorisi",
                CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
                ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now
            },
            new Category {
                Id = 4, Name= "ChatGPT ve SEO", Description= "Google’a bir konu hakkındaki uzmanlığınızı anlatma sanatıdı",
                IsActive = true,IsDeleted=false, Note= "ChatGPT ve SEO blog kategorisi",
                CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
                ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now
            }
            );


        }
    }
}
