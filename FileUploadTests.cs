using NUnit.Framework;
using SeleniumBasics.Pages;

namespace SeleniumBasics;

[TestFixture]
public class FileUploadTests : BaseTest
{
    private FileUploadPage fileUploadPage = null!;
    private string testFilePath = null!;

    [SetUp]
    public override void Setup()
    {
        base.Setup();
        fileUploadPage = new FileUploadPage(Driver);
        testFilePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "testfile.txt");
        File.WriteAllText(testFilePath, "test content");
    }

    [Test]
    public void Should_ShowUploadedFileName_When_FileIsUploaded()
    {
        // Arrange
        fileUploadPage.Open();

        // Act
        fileUploadPage.UploadFile(testFilePath);

        // Assert
        Assert.That(fileUploadPage.GetUploadedFileName(), Does.Contain("testfile.txt"),
            "Uploaded file name should appear on the page");
    }

    [Test]
    public void Should_ShowSuccessMessage_When_FileIsUploaded()
    {
        // Arrange
        fileUploadPage.Open();

        // Act
        fileUploadPage.UploadFile(testFilePath);

        // Assert
        Assert.That(fileUploadPage.IsUploadSuccessful(), Is.True,
            "Page should show 'File Uploaded!' after successful upload");
    }

    [TearDown]
    public override void TearDown()
    {
        base.TearDown();
        if (File.Exists(testFilePath))
            File.Delete(testFilePath);
    }
}
