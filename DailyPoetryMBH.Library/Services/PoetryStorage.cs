using DailyPoetryMBH.Library.Services.IServices;

namespace DailyPoetryMBH.Library.Services;

public class PoetryStorage : IPoetryStorage
{
    private readonly IPreferenceStorage _preferenceStorage;
    private readonly IFileSystemStorage _fileSystemStorage;

    public const string DBName = "PoetryMBH.sqlite3";

    /// <summary>
    /// <see cref="DBName"/> 数据库保存位置
    /// </summary>
    public string PoertyDBSqlite3Path => Path.Combine(_fileSystemStorage.AppDataDirectory , DBName);
    public static string PoertyDBSqlite3Path_Old = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) , DBName);

    public PoetryStorage(IPreferenceStorage preferenceStorage , IFileSystemStorage fileSystemStorage)
    {
        _preferenceStorage = preferenceStorage;
        _fileSystemStorage = fileSystemStorage;
    }

    /// <summary>
    /// 是否成功初始化过了数据库
    /// </summary>
    public bool IsInitialized =>
        _preferenceStorage.Get(PoetryStorageConstant.DbVersionKey , 0)
        .Equals(PoetryStorageConstant.DbVersion);


    public async Task InitializedAsync( )
    {
        await using var dbFileStream = new FileStream(PoertyDBSqlite3Path_Old , FileMode.OpenOrCreate , FileAccess.ReadWrite);

        //利用 reflection 拿到自己 dll 文件, 然后从其中的 manifest 里取出 database copy 到用户目标位置
        await using var dbAssertStream = typeof(PoetryStorage).Assembly.GetManifestResourceStream(DBName);
        await dbAssertStream.CopyToAsync(dbFileStream);
        _preferenceStorage.Set(PoetryStorageConstant.DbVersionKey , PoetryStorageConstant.DbVersion);
    }
}


public static class PoetryStorageConstant
{
    /// <summary>
    /// Microsoft.Maui.Storage.Preferences API helps to store application preferences in a key/value store.<br/><br/>
    /// 使用 <see cref="IPreferenceStorage"/> 来抽象化 <see cref="Microsoft.Maui.Storage.Preferences"/><br/><br/>
    /// </summary>
    /// <returns>string: PoetryStorageConstant.DbVersionKey</returns>
    public const string DbVersionKey = nameof(PoetryStorageConstant) + "." + nameof(DbVersionKey);

    /// <summary>
    /// 预期的 Poetry Database version
    /// </summary>
    /// <returns>int: Database Version</returns>
    public const int DbVersion = 1;
}