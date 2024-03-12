using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using ExciteKit.DTO;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace ExciteKit.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    [HttpPost]
    [Route("ExportDataToCSV")]
    public async Task<IActionResult> ExportToCsv(
        [FromBody] List<DataEventVm> dataToExport
    )
    {
        if (!dataToExport.Any())
        {
            return NotFound();
        }

        using var memoryStream = new MemoryStream();
        await using var writer = new StreamWriter(memoryStream, Encoding.UTF8);
        await using var csvWriter = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
        csvWriter.WriteHeader<DataEventVm>();
        await csvWriter.NextRecordAsync();
        await csvWriter.WriteRecordsAsync(dataToExport);

        return File(memoryStream.ToArray(), "text/csv", "data.csv");
    }

    [HttpPost]
    [Route("ExportDataToExcel")]
    public async Task<IActionResult> ExportToExcel(
        [FromBody] List<DataEventVm> dataToExport
    )
    {
        if (!dataToExport.Any())
        {
            return NotFound();
        }

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Sheet1");
        worksheet.Cells.LoadFromCollection(dataToExport, true);
        
        var stream = new MemoryStream(await package.GetAsByteArrayAsync());
        
        return File(stream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "data.xlsx"
        );
    }
}