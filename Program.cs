using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var testImage = @"C:\ocr_teste.png";
            try
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImage))

                    {
                        using (var page = engine.Process(img))
                        {
                            var texto = page.GetText();
                            Console.WriteLine("Taxa de precisão: {0}", page.GetMeanConfidence());
                            Console.WriteLine("Texto : \r\n{0}", texto);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: {0}", ex.Message);
            }

            finally
            {
                Console.ReadLine();
            }
        }
    }
}
