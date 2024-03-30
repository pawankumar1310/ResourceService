using DTO.ResourceService;
using Model.ResourceService;
using DBService;
using Package;

namespace Service
{
    public class ImageFileService
    {
        public StatusResponse<ImageFileResponse> GetImage(GetImageRequest getImageRequest)
        {
            var getImageModelRequest=new GetImageModelRequest { UserID=getImageRequest.UserID };
            try
            {
                ImageFileDBService imageFileDBService=new();
                var result=imageFileDBService.GetImage(getImageModelRequest).Result;
                if (result.Success)
                {
                    ImageFileResponse imageFileResponse = new();
                    imageFileResponse.ImageContent = result.Data.ImageContent;


                    return StatusResponse<ImageFileResponse>.SuccessStatus(imageFileResponse, StatusCode.Found);
                }
                else
                {
                    return StatusResponse<ImageFileResponse>.FailureStatus(result.StatusCode, new Exception());
                }

            }
            catch (Exception ex)
            {
                return StatusResponse<ImageFileResponse>.FailureStatus(StatusCode.knownException, ex);
            }
            
        }
        public StatusResponse<int> UploadImage(UserImageRequest userImageRequest)
        {
            var userImageModelRequest=new UserImageModelRequest { Content = userImageRequest.Content,UserReferenceId=userImageRequest.UserReferenceId,Name=userImageRequest.Name,Label=userImageRequest.Label };
            try
            {
                ImageFileDBService imageFileDBService = new();
                var result = imageFileDBService.UploadImage(userImageModelRequest).Result;
                if (result.Success) 
                {
                    return StatusResponse<int>.SuccessStatus(result.Data, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<int>.FailureStatus(result.StatusCode, new Exception());
                }
            }
            catch (Exception ex)
            {
                return StatusResponse<int>.FailureStatus(StatusCode.knownException,ex);
            }
        }
        public StatusResponse<int> UpdateImage(UpdateImageRequest userImageRequest)
        {
            var UpdateImageModel = new UpdateImageModelRequest { Content = userImageRequest.Content, UserReferenceId = userImageRequest.UserReferenceId };
            try
            {
                ImageFileDBService imageFileDBService = new();
                var result = imageFileDBService.UpdateImage(UpdateImageModel).Result;
                if (result.Success)
                {
                    return StatusResponse<int>.SuccessStatus(result.Data, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<int>.FailureStatus(result.StatusCode, new Exception());
                }
            }
            catch (Exception ex)
            {
                return StatusResponse<int>.FailureStatus(StatusCode.knownException, ex);
            }
        }

        

    }
}
