using Example.Ecommerce.Application.DTO.Request;
using Example.Ecommerce.Application.DTO.Response;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Transversal.Common.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpreadsheetLight;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using DocumentFormat.OpenXml.Office2010.Excel;
using SharpCompress.Common;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApplication _categoryApplication;
        private readonly IHostEnvironment _env;

        public CategoryController(ICategoryApplication categoryApplication, IHostEnvironment env) =>
            (_categoryApplication, _env) = (categoryApplication, env);

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Create a new category",
            Description = "Insert a new category", Tags = new[] { "Category" }, OperationId = "CreateCategory")]
        [SwaggerResponse(StatusCodes.Status201Created, "Successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [ProducesResponseType(500)]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryRequestCreateDto category)
        {
            Response<int?> response = await _categoryApplication.Create(category);

            return response.IsSuccess ?
                StatusCode(StatusCodes.Status201Created, response) : StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpPatch]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Update fields a category",
            Description = "Edit fields a category", Tags = new[] { "Category" }, OperationId = "PatchUpdateCategory")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [ProducesResponseType(500)]
        [Route("{categoryId:int:min(1)}/PatchUpdate", Name = "PatchUpdate")]
        public async Task<IActionResult> PatchUpdate(int categoryId, [FromBody] CategoryRequestUpdateDto category)
        {
            Response<bool> response = await _categoryApplication.Patch(categoryId, category);

            return response.IsSuccess ?
                StatusCode(StatusCodes.Status204NoContent) : StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Get a category",
            Description = "Get a category by id", Tags = new[] { "Category" }, OperationId = "GetCategoryById")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [ProducesResponseType(500)]
        [Route("{categoryId:int:min(1)}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            Response<CategoryResponseDto?> response = await _categoryApplication.GetById(categoryId);

            return response.IsSuccess ?
                StatusCode(StatusCodes.Status200OK, response) : StatusCode(StatusCodes.Status400BadRequest, response);
        }

        [HttpPost]
        [Route("CreateFileMultipartData/{categoryId:int:min(1)}", Name = "CreateFile")]
        [AllowAnonymous]
        //[DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateFileMultipartData(
            int categoryId, [FromForm] CategoryRequestCreateFileUpload categoryRequestCreateFileUpload)
        {
            IFormFile? image = categoryRequestCreateFileUpload.Cedula!;
            IEnumerable<IFormFile?> image2 = categoryRequestCreateFileUpload.Cartas!;

            if (image is null) return BadRequest();

            string fileName = Path.GetFileName(image.FileName);
            string uniqueFileName = Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + categoryId
                + "_"
                + Guid.NewGuid().ToString()[..4]
                + Path.GetExtension(fileName);

            string dir = Path.Combine(_env.ContentRootPath, "Images");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string filePath = Path.Combine(dir, uniqueFileName);
            await image.CopyToAsync(new FileStream(filePath, FileMode.Create));

            return Ok(uniqueFileName);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "GenerateExcelDataTable",
            Description = "GenerateExcelDataTable", Tags = new[] { "GenerateExcelDataTable" }, OperationId = "GenerateExcelDataTable")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [ProducesResponseType(500)]
        [Route("GenerateExcelDataTable", Name = "GenerateExcelDataTable")]
        public async Task<IActionResult> GenerateExcelDataTable()
        {
            SLStyle style = new();
            style.Font.FontSize = 12;
            style.Font.Bold = true;
            style.Font.FontColor = System.Drawing.Color.Green;
            style.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
            style.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, System.Drawing.Color.Green);

            SLDocument sLDocument = new();
            sLDocument.SetCellStyle(1, 1, style);
            sLDocument.AutoFitColumn(2);

            DataTable dt = new();

            #region Encabezados

            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Edad", typeof(string));
            dt.Columns.Add("Sexo", typeof(string));

            #endregion

            #region Contenido

            dt.Rows.Add("Pepe", 19, "M");
            dt.Rows.Add("Ana", 20, "F");
            dt.Rows.Add("Perla", 30, "F");

            #endregion

            sLDocument.ImportDataTable(1, 1, dt, true);
            sLDocument.SaveAs(Path.Combine(_env.ContentRootPath, "Excel/") + "MiExcel.xlsx");

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "GenerateExcelNative",
            Description = "GenerateExcelNative", Tags = new[] { "GenerateExcelNative" }, OperationId = "GenerateExcelNative")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [ProducesResponseType(500)]
        [Route("GenerateExcelNative", Name = "GenerateExcelNative")]
        public async Task<IActionResult> GenerateExcelNative()
        {
            using (SLDocument sld = new())
            {
                #region Encabezados

                sld.SetCellValue(1, 1, "Materia");
                sld.SetCellValue(1, 2, "Nota");

                #endregion

                #region Contenido

                sld.SetCellValue(2, 1, "Español");
                sld.SetCellValue(2, 2, 2.5F);

                sld.SetCellValue(3, 1, "Ciencias");
                sld.SetCellValue(3, 2, 2.5F);

                sld.SetCellValue(4, 2, "=sum(B2:B3)");

                #endregion

                sld.SaveAs(Path.Combine(_env.ContentRootPath, "Excel/") + "MiExcel.xlsx");
            }

            return StatusCode(StatusCodes.Status200OK, "Archivo generado.");
        }

        [HttpGet]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "EditarArchivoAlmacenado",
            Description = "EditarArchivoAlmacenado", Tags = new[] { "EditarArchivoAlmacenado" }, OperationId = "EditarArchivoAlmacenado")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [ProducesResponseType(500)]
        [Route("EditarArchivoAlmacenado", Name = "EditarArchivoAlmacenado")]
        public async Task<IActionResult> EditarArchivoAlmacenado()
        {
            string FilePath = Path.Combine(_env.ContentRootPath, "Excel/") + "MiExcel.xlsx";

            using (SLDocument sl = new())
            {
                FileStream fs = new(FilePath, FileMode.Open);
                SLDocument sheet = new(fs, "Sheet1");

                string value = sheet.GetCellValueAsString(4, 2);
                sl.SetCellValue("A4", value);

                fs.Close();
                sl.SaveAs(FilePath);
            }

            return StatusCode(StatusCodes.Status200OK, "Archivo Editado.");
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "DownloadExcel",
            Description = "DownloadExcel", Tags = new[] { "DownloadExcel" }, OperationId = "DownloadExcel")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successful")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "BadRequest")]
        [ProducesResponseType(500)]
        [Produces("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [AllowAnonymous]
        [Route("DownloadExcel", Name = "DownloadExcel")]
        public async Task<IActionResult> DownloadExcel()
        {
            MemoryStream ms = new();
            using (SLDocument sl = new())
            {
                sl.SetCellValue("B3", "I love ASP.NET MVC");
                sl.SaveAs(ms);
            }
            // this is important. Otherwise you get an empty file
            // (because you'd be at EOF after the stream is written to, I think...).
            ms.Position = 0;

            return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
        }
    }
}