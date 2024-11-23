using System.Text;

namespace shorturl.API.Extensions;

public static class ShortCodeExtension
{
    public static string GenerateCode(int letterLength, int numberLength)
    {
        Random random = new Random();
        StringBuilder code = new StringBuilder();

        // First {letterLength} characters are random letters
        for (int i = 0; i < letterLength; i++)
        {
            char letter = (char)random.Next('a', 'z' + 1); // random cahr from between a-z
            code.Append(letter);
        }

        // Last {numberLength} characters are random numbers
        for (int i = 0; i < numberLength; i++)
        {
            int number = random.Next(0, 10); // random number between 0-10
            code.Append(number);
        }

        return code.ToString();
    }
}
