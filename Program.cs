// See https://aka.ms/new-console-template for more information


using SeriesAnalyzer;

namespace SeriesAnalyzer
{
    class program()
    {
        static void Main(string[] args) //Activates functions according to user selection
        {
            bool Exit = false;
            string UserNumbers = GettingNumber();
            List<int> UserNumberList = InsertArray(UserNumbers);
            if (NumberChecker(UserNumberList))
            {
                while (!Exit)
                {
                    string UserChoice = PrintMenu();
                    ProgramControl(UserChoice);            
                }
            }
            
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
                return (NumbersList.Count >= 3) && Flag;
            }

            List<int> InsertArray(string Numbers)
            {
                List<string> StrNumberList = ArrayBuilder(Numbers);
                List<int> NumberList = new List<int>();
                foreach (var num in StrNumberList)
                {
                    NumberList.Add(int.Parse(num));
                }
                return NumberList;
            }
            List<string> ArrayBuilder(string Numbers)
            {
                List<string> NumberList = new List<string> (Numbers.Split(" "));
                return NumberList; 
            }

            string PrintMenu()
            {
                System.Console.WriteLine("Please enter your choice (1-10)\n"+
                "A - Input a Series. (Replace the current series)\n"+
                "B - Display the series in the order it was entered.\n"+
                "C - Display the series in the reversed order it was entered.\n"+
                "D - Display the series in sorted order (from low to high).\n"+
                "E - Display the Max value of the series.\n"+
                "F - Display the Min value of the series.\n"+
                "G - Display the Average of the series.\n"+
                "H - Display the Number of elements in the series.\n"+
                "I - Display the Sum of the series.\n"+
                "J - Exit.");
                string choice = Console.ReadLine();
                return choice;
            }

            void NumberPrinter()
            {
                System.Console.WriteLine(UserNumbers);
            }

            void ProgramControl(string choice)
            {
                switch(choice)
                {
                    case "a":
                    UserNumbers = GettingNumber();
                    break;

                    case "b":
                    NumberPrinter();
                    break;
                }
            }
            
            
        }
    }
}
