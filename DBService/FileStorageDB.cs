//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Structure;
//using System.Data;
//using System.Data.SqlClient;
//using NewFolder;

//namespace DBService
//{
//    public class FileStorageDB : IFileStorage
//    {
//        private readonly string _connectionString;
//        public FileStorageDB(IConfiguration configuration)
//        {
//            this._connectionString = configuration.GetConnectionString("SaUserDB"); ;
//        }
//        public async Task<int> SaveFilePathToDatabase(ImageModel image)
//        {
//            using (SqlConnection connection = new SqlConnection(_connectionString))
//            {
//                await connection.OpenAsync();

//                using (SqlCommand command = new SqlCommand("SP_InsertImage", connection))
//                {
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.Parameters.AddWithValue("@label", image.Label);
//                    command.Parameters.AddWithValue("@name", image.Name);
//                    using (MemoryStream memoryStream = new MemoryStream())
//                    {
//                        await image.Content.CopyToAsync(memoryStream);
//                        command.Parameters.AddWithValue("@content", memoryStream.ToArray());
//                    }
//                    return await command.ExecuteNonQueryAsync();
//                }
//            }
//        }
//    }
//}
//    //public async Task<int> SaveFilePathToDatabase(string filePath)
//    //{
//    //    using (SqlConnection connection = new SqlConnection(_connectionString))
//    //    {
//    //        await connection.OpenAsync();

//    //        using (var command = new SqlCommand("spInsertInstituteResource", connection))
//    //        {
//    //            command.CommandType = CommandType.StoredProcedure;

//    //            command.Parameters.AddWithValue("@FilePath", filePath);
//    //            command.Parameters.AddWithValue("@IDocumentID", "B027BE1E-50F8-4ECD-90E8-36A2CF7ECF15");

//    //            return await command.ExecuteNonQueryAsync();
//    //        }
//    //    }
//    //}










