using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPhoneDal efPhoneDal = new EfPhoneDal();
            IPhoneService phoneService = new PhoneManager(efPhoneDal);
            List<Phone> phoneList = phoneService.GetAll().Data;

            CreatePdfForPhones(phoneList);
        }

        private static void CreatePdfForPhones(List<Phone> phones)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Phone List")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Item().Text("List of Phones:");
                            int index = 1;
                            foreach (var phone in phones)
                            {
                                column.Item().Text($"{index}. Phone:");
                                column.Item().Text($"   Brand: {phone.Brand}");
                                column.Item().Text($"   Model: {phone.Model}");
                                column.Item().Text($"   Release Date: {phone.ReleaseDate.ToShortDateString()}");
                                column.Item().Text($"   Price: ${phone.Price}");
                                column.Item().PaddingBottom(10);
                                index++;
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "PhoneList.pdf");
            document.GeneratePdf(filePath);
            Console.WriteLine($"PDF document created at: {filePath}");
        }
    }
}
