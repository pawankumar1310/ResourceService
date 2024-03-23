using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewFolder;
using System.Data;
using System.Data.SqlClient;


namespace ResourceService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public ImageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult PostImage([FromBody] ImageModel imageModel)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SaUserDB")))
            {
                using (SqlCommand command = new SqlCommand("SP_InsertImage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@label", imageModel.Label);
                    command.Parameters.AddWithValue("@name", imageModel.Name);
                    command.Parameters.AddWithValue("@content", imageModel.Content);
                    command.Parameters.AddWithValue("@USR_referenceID", imageModel.UserReferenceId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return Ok("Image inserted successfully");
        }
    }
}
