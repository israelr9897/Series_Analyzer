// See https://aka.ms/new-console-template for more information


using SeriesAnalyzer;

namespace SeriesAnalyzer
{
    class program()
    {
        static void Main(string[] args) //Activates functions according to user selection
        {
            void Manu()
            {
                bool IsOnlyNumbers = false;
                bool IsNormalSeries = false;
                bool IsExit = false;
                string UserNumber = "";
                List<string> StrNumberList = new List<string>();
                List<int> UserNumbersList = new List<int>();
                while(!IsExit)
                {
                    while(!IsNormalSeries)
                    {
                        while(!IsOnlyNumbers)
                        {
                            UserNumber = GettingNumber();
                            StrNumberList = ArrayBuilder(UserNumber);
                            IsOnlyNumbers = ChecksOnlyNumbers(StrNumberList);
                        }
                        UserNumbersList = ConvertsListFromStringToInt(StrNumberList);
                        IsNormalSeries = NumberChecker(UserNumbersList);
                    }
                    string UserChoice = PrintMenu();
                    ProgramControl(UserChoice,UserNumbersList);
                        

                    string PrintMenu()
                    {
                        System.Console.WriteLine("\nPlease enter your choice (A - J)\n" +
                        "A - Input a Series. (Replace the current series)\n" +
                        "B - Display the series in the order it was entered.\n" +
                        "C - Display the series in the reversed order it was entered.\n" +
                        "D - Display the series in sorted order (from low to high).\n" +
                        "E - Display the Max value of the series.\n" +
                        "F - Display the Min value of the series.\n" +
                        "G - Display the Average of the series.\n" +
                        "H - Display the Number of elements in the series.\n" +
                        "I - Display the Sum of the series.\n" +
                        "J - Exit.");
                        string choice = Console.ReadLine();
                        return choice;
                    }

                    void ProgramControl(string choice, List<int> UserNumbersList)
                    {
                        switch (choice)
                        {
                            case "a":
                                IsOnlyNumbers = false;
                                IsNormalSeries = false;
                                break;

                            case "b":
                                NumberPrinter(UserNumbersList);
                                break;

                            case "c":
                                ReversePrinter(UserNumbersList);
                                break;

                            case "d":
                                SortsNumbers(UserNumbersList);
                                break;

                            case "e":
                                System.Console.WriteLine(FindMaximumValue(UserNumbersList));
                                break;

                            case "f":
                                System.Console.WriteLine(FindMinimumValue(UserNumbersList));
                                break;

                            case "g":
                                System.Console.WriteLine(AverageCalculator(UserNumbersList));
                                break;

                            case "h":
                                System.Console.WriteLine(NumberElements(UserNumbersList));
                                break;

                            case "i":
                                System.Console.WriteLine(SumNumbers(UserNumbersList));
                                break;

                            case "j":
                                IsExit = true;
                                System.Console.WriteLine("By");
                                break;
                            
                            default:
                            System.Console.WriteLine("Wrong choice");
                            break;
                        }
                    }

                    string GettingNumber()
                    {
                        System.Console.WriteLine("Please enter a series of numbers with a space separating each number.");
                        return Console.ReadLine();
                    }

                    bool NumberChecker(List<int> NumbersList)
                    {
                        bool PositiveNumber = true;
                        foreach (var num in NumbersList)
                        {
                            if (num < 0)
                            {
                                PositiveNumber = false;
                            }
                        }
                        bool IsNormalSeries = (NumbersList.Count >= 3) && PositiveNumber;
                        if(!IsNormalSeries)
                        {
                            System.Console.WriteLine("Entering an invalid series of numbers");
                            IsOnlyNumbers = false;
                        }
                        return IsNormalSeries;
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

                    List<string> ArrayBuilder(string Numbers)
                    {
                        List<string> StrNumberList = new (Numbers.Split(" "));
                        return StrNumberList;
                    }

                    bool ChecksOnlyNumbers(List<string> StrNumberList )
                    {
                        bool IsNumber = true;
                        foreach(var num in StrNumberList)
                        {
                            if(!(IsNumber = int.TryParse(num, out int n)))
                            {
                                System.Console.WriteLine("Please enter characters consisting only of numbers.");
                                break;
                            }
                        }
                        return IsNumber;
                    }


                    List<int> NumberPrinter(List<int> UserNumbersList)
                    {
                        for (int i =0; i < UserNumbersList.Count; i++)
                        {
                            System.Console.Write(UserNumbersList[i] + " ");
                        }
                        return UserNumbersList;
                    }

                    List<int> ReversePrinter(List<int> UserNumberList)
                    {
                        List<int> ReverseList = new List<int>();
                        for (int i = UserNumberList.Count - 1; i >= 0; i--)
                        {
                            ReverseList.Add(UserNumberList[i]);
                        }
                        for (int i = 0; i < ReverseList.Count; i++)
                        {
                            System.Console.Write(ReverseList[i] + " ");
                        }
                        return ReverseList;
                    }

                    List<int> SortsNumbers(List<int> UserNumberList)
                    {
                        List<int> SortList = CreatesNewList(UserNumberList);
                        for (int i = 0; i < UserNumberList.Count - 1; i++)
                        {
                            int MiniIdx = UpdatingList(SortList, i);
                            SortList = Swep(SortList, MiniIdx, i);
                        }
                        foreach (var item in SortList)
                        {
                            System.Console.Write(item + " ");
                        }
                        return SortList;
                    }

                    List<int> CreatesNewList(List<int> UserNumberList)
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
                        List<int> ShortList = (UserNumberList.GetRange(i, UserNumberList.Count - i));
                        int MiniIdx = ShortList.IndexOf(FindMinimumValue(ShortList));
                        return MiniIdx + i;
                    }

                    List<int> Swep(List<int> SortList, int MiniIdx, int i)
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
                }

            }

            Manu();
        }
    }
}
