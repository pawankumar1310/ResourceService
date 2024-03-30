using Middleware;
using Constants.StoredProcedure;
using System.Data.SqlClient;
using Model.ResourceService;
using Package;
using Model.SolutionService;

namespace DBService
{
    public class ImageFileDBService
    {
        public async Task<StatusResponse<ImageFileModelResponse>> GetImage(GetImageModelRequest getImageRequest)
        {
            try
            {
                CurdMiddleware curdMiddleware = new();
                var storedProcedure = ResourceDB.GetImage;
                var parameter = new SqlParameter[] { new SqlParameter("@USR_referenceID", getImageRequest.UserID) };
                string ConnectionString = Utility.ConfigurationUtility.GetConnectionString();
                var result = await curdMiddleware.ExecuteDataReaderSingle<ImageFileModelResponse>(ConnectionString, storedProcedure,
                    (reader) => new ImageFileModelResponse
                    {
                        ImageContent = reader["content"] != DBNull.Value
                        ? (byte[])reader["content"]
                        : new byte[0]
                    }, parameter);
                if (result != null)
                {
                    return StatusResponse<ImageFileModelResponse>.SuccessStatus(result, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<ImageFileModelResponse>.FailureStatus(StatusCode.NotFound, new Exception());
                }

            }
            catch (Exception ex)
            {
                return StatusResponse<ImageFileModelResponse>.FailureStatus(StatusCode.NotFound, ex);
            }
        }
        public async Task<StatusResponse<int>> UploadImage(UserImageModelRequest userImageRequest)
        {
            try
            {
                CurdMiddleware curdMiddleware = new();
                var storedProcedure = ResourceDB.UploadImage;
                string ConnectionString = Utility.ConfigurationUtility.GetConnectionString();
                var parameter = new SqlParameter[]
                   {
                        new SqlParameter("@label", userImageRequest.Label) ,
                        new SqlParameter("@name",userImageRequest.Name),
                        new SqlParameter("@content",userImageRequest.Content),
                        new SqlParameter("@USR_referenceID", userImageRequest.UserReferenceId)
                   };
                
                var result = await curdMiddleware.ExecuteNonQuery(ConnectionString, storedProcedure,parameter);
                if (result != null)
                {
                    return StatusResponse<int>.SuccessStatus(result, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<int>.FailureStatus(StatusCode.NotFound, new Exception());
                }
            }
            catch(Exception ex)
            {
                return StatusResponse<int>.FailureStatus(StatusCode.NotFound, ex);
            }
        }
        public async Task<StatusResponse<int>> UpdateImage(UpdateImageModelRequest updateImageModelRequest)
        {
            try
            {
                CurdMiddleware curdMiddleware = new();
                var storedProcedure = ResourceDB.UpdateImage;
                string ConnectionString = Utility.ConfigurationUtility.GetConnectionString();
                var parameter = new SqlParameter[] 
                { 
                    new SqlParameter("@USR_referenceID", updateImageModelRequest.UserReferenceId) ,
                    new SqlParameter("@newContent",updateImageModelRequest.Content)
                };
                var result = await curdMiddleware.ExecuteNonQuery(ConnectionString, storedProcedure,parameter);
                if (result != null)
                {
                    return StatusResponse<int>.SuccessStatus(result, StatusCode.Success);
                }
                else
                {
                    return StatusResponse<int>.FailureStatus(StatusCode.NotFound,new Exception());
                }
            }
            catch(Exception ex)
            {
                return StatusResponse<int>.FailureStatus(StatusCode.NotFound,ex);
            }
        }
    }
}

