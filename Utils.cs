
namespace SkalProj_Datastrukturer_Minne;

internal static class Utils
{
    internal static string ReadStringInput(string prompt = "Input: ")
    {
        string input;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        }
        while (string.IsNullOrEmpty(input));

        return input;
    }

    internal static int ReadNumberInput(string prompt = "Input: ")
    {
        string input;
        int number;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();

        }
        while (!int.TryParse(input, out number));

        return number;
    }
}
