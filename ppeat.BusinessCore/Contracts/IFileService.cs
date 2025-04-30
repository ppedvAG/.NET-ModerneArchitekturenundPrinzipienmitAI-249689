namespace ppeat.BusinessCore.Contracts
{
    public interface IFileService
    {
        Task<string> UploadFile(Stream file, string filePath);
    }
}