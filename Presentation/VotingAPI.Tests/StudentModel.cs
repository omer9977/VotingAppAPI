using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace VotingAPI.Tests
{
    public class StudentModel
    {
        public string UserName { get {
                CultureInfo turkishCulture = new CultureInfo("tr-TR");
                string text = $"{(Name + LastName)}@std.iyte.edu.tr";
                string lowerText = text.ToLower(turkishCulture);

                string normalizedText = lowerText
                    .Normalize(NormalizationForm.FormD)
                    .Replace('\u0131', 'i')
                    .Replace('\u0307', '\0');
                return normalizedText;
            } set { }
        }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
    }
}
