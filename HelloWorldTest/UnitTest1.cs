using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("en", "Et edes antanut lukua", "miksi?", "Et edes antanut lukua", "3", "Yritapa uudelleen", "6", "Yritapa uudelleen", "4", "Onnistuit! Poistuit silmukasta")]
        [Trait("TestGroup", "InputLoop")]
        public void TestInputLoop_IgnoreSpacesAndSymbols(params string[] inputs)
        {
            // Arrange
            var input = new StringReader(string.Join(Environment.NewLine, inputs));
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString();

            // Expected substrings we want to find in the result
            var expectedSubstrings = new[]
            {
        "kirjoita luku 4",
        "et edes antanut lukua",
        "yritapa uudelleen",
        "onnistuit! poistuit silmukasta"
    };

            // Ensure the result contains the expected substrings
            foreach (var expected in expectedSubstrings)
            {
                Assert.True(LineContainsIgnoreSpaces(result, expected),
                    $"Expected to find: {expected} in the output, but it was not found.");
            }
        }


        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace and convert to lowercase
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();

            // Create a regex pattern to allow any character for "ä" and "ö"
            string pattern = Regex.Escape(normalizedExpectedText)
                                  .Replace("ö", ".")  // Allow any character for "ö"
                                  .Replace("ä", ".") // Allow any character for "ä"
                                  .Replace("a", ".") // Allow any character for "ä"
                                  .Replace("o", "."); // Allow any character for "ä"

            // Check if the line matches the pattern, ignoring case
            return Regex.IsMatch(normalizedLine, pattern, RegexOptions.IgnoreCase);
        }


        private int CountWords(string line)
        {
            return line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private bool CompareLines(string[] actualLines, string[] expectedLines)
        {
            if (actualLines.Length != expectedLines.Length)
            {
                return false;
            }

            for (int i = 0; i < actualLines.Length; i++)
            {
                if (actualLines[i] != expectedLines[i])
                {
                    return false;
                }
            }

            return true;
        }
        private string NormalizeOutput(string output)
        {
            // Normalize line endings to Unix-style '\n' and trim any extra spaces or newlines
            return output.Replace("\r\n", "\n").Trim();
        }
    }
}
