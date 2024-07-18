using CashFlow.Application.UseCases.Expenses.Report.Excel;
using CashFlow.Application.UseCases.Expenses.Report.Pdf;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
 public class ReportController : ControllerBase
 {
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateReportExcelJsonUseCase useCase,
        [FromHeader] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);

        if (file.Length > 0 )
            return File(file, MediaTypeNames.Application.Octet, "report.xlsx");

        return NoContent();
    }

    [HttpGet("pdf")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPdf(
        [FromServices] IGenerateReportPdfJsonUseCase useCase,
        [FromQuery] DateOnly month)
    {
        byte[] file = await useCase.Execute(month);

        if (file.Length > 0)
            return File(file, MediaTypeNames.Application.Pdf, "report.pdf");

        return NoContent();
    }

 }

