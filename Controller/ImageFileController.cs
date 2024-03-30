using Microsoft.AspNetCore.Mvc;
using Service;
using DTO.ResourceService;

namespace ResourceService;
[Route("[controller]")]
[ApiController]
public class ImageFileController:ControllerBase
{
    [HttpPost("GetImage")]
    public IActionResult GetImage(GetImageRequest getImageRequest)
    {
        if (!string.IsNullOrEmpty(getImageRequest.UserID))
        {
            try
            {
                ImageFileService imageService = new();
                return Ok(imageService.GetImage(getImageRequest));
            }
            catch
            {
                return StatusCode(500);
            }
        }
        else
        {
            return BadRequest();
        }

    }
    [HttpPost("UploadImage")]
    public IActionResult UploadImage(UserImageRequest userImageRequest)
    {
        if (!string.IsNullOrEmpty(userImageRequest.UserReferenceId) || userImageRequest.Content != null || !string.IsNullOrEmpty(userImageRequest.Name) || !string.IsNullOrEmpty(userImageRequest.Label))
        {
            try
            {
                ImageFileService imageService = new();
                return Ok(imageService.UploadImage(userImageRequest));

            }
            catch 
            {
                return StatusCode(500);
            }
        }
        else
        {
            return BadRequest();
        }
    }
    [HttpPost("UpdateImage")]
    public IActionResult UpdateImage(UpdateImageRequest updateImageRequest)
    {
        if(!string.IsNullOrEmpty(updateImageRequest.UserReferenceId) || updateImageRequest.Content!=null)
        {
            try
            {
                ImageFileService imageService = new();
                return Ok(imageService.UpdateImage(updateImageRequest));
            }
            catch
            {
                return StatusCode(500);
            }
        }
        else
        {
            return BadRequest();
        }
    }
}
