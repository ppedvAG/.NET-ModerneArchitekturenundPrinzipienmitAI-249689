using ppeat.BusinessCore.Contracts;

namespace ppeat.BusinessCore.Services
{
    public class RemoteFileService : IFileService
    {
        private readonly HttpClient _httpClient;

        public RemoteFileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> UploadFile(Stream file, string filePath)
        {
            //_httpClient.PostAsync("https://example.com/" + filePath);

            // Koente gegen eine API eines File Servers gehen oder so

            return Task.FromResult("https://www.ppedv.de/Images/ppedv.svg");
        }
    }
}
