namespace Infrastructure
{
    public static class Utility
    {
        static Utility()
        {

        }

        private static void RenameFile(string filePath, string newFileName)
        {
            var newFilePath =
                System.IO.Path.Combine
                    (System.IO.Path.GetDirectoryName(filePath), newFileName + System.IO.Path.GetExtension(filePath));

            if (System.IO.File.Exists(newFilePath) == false)
            {
                System.IO.File.Move(filePath, newFilePath);
            }
        }

        public static void RenameFileByRegExPattern(string path, string regexPattern, string replacedString)
        {
            if (System.IO.Directory.Exists(path) == true)
            {
                var varFiles = System.IO.Directory.GetFiles(path);

                int count = 0;

                foreach (var item in varFiles)
                {
                    string oldFileName = System.IO.Path.GetFileNameWithoutExtension(item);

                    if (oldFileName.Contains(replacedString) == false && oldFileName.Contains(".") == true)
                    {
                        string newFileName =
                            System.Text.RegularExpressions.Regex.Replace
                                (input: oldFileName, pattern: regexPattern, replacement: replacedString);

                        RenameFile(item, newFileName);

                        count++;

                        System.Console.WriteLine($"{count}- {oldFileName} Renamed to: {newFileName}");

                        System.Console.WriteLine();
                    }
                }

                System.Console.WriteLine($"{count} Files Renamed !");
            }
        }
    }
}