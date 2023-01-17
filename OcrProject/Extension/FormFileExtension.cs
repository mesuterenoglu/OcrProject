namespace OcrProject.Extension;

public static class FormFileExtensions
{
    public static async Task<byte[]> GetBytesAsync(this IFormFile formFile,CancellationToken cancellationToken)
    {
        var ms = new MemoryStream();
        await formFile.CopyToAsync(ms,cancellationToken);
        return ms.ToArray();
    }
}
