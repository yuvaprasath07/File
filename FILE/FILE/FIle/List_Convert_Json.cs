using FILE.PepoleModel;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using iTextSharp.text;

namespace FILE.FIle
{
    public class List_Convert_Json
    {
        public void getPeople()
        {
            List<Pepole> Person = new List<Pepole>
            {
                new Pepole { Name = "Alice", Age = 30 },
                new Pepole { Name = "Bob", Age = 25 },
                new Pepole { Name = "Charlie", Age = 40 }
            };

            string json = JsonConvert.SerializeObject(Person, Formatting.Indented);

            string jsonFilePath = "D:\\Csharpwork\\CSharpTask\\people.json";
            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine("JSON data saved to: " + jsonFilePath);

            string pdfFilePath = "D:\\Csharpwork\\CSharpTask\\people.pdf";

            Document document = new Document();

            try
            {
                PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));

                document.Open();

                Paragraph jsonParagraph = new Paragraph(json);
                document.Add(jsonParagraph);

            }
            catch (DocumentException de)
            {
                Console.WriteLine("Error creating PDF: " + de.Message);
            }
            finally
            {
                document.Close();
            }

            Console.WriteLine("PDF created and JSON content added.");
        }
    }
}
