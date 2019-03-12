using BusinessLayer.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.Models
{
    public partial class Gallery_dbContext : DbContext
    {
        private IOptions<AppSettingsModel> settings;

        public Gallery_dbContext(IOptions<AppSettingsModel> settings)
        {
            this.settings = settings;
        }

        public Gallery_dbContext(DbContextOptions<Gallery_dbContext> options)
            : base(options) {}

        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<CartItemTypes> CartItemTypes { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<DeliveryDetails> DeliveryDetails { get; set; }
        public virtual DbSet<DeliveryOption> DeliveryOption { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderTb> OrderTb { get; set; }
        public virtual DbSet<PaymentOption> PaymentOption { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SellItem> SellItem { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && settings!=null && settings.Value!=null)
            {
                optionsBuilder.UseSqlServer(settings.Value.ConnectionStrings["GalleryDatabase"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ShoppingCartId).HasColumnName("shoppingCartID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__CartItem__produc__4D94879B");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.CartItem)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .HasConstraintName("FK__CartItem__shoppi__4E88ABD4");
            });

            modelBuilder.Entity<CartItemTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(122)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(122)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeliveryDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(122)
                    .IsUnicode(false);

                entity.Property(e => e.FlatNr)
                    .IsRequired()
                    .HasColumnName("flatNR")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNr)
                    .IsRequired()
                    .HasColumnName("houseNR")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(122)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(122)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.DeliveryDetails)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK__DeliveryD__Count__403A8C7D");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.DeliveryDetails)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK__DeliveryD__IDUse__3F466844");
            });

            modelBuilder.Entity<DeliveryOption>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CartItemId).HasColumnName("CartItemID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("date");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.CartItem)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.CartItemId)
                    .HasConstraintName("FK__OrderItem__CartI__74AE54BC");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__Order__75A278F5");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(122)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderTb>(entity =>
            {
                entity.ToTable("OrderTB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryOptionId).HasColumnName("DeliveryOptionID");

                entity.Property(e => e.Error)
                    .HasColumnName("error")
                    .HasMaxLength(122)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentOptionId).HasColumnName("PaymentOptionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DeliveryOption)
                    .WithMany(p => p.OrderTb)
                    .HasForeignKey(d => d.DeliveryOptionId)
                    .HasConstraintName("FK__OrderTB__Deliver__70DDC3D8");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.OrderTb)
                    .HasForeignKey(d => d.OrderStatus)
                    .HasConstraintName("FK__OrderTB__OrderSt__6FE99F9F");

                entity.HasOne(d => d.PaymentOption)
                    .WithMany(p => p.OrderTb)
                    .HasForeignKey(d => d.PaymentOptionId)
                    .HasConstraintName("FK__OrderTB__Payment__71D1E811");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderTb)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__OrderTB__UserID__6EF57B66");
            });

            modelBuilder.Entity<PaymentOption>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.HasCart).HasColumnName("hasCart");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SellItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CurrencyCode).HasColumnName("currencyCode");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Idtype).HasColumnName("IDType");

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasColumnType("decimal(5, 5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NewPrice)
                    .HasColumnName("newPrice")
                    .HasColumnType("decimal(5, 5)");

                entity.Property(e => e.OldPrice)
                    .HasColumnName("oldPrice")
                    .HasColumnType("decimal(5, 5)");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(5, 5)");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasColumnType("decimal(5, 5)");

                entity.HasOne(d => d.CurrencyCodeNavigation)
                    .WithMany(p => p.SellItem)
                    .HasForeignKey(d => d.CurrencyCode)
                    .HasConstraintName("FK__SellItem__curren__4AB81AF0");

                entity.HasOne(d => d.IdtypeNavigation)
                    .WithMany(p => p.SellItem)
                    .HasForeignKey(d => d.Idtype)
                    .HasConstraintName("FK__SellItem__IDType__49C3F6B7");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.ShoppingCart)
                    .HasForeignKey(d => d.Iduser)
                    .HasConstraintName("FK__ShoppingC__IDUse__4316F928");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(128);

                entity.Property(e => e.ProfilePictName)
                    .HasColumnName("profilePictName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Users__idRole__3A81B327");
            });
        }
    }
}
