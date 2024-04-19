using System;
using System.IO;
using OfficeOpenXml;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string excelFilePath = "your_excel_file.xlsx";
        string jsonFilePath = "output.json";

        // Read data from Excel
        var data = ReadFromExcel(excelFilePath);

        // Write data to JSON
        WriteToJson(data, jsonFilePath);

        Console.WriteLine("Data has been written to JSON successfully.");
    }

    static List<Person> ReadFromExcel(string filePath)
    {
        List<Person> people = new List<Person>();

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++) // Assuming first row is header
            {
                string name = worksheet.Cells[row, 1].Value?.ToString();
                string family = worksheet.Cells[row, 2].Value?.ToString();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(family))
                {
                    people.Add(new Person { Name = name, Family = family });
                }
            }
        }

        return people;
    }

    static void WriteToJson(List<Person> data, string filePath)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}

class Person
{
    public string Name { get; set; }
    public string Family { get; set; }
}
