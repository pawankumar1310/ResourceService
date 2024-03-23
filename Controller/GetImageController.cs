using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace ResourceService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetImageController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public GetImageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{userReferenceId}")]
        public IActionResult GetImageContent(string userReferenceId)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SaUserDB")))
            {
                using (SqlCommand command = new SqlCommand("SP_GetImageContent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@USR_referenceID", userReferenceId);

                    connection.Open();
                    var content = (byte[])command.ExecuteScalar();
                    connection.Close();

                    if (content != null)
                    {
                        // Returning the image content as a file
                        return File(content, "image/jpeg"); // Adjust the content type based on your image type
                    }
                    else
                    {
                        return NotFound("Image not found");
                    }
                }
            }
        }
    }
}
