using NewFolder;

namespace Structure
{
    public interface IFileStorage
    {
     public  Task<int> SaveFilePathToDatabase(ImageModel image);
    
    }
}
