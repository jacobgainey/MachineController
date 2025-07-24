using MachineController.Objects;
using System.Diagnostics;
using System.Windows.Forms;

namespace MachineController.Functions
{
    public static class GenericFunctions
    {

        public static void ShowErrorMessage(Exception ex)
        {
            string message = string.Empty;
            message += $"Houston, we have a problem! ...";
            message += $"{Environment.NewLine}------------------------------------------------";
            message += $"{Environment.NewLine}{ex.Source}";
            message += $"{Environment.NewLine}------------------------------------------------";
            message += $"{Environment.NewLine}{ex.Message}";
            message += $"{Environment.NewLine}------------------------------------------------";
            message += $"{Environment.NewLine}{ex.StackTrace}";

            MessageBox.Show(message);
        }

        public static string ParseRunTime(string filePath)
        {
            // Ensure filePath is not null or empty
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            using StreamReader sr = new(filePath);
            string? line; // Use nullable string to handle potential null values
            while ((line = sr.ReadLine()) != null)
            {
                // Process the line if needed
                string[] lineParts = line.Trim().Split(new[] { ':', '\t' }, 3);

                if (lineParts.Length > 1)
                {
                    if (lineParts[0].Contains("build time", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // Return the runtime value, which is expected to be in the third part
                        return lineParts[1].Trim();
                    }
                }
            }

            return "unknown"; // Default return value if no lines are read or no build time was found
        }

        internal static void ShowWarningMessage(string v1, string v2, MessageBoxButtons yesNo, MessageBoxIcon warning)
        {
            throw new NotImplementedException();
        }

        //public static string ParseMaterialUsed(string filePath)
        //{
        //    // TODO: Implement logic to parse the material used from the file at the given filePath.
        //    return "0"; // Placeholder return value
        //}
    }
}