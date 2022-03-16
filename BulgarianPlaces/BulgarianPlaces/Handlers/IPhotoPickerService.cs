using System.IO;
using System.Threading.Tasks;

namespace BulgarianPlaces.Handlers
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
