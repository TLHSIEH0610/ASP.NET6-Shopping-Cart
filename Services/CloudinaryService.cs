using System;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using RamenKing.Interfaces;
using Microsoft.Extensions.Options;
using RamenKing.Helpers;

namespace RamenKing.Services
{
	public class CloudinaryService: ICloudinaryService
	{
        private readonly Cloudinary _cloudinary;    

		public CloudinaryService(IOptions<CloudinarySettings> config)
		{
            var account = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
           );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile photo)
        {
            var result = new ImageUploadResult();
            if(photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")

                };
                result = await _cloudinary.UploadAsync(uploadParams);
            }

            return result;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string url)
        {
            var urlId = url.Split("/").Last().Split(".")[0];
            var deleteParams = new DeletionParams(urlId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}

