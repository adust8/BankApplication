using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DatabaseLibrary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace DatabaseLibrary.Tables
{
    public class BankAppContext : DbContext
    {
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<LoginAndPassword> LoginsAndPasswords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AccountDB> Accounts { get; set; }
        public DbSet<AccountIdentityNumber> AccountNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BankAppDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LoginAndPasswordConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AccountIdentityNumberConfiguration());

            modelBuilder.Entity<AccountIdentityNumber>().HasData(new AccountIdentityNumber { Id =1,AccountNumber = 3090});           
            modelBuilder.Entity<AccountType>().HasData(new AccountType {Id=1, Name = "До востребования"});
            modelBuilder.Entity<AccountType>().HasData(new AccountType { Id = 2, Name = "Депозитный(7%)" });

            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CS_AS");    
        }

                    
    }

    public class AccountTypeConfiguration:IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Ignore(c => c.Id);
            builder.Property(i => i.Id).HasColumnName("account_type_id")
                                       .IsRequired();
            builder.Property(n => n.Name).HasColumnName("account_type_name")
                                         .IsRequired();           
        }
    }

    public class AccountIdentityNumberConfiguration : IEntityTypeConfiguration<AccountIdentityNumber>
    {
        public void Configure(EntityTypeBuilder<AccountIdentityNumber> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(i => i.Id).HasColumnName("account_id")
                                       .IsRequired();
            builder.Property(n => n.AccountNumber).HasColumnName("account_number")
                                         .IsRequired();
        }
    }

    public class LoginAndPasswordConfiguration : IEntityTypeConfiguration<LoginAndPassword>
    {
        public void Configure(EntityTypeBuilder<LoginAndPassword> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(p => p.Id).HasColumnName("id")
                                        .IsRequired();
            builder.Property(p => p.Login).HasColumnName("user_login")
                                        .IsRequired();
            builder.Property(p => p.Password).HasColumnName("user_password")
                                        .IsRequired();
            builder.Property(p => p.UserId).HasColumnName("user_id")
                                        .IsRequired();

            builder.Property(p => p.Email).HasColumnName("user_email")
                                        .IsRequired();

            //builder.HasOne(p => p.User).WithOne(p => p.LoginAndPassword).OnDelete(DeleteBehavior.Cascade);
                                        
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(p => p.Id).HasColumnName("id")
                                        .IsRequired();
            builder.Property(p => p.Name).HasColumnName("user_name")
                                        .IsRequired();
            builder.Property(p => p.Surname).HasColumnName("user_surname")
                                        .IsRequired();
            builder.Property(p => p.Patronymic).HasColumnName("user_patronymic")
                                        .IsRequired();
            builder.Property(p => p.BirthDate).HasColumnName("user_birth_date")
                                        .IsRequired();
            builder.Property(p => p.RegistrationDate).HasColumnName("user_registration_date")
                                        .IsRequired();
            builder.Property(p => p.PhoneNumber).HasColumnName("user_phone_number")
                                        .IsRequired();


            //builder.HasOne(p => p.User).WithOne(p => p.LoginAndPassword).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class AccountConfiguration : IEntityTypeConfiguration<AccountDB>
    {
        public void Configure(EntityTypeBuilder<AccountDB> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(c => c.Id).HasColumnName("account_id").IsRequired();
            builder.Property(c => c.Balance).HasColumnName("account_balance").IsRequired();
            builder.Property(c => c.UserId).HasColumnName("account_user_id").IsRequired();
            builder.Property(c => c.AccountTypeId).HasColumnName("account_type_id").IsRequired();
            builder.Property(c => c.AccountIdentificationNumber).HasColumnName("account_id_number").IsRequired();
            builder.HasAlternateKey(c => c.AccountIdentificationNumber);
            builder.Property(c => c.AccountPhoneNumber).HasColumnName("account_phone_number").IsRequired();
            builder.Property(c => c.CreatingAccountDate).HasColumnName("account_create_date").IsRequired();
            builder.Property(c => c.NextReplenishment).HasColumnName("account_next_replenishment").IsRequired();

            //builder.HasOne(p => p.User).WithOne(p => p.LoginAndPassword).OnDelete(DeleteBehavior.Cascade);

        }
    }





}
