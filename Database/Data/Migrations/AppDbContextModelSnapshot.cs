// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WDD.Data;

#nullable disable

namespace WDD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WDD.Data.Entities.Contact", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Eric",
                            LastName = "Elliot",
                            PhoneNumber = "222-555-6575"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Steve",
                            LastName = "Jobs",
                            PhoneNumber = "220-454-6754"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Fred",
                            LastName = "Allen",
                            PhoneNumber = "210-657-9886"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Steve",
                            LastName = "Woznaik",
                            PhoneNumber = "343-675-8786"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Bill",
                            LastName = "Gates",
                            PhoneNumber = "343-654-9688"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
