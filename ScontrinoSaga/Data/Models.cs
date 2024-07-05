using Microsoft.EntityFrameworkCore;

namespace ScontrinoSaga.Data {
    public record class Product {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public double ProductVat { get; set; }
        public bool IsAvaialable { get; set; }

        public Product() {
            this.ProductVat = .22d;
            this.ProductDescription = "Empty";
        }
    }

    public record class Invoice {
        public int InvoiceId { get; set; }
        public string InvoiceGUID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceRow> InvoiceRows { get; set; }

        public decimal InvoiceGrandTotal { get; set; }

        public Invoice() {
            this.InvoiceDate = DateTime.Now;
            this.InvoiceGUID= Guid.NewGuid().ToString();
            this.InvoiceRows = new List<InvoiceRow>();
        }
    }

    public record  class InvoiceRow {
        public int InvoiceRowID { get; set; }
        public Invoice ParentInvoice { get; set; }
        public Product InvoiceRowProduct { get; set; }
        public int InvoiceRowQuantity { get; set; }
        public double InvoiceRowPrice { get; set; }

    }

    public  class AppDBContext :DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options)
       : base(options) {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceRow> InvoicesRows { get; set; }
    }
}
