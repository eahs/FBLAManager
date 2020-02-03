using System.IO;
using System.Threading.Tasks;

namespace FBLAManager.Services
{
    interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
