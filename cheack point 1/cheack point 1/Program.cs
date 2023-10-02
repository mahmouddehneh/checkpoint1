internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Checkpoint 1 ");
        string[] productArray = new string[0];
        int index = 0;
        bool hasError = false;
        while (true)
        {
            hasError = false;
            Console.ResetColor();
            Console.WriteLine("skriv 'exit' för visa alla vår produkter.");
            var input = Console.ReadLine();


#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (input.Trim().ToLower() != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (input.Length < 5)
                {
                    Console.WriteLine("Incorrect Entry. Too few characters. Write like exit.");
                    continue;
                }

                string[] split = input.Split("-");
                if (split.Length < 2)
                {
                    Console.WriteLine("Incorrect Entry. One hyphen (-) is required. Write like exit.");
                    continue;
                }
                else if (split.Length > 2)
                {
                    Console.WriteLine("Incorrect Entry. Only one hyphen (-) is allowed. Write like exit.");
                    continue;
                }

                if (string.IsNullOrEmpty(split[0]) || string.IsNullOrEmpty(split[1]))
                {
                    Console.WriteLine("Incorrect Entry. Need data on both sides. Write like exit.");
                    hasError = true;
                }
                else
                {
                    foreach (char c in split[0])
                    {
                        if (!char.IsLetter(c))
                        {
                            hasError = true;
                        }
                    }
                    if (hasError)
                    {
                        Console.WriteLine("Incorrect Entry. Left part is not correct. Write like exit.");
                    }
                }

                bool isInt = int.TryParse(split[1], out int value);
                if (!isInt)
                {
                    Console.WriteLine("Incorrect Entry. Right part is not correct. Write like exit.");
                    hasError = true;
                }
                else if (value < 201 || value > 499)
                {
                    Console.WriteLine("Incorrect Entry. Right part number must be between 200 and 500. Write like exit.");
                    hasError = true;
                }



                if (!hasError)
                {
                    Array.Resize(ref productArray, index + 1);
                    productArray[index] = input.ToUpper();
                    index++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct Entry!");
                }
            }
            else
            {
                break;
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }

        Console.WriteLine("vår product är");

        Array.Sort(productArray);
        foreach (string  product in productArray)
        {
            Console.WriteLine("*b " +  product);
        }

        Console.WriteLine("ska");
        Console.WriteLine("skarmskydd");
        Console.WriteLine("iphone-tillbehor");
        Console.WriteLine("laddare");

        Console.ReadLine();

        Console.WriteLine("välkomen åter!");
    }
}