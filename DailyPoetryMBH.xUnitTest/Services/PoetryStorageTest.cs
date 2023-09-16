using DailyPoetryMBH.Library.Services;
using DailyPoetryMBH.Library.Services.IServices;
using DailyPoetryMBH.xUnitTest.Helpers;
using Moq;
using System.Diagnostics;

namespace DailyPoetryMBH.xUnitTest.Services;

public class PoetryStorageTest : IDisposable
{
    /// <summary>
    /// Method SetUp for xUnit
    /// </summary>
    public PoetryStorageTest( )
    {
        Debug.WriteLine("Test SetUp");
        PoetryStorageHelper.RemovePoetryDBFile();
    }

    /// <summary>
    /// Method TearDown for xUnit
    /// </summary>
    public void Dispose( )
    {
        Debug.WriteLine("Test TearDown");
        PoetryStorageHelper.RemovePoetryDBFile();
    }

    [Theory]
    [InlineData(PoetryStorageConstant.DbVersionKey , PoetryStorageConstant.DbVersion , true)]
    [InlineData(PoetryStorageConstant.DbVersionKey , 0 , false)]
    public void IsInitialized_IF_Initialized(string key_input , int value_got , bool expect_result)
    {
        // using mock to test.
        // Creat a target object mocker
        var preferenceStorageMockBuilder = new Mock<IPreferenceStorage>();
        var fileSystemStorageMockBuilder = new Mock<IFileSystemStorage>();

        // Setup the mocked Object's behavior

        //For FactAttribute
        //preferenceStorageMockBuilder.Setup(I => I.Get(PoetryStorageConstant.DbVersionKey , 0))
        //                            .Returns(PoetryStorageConstant.Version);

        //For TheoryAttribute
        preferenceStorageMockBuilder.Setup(I => I.Get(key_input , 0 , null))
                                    .Returns(value_got);


        // Return the mocked target object from mocker
        var mockedPreferenceStorager = preferenceStorageMockBuilder.Object;
        var mockedFileStorager = fileSystemStorageMockBuilder.Object;

        //Start Testing
        var poetryStorage = new PoetryStorage(mockedPreferenceStorager , mockedFileStorager);

        // Assertion
        Assert.True(poetryStorage.IsInitialized.Equals(expect_result));
    }



    [Fact]
    public async Task InitializeAsync_Default( )
    {
        var iPreferenceStorageMockBuilder = new Mock<IPreferenceStorage>();
        var iFileSystemStorageMockBuilder = new Mock<IFileSystemStorage>();

        var mockedPoetryStorager = new PoetryStorage(iPreferenceStorageMockBuilder.Object , iFileSystemStorageMockBuilder.Object);

        Assert.False(File.Exists(PoetryStorage.PoertyDBSqlite3Path_Old));
        await mockedPoetryStorager.InitializedAsync();
        Assert.True(File.Exists(PoetryStorage.PoertyDBSqlite3Path_Old));
        // 验证方法是否有被调用过
        iPreferenceStorageMockBuilder.Verify(i => i.Set(PoetryStorageConstant.DbVersionKey , PoetryStorageConstant.DbVersion , null) , Times.Once);
    }

}
