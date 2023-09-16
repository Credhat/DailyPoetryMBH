namespace DailyPoetryMBH.Library.Services.IServices;

/// <summary>
/// 为了解决 该类库不是 MAUI 项目,从而缺失 MAUI.Preference 能力的问题<br/><br/>
/// <see cref="Microsoft.Maui.Storage.Preferences"/>（偏好设置）接口用于在键值存储中存储应用程序的首选项。偏好设置是应用程序的配置选项，允许用户自定义应用程序的行为和外观。 <br/>
/// 通过使用偏好设置，应用程序可以提供一种持久化存储用户首选项的机制。<br/>
/// </summary>
public interface IPreferenceStorage
{
    void Set(string key , int value , string? sharedName = null);
    int Get(string key , int defaultValue , string? sharedName = null);
}
