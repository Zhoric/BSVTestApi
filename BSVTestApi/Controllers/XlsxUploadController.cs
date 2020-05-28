using System;
using System.Collections.Generic;
using BDVTest.BLL;
using BDVTest.BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace BSVTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XlsxUploadController : ControllerBase
    {
        private readonly IWorkSheetService _workSheetService;
        private const int ROW_COUNT = 1;

        public XlsxUploadController(IWorkSheetService workSheetService)
        {
            _workSheetService = workSheetService;
        }

        // POST api/xlsxUpload
        [HttpPost]
        public ActionResult UploadXlsxToDb(IFormFile objFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (objFile == null) return NotFound("XLSX object NotFound");

            if (objFile.Length > 0)
            {
                try
                {
                    using (ExcelPackage package = new ExcelPackage(objFile.OpenReadStream()))
                    {
                        var workSheets = new List<BaseWorkSheetDto>();

                        workSheets.AddRange(ReadExcelWorksheet(package.Workbook.Worksheets[0], ROW_COUNT, new WorkSheetOneDto()));
                        workSheets.AddRange(ReadExcelWorksheet(package.Workbook.Worksheets[1], ROW_COUNT, new WorkSheetTwoDto()));
                        
                        if( _workSheetService.CreateWorkSheets(workSheets))
                        {
                            return StatusCode(201, "WorkSheets saved successfully");
                        }
                        return StatusCode(500, "WorkSheets saving error");
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Internal API error");
                }
            }
            
            return StatusCode(500, "Internal API error");
        }
        
        private IList<BaseWorkSheetDto> ReadExcelWorksheet(ExcelWorksheet excelWorksheet, int rowCount, BaseWorkSheetDto baseWorkSheetDto)
        {
            var workSheets = new List<BaseWorkSheetDto>();
            for (int row = 2; row < 2 + rowCount; row++)
            {
                var workSheetOneDto = baseWorkSheetDto.CreateNewWorkSheetDto();
                for (int col = 1; col < 21; col++)
                {
                    workSheetOneDto["Col" + col] = excelWorksheet.Cells[row, col].Value;
                }
                workSheets.Add(workSheetOneDto);
            }

            return workSheets;
        }
    }
}