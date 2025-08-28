namespace PustokProject.helpers
{
    public class FileHelper
    {
        public static string SaveFile(IFormFile file,string folderName)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/adminAssets/img", folderName, fileName);
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/adminAssets/img", folderName, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
