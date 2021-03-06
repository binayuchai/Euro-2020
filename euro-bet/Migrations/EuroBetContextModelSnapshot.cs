// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using euro_bet.Data;

namespace euro_bet.Migrations
{
    [DbContext(typeof(EuroBetContext))]
    partial class EuroBetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("euro_bet.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastActive")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("euro_bet.Models.Balance", b =>
                {
                    b.Property<int>("BalanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BalanceID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("Balance");
                });

            modelBuilder.Entity("euro_bet.Models.Coach", b =>
                {
                    b.Property<int>("CoachID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoachID");

                    b.HasIndex("CountryID");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("euro_bet.Models.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("euro_bet.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("euro_bet.Models.Fixture", b =>
                {
                    b.Property<int>("FixtureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score_FullTime_Away")
                        .HasColumnType("int");

                    b.Property<int>("Score_FullTime_Home")
                        .HasColumnType("int");

                    b.Property<int>("Score_HalfTime_Away")
                        .HasColumnType("int");

                    b.Property<int>("Score_HalfTime_Home")
                        .HasColumnType("int");

                    b.Property<int?>("SquadAwaySquadID")
                        .HasColumnType("int");

                    b.Property<int?>("SquadHomeSquadID")
                        .HasColumnType("int");

                    b.Property<string>("Venue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FixtureID");

                    b.HasIndex("SquadAwaySquadID");

                    b.HasIndex("SquadHomeSquadID");

                    b.ToTable("Fixture");
                });

            modelBuilder.Entity("euro_bet.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClubName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerID");

                    b.HasIndex("CountryID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("euro_bet.Models.Squad", b =>
                {
                    b.Property<int>("SquadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachID")
                        .HasColumnType("int");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.HasKey("SquadID");

                    b.HasIndex("CoachID");

                    b.HasIndex("CountryID");

                    b.ToTable("Squad");
                });

            modelBuilder.Entity("euro_bet.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountID")
                        .HasColumnType("int");

                    b.Property<int?>("ContactID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("AccountID");

                    b.HasIndex("ContactID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("euro_bet.Models.Balance", b =>
                {
                    b.HasOne("euro_bet.Models.User", null)
                        .WithOne("Balance")
                        .HasForeignKey("euro_bet.Models.Balance", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("euro_bet.Models.Coach", b =>
                {
                    b.HasOne("euro_bet.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("euro_bet.Models.Fixture", b =>
                {
                    b.HasOne("euro_bet.Models.Squad", "SquadAway")
                        .WithMany()
                        .HasForeignKey("SquadAwaySquadID");

                    b.HasOne("euro_bet.Models.Squad", "SquadHome")
                        .WithMany()
                        .HasForeignKey("SquadHomeSquadID");

                    b.Navigation("SquadAway");

                    b.Navigation("SquadHome");
                });

            modelBuilder.Entity("euro_bet.Models.Player", b =>
                {
                    b.HasOne("euro_bet.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("euro_bet.Models.Squad", b =>
                {
                    b.HasOne("euro_bet.Models.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachID");

                    b.HasOne("euro_bet.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID");

                    b.Navigation("Coach");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("euro_bet.Models.User", b =>
                {
                    b.HasOne("euro_bet.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("euro_bet.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactID");

                    b.Navigation("Account");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("euro_bet.Models.User", b =>
                {
                    b.Navigation("Balance");
                });
#pragma warning restore 612, 618
        }
    }
}
