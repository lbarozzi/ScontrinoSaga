using Microsoft.EntityFrameworkCore;

namespace ScontrinoSaga.Data {
    public record class Product {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public double ProductVat { get; set; }
        public bool IsAvaialable { get; set; }

        public string ProductIcon {get;set;}

        public Product() {
            this.ProductVat = .22d;
            this.ProductDescription = "Empty";
            this.ProductIcon = "empty.png";
        }
    }

    public record class Invoice {
        public int InvoiceId { get; set; }
        public string InvoiceGUID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceRow> InvoiceRows { get; set; }

        public double InvoiceGrandTotal { get; set; }

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

    public record class User{
        public string UserName { get; set;}
        public string Password { get; set;}

        public User(string userName, string password) {
            this.UserName = userName;
            this.Password = password;
        }
        public User(): this(string.Empty,string.Empty) {}
        

        public string EncodePassword(string password) {
            var enc = System.Security.Cryptography.SHA512.Create();
            var raw= System.Text.ASCIIEncoding.UTF8.GetBytes(password);
            var hs= enc.ComputeHash(raw);
            return System.Text.ASCIIEncoding.UTF8.GetString(hs);
        }    
    }
}
