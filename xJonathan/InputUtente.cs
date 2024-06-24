using System.Text.RegularExpressions;

namespace ProgettoFinale
{
    static class InputUtente
    {
        public static string GetValidNameOrSurname(string message)
        {
            string input;
            Regex onlyLetters = new Regex("^[a-zA-Z]+$");

            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine();

                if (!onlyLetters.IsMatch(input))
                {
                    Console.WriteLine("Inserisci solo lettere (senza numeri, spazi o caratteri speciali).");
                }

            } while (!onlyLetters.IsMatch(input));

            return input;
        }
    }
}
