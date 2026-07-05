using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using StreamBoxMvc.Models;

namespace StreamBoxMvc.Controllers
{
    public class AdminReportController : Controller
    {
        private readonly HttpClient _client;

        public AdminReportController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            ViewBag.MovieCount = GetIntValue("MovieCount");
            ViewBag.CategoryCount = GetIntValue("CategoryCount");
            ViewBag.ActorCount = GetIntValue("ActorCount");
            ViewBag.MovieActorCount = GetIntValue("MovieActorCount");
            ViewBag.OldestMovie = GetObjectValue<ReportMovieDto>("OldestMovie");
            ViewBag.NewestMovie = GetObjectValue<ReportMovieDto>("NewestMovie");
            ViewBag.MovieCountByCategory = GetListValue<ReportCountDto>("MovieCountByCategory");
            ViewBag.ActorCountByCountry = GetListValue<ReportCountDto>("ActorCountByCountry");
            ViewBag.MovieCategoryList = GetListValue<ReportMovieDto>("MovieCategoryList");
            ViewBag.MovieActorList = GetListValue<ReportActorMovieDto>("MovieActorList");

            return View();
        }

        public IActionResult ExportExcel()
        {
            var movieCategoryList = GetListValue<ReportMovieDto>("MovieCategoryList");
            var movieActorList = GetListValue<ReportActorMovieDto>("MovieActorList");

            using var workbook = new XLWorkbook();

            var sheet1 = workbook.Worksheets.Add("Filmler");
            sheet1.Cell(1, 1).Value = "Film Adı";
            sheet1.Cell(1, 2).Value = "Yıl";
            sheet1.Cell(1, 3).Value = "Kategori";

            int row = 2;
            foreach (var item in movieCategoryList)
            {
                sheet1.Cell(row, 1).Value = item.Title;
                sheet1.Cell(row, 2).Value = item.ReleaseYear;
                sheet1.Cell(row, 3).Value = item.CategoryName;
                row++;
            }

            var sheet2 = workbook.Worksheets.Add("Film Oyunculari");
            sheet2.Cell(1, 1).Value = "Film Adı";
            sheet2.Cell(1, 2).Value = "Oyuncu Adı";

            row = 2;
            foreach (var item in movieActorList)
            {
                sheet2.Cell(row, 1).Value = item.MovieTitle;
                sheet2.Cell(row, 2).Value = item.ActorName;
                row++;
            }

            sheet1.Columns().AdjustToContents();
            sheet2.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return File(
                stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "StreamBox_Rapor.xlsx"
            );
        }

        public IActionResult ExportPdf()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var movieCount = GetIntValue("MovieCount");
            var categoryCount = GetIntValue("CategoryCount");
            var actorCount = GetIntValue("ActorCount");
            var movieActorCount = GetIntValue("MovieActorCount");
            var oldestMovie = GetObjectValue<ReportMovieDto>("OldestMovie");
            var newestMovie = GetObjectValue<ReportMovieDto>("NewestMovie");

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header().Text("StreamBox Raporu").FontSize(22).Bold();

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);
                        column.Item().Text($"Toplam Film: {movieCount}");
                        column.Item().Text($"Toplam Kategori: {categoryCount}");
                        column.Item().Text($"Toplam Oyuncu: {actorCount}");
                        column.Item().Text($"Film-Oyuncu Eşleşmesi: {movieActorCount}");
                        column.Item().Text("");
                        column.Item().Text($"En Eski Film: {oldestMovie?.Title} - {oldestMovie?.ReleaseYear} - {oldestMovie?.CategoryName}");
                        column.Item().Text($"En Yeni Film: {newestMovie?.Title} - {newestMovie?.ReleaseYear} - {newestMovie?.CategoryName}");
                    });

                    page.Footer().AlignCenter().Text("StreamBox Admin Panel");
                });
            }).GeneratePdf();

            return File(pdf, "application/pdf", "StreamBox_Rapor.pdf");
        }

        private int GetIntValue(string endpoint)
        {
            var response = _client.GetAsync($"https://localhost:7064/api/Reports/{endpoint}").Result;
            if (!response.IsSuccessStatusCode) return 0;

            var json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<int>(json);
        }

        private List<T> GetListValue<T>(string endpoint)
        {
            var response = _client.GetAsync($"https://localhost:7064/api/Reports/{endpoint}").Result;
            if (!response.IsSuccessStatusCode) return new List<T>();

            var json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        private T GetObjectValue<T>(string endpoint)
        {
            var response = _client.GetAsync($"https://localhost:7064/api/Reports/{endpoint}").Result;
            if (!response.IsSuccessStatusCode) return default;

            var json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}