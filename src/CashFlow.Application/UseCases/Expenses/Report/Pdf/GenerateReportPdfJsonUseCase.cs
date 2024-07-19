
using CashFlow.Application.UseCases.Expenses.Report.Pdf.Fonts;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Fonts;

namespace CashFlow.Application.UseCases.Expenses.Report.Pdf
{
    public class GenerateReportPdfJsonUseCase : IGenerateReportPdfJsonUseCase
    {
        private const string CURRENCY_SYMBOL = "R$";

        private readonly IExpensesReadOnlyRepository _repository;
        public GenerateReportPdfJsonUseCase(IExpensesReadOnlyRepository repository)
        {
            _repository = repository;

            GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
        }
        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _repository.FilterByMonth(month);
            if (expenses.Count == 0)
            {
                return [];
            }

            var document = CreateDocument(month);
            var page = CreatePage(document);

            var paragraph = page.AddParagraph();
            var title = string.Format(ResourceReportGenerationMessages.TOTAL_SPENT_IN, month.ToString("Y"));

            paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15});

            paragraph.AddLineBreak();

            var totalExpenses = expenses.Sum(expense => expense.Amount);
            paragraph.AddFormattedText($"{CURRENCY_SYMBOL} {totalExpenses}", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50});

            return [];
        }

        private Document CreateDocument(DateOnly month)
        {
            var document = new Document();

            document.Info.Title = $"{ResourceReportGenerationMessages.EXPENSES_FOR} {month:Y}";
            document.Info.Author = "Bruno Rezende";

            var style = document.Styles["Normal"];
            style!.Font.Name = FontHelper.RALEWAY_REGULAR;

            return document;
        }

        private Section CreatePage(Document document)
        {
            var section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();

            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.LeftMargin = 40;
            section.PageSetup.RightMargin = 40;
            section.PageSetup.TopMargin = 80;
            section.PageSetup.BottomMargin = 80;

            return section;
        }
    }
}
