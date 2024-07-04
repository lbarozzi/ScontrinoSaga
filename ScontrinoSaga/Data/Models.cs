using Microsoft.EntityFrameworkCore;

namespace ScontrinoSaga.Data {
    public record class Product {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public double ProductVat { get; set; }
        public bool IsAvaialable { get; set; }

        public Product() {
            this.ProductVat = .22d;
            this.ProductDescription = "Empty";
        }
    }

    public record class Invoice {
        public int InvoiceId { get; set; }
        public List<InvoiceRow> InvoiceRows { get; set; }

        public decimal InvoiceGrandTotal { get; set; }
    }

    public record  class InvoiceRow {
        public int InvoiceRowID { get; set; }
        public Invoice ParentInvoice { get; set; }
        public Product InvoicRowProducts { get; set; }
        public int InvoiceRowQuantity { get; set; }
        public int InvoiceRowPrice { get; set; }

    }

    public  class AppDBContext :DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options)
       : base(options) {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceRow> InvoicesRows { get; set; }
    }
}
