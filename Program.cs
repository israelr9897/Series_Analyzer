// See https://aka.ms/new-console-template for more information


namespace SeriesAnalyzer
{
    class program()
    {
        static void Main(string[] args) //Activates functions according to user selection
        {
            string GettingNumber()
            {
                System.Console.WriteLine("Please enter a series of numbers with a space separating each number.");
                string UserNumber = Console.ReadLine();
                return UserNumber;
            }
            
            bool NumberChecker(List<int> NumbersList)
            {
                bool Flag = true;
                foreach (var num in NumbersList)
                {
                    if (num < 0)
                    {
                        Flag = false;
                    }
                }
                return (NumbersList.Count > 3) && Flag;
            }

            string[] InsertArray(string Numbers)
            {
                string[] NumberList = Numbers.Split(" ");
                return NumberList;
            }

            int PrintMenu()
            {
                System.Console.WriteLine("Please enter your choice (1-10)\n"+
                "1 - Input a Series. (Replace the current series)\n"+
                "2 - Display the series in the order it was entered.\n"+
                "3 - Display the series in the reversed order it was entered.\n"+
                "4 - Display the series in sorted order (from low to high).\n"+
                "5 - Display the Max value of the series.\n"+
                "6 - Display the Min value of the series.\n"+
                "7 - Display the Average of the series.\n"+
                "8 - Display the Number of elements in the series.\n"+
                "9 - Display the Sum of the series.\n"+
                "10 - Exit.");
                int choice = int.Parse(Console.ReadLine());
                return choice;
            }
            
            
        }
    }
}