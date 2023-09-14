using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a=> a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a =>a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany
                (c => c.Articles).HasForeignKey(a => a.CategoryId);

            builder.HasOne<User>(a => a.User).WithMany
                (u => u.Articles).HasForeignKey(a => a.UserId);

            builder.ToTable("Articles");

            //builder.HasData(new Article { 
            //    Id = 4,CategoryId = 4, UserId = 1,
            //    Title= "ChatGPT ve SEO", Content= "SEO, Google’a bir konu hakkındaki uzmanlığınızı anlatma sanatıdır. Google’ın yayınlamış olduğu güncellemelerin temelinde kullanıcı deneyimi vardır. Kullanıcıların arama motoru kullanarak araştırdığı konular hakkındaki uzmanlığınız Google tarafından değerlendirilir ve bir algoritma ile sıralanır. Bu sıralamalardaki ana etken kitabın bir sayfasına hâkim olmak değil, kitabın her alanını bilmek fakat bazı alanlarda uzman olduğunuzu belirtmekten geçer. Google’a sunduğunuz içerikler ne kadar kaliteli ve kullanıcıya hitap ediyorsa ödülünüz o kadar büyük olur ve Google’da üst sıralarda yer edinebilirsiniz. Tabi ki sunduğunuz bilgiler birçok etken barındırmakta örneğin içeriğinizin özgün olması ve semantik kelimelerin web sayfanızda yer alması sizlere her zaman avantaj sağlayacak ve Google arama motorunda üst sıralarda yer almanızı sağlayacaktır.",
            //    Thumbnail="Default.jpg",SeoDescription= "ChatGPT ve SEO",
            //    SeoAuthor="Batuhan Altan",SeoTags= "ChatGPT, SEO, Google",
            //    Date=DateTime.Now,IsActive=true,IsDeleted=false, Note= "ChatGPT ve SEO makalesi",
            //    CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //    ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now
            //},
            //    new Article { 
            //    Id = 1,CategoryId = 1, UserId = 1,
            //    Title= "ASP.NET", Content= "Günümüzde İnternetin gelişimi birçok alanda değişiklik ve yeniliklerin oluşmasına olanak sağlamıştır. Bu alanlardan biri de hiç şüphesiz Elektronik Ticaret alanı alanıdır. Elektronik Ticaret’in gelişimi ve değişimi internetten sonra büyük ölçüde değiştiren ve geliştiren ise Mobil Dünyadaki gelişmeler ve değişimler olmuştur. Mobil Araçların gelişimi ve yaygınlaşması ile birlikte insanların İnternet’e ve dolayısı ile Elektronik Web Sitelerine ulaşmaları ve alışveriş yapma oranlarında büyük bir artış olmuştur. Elektronik Ticaret alanında faaliyet göstermek isteyen firmalar tanıtımlarını yapabilecekleri ve yine ürün veya hizmetlerini sunabilecekleri tasarım ve yazılım açısından güçlü ve etkileşimli Elektronik Ticaret Web sitesine sahip olmak istemektedirler. Web site tasarımında kullanılan ve Microsoft tarafından geliştirilen C# ve ASP.NET MVC gibi teknolojilerin gelişimi e-ticaret sitelerinin daha üst seviyede güvenlikli ve daha rahat tasarlanıp kodlanmasını sağlamaktadır. Bu çalışmada geliştirilen dinamik web içeriklerinin kullanılmasıyla MVC teknolojisini temel alan bir e-ticaret sayfası geliştirilmiştir. Model, görünüm ve kontrol bölümlerinin ayrı ayrı gerçekleştirilmesi ile Front End ve Back End yapılar birbirinden ayrı ayrı olarak geliştirilmiştir. Front End bölümü ASP kaynak kodları ile yazılan projede Back End bölümünde Controller ve veritabanı yer almaktadır. Bu tasarım ile kod optimizasyonu, kodun genişletilmesi ve yeniden kullanılması, ekip olarak kodun güncellenmesi olanakları sağlamaktadır.",
            //    Thumbnail="Default.jpg",SeoDescription= "ASP.NET",
            //    SeoAuthor="Batuhan Altan",SeoTags= "ASP.NET, C#, Mvc",
            //    Date=DateTime.Now,IsActive=true,IsDeleted=false, Note= "ASP.NET makalesi",
            //    CreatedByName="InitialCreate", CreatedDate=DateTime.Now,
            //    ModifiedByName="InitialCreate", ModifiedDate=DateTime.Now
            //},
            //    new Article {
            //    Id = 2,CategoryId = 2, UserId = 1,
            //    Title = "Yapay Zeka", Content = "Yapay zekanın (AI) yükselişe geçtiğine şüphe yok. Ancak yapay zekanın insanlardan daha akıllı hale gelmesi ve dünyayı ele geçirmesi korkuları makul mü? Yoksa bunlar, fazlasıyla şişirilmiş korkular mı? Bazı uzmanlar, yapay zekanın insanlığa gerçek bir tehdit oluşturacak kadar akıllı ve güçlü olabileceğine inanıyor. Örneğin ünlü fizikçi Stephen Hawking, “tam yapay zekanın geliştirilmesinin insan ırkının sonunu getirebileceğini” söyledi. Bill Gates gibi diğer uzmanlar, yapay zekanın insan zekâsını aşma potansiyeli konusunda benzer endişeleri dile getirdiler.Ama aynı zamanda yapay zeka çevresinde çok fazla \"hype\" ve korku tellallığı var. Örneğin, bazı insanlar yapay zekanın araba kullanmak, hastalıkları teşhis etmek ve hatta sanat üretmek de dâhil hemen her şeyi insanlardan daha iyi yapabileceğini iddia ediyor. Peki yapay zekanın yükselişiyle ilgili gerçek ne? Makinelerin dünyayı ele geçireceği bir gelecekle mi karşı karşıyayız? Yoksa bu korku yersiz mi?",
            //    Thumbnail = "Default.jpg",SeoDescription = "Yapay Zeka",
            //    SeoAuthor = "Batuhan Altan",SeoTags = "AI, GPT-3, YSA",
            //    Date = DateTime.Now,IsActive = true,IsDeleted = false, Note = "Yapay Zeka makalesi",
            //    CreatedByName = "InitialCreate", CreatedDate = DateTime.Now,
            //    ModifiedByName = "InitialCreate", ModifiedDate = DateTime.Now
            //},
            //    new Article {
            //    Id = 3,CategoryId = 3, UserId = 1,
            //    Title = "Sql Server", Content = "Veri tabanı yönetim sistemleri, veri tabanlarını tanımlamak, oluşturmak, kullanmak, değiştirmek ve veri tabanı sistemleriyle ilgili her türlü işletimsel gereksinimleri karşılamak için tasarlanmış sistem ve yazılımlardır. DBEngines verilerine göre günümüzde 300’ün üzerinde veri tabanı yönetim sistemi geliştirilmiştir. Bu tez çalışmasında Oracle ve MS SQL Server veri tabanı yönetim sistemleri için kendi şirketleri tarafından oluşturulan güvenlik kontrol ilkeleri incelenmiş ve bu ilkelerin uygulanmadığı takdirde ortaya çıkabilecek olası sonuçlar ortaya konulmuştur. Güvenlik kontrol ilkelerinin detaylıca tanımlanmasının ardından, java server faces aracılığı ile güvenlik kontrol ilkelerini Oracle ve MS SQL Server veri tabanlarına uygulayan bir uygulama geliştirilmiştir. Uzak sunucu ihtiyacı için sanal laboratuvar ortamı oluşturulmuştur.",
            //    Thumbnail = "Default.jpg",SeoDescription = "Sql Server",
            //    SeoAuthor = "Batuhan Altan",SeoTags = "Sql, Database, Microsoft",
            //    Date = DateTime.Now,IsActive = true,IsDeleted = false, Note = "Sql Server makalesi",
            //    CreatedByName = "InitialCreate", CreatedDate = DateTime.Now,
            //    ModifiedByName = "InitialCreate", ModifiedDate = DateTime.Now
            //}
            //    );















        }
    }
}
