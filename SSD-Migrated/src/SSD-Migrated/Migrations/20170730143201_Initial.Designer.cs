using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SSD_Migrated.Data;

namespace SSDMigrated.Migrations
{
    [DbContext(typeof(AppThreadDbContext))]
    [Migration("20170730143201_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SSD_Migrated.Models.MessageModels.Message", b =>
                {
                    b.Property<int>("mId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("author");

                    b.Property<string>("content");

                    b.Property<int>("tId");

                    b.Property<string>("title");

                    b.HasKey("mId");

                    b.ToTable("Messages");
                });
        }
    }
}
