namespace FileRenameByRegexPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string _regExPattern = @"(?<=[A-Za-z])\.|\.(?![part])(?=[A-Za-z])";

            string _replacedString = " ";

            System.Console.Write("Enter Path: ");

            string _folderPath = System.Console.ReadLine();

            if (string.IsNullOrWhiteSpace(_folderPath) != true )
            {
                Infrastructure.Utility.RenameFileByRegExPattern
                    (path: _folderPath, regexPattern: _regExPattern, replacedString: _replacedString);
            }

            System.Console.WriteLine("Press [ENTER] to Exit ... ");

            System.Console.ReadLine();
        }
    }
}
