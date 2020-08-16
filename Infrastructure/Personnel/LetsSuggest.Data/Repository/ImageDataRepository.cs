using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

using Jainism.Context;
using Jainism.Core;
using Jainism.Core.Model;
using Jainism.Core.Interfaces;
using Jainism.Data.Context;
using Jainism.Shared.Helper;
using Microsoft.Extensions.Options;

namespace Jainism.Data.Repository
{
    public class ImageDataRepository : GenericRepository<IJainismContext, ImageData>, IImageDataInterface
    {
        readonly JainismContext _context;
        readonly IOptions<ImagePath> _imagePath;
        public ImageDataRepository(IUnitOfWork<IJainismContext> uow,
             IOptions<ImagePath> imagePath) : base(uow)
        {
            _context = uow.Context as JainismContext;
            _imagePath = imagePath;
        }
        public string SaveTempImage(byte[] fileByte, string fileName)
        {
            var fileSetting = _imagePath.Value;
            string name = Path.GetFileName(fileName);
            string newFileName = string.Format("{0}_{1}{2}", Path.GetFileNameWithoutExtension(name), Guid.NewGuid(), Path.GetExtension(name));
            var filePath = Path.Combine(fileSetting.ImageDir, fileSetting.TempDir, newFileName);
            File.WriteAllBytes(filePath, fileByte);
            return newFileName;
        }

        public ImageData SaveImage(ImageData imageData)
        {
            ImageData imageResult = null;
            if (imageData.ImageDataId > 0 && (imageData.IsNew || string.IsNullOrEmpty(imageData.FileName)))
            {
                imageResult = _context.ImageData.Find(imageData.ImageDataId);
                if (imageResult == null)
                    throw new NullReferenceException("No record found");
                this.Delete(imageResult.ImageDataId);
            }

            if (imageData.IsNew && !string.IsNullOrEmpty(imageData.FileName))
            {
                string imageName;
                var fileName = SaveImage(imageData.FileName, out imageName);
                imageResult = new ImageData
                {
                    OriginalName = imageName,
                    FileName = fileName,
                    SubjectKeyId = imageData.SubjectKeyId,
                    SubjectRecordId = imageData.SubjectRecordId
                };
                this.Add(imageResult);
                _context.SaveChanges();
                return imageResult;
            }
            return imageResult;
        }

        private string SaveImage(string fileName, out string imageName)
        {
            var fileSetting = _imagePath.Value;
            var fileExt = Path.GetExtension(fileName);
            var coreFile = Path.GetFileNameWithoutExtension(fileName);
            imageName = string.Format("{0}{1}", coreFile.Substring(0, coreFile.LastIndexOf("_")), fileExt);
            fileName = string.Format("{0}{1}", coreFile.Substring(coreFile.LastIndexOf("_") + 1), fileExt);
        
            var tempPath = Path.Combine(fileSetting.ImageDir, fileSetting.TempDir, string.Format("{0}{1}", coreFile, fileExt));
            var fileBytes = File.ReadAllBytes(tempPath);
            var imagePath = Path.Combine(fileSetting.ImageDir, fileSetting.OriginalDir, fileName);
            File.WriteAllBytes(imagePath, fileBytes);
            fileBytes = CreateThumbByte(fileBytes);
            var thumbPath = Path.Combine(fileSetting.ImageDir, fileSetting.ThumbnailDir, fileName);
            File.WriteAllBytes(thumbPath, fileBytes);           
            File.Delete(tempPath);
            return fileName;
        }
        public ImageData GetImage(int subjectKeyId, int subjectRecordId)
        {
            return _context.ImageData.FirstOrDefault(x => x.DeletedDate == null
           && x.SubjectKeyId == subjectKeyId && x.SubjectRecordId == subjectRecordId);
        }
        public List<ImageData> GetImages(int subjectKeyId, int subjectRecordId)
        {
            return _context.ImageData
               .Where(x => x.DeletedDate == null && x.SubjectKeyId == subjectKeyId && x.SubjectRecordId == subjectRecordId)
               .ToList();
        }

        #region Resize

        private byte[] CreateThumbByte(byte[] file)
        {
            try
            {
                Image frontImg = this.ByteArrayToImage(file);
                byte[] thumbImg = this.ImageToByteArray(frontImg.GetThumbnailImage(100, 125, null, IntPtr.Zero));
                return this.ImageToByteArray(NistCompliant(frontImg, new Size(480, 600)));
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms2 = new MemoryStream(byteArrayIn);
            ms2.Position = 0;
            Image returnImage = Image.FromStream(ms2);
            return returnImage;
        }
        private byte[] ImageToByteArray(Image imageIn)
        {
            byte[] imageArray;
            MemoryStream ms1 = new MemoryStream();
            ms1.Position = 0;
            imageIn.Save(ms1, ImageFormat.Jpeg);
            imageArray = ms1.ToArray();
            return imageArray;
        }
        private static Image NistCompliant(Image original, Size renderSize)
        {
            return NistCompliant(original, renderSize, InterpolationMode.HighQualityBilinear);
        }
        private static Image NistCompliant(Image original, Size renderSize, InterpolationMode mode)
        {
            if (original == null || renderSize.Width == 0 || renderSize.Height == 0 || renderSize.Width >= original.Width || renderSize.Height >= original.Height)
            {
                return original;
            }
            double num = original.Width / original.Height;
            int num2 = Math.Min(renderSize.Width, renderSize.Height);
            double num3;
            if (num >= 1.0)
            {
                num3 = original.Width / num2;
            }
            else
            {
                num3 = original.Height / num2;
            }
            if (1.0 / num3 < 0.01)
            {
                throw new DivideByZeroException("NistCompliant size must be at least 1% of the original");
            }
            var width = (int)((double)original.Width / num3);
            var height = (int)((double)original.Height / num3);
            var image = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = mode;
                graphics.DrawImage(original, new Rectangle(0, 0, image.Width, image.Height),
                    0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
            }
            return image;
        }

        #endregion
    }
}
