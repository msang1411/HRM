using HRM.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Services
{
    public class ExcelService
    {
        readonly IDbContextFactory<HRMContext> _dbContextFactory;

        public ExcelService(IDbContextFactory<HRMContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public MemoryStream CreateExcelSalary()
        {
            //Create an instance of ExcelEngine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Create a workbook.
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Initialize DataTable and data get from SampleDataTable method.
                SalaryService salaryService = new SalaryService(_dbContextFactory);
                EmployeeService employeeService = new EmployeeService(_dbContextFactory);
                PositionService positionService = new PositionService(_dbContextFactory);
                DataTable table = new DataTable();
                table.Columns.Add("Họ tên");
                table.Columns.Add("Chức vụ");
                table.Columns.Add("Lương");
                table.Columns.Add("Tình trạng");
                foreach (Salary salary in salaryService.GetListSalaryCurrent())
                {
                    table.Rows.Add(employeeService.GetEmployee(int.Parse(salary.SalaryId.Split("-")[0])).Name,
                        positionService.GetPosition((int)employeeService.GetEmployee(int.Parse(salary.SalaryId.Split("-")[0])).PositionId).Name,
                        salary.TotalSalary,
                        (bool)salary.IsPaid ? "Đã thanh toán" : "Chưa thanh toán");
                }

                //Export data from DataTable to Excel worksheet.
                worksheet.ImportDataTable(table, true, 1, 1);

                worksheet.UsedRange.AutofitColumns();

                //Save the document as a stream and return the stream.
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
            return null;
        }
    }
}
