namespace DailyPoetryMBH.Library.Services.IServices;

/// <summary>
/// Poetry 数据库操作
/// </summary>
public interface IPoetryStorage
{
    bool IsInitialized { get; }
    Task InitializedAsync( );
}