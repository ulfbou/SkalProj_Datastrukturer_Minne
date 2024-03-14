using System;
using System.Text;

namespace SkalProj_Datastrukturer_Minne;

/*
 * Frågor:
 * 1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess 
 *    grundläggande funktion
 *    Svar: Stacken är som en stor array som man lånar plats ifrån varje gång ett nytt 
 *          Scope skapas. Man kan likna detta vid en hög med tallrikar i en restaurang, 
 *          så när ett nytt scope skapas är det som att lägga en ny tallrik överst. Man 
 *          kommer inte åt någonting under den översta tallriken. 
 *    
 *          Heapen kan man se som en hårddisk i internminnet där man kan 
 *          allokera minne dynamiskt efter behov. Det innebär att den platsen i minnet 
 *          är reserverat för det specifika ändamålet som det allokerats för. Vid 
 *          allokeringen får koden en referenspekare som är det ända sättet som koden 
 *          kan nå minnet på heapen. Man kan likna heapen vid ett buffébord där gästerna 
 *          kan placera sina tallrikar. Tallrikarna kan vara utspridda lite hur som 
 *          helst. När en gäst lämnar buffén tar man bort tallrikarna som gästen hade 
 *          och platsen där de låg kan återanvändas för nya tallrikar. 
 * 
 * 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
 *    Svar: Value Types (värdetyp) är variabler som lagras på stacken under en viss tid 
 *          och är oftast bara åtkomligt för användning inom ett givet scope. Om en värdtyp
 *          används som indata till en metod kopieras värdet av den typen när ett nytt scope
 *          skapas. 
 *    
 *          Reference Types (referenstyper) är data som lagras på heapen med hjälp av 
 *          referenspekare och är åtkomligt för alla metoder som har tillgång till 
 *          dess referenspekare. Vid ett anrop till en metod kopieras endast 
 *          referenspekaren utan att själva minnet som referensen pekar på kopieras. 
 *          När det gäller stora dataobjekt går detta mycket snabbare. En nackdel av  
 *          detta är att andra metoder kan ibland förändra minnet, vilket kan få 
 *          oönskade konsekvenser. 
 *
 * 3. Följande metoder (se bild nedan) genererar olika svar. Den första returnerar 3, 
 *    den andra returnerar 4, varför?
 *    Svar: I metoden ReturnValue skapas variabeln x som är en värdtyp. Éfter att den 
 *          skapats får den värdet 3. Sedan kopieras värdet i x till variabeln y och 
 *          sedan ändras värdet i y till 4. Detta påverkar dock inte x som fortfarande 
 *          har värdet 3, vilket är det som returneras vid slutet av metoden.
 *    
 *          I metoden ReturnValue2 skapas variabeln x som är referenstypen MyInt. 
 *          Minnet som x pekar på finns på heapen och en del av det minnet upptar 
 *          platsen för fältet MyValue. Den platsen som fältet MyValue upptar får 
 *          värdet 3. Därefter skapas en variabel y av typen MyInt som pekar på en 
 *          annan del av heapen. Dock kopieras y till att värdet av x, vilket innebär 
 *          att y pekar på samma adress som x pekar på. Det innebär att minnet y pekade 
 *          på från början är bortglömt. Därefter ändras värdet på MyValue i variabeln  
 *          y till 4, vilket är samma plats som x pekar på. När metoden avslutas  
 *          returneras värdet av x.MyValue, vilket är 4.
 *    
 */

