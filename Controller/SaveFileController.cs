
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Service;
//using System.Data.SqlClient;
//using Structure;
//using Microsoft.AspNetCore.StaticFiles;
//using NewFolder;
//using System.Data;

//namespace Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SaveFileController : ControllerBase
//    {
//        private readonly SaveFileService _saveFileService;

//        public SaveFileController(SaveFileService saveFileService)
//        {
//            _saveFileService = saveFileService;
//        }

//        [HttpPost]
//        public async Task<IActionResult> InsertImage([FromBody] ImageModel image)
//        {
//            try
//            {
//                int result = await _saveFileService.SaveFilePathService(image);
//                if (result > 0)
//                {
//                    return Ok("Image saved  successfully");
//                }
//                else
//                {
//                    return BadRequest("image not saved");
//                }

//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }
//        [HttpGet("getByReferenceID/{USR__referenceID}")]
//        public async Task<IActionResult> GetImageByReferenceID(string USR__referenceID)
//        {
//            try
//            {
//                byte[] imageData;

//                using (SqlConnection connection = new SqlConnection("Server=192.168.0.200\\MSSQLSERVERENT;Database=UserDB;User Id=sa;Password=tagme!23;"))
//                {
//                    await connection.OpenAsync();

//                    using (SqlCommand command = new SqlCommand("SP_GetImageByReferenceID", connection))
//                    {
//                        command.CommandType = CommandType.StoredProcedure;
//                        command.Parameters.AddWithValue("@USR__referenceID", USR__referenceID);

//                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
//                        {
//                            if (reader.Read())
//                            {
//                                imageData = (byte[])reader["content"];
//                            }
//                            else
//                            {
//                                return NotFound("Image not found");
//                            }
//                        }
//                    }
//                }

//                return File(imageData, "image/jpeg"); // Assuming the image format is JPEG
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }
//    }
//}

//        //private readonly SaveFileService _saveFileService;
//        //private readonly string _uploadFolderPath;
//        //private readonly string _dbConnectionString;

//        //public SaveFileController(IFileStorage saveFile,IConfiguration configuration)
//        //{
//        //    _uploadFolderPath = configuration["UploadFolderPath"];
//        //    _dbConnectionString = configuration.GetConnectionString("DefaultConnection");
//        //    _saveFileService = new SaveFileService(saveFile);
//        //}
//        //[HttpPost("upload")]
//        //public async Task <IActionResult> UploadFile(IFormFile file)
//        //{
//        //    // Validate file
//        //    if (file == null || file.Length == 0)
//        //    {
//        //        return BadRequest("Invalid file");
//        //    }

//        //    // Generate a unique filename
//        //    var fileName = Path.GetFileName(file.FileName);
//        //    var filePath = Path.Combine(_uploadFolderPath, fileName);

//        //    // Save file locally
//        //    using (var stream = new FileStream(filePath, FileMode.Create))
//        //    {
//        //        file.CopyTo(stream);
//        //    }

//        //    // Save file path to the database
//        //    _saveFileService.SaveFilePathService(filePath);

//        //    return Ok(new { filePath });
//        //}

//        //[HttpGet("download/{fileName}")]
//        //public async Task<IActionResult> DownloadFile(string fileName)
//        //{
//        //    var filePath = Path.Combine(_uploadFolderPath, fileName);

//        //    if (!System.IO.File.Exists(filePath))
//        //    {
//        //        return NotFound(); // File not found
//        //    }

//        //    var memory = new MemoryStream();
//        //    using (var stream = new FileStream(filePath, FileMode.Open))
//        //    {
//        //        await stream.CopyToAsync(memory);
//        //    }

//        //    memory.Position = 0;

//        //    return File(memory, GetContentType(filePath), Path.GetFileName(filePath));
//        //}

//        //private string GetContentType(string path)
//        //{
//        //    var provider = new FileExtensionContentTypeProvider();
//        //    if (!provider.TryGetContentType(path, out var contentType))
//        //    {
//        //        contentType = "application/octet-stream";
//        //    }
//        //    return contentType;
//        //}



////    }
////}
