﻿// <auto-generated />
using CashBank3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CashBank3.Migrations
{
    [DbContext(typeof(ClienteContext))]
    [Migration("20210710011442_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CashBank3.Models.Carteira", b =>
                {
                    b.Property<int>("id_carteira")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fk_email_proprietario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("saldo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.HasKey("id_carteira");

                    b.HasIndex("fk_email_proprietario")
                        .IsUnique()
                        .HasFilter("[fk_email_proprietario] IS NOT NULL");

                    b.ToTable("CarteiraItems");
                });

            modelBuilder.Entity("CashBank3.Models.Cliente", b =>
                {
                    b.Property<string>("email_proprietario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("email_proprietario");

                    b.ToTable("ClienteItems");
                });

            modelBuilder.Entity("CashBank3.Models.Carteira", b =>
                {
                    b.HasOne("CashBank3.Models.Cliente", "Cliente")
                        .WithOne("Carteira")
                        .HasForeignKey("CashBank3.Models.Carteira", "fk_email_proprietario");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CashBank3.Models.Cliente", b =>
                {
                    b.Navigation("Carteira");
                });
#pragma warning restore 612, 618
        }
    }
}