public class Program
{
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    static void Main()
    {

        while (true)
        {
            Console.WriteLine(
                "Choose: "
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n5. Recursive even numbers"
                + "\n6. Fibonacci numbers"
                + "\n7. Iterative even numbers"
                + "\n0. Exit the application");

            char input = ' '; //Creates the character input to be used with the switch-case below.

            Console.Write("Choice: ");

            try
            {
                input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }

            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '5':
                    ProcessRecursiveEven();
                    break;
                case '6':
                    ProcessFibonacci();
                    break;
                case '7':
                    ProcessIterativeFibonacci();
                    break;
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure List
    /// </summary>
    static void ExamineList()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */

        /*
         * 1. Skriv klart implementationen av ExamineList-metoden så att undersökningen 
         *    blir genomförbar.
         * 2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
         *    Svar: Listans kapacitet ökar när man lägger till ett element och 
         *          Count == Capacity
         * 3. Med hur mycket ökar kapaciteten?
         *    Svar: Listans kapacitet ökar med minst fyra, men dubbleras successivt. 
         * 4. Varför ökar inte listans kapacitet i samma takt som element läggs till?
         *    Svar: Därför att det är ineffektivt att varje gång öka listans kapacitet. 
         *    Varje gång kapaciteten ökar måste klassen kopiera alla element i listan 
         *    till en ny array. 
         * 5. Minskar kapaciteten när element tas bort ur listan?
         *    Svar: Nej
         * 6. När är det då fördelaktigt att använda en egendefinierad array istället 
         *    för en lista?
         *    Svar: När det är känt från början hur många element som listan maximalt 
         *    ska lagra. 
         * 
         */
        Console.WriteLine("Begin each line with either '+' or '-' to add or remove information from the list.");
        Console.WriteLine("Enter an empty line to return to the main menu.");

        List<string> list = new List<string>();

        Console.Write("Input: ");
        string input = Console.ReadLine();

        while (!string.IsNullOrEmpty(input))
        {
            switch (input[0])
            {
                case '+':
                    list.Add(input.Substring(1));
                    Console.WriteLine($"The collection has {list.Count} strings and can for the moment store at most {list.Capacity} strings");
                    break;
                case '-':
                    list.Remove(input.Substring(1));
                    Console.WriteLine($"The collection has {list.Count} strings and can for the moment store at most {list.Capacity} strings");
                    break;
                default:
                    Console.WriteLine("Your input has to begin with either '+' or '-'.");
                    break;
            }

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

            Console.Write("\nInput: ");
            input = Console.ReadLine();
        }
    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */
        Queue<string> queue = new Queue<string>();

        Console.WriteLine("The store has now opened and the line to the cashier are empty.");

        while (true)
        {
            Console.WriteLine("\nQueue Menu:");
            Console.WriteLine("1. Add customer to queue");
            Console.WriteLine("2. Process next customer");
            Console.WriteLine("3. Display queue");
            Console.WriteLine("4. Exit");

            int choice = Utils.ReadNumberInput("Enter your choice: ");
            
            switch (choice)
            {
                case 1:
                    Console.Write("Enter customer name: ");
                    string customerName = Console.ReadLine();
                    queue.Enqueue(customerName);
                    Console.WriteLine($"Customer '{customerName}' added to the queue.");
                    break;
                case 2:
                    if (queue.Count > 0)
                    {
                        string nextCustomer = queue.Dequeue();
                        Console.WriteLine($"Processing customer '{nextCustomer}'.");
                    }
                    else
                    {
                        Console.WriteLine("The queue is empty.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Current queue:");
                    foreach (string customer in queue)
                    {
                        Console.WriteLine(customer);
                    }
                    break;
                case 4:
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    static void ExamineStack()
    {
        /*
         * Loop this method until the user inputs something to exit to main menue.
         * Create a switch with cases to push or pop items
         * Make sure to look at the stack after pushing and and poping to see how it behaves
        */

        ReverseText();
    }

    private static void ReverseText()
    {
        string input = Utils.ReadStringInput();
        Stack<char> stack = new Stack<char>(input.ToCharArray());
        StringBuilder reversedText = new();

        while (stack.Count > 0)
        {
            reversedText.Append(stack.Pop());
        }

        Console.WriteLine(reversedText.ToString());
    }

    static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<"int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */
        string input = Utils.ReadStringInput();

        if (CheckParenthesis(input ?? String.Empty))
        {
            Console.WriteLine($"The string {input} is well formed.");
        }
        else
        {
            Console.WriteLine($"The string {input} is NOT well formed.");

        }
    }

    private static bool CheckParenthesis(string input)
    {
        Dictionary<char, char> openEnded = new Dictionary<char, char>
        {
            { '(',')' },
            { '{','}' },
            { '[',']' }
        };
        Dictionary<char, char> closeEnded = new Dictionary<char, char>
        {
            { ')','(' },
            { '}','{' },
            { ']','[' }
        };
        string openChars = "({[";
        string closeChars = ")}]";
        Stack<char> stack = new();

        foreach (char item in input)
        {
            if (openChars.Contains(item))
            {
                stack.Push(item);
            }
            else if (closeChars.Contains(item))
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                if (closeEnded.ContainsKey(item))
                {
                    if (closeEnded[item] != stack.Peek())
                    {
                        return false;
                    }


                    stack.Pop();
                }
            }
        }

        return stack.Count == 0;
    }

    private static void ProcessRecursiveEven()
    {
        Console.WriteLine("Let's find the nth even number.");

        int number = Utils.ReadNumberInput();

        Console.WriteLine(RecursiveEven(number));
    }

    private static int RecursiveEven(int n)
    {
        if (n == 1)
        {
            return 2;
        }
        else
        {
            return 2 + RecursiveEven(n - 1);
        }
    }

    private static int RecursiveEven(int number, int count = 0)
        => number == 1 ? 2 : RecursiveEven(number - 1, count + 2);

    private static void ProcessFibonacci()
    {
        Console.WriteLine("Let's find the nth even number.");

        int number = Utils.ReadNumberInput();

        Console.WriteLine(Fibonacci(number));
    }

    private static int Fibonacci(int number)
    {
        if (number <= 1)
        {
            return 1;
        }

        return Fibonacci(number - 1) + Fibonacci(number - 2);
    }

    private static void ProcessIterativeEven()
    {
        Console.WriteLine("Let's find the nth Fibonacci number.");

        int number = Utils.ReadNumberInput();

        Console.WriteLine(IterativeEven(number));
    }

    private static int IterativeEven(int number)
    {
        int result = 2;
        for (int i = 1; i < number; i++)
        {
            result += 2;
        }

        return result;
    }

    private static void ProcessIterativeFibonacci()
    {
        Console.WriteLine("Let's find the nth Fibonacci number.");

        int number = Utils.ReadNumberInput();

        Console.WriteLine(IterativeFibonacci(number));
    }

    private static int IterativeFibonacci(int number)
    {
        int[] fibonacciNumbers = new int[number + 1];

        fibonacciNumbers[1] = 1;
        fibonacciNumbers[2] = 1;

        for (int i = 3; i <= number; i++)
        {
            fibonacciNumbers[i] = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
        }

        return fibonacciNumbers[number];
    }
}

/*
 * Fråga:
 * Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering. Vilken av 
 * ovanstående funktioner är mest minnesvänlig och varför?
 * 
 * Iteration är mest minnesvänlig eftersom det endast kräver ett scope eftersom 
 * resultatet beräknas inuti den iterativa metoden. Varje rekursivt anrop skapar ett 
 * nytt scope, vilket praktiskt innebär att metoden lånar plats på stacken. 
 * 
 */
