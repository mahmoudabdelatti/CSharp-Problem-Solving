using System;
using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;


//MergeArray();
//CopyFromEndProgram();
//DifferentNumbers();
//UnionTwoArray();

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
        Menu(userChoice.sUserChoice,firstArray, secondArray, resultArray,userChoice.nelements1, userChoice.nelements2);
        PrintLine("the new array");
        Printarray(resultArray);
        Console.ReadKey();
    void Menu(int selectUser, int[] firstArray, int[] secondArray, int[] resultArray,int userChoice1, int userChoice2)
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
   (int nelements1,int nelements2,int sUserChoice) ReadInformation(int nFirstArray,int nSecondArray)
    {
        PrintLine(" Choose the number of elements from first array you want to merge");
        int nelements1 = ReadLineInt();
        PrintLine(" Choose the number of elements from secound array you want to merge");
        int nelements2 = ReadLineInt();
        PrintLine("Do you want to 1-start with the first element or the 2-last?");
        int sUserChoice=ReadLineInt();
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
            } else if (nelements2 > nSecondArray)
            {
                PrintLine($"Please enter a number lower than {nSecondArray}");
                nelements2 = ReadLineInt();
            }else isvaliedt=false;  

        }
        return (nelements1, nelements2, sUserChoice);
    }
    void MergeFromStart(int[] firstArray, int[] secondArray, int[] resultArray,int nelements1,int nelements2)
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
            resultArray[(nelements1-1)-i] = firstArray[(firstArray.Length-1)-i];
         
        }
        for (int i =0; i < nelements2; i++)
        {
            resultArray[(resultArray.Length - 1)-i] = secondArray[(secondArray.Length-1)-i];
           
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
        for (int i = resultArra.Length-1; i >=0;i--)
        {
            resultArra[i] = firstArray[index];
            index--;
        }
    }
    
}
void DifferentNumbers()
{
    WelcomeApp("Welcome to the copy from end program");
int[]Array1= new int[5] {1,2,3,4,5};
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
    Printarra1y(resultArray,index,firstArray.Length);
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
        for (int i = 0;i< secondArray.Length; i++)
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
    bool FindingTheFrequency(int[]array,int i)
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
    bool Comparison2(int [] Array1 , int []Array2, int i,int k)
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
void ReadArray(int[]array)
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


