using HelloWorld; // Ensure this is the correct namespace for the Program class
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using System.Text.RegularExpressions;

namespace HelloWorldTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Tammikuu", "Sininen", "3", "Pelinimesi on Lumisateen Sininen K��pi�.")]
        [InlineData("Huhtikuu", "Punainen", "7", "Pelinimesi on Aamukasteen Punainen Haltija.")]
        [InlineData("Hein�kuu", "Vihre�", "12", "Pelinimesi on Kes�p�iv�n Vihre� Ewok.")]

        [Trait("TestGroup", "TestNicknameGeneration")]
        public void TestNicknameGeneration(string kuukausi, string v�ri, string p�iv�, string expectedOutput)
        {
            // Arrange
            var input = new StringReader($"{kuukausi}\n{v�ri}\n{p�iv�}\n"); // Simulate user inputs
            Console.SetIn(input);

            using var sw = new StringWriter();
            Console.SetOut(sw); // Capture console output

            // Act
            HelloWorld.Program.Main(new string[0]); // Run the Main method

            // Get the console output
            var result = sw.ToString();

            // Split the output into lines
            var resultLines = result.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            // Assert: Check the final output for correctness
            var lastLine = resultLines[1];
            Assert.True(LineContainsIgnoreSpaces(lastLine, expectedOutput),
                $"Expected: {expectedOutput} but got: {lastLine}");
        }


        private bool LineContainsIgnoreSpaces(string line, string expectedText)
        {
            // Remove all whitespace and convert to lowercase
            string normalizedLine = Regex.Replace(line, @"\s+", "").ToLower();
            string normalizedExpectedText = Regex.Replace(expectedText, @"\s+", "").ToLower();

            // Create a regex pattern to allow any character for "�" and "�"
            string pattern = Regex.Escape(normalizedExpectedText)
                                  .Replace("�", ".")  // Allow any character for "�"
                                  .Replace("�", "."); // Allow any character for "�"

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