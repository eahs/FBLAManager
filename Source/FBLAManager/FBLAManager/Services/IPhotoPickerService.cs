using System.IO;
using System.Threading.Tasks;

namespace FBLAManager.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
