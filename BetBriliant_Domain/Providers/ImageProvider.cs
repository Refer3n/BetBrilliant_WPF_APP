using System.IO;
using System.Reflection;

namespace BetBriliant_Domain.Providers
{
    public static class ImageProvider
    {
        public static string? GetImageByGroup(string? group)
        {
            if (string.IsNullOrWhiteSpace(group))
                return null;

            string normalizedGroup = group.Replace(" ", "");
            string imageName = $"{normalizedGroup}Icon.png";

            string appDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string imagePath = Path.Combine(appDirectory, "Images", imageName);

            if (File.Exists(imagePath))
            {
                return imagePath;
            }

            return null;
        }
    }
}
