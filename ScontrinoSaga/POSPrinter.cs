/*
*/
using System;
using System.IO;
using System.Linq;  
using System.Collections.Generic;
using ESC_POS_USB_NET;
using ScontrinoSaga.Data;
using ESC_POS_USB_NET.Printer;
using ScontrinoSaga;
using Humanizer;

public class POSPrinter{
    public string Name {get; set;}
    public string Encoding {get; set;}
    protected Printer lpt;
    protected SagaConfig cfg;
    public POSPrinter(SagaConfig cfg, string Encoding="utf-8"){
        this.Name = cfg.PrinterName;
        this.Encoding = Encoding;
        this.cfg = cfg;
        lpt = new Printer(Name,Encoding);
    }
    
    /*/
    private void PrintTotalAsSvg()
    {
        SaveOrder();

        // Crea il contenuto SVG
        var svgContent = new System.Text.StringBuilder();
        svgContent.AppendLine("<svg width='58mm' height='800' xmlns='http://www.w3.org/2000/svg'>");
        svgContent.AppendLine("<rect width='100%' height='100%' fill='white'/>");

        int xPos=10;
        int x1Pos=110;
        float yPos = 20;

        // Logo (se presente)
        if (File.Exists(cfg.LogoFile))
        {
            var logoData = Convert.ToBase64String(File.ReadAllBytes(cfg.LogoFile));
            svgContent.AppendLine($"<image href='data:image/png;base64,{logoData}' x='{xPos}' y='{yPos}' width='100' height='100'/>");
            yPos += 110;
        }

        // Intestazione
        if (File.Exists(cfg.HeaderFile))
        {
            string head = File.ReadAllText(cfg.HeaderFile);
            svgContent.AppendLine($"<text x='xPos' y='{yPos}' font-size='12' fill='black'>{head}</text>");
            yPos += 30;
        }

        // Righe ordine
        foreach (var o in Order)
        {
            string line = $"{o.InvoiceRowQuantity:D02}x {o.InvoiceRowProduct.ProductDescription}";
            //  {o.InvoiceRowPrice:C2}";
            svgContent.AppendLine($"<text x='{xPos}' y='{yPos}' font-size='12' fill='black'>{line}</text>");
            line= $"{o.InvoiceRowPrice:C2}";
            svgContent.AppendLine($"<text x='110' y='{yPos}' font-size='12' fill='black'>{line}</text>");
            yPos += 20;
        }

        // Totale
        double tot = Order.Sum(o => o.InvoiceRowPrice);
        yPos += 10;
        svgContent.AppendLine($"<line x1='xPos' y1='{yPos}' x2='374' y2='{yPos}' stroke='black'/>");
        yPos += 20;

        // Totale in grassetto e più grande
        svgContent.AppendLine($"<text x='{xPos}' y='{yPos}' font-size='16' fill='black'>TOTALE:</text>");
        svgContent.AppendLine($"<text x='{x1Pos}' y='{yPos}' font-size='16' fill='black'>{tot:C2}</text>");

        // Piè di pagina
        if (File.Exists(cfg.TailFile))
        {
            yPos += 30;
            string tail = File.ReadAllText(cfg.TailFile);
            svgContent.AppendLine($"<text x='xPos' y='{yPos}' font-size='12' fill='black'>{tail}</text>");
        }

        svgContent.AppendLine("</svg>");

        // Salva il contenuto SVG in un file
        var tempFile = Path.Combine(Environment.WebRootPath, $"images/{this.ImageCurrent}.svg");
        File.WriteAllText(tempFile, svgContent.ToString());

        lpt.InitializePrint();
        //lpt.Image(tempFile);
        lpt.PrintDocument();
        lpt.FullPaperCut();

        CleanOrder();
        //Navigation.NavigateTo($"image/{this.ImageCurrent}");
    }
    //*/

