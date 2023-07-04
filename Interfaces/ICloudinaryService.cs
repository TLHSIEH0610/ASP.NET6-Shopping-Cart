using CloudinaryDotNet.Actions;


namespace RamenKing.Interfaces
{
	public interface ICloudinaryService
	{
		Task<ImageUploadResult> AddPhotoAsync(IFormFile photo);
		Task<DeletionResult> DeletePhotoAsync(string url);
	}
}

