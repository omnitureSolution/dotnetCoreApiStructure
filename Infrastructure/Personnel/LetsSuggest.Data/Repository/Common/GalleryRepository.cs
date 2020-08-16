using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using LetsSuggest.Context;
using LetsSuggest.Personnel.Core;
using LetsSuggest.Personnel.Core.Interfaces;
using LetsSuggest.Personnel.Core.Model.Common;
using LetsSuggest.Personnel.Data.Context;
using LetsSuggest.Shared.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace LetsSuggest.Personnel.Data.Repository.Common
{
    public class GalleryRepository : GenericRepository<ILetsSuggestContext, Gallery>, IGalleryInterface
    {
        public GalleryRepository(IUnitOfWork<ILetsSuggestContext> uow) : base(uow)
        {
        }

        readonly LetsSuggestContext _context;
        readonly IOptions<ImagePath> _imagePath;
        public GalleryRepository(IUnitOfWork<ILetsSuggestContext> uow,
             IOptions<ImagePath> imagePath) : base(uow)
        {
            _context = uow.Context as LetsSuggestContext;
            _imagePath = imagePath;
        }
      

        public List<Gallery> GallerySave(List<IFormFile> files)
        {
            var fileSetting = _imagePath.Value;
            List<Gallery> objlist = new List<Gallery>();
            foreach (var item in files)
            {
                string fileName = Path.GetFileName(item.FileName);
                byte[] fileBytes = null;
                using (var ms = new MemoryStream())
                {
                    
                    item.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                Gallery objGallery = new Gallery();
                objGallery.GalleryId = Guid.NewGuid();
                objGallery.OriginalName = fileName;
                objGallery.FileExtension = Path.GetExtension(fileName);
                fileName = objGallery.GalleryId.ToString()  + Path.GetExtension(fileName);
                var imagePath = Path.Combine(fileSetting.ImageDir, fileSetting.OriginalDir, fileName);
                File.WriteAllBytes(imagePath, fileBytes);

                fileBytes = CreateThumbByte(fileBytes);
                var thumbPath = Path.Combine(fileSetting.ImageDir, fileSetting.ThumbnailDir, fileName);
                File.WriteAllBytes(thumbPath, fileBytes);

       
                this.Add(objGallery);
                objlist.Add(objGallery);

            }

            return objlist;

      
        }

       
        public List<Gallery> GetGallery(List<Guid> galleryId)
        {
            return _context.Gallery.Where(x => x.DeletedDate == null
           && galleryId.Contains(x.GalleryId)).ToList();
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
