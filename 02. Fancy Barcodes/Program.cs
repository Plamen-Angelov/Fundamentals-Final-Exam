using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string barcode = Console.ReadLine();

                Regex barcodeRegex = new Regex(@"^(@#+)([A-Z][A-Za-z0-9]{4,}[A-Z])(@#+)$");
                Match validBarcode = barcodeRegex.Match(barcode);

                if (!validBarcode.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                string productGroup = string.Empty;

                foreach (char item in validBarcode.Groups[2].Value)
                {
                    if (char.IsDigit(item))
                    {
                        productGroup += item;
                    }
                }

                if (productGroup == string.Empty)
                {
                    productGroup = "00";
                }

                Console.WriteLine($"Product group: {productGroup}");
            }
        }
    }
}
