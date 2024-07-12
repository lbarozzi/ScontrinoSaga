namespace ScontrinoSaga;

public  record class SagaConfig {
    public string PrinterName { get; set; }
    public  string WorkingPath { get; set; }

    public string HeaderFile { get; set; }
    public string LogoFile { get; set; }
    public string TailFile { get; set; }
    public string TemplateFile { get; set; }
}