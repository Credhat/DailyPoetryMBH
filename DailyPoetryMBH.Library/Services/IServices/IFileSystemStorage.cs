namespace DailyPoetryMBH.Library.Services.IServices;

/// <summary>
/// 抽象 Microsoft.Maui.Storage.FileSystem
/// </summary>
public interface IFileSystemStorage
{
    //
    // 摘要:
    //     Gets the location where temporary data can be stored.
    //
    // 言论：
    //     This location usually is not visible to the user, is not backed up, and may be
    //     cleared by the operating system at any time.
    string CacheDirectory { get; }
    //
    // 摘要:
    //     Gets the location where app data can be stored.
    //
    // 言论：
    //     This location usually is not visible to the user, and is backed up.
    string AppDataDirectory { get; }

    //
    // 摘要:
    //     Determines whether or not a file exists in the app package.
    //
    // 参数:
    //   filename:
    //     The name of the file (excluding the path) to load from the app package.
    //
    // 返回结果:
    //     true when the specified file exists in the app package, otherwise false.
    Task<bool> AppPackageFileExistsAsync(string filename);
    //
    // 摘要:
    //     Opens a stream to a file contained within the app package.
    //
    // 参数:
    //   filename:
    //     The name of the file (excluding the path) to load from the app package.
    //
    // 返回结果:
    //     A System.IO.Stream containing the (read-only) file data.
    Task<Stream> OpenAppPackageFileAsync(string filename);
}
