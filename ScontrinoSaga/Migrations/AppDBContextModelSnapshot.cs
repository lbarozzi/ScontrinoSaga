﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScontrinoSaga.Data;

#nullable disable

namespace ScontrinoSaga.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ScontrinoSaga.Data.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("InvoiceGrandTotal")
                        .HasColumnType("TEXT");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("ScontrinoSaga.Data.InvoiceRow", b =>
                {
                    b.Property<int>("InvoiceRowID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvoicRowProductsProductID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvoiceRowPrice")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvoiceRowQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentInvoiceInvoiceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("InvoiceRowID");

                    b.HasIndex("InvoicRowProductsProductID");

                    b.HasIndex("ParentInvoiceInvoiceId");

                    b.ToTable("InvoicesRows");
                });

            modelBuilder.Entity("ScontrinoSaga.Data.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAvaialable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ProductVat")
                        .HasColumnType("REAL");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ScontrinoSaga.Data.InvoiceRow", b =>
                {
                    b.HasOne("ScontrinoSaga.Data.Product", "InvoicRowProducts")
                        .WithMany()
                        .HasForeignKey("InvoicRowProductsProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScontrinoSaga.Data.Invoice", "ParentInvoice")
                        .WithMany("InvoiceRows")
                        .HasForeignKey("ParentInvoiceInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoicRowProducts");

                    b.Navigation("ParentInvoice");
                });

            modelBuilder.Entity("ScontrinoSaga.Data.Invoice", b =>
                {
                    b.Navigation("InvoiceRows");
                });
#pragma warning restore 612, 618
        }
    }
}
