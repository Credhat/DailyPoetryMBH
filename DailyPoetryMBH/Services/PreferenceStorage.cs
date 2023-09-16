using DailyPoetryMBH.Library.Services.IServices;

namespace DailyPoetryMBH.Services;

internal class PreferenceStorage : IPreferenceStorage
{
    public int Get(string key , int defaultValue , string sharedName = null)
    => Preferences.Get(key , defaultValue , sharedName);

    public void Set(string key , int value , string sharedName = null)
    => Preferences.Set(key , value , sharedName);
}
