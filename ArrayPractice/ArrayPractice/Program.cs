using System;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Runtime.ExceptionServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

Menu();

#region app
void MergeArray()
{

    WelcomeApp("Welcome to the array merge program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    PrintLine("Pleas enter length secondArray");
    int nSecondArray = ReadLineInt();
    int[] firstArray = new int[nFirstArray];
    int[] secondArray = new int[nSecondArray];
    ReadArray(firstArray);
    ReadArray(secondArray);
    var userChoice = ReadInformation(nFirstArray, nSecondArray);
    int[] resultArray = new int[(userChoice.nelements1 + userChoice.nelements2)];
    Menu(userChoice.sUserChoice, firstArray, secondArray, resultArray, userChoice.nelements1, userChoice.nelements2);
    PrintLine("the new array");
    Printarray(resultArray);
    Console.ReadKey();
    void Menu(int selectUser, int[] firstArray, int[] secondArray, int[] resultArray, int userChoice1, int userChoice2)
    {
        switch (selectUser)
        {
            case 1:
                {
                    MergeFromStart(firstArray, secondArray, resultArray, userChoice1, userChoice2);
                    break;
                }
            case 2:
                {
                    MergeArrayFromEnd(firstArray, secondArray, resultArray, userChoice1, userChoice2);
                    break;

                }
        }
    }
    (int nelements1, int nelements2, int sUserChoice) ReadInformation(int nFirstArray, int nSecondArray)
    {
        PrintLine(" Choose the number of elements from first array you want to merge");
        int nelements1 = ReadLineInt();
        PrintLine(" Choose the number of elements from secound array you want to merge");
        int nelements2 = ReadLineInt();
        PrintLine("Do you want to 1-start with the first element or the 2-last?");
        int sUserChoice = ReadLineInt();
        bool isvaliedt = true;
        while (isvaliedt)
        {
            if (!(sUserChoice < 3 && sUserChoice > 0))
            {
                PrintLine("pleas enter number between 1 and 2");
                sUserChoice = ReadLineInt();
            }
            else if (nelements1 > nFirstArray)
            {
                PrintLine($"Please enter a number lower than {nFirstArray}");
                nelements1 = ReadLineInt();
            }
            else if (nelements2 > nSecondArray)
            {
                PrintLine($"Please enter a number lower than {nSecondArray}");
                nelements2 = ReadLineInt();
            }
            else isvaliedt = false;

        }
        return (nelements1, nelements2, sUserChoice);
    }
    void MergeFromStart(int[] firstArray, int[] secondArray, int[] resultArray, int nelements1, int nelements2)
    {

        int index = resultArray.Length - 1;
        for (int i = 0; i < (nelements1); i++)
        {
            resultArray[i] = firstArray[i];

        }
        for (int i = nelements2 - 1; i >= 0; i--)
        {
            resultArray[index] = secondArray[i];
            index--;
        }
    }
    void MergeArrayFromEnd(int[] firstArray, int[] secondArray, int[] resultArray, int nelements1, int nelements2)
    {




        for (int i = 0; i < (nelements1); i++)
        {
            resultArray[(nelements1 - 1) - i] = firstArray[(firstArray.Length - 1) - i];

        }
        for (int i = 0; i < nelements2; i++)
        {
            resultArray[(resultArray.Length - 1) - i] = secondArray[(secondArray.Length - 1) - i];

        }
    }

}
void CopyFromEndProgram()
{
    WelcomeApp("Welcome to the copy from end program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    int[] firstArray = new int[nFirstArray];
    ReadArray(firstArray);
    PrintLine("Enter the number of items you want to copy ");
    int nNewlength = ReadLength();
    int[] resultArray = new int[nNewlength];
    CopyFromEnd(firstArray, resultArray);
    PrintLine("the new array");
    Printarray(resultArray);
    int ReadLength()
    {
        int nNewLength = 0;
        do
        {
            if (nNewLength > nFirstArray)
            {
                PrintLine($"Please enter a number less than {nFirstArray}");
            }
            nNewLength = ReadLineInt();
        } while (nNewLength > nFirstArray);
        return nNewLength;
    }
    void CopyFromEnd(int[] firstArray, int[] resultArra)
    {
        int index = firstArray.Length - 1;
        for (int i = resultArra.Length - 1; i >= 0; i--)
        {
            resultArra[i] = firstArray[index];
            index--;
        }
    }

}
void DifferentNumbers()
{
    WelcomeApp("Welcome to the copy from end program");
    int[] Array1 = new int[5] { 1, 2, 3, 4, 5 };
    int[] Array2 = new int[5] { 4, 5, 6, 7, 8 };
    int[] result = new int[Array1.Length];

    int counter = 0;
    int Index = 0;
    for (int i = 0; i < Array1.Length; i++)
    {
        counter = 0;
        foreach (int j in Array2)
        {
            if (Array1[i] == j)
            {
                counter++;
                break; ;

            }
        }
        if (counter == 0)
        {
            result[Index] = Array1[i];
            Index++;
        }


    }
    for (int i = 0; i < Index; i++)
    {

        PrintLine($"{result[i]}");
    }

}
void UnionTwoArray()
{
    ///<summary>
    ///Program description:
    /// The user can enter numbers into the first 
    /// array and the second array.The program ignores duplicate 
    /// numbers and prints all numbers without repetition.
    ///Duplicate numbers entered within the first array are also ignored.
    ///Duplicate numbers between the two arrays are ignored as well.
    ///</summary>
    WelcomeApp("Welcome to the Union Two Array program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    PrintLine("Pleas enter length SecondArray");
    int nSecondArray = ReadLineInt();
    int[] firstArray = new int[nFirstArray];
    int[] secondArray = new int[nSecondArray];
    ReadArray(firstArray);
    ReadArray(secondArray);
    int[] resultArray = new int[(firstArray.Length + secondArray.Length)];
    int index = MergeArray(firstArray, secondArray, resultArray);
    Printarra1y(resultArray, index, firstArray.Length);
    Console.ReadKey();

    ///<summary>
    ///This method prints two arrays into a new array.
    ///</summary>
    int MergeArray(int[] firstArray, int[] secondArray, int[] resultArray)
    {
        bool IsFound1 = true;
        int counter = 0;
        for (int i = 0; i < firstArray.Length; i++)
        {
            IsFound1 = true;
            FindingTheFrequency(firstArray, i);
            if (IsFound1)
            {
                resultArray[counter] = firstArray[i];
                counter++;
            }
        }
        for (int i = 0; i < secondArray.Length; i++)
        {
            bool IsFound = Comparison2(resultArray, secondArray, counter, i);
            if (IsFound)
            {
                resultArray[counter] = secondArray[i];
                counter++;
            }
        }
        return counter;
    }
    ///<summary>
    ///This method compares the array to itself to determine if there are duplicate numbers.
    ///</summary>
    bool FindingTheFrequency(int[] array, int i)
    {
        bool IsFound = true;
        // Here we used 'i' so that the loop doesn't completely
        // wrap around the elements.
        // We always want to look at what came before to see
        // if the number we have now exists before or not.
        for (int L = 0; L < i; L++)
        {
            if (firstArray[i] == firstArray[L])
            {
                IsFound = false;
                break;
            }

        }
        return IsFound;
    }
    ///<summary>
    ///TThis method compares two different arithms to determine if there is a duplicate number..
    ///</summary>
    bool Comparison2(int[] Array1, int[] Array2, int i, int k)
    {
        bool IsFound = true;
        IsFound = true;
        for (int L = 0; L < i; L++)
        {
            if (Array2[k] == Array1[L])
            {
                IsFound = false;
                break;
            }
        }
        return IsFound;
    }
    ///<summary>
    ///It prints the array
    ///</summary>
    void Printarra1y(int[] resultArray, int length, int firstArrayl)
    {
        for (int i = 0; i < length; i++)
        {
            PrintLine($"{resultArray[i]}");
        }
    }

}
void IntersectionTwoArray()
{
    WelcomeApp("Welcome to the Union Two Array program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    PrintLine("Pleas enter length SecondArray");
    int nSecondArray = ReadLineInt();
    int[] FirstArray = new int[nFirstArray];
    int[] SecondArray = new int[nSecondArray];
    ReadArray(FirstArray);
    ReadArray(SecondArray);
    int[] result = new int[nFirstArray];

    int index = SubscriberNumber(FirstArray, SecondArray, result);
    Printarray(result, index);
    ///<summary>
    ///This method copies the duplicate numbers into a new array.
    ///</summary>
    int SubscriberNumber(int[] FirstArray, int[] SecondArray, int[] result)
    {
        int index = 0;
        bool IsFound = true;
        for (int i = 0; i < FirstArray.Length; i++)
        {
            IsFound = comparison(FirstArray, SecondArray, i);
            if (IsFound)
            {
                result[index] = FirstArray[i];
                index++;
            }
        }
        return index;
    }
    ///<summary>
    ///It prints.
    ///</summary>
    void Printarray(int[] resultArray, int length)
    {
        for (int i = 0; i < length; i++)
        {
            PrintLine($"{resultArray[i]}");
        }
    }
    ///<summary>
    ///This method checks whether the number we want to print
    ///has already been added to the new array or not.
    ///If it already exists, it detects it so that it is not added twice.
    ///</summary>
    bool DetectingDuplication(int[] FirstArray, int[] result, int i)
    {
        bool IsFound = true;
        for (int l = 0; l < i; l++)
        {
            if (FirstArray[i] == result[l])
            {
                IsFound = false;
                break;
            }
        }
        return IsFound;

    }
    ///<summary>
    ///This method detects duplicates between the first and the second method,
    ///and if a duplicate is found, it is printed.
    ///</summary>
    bool comparison(int[] FirstArray, int[] SecondArray, int i)
    {
        bool IsFound = true;
        for (int j = 0; j < SecondArray.Length; j++)
        {
            if (FirstArray[i] == SecondArray[j])
            {
                for (int l = 0; l < i; l++)
                {
                    IsFound = DetectingDuplication(FirstArray, result, i);
                }
                break;
            }

        }
        return IsFound;
    }

}
void ascending()
{
    WelcomeApp("Welcome to the asendig  Array program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    int[] Array = new int[nFirstArray];
    ReadArray(Array);
    // bool bIsAscending = AscendingCalcultion(Array);
    bool bIsAscending2 = AscendingCalcultion2(Array);

    if (!bIsAscending2)
    {
        PrintLine("this array is no asending");
    }
    else PrintLine("this array is asending");
    bool AscendingCalcultion(int[] Array)
    {

        for (int i = 0; i < Array.Length - 1; i++)
        {
            if (Array[i] > Array[i + 1])
                return false;
        }
        return true;
    }
    bool AscendingCalcultion2(int[] Array)
    {
        int nTemp = 0;
        foreach (int i in Array)
        {
            if (!(nTemp < i))
            {
                return false;
            }
            nTemp = i;
        }
        return true;
    }



}
void sorting()
{
    WelcomeApp("Welcome to the Union Two Array program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    int[] Array = new int[nFirstArray];
    ReadArray(Array);
    bool bIslower = false;
    int index = 0;
    int largst = 0;
    do
    {
        bIslower = false;
        index = 0;
        for (int i = 0; i < (Array.Length - 1); i++)
        {
            index++;
            if (Array[i] > Array[index])
            {
                largst = Array[i];
                Array[i] = Array[index];
                Array[index] = largst;
                bIslower = true;
            }
        }
    } while (bIslower);
    Printarray(Array);

}
void RemoveAnElement()
{
    WelcomeApp("Welcome to the  vemove element of Array program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    int[] Array = new int[nFirstArray];
    ReadArray(Array);
    int[] result = new int[nFirstArray];
    PrintLine("Pleas enter number of remove");
    int nUserChoice = ReadLineInt();
    //int i = RemovCalculation(array, result);
    RemovCalulation2(Array, nUserChoice);
    Printarray2(Array, (Array.Length - 1));
    int RemovCalculation(int[] Array, int[] result)
    {
        int i = 0;
        PrintLine("Pleas enter number of remove");
        int nUserChoice = ReadLineInt();

        foreach (int value in Array)
        {
            if (nUserChoice == value)
                continue;
            result[i] = value;
            i++;
        }
        return i;
    }
    void RemovCalulation2(int[] Array, int index)
    {
        for (int i = index; i < Array.Length - 1; i++)
        {
            Array[i] = Array[i + 1];
        }

    }
}
void InsertAnElment()
{
    WelcomeApp("Welcome to the  insert an element of Array program");
    PrintLine("Pleas enter length FirstArray");
    int nFirstArray = ReadLineInt();
    int[] Array = new int[nFirstArray];
    ReadArray(Array);
    PrintLine("Pleas enter number of insert");
    int nUserChoice = ReadLineInt();
    PrintLine("Pleas enter index of insert");
    int index = ReadLineInt();
    int[] result = new int[nFirstArray + 1];
    //for (int i = (nFirstArray); i>0;i--)
    //{
    //    if (i== index)
    //    { 
    //        Array[i] = nUserChoice;
    //        break;

    //    }else
    //    {
    //        Array[i] = Array[i - 1];
    //    }
    //}
    for (int i = 0; i < result.Length; i++)
    {

        if (i == index)
        {
            result[i] = nUserChoice;


        }
        else
        {
            result[i] = Array[i];
        }
    }
    Printarray(result);
}
void RotatArray()
{
    int[] array = new int[5] { 1, 2, 3, 4, 5 };
    int[] Result = new int[array.Length];
    int index = 0;
    int index2 = 0;
    PrintLine("Pleas enter number of insert");
    int nUserChoice = ReadLineInt();
    for (int i = nUserChoice; i < Result.Length; i++)
    {
        Result[index] = array[i];
        index++;
    }
    for (int i = index; i < Result.Length; i++)
    {
        Result[i] = array[index2];
        index2++;
    }

}


#endregion
#region Ganeral Method
void Menu()
{
    bool isExit=true;    
    while (isExit)
    {

        Console.Clear();    
        PrintLine(
        """
    ======================================
                    Menu 
    ======================================
    Please choose a program number:
    1 - Merge Array
    2 - Copy From End Program
    3 - Different Numbers
    4 - Union Two Array
    5 - Intersection Two Array
    6 - Check Ascending Array
    7 - Sorting Array
    8 - Remove An Element
    9 - Insert An Element
    10 - Rotate Array
    11 - Exit
    ===========================================
    pleas enter your choice 
    """
    );
        int Userchoice = ReadLineInt();
 
        switch (Userchoice)
        {
            case 1:
                {
                    MergeArray();
                    Console.ReadKey();
                    break;
                }
            case 2:
                {
                    CopyFromEndProgram();
                    Console.ReadKey();
                    break;
                }
            case 3:
                {
                    DifferentNumbers();
                    Console.ReadKey();
                    break;
                }
            case 4:
                {
                    UnionTwoArray();
                    Console.ReadKey();
                    break;
                }
            case 5:
                {
                    IntersectionTwoArray();
                    Console.ReadKey();

                    break;
                }
            case 6:
                {
                    ascending();
                    Console.ReadKey();

                    break;
                }
            case 7:
                {
                    sorting();
                    Console.ReadKey();

                    break;
                }
            case 8:
                {
                    RemoveAnElement();
                    Console.ReadKey();

                    break;
                }
            case 9:
                {
                    InsertAnElment();
                    Console.ReadKey();

                    break;
                }
            case 10:
                {
                    RotatArray();
                    Console.ReadKey();

                    break;
                }
            case 11:
                {
                    isExit=false;
                    break;
                }
        }
    }
}
void WelcomeApp(string text)
{
    Console.Clear();
    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
    Console.WriteLine(text);
    Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");

}
void PrintLine(string text)
{
    Console.WriteLine("==================================");
    Console.WriteLine(text);
    Console.WriteLine("==================================");

}
void PrintResult(string text)
{
    Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+");
    Console.WriteLine(text);
    Console.WriteLine("=+=+=+=+=+=+Press Enter =+=+=+=+=+=+");
    Console.ReadKey();
}
int ReadLineInt()
{
    int value;
    while (!int.TryParse(Console.ReadLine(), out value))
    {
        PrintLine("Invalid Number");
    }
    return value;
}
void ReadArray(int[] array)
{
    PrintLine("pleas enter numbers");
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = ReadLineInt();
    }
}
string ReadLineString()
{
    while (true)
    {
        bool isValid = true;
        string value = Console.ReadLine();
        foreach (char value1 in value)
        {
            if (!char.IsLetter(value1))
            {
                isValid = false;
                break;
            }
        }
        if (isValid)
            return value;
        PrintLine("Invalid input, letters only");

    }

}
void Printarray(int[] resultArray)
{
    for (int i = 0; i < resultArray.Length; i++)
    {
        PrintLine($"{resultArray[i]}");
    }
}
void Printarray2(int[] resultArray, int length)
{
    for (int i = 0; i < length; i++)
    {
        PrintLine($"{resultArray[i]}");
    }
}


#endregion