    /// OLD CODE
    public void PrintTotal(IEnumerable<InvoiceRow> Order) {
        lpt.Clear();
    
        var path = cfg.WorkingPath;
        
        if(File.Exists(cfg.LogoFile)) {
            var png = new System.Drawing.Bitmap(System.Drawing.Bitmap.FromFile( cfg.LogoFile) );
            lpt.Image(png);
        } else {
            Console.WriteLine("Not found {0}",cfg.LogoFile);
        }
        if(File.Exists(cfg.HeaderFile)) {
            string head = File.ReadAllText(cfg.HeaderFile);
            lpt.Append(head);
        }  else {
            Console.WriteLine("Not found {0}",cfg.HeaderFile);
        }

        lpt.NewLines(2);
        double tot = 0.0d;
        char Euro = 'E'; //Convert.ToChar(0xD5); //'E'; //&euro;
        
        foreach(var o in Order) {
            lpt.Append(string.Format("{0,1:D2}x {1,-10}  {3,4:F2} {4}", o.InvoiceRowQuantity, o.InvoiceRowProduct.ProductDescription,
                        o.InvoiceRowProduct.ProductPrice, o.InvoiceRowPrice,Euro) );
            tot += o.InvoiceRowPrice;
        }
        lpt.NewLines(2);
        //Grand Total
        lpt.Append("================================");
        lpt.DoubleWidth2();
        lpt.Append(string.Format("TOTALE: {0,5:F2} {1}", tot, Euro));
        lpt.NormalWidth();
        lpt.Append("================================");

        if (File.Exists(cfg.TailFile)) {
            string tail = File.ReadAllText(cfg.TailFile);
            lpt.Append(tail);
        }else {
            Console.WriteLine("Not found {0}",cfg.TailFile);
        }
        lpt.NewLines(2);

        lpt.FullPaperCut();
        lpt.PrintDocument();

    }
    //*/
    public string PrintSvg(IEnumerable<InvoiceRow> Order) {
        // Crea il contenuto SVG
        var svgContent = new System.Text.StringBuilder();
        //svgContent.AppendLine("<svg width='58mm' height='800' xmlns='http://www.w3.org/2000/svg'>");
        svgContent.AppendLine("<rect width='100%' height='100%' fill='white'/>");
        const int xPos=0;
        float yPos = 20;

        // Logo (se presente)
        if (File.Exists(cfg.LogoFile))
        {
            var logoData = Convert.ToBase64String(File.ReadAllBytes(cfg.LogoFile));
            svgContent.AppendLine($"<image href='data:image/png;base64,{logoData}' x='{xPos}' y='{yPos}' width='100' height='100'/>");
            //svgContent.AppendLine($"<image href='/images/{cfg.LogoFile})' x='10' y='20' width='100' height='100'/>");
            yPos += 110;
        }

        // Intestazione
        if (File.Exists(cfg.HeaderFile))
        {
            string head = File.ReadAllText(cfg.HeaderFile);
            svgContent.AppendLine($"<text x='{xPos}' y='{yPos}' font-size='12' fill='black'>{head}</text>");
            yPos += 30;
        }

        // Righe ordine
        foreach (var o in Order)
        {
            string line = $"{o.InvoiceRowQuantity:D02}x {o.InvoiceRowProduct.ProductDescription}";
            //  {o.InvoiceRowPrice:C2}";
            svgContent.AppendLine($"<text x='{xPos}' y='{yPos}' font-size='12' fill='black'>{line}</text>");
            line= $"{o.InvoiceRowPrice:C2}";
            svgContent.AppendLine($"<text x='110' y='{yPos}' font-size='12' fill='black'>{line}</text>");
            yPos += 20;
        }

        // Totale
        double tot =  Order.Sum(o => o.InvoiceRowPrice);
        yPos += 10;
        svgContent.AppendLine($"<line x1='{xPos}' y1='{yPos}' x2='150' y2='{yPos}' stroke='black'/>");
        yPos += 20;

        // Totale in grassetto e più grande
        svgContent.AppendLine($"<text x='{xPos}' y='{yPos}' font-size='16' fill='black'>TOTALE:</text>");
        svgContent.AppendLine($"<text x='100' y='{yPos}' font-size='16' fill='black'>{tot:C2}</text>");

        // Piè di pagina
        if (File.Exists(cfg.TailFile))
        {
            yPos += 30;
            string tail = File.ReadAllText(cfg.TailFile);
            svgContent.AppendLine($"<text x='{xPos}' y='{yPos}' font-size='12' fill='black'>{tail}</text>");
        }

        return $"<svg width='58mm' height='{yPos+40}' xmlns='http://www.w3.org/2000/svg' id='printableSvg'>{svgContent.ToString()}</svg>";
    }

}
