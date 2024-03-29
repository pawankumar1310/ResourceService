using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace ResourceService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateImageController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public UpdateImageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPut("{userReferenceId}")]
        public IActionResult UpdateImageContent(string userReferenceId, [FromBody] UpdateImage newImageModel)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SaUserDB")))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateImageContent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@USR_referenceID", userReferenceId);
                    command.Parameters.AddWithValue("@newContent", newImageModel.Content);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        return Ok("Image content updated successfully");
                    }
                    else
                    {
                        return NotFound("Image not found or content not updated");
                    }
                }
            }
        }
    }
}
