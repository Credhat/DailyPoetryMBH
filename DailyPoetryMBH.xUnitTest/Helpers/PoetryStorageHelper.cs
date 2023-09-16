using DailyPoetryMBH.Library.Services;

namespace DailyPoetryMBH.xUnitTest.Helpers;

public class PoetryStorageHelper
{
    public static void RemovePoetryDBFile( ) => File.Delete(PoetryStorage.PoertyDBSqlite3Path_Old);
}
