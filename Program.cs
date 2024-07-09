namespace CSharp15._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file path: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            string content = File.ReadAllText(filePath);
            DisplayStatistics(content);
        }

        static void DisplayStatistics(string content)
        {
            int sentenceCount = CountSentences(content);
            int uppercaseCount = content.Count(char.IsUpper);
            int lowercaseCount = content.Count(char.IsLower);
            int vowelCount = content.Count(IsVowel);
            int consonantCount = content.Count(IsConsonant);
            int digitCount = content.Count(char.IsDigit);

            Console.WriteLine("File Statistics:");
            Console.WriteLine($"Number of sentences: {sentenceCount}");
            Console.WriteLine($"Number of uppercase letters: {uppercaseCount}");
            Console.WriteLine($"Number of lowercase letters: {lowercaseCount}");
            Console.WriteLine($"Number of vowels: {vowelCount}");
            Console.WriteLine($"Number of consonants: {consonantCount}");
            Console.WriteLine($"Number of digits: {digitCount}");
        }

        static int CountSentences(string content)
        {
            char[] sentenceEndings = { '.', '!', '?' };
            return content.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        static bool IsVowel(char c)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            return vowels.Contains(c);
        }

        static bool IsConsonant(char c)
        {
            return char.IsLetter(c) && !IsVowel(c);
        }
    }
}
