using System.IO;
using System.Threading.Tasks;
using Firebase.Storage;

namespace TheLight
{

    public class FirebaseStorageHelper
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("gs://the-light-7f317.appspot.com/");

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }

        public async Task<string> GetFile(string fileName)
        {
            return await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }
        public async Task DeleteFile(string fileName)
        {
            await firebaseStorage
                 .Child("XamarinMonkeys")
                 .Child(fileName)
                 .DeleteAsync();

        }
    }
}