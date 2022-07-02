namespace API.Services;
public class ImageService : IImageService
{
    private readonly Cloudinary _cloudinary;
    public ImageService(IOptions<CloudinarySettings> config)
    {
        var account = new Account
        {
            ApiKey = config.Value.ApiKey,
            ApiSecret = config.Value.ApiSecret,
            Cloud = config.Value.CloudName
        };

        _cloudinary = new Cloudinary(account);
    }

    public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
    {
        var uploadResult = new ImageUploadResult();

        if (file.Length > 0)
        {
            using var steam = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, steam),
                Transformation = new Transformation().Height(500).Width(500).Crop("fill")
            };

            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }

        return uploadResult;
    }

    public async Task<DeletionResult> DeleteImageAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);

        var result = await _cloudinary.DestroyAsync(deleteParams);

        return result;
    }
}
