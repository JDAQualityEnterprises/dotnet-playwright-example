using dotnet_playwright_example.model;
using System.Text.Json;

namespace dotnet_playwright_example.framework
{
    internal class TestData
    {
        private string rootFolder;

        public TestData() {
            var currentDir = Directory.GetCurrentDirectory();
            var dirInfo = new DirectoryInfo(currentDir);
            
            if (dirInfo == null) {
                throw new ArgumentNullException("Unable to get current folder for test data");
            }
            rootFolder = $"{dirInfo.FullName}/TestData";
        }

        public SiteInfo SiteInfo() {
            string fileName = $"{rootFolder}/SiteInfo.json";
            SiteInfo siteInfo;

            try
            {
                string jsonString = File.ReadAllText(fileName);
                if (string.IsNullOrEmpty(jsonString))
                {
                    throw new ArgumentNullException("Unable to read SiteInfo test data");
                }

                siteInfo = JsonSerializer.Deserialize<SiteInfo>(jsonString)!;

                if (siteInfo == null)
                {
                    throw new ArgumentNullException("Unable to deserialize SiteInfo test data");
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException($"Unable to find SiteInfo test data file: {fileName}");
            }
            
            return siteInfo;
        }
    }
}
