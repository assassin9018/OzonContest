using System.IO.Compression;

namespace OzonContestDataSet
{
    public class DatasetProvider
    {
        private const string _dirWithFiles = "files";

        public static IEnumerable<(string question, string answer)> GetFilesNames(string datasetName, string issueName)
        {
            EnsureFilesCreated(datasetName, issueName);
            string targetDir = Path.Combine(_dirWithFiles, datasetName, issueName);
            string[] fileNames = Directory.GetFiles(targetDir);
            for (int i = 0; i < fileNames.Length; i += 2)
                yield return (fileNames[i], fileNames[i + 1]);
        }

        private static void EnsureFilesCreated(string datasetName, string issueName)
        {
            string targetDir = Path.Combine(_dirWithFiles, datasetName, issueName);
            if (Directory.Exists(targetDir) && Directory.GetFiles(targetDir).Length != 0)
                return;
            Directory.CreateDirectory(targetDir);
            using FileStream sourceFs = new(Path.Combine(datasetName, issueName + ".zip"), FileMode.Open, FileAccess.Read);
            using ZipArchive zip = new(sourceFs);
            foreach (var entry in zip.Entries.Where(x=>!x.FullName.EndsWith('/')))
                entry.ExtractToFile(Path.Combine(targetDir, entry.Name), true);
        }
    }
}
