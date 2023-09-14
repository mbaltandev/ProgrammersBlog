using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(1000);
            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);
            

            builder.HasOne<Article>(c => c.Article).WithMany
                (a => a.Comments).HasForeignKey(c => c.ArticleId);

            builder.ToTable("Comments");

            //builder.HasData(
            //    new Comment { 
            //        Id = 1,ArticleId = 1,
            //        Text="ASP.NET icin cok faydali bir makale olmus tesekkurler",
            //        IsActive = true,IsDeleted=false, Note= "ASP.NET makale yorumu",
            //        CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //        ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now,
            //    },
            //    new Comment { 
            //        Id = 2,ArticleId = 1,
            //        Text="Aradigim butun bilgileri burada buldum tesekkurler",
            //        IsActive = true,IsDeleted=false, Note= "ASP.NET makale yorumu 2",
            //        CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //        ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now,
            //    },
            //    new Comment { 
            //        Id = 3,ArticleId = 2,
            //        Text="Yapay Zeka icin cok faydali bir makale olmus tesekkurler",
            //        IsActive = true,IsDeleted=false, Note= "Yapay Zeka makale yorumu",
            //        CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //        ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now,
            //    },
            //    new Comment { 
            //        Id = 4,ArticleId = 2,
            //        Text="Aradigim butun bilgileri burada buldum tesekkurler",
            //        IsActive = true,IsDeleted=false, Note= "Yapay Zeka makale yorumu 2",
            //        CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //        ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now,
            //    },
                     
            //     new Comment { 
            //        Id = 7,ArticleId = 4,
            //        Text= "ChatGPT ve SEO icin cok faydali bir makale olmus tesekkurler",
            //         IsActive = true,IsDeleted=false, Note= "ChatGPT ve SEO makale yorumu",
            //        CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //        ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now,
            //    },
            //    new Comment { 
            //        Id = 8,ArticleId = 4,
            //        Text="Aradigim butun bilgileri burada buldum tesekkurler",
            //        IsActive = true,IsDeleted=false, Note= "ChatGPT ve SEO makale yorumu 2",
            //        CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //        ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now,
            //    }
            //    );
        }
    }
}
