using DailyPoetryMBH.Library.Services.IServices;

namespace DailyPoetryMBH.Services;

internal class FileSystemStorage : IFileSystemStorage
{
    public string CacheDirectory => FileSystem.CacheDirectory;

    public string AppDataDirectory => FileSystem.AppDataDirectory;

    public async Task<bool> AppPackageFileExistsAsync(string filename)
    {
        return await FileSystem.AppPackageFileExistsAsync(filename);
    }

    public async Task<Stream> OpenAppPackageFileAsync(string filename)
    {
        return await FileSystem.OpenAppPackageFileAsync(filename);
    }
}
