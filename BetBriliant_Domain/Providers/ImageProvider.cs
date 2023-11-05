using BetBriliant_Enum;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BetBriliant_Domain.Providers
{
    public static class ImageProvider
    {
        public static Image GetImageBySportType(SportType sportType)
        {
            string sportTypeString = sportType.ToString();
            string imageName = $"{sportTypeString}Icon.png";

            string appDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string imagePath = Path.Combine(appDirectory, "Images", imageName);

            if (File.Exists(imagePath))
            {
                Image image = new Image();
                var source = new BitmapImage(new Uri(imagePath));
                image.Source = source;
                return image;
            }

            return null;
        }

        public static async Task<ImageSource> GetImageByUrlAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            try
            {
                return new BitmapImage(new Uri(url, UriKind.Absolute));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static async Task<ImageSource> GetFlagByCodeAsync(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                string uri = $"https://flagsapi.com/{code}/flat/64.png";
                return await GetImageByUrlAsync(uri);
            }

            return null;
        }

    }
}
