// See https://aka.ms/new-console-template for more information


using SeriesAnalyzer;

namespace SeriesAnalyzer
{
    class program()
    {
        static void Main(string[] args) //Activates functions according to user selection
        {
            bool Exit = false;
            List<int> UserNumberList = GettingNumber();
            if (NumberChecker(UserNumberList))
            {
                while (!Exit)
                {
                    string UserChoice = PrintMenu();
                    ProgramControl(UserChoice);            
                }
            }
            
            List<int> GettingNumber()
            {
                System.Console.WriteLine("Please enter a series of numbers with a space separating each number.");                
                return UserNumberList = ArrayBuilder(Console.ReadLine());;
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

            List<int> ConvertsListFromStringToInt(List<string> StrNumberList)
            {
                List<int> NumberList = new List<int>();
                foreach (var num in StrNumberList)
                {
                    NumberList.Add(int.Parse(num));
                }
                return NumberList;
            }

            List<int> ArrayBuilder(string Numbers)
            {
                List<string> StrNumberList = new List<string> (Numbers.Split(" "));
                List<int> NumberList = (ConvertsListFromStringToInt(StrNumberList));
                return NumberList; 
            }

            string PrintMenu()
            {
                System.Console.WriteLine("\nPlease enter your choice (1-10)\n"+
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

            List<int> NumberPrinter(List<int> UserNumberList)
            {
                foreach (var num in UserNumberList)
                {
                System.Console.Write(num + " ");
                }
                return UserNumberList;
            }

            List<int> ReversePrinter(List<int> UserNumberList)
            {
                List<int> ReverseList = new List<int>();
                for (int i = UserNumberList.Count -1; i >= 0; i--)
                {
                    ReverseList.Add(UserNumberList[i]);
                }
                for (int i = 0; i < ReverseList.Count; i++)
                {
                    System.Console.Write(ReverseList[i] + " ");
                }
                return ReverseList;
            }

            List<int> SortsNumbers(List<int> UserNumbersList)
            {
                List<int> SortList = (CreatesNewList(UserNumberList));
                for (int i = 0; i < UserNumberList.Count-1; i++)
                {
                    int MiniIdx = UpdatingList(SortList , i);
                    SortList = Swep(SortList, MiniIdx, i);
                }
                foreach (var item in SortList)
                {
                System.Console.Write(item + " ");
                }                    
                return SortList;
            }

            List<int>CreatesNewList(List<int> UserNumberList)
            {
                List<int> NewList = new List<int>();
                foreach (var num in UserNumberList)
                {
                     NewList.Add(num);
                }
                return NewList;
            }

            int UpdatingList(List<int> UserNumberList, int i)
            {
               List<int> ShortList  = (UserNumberList.GetRange(i, UserNumberList.Count - i));
               int MiniIdx = ShortList.IndexOf(FindMinimumValue(ShortList));
               return MiniIdx + i ;
            }

            List<int> Swep(List<int> SortList,int MiniIdx, int i)
            {
                int temp = SortList[MiniIdx];
                SortList[MiniIdx] = SortList[i];
                SortList[i] = temp;
                return SortList;
            }

            int FindMaximumValue(List<int> UserNumberList)
            {
                int MaxValue = UserNumberList[0];
                foreach (var num in UserNumberList)
                {
                    if (MaxValue < num)
                    {
                        MaxValue = num;
                    }
                }
                return MaxValue;
            
            }

            int FindMinimumValue(List<int> UserNumberList)
            {
                int MinValue = UserNumberList[0];
                foreach (var num in UserNumberList)
                {
                    if (MinValue > num)
                    {
                        MinValue = num;
                    }
                }
                return MinValue;
            }

            double AverageCalculator(List<int> UserNumberList)
            {
                return SumNumbers(UserNumberList) / UserNumberList.Count;
            }

            int NumberElements(List<int> UserNumberList)
            {
                return UserNumberList.Count;
            }

            double SumNumbers(List<int> UserNumberList)
            {
                double result = 0;
                foreach (var num in UserNumberList)
                {
                    result += num;
                }
                return result;
            }

            void ProgramControl(string choice)
            {
                switch(choice)
                {
                    case "a":
                    GettingNumber();
                    break;

                    case "b":
                    NumberPrinter(UserNumberList);
                    break;

                    case "c":
                    ReversePrinter(UserNumberList);
                    break;

                    case "d":
                    SortsNumbers(UserNumberList);
                    break;

                    case "e":
                    System.Console.WriteLine(FindMaximumValue(UserNumberList));
                    break;

                    case "f":
                    FindMinimumValue(UserNumberList);
                    break;

                    case "g":
                    System.Console.WriteLine(AverageCalculator(UserNumberList));
                    break;

                    case "h":
                    NumberElements(UserNumberList);
                    break;

                    case "i":
                    System.Console.WriteLine(SumNumbers(UserNumberList));
                    break;

                    case "j":
                    Exit = true;
                    break;
                }
            }
            
            
        }
    }
}
