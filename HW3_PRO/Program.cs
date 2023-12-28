using HW3_PRO;

interface IOutPut
{
    void Show();
    void Show(string info);
}



class MyArray : IOutPut, IMath, ISort 
{
    byte[] array = new byte[10];
    public void ArrInicializ()
    {
        Random random = new Random();
        random.NextBytes(array);
    }

    public void Show()
    {
        foreach (byte item in array)
        {
            Console.WriteLine(item);
        }
    }
    public void Show(string info)
    {
        Console.WriteLine($"{info}");
    }

    public int Max() => array.Max();
    public int Min() => array.Min(); 
    public float Avg()
    {
        float result = 0;
        for(int i = 0; i < array.Length; i++)
        {
            result += array[i];
        }
        return result / array.Length;
    }
    public bool Search(int valueToSearch)
    {
        bool result = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == valueToSearch)
            {
                result = true;
                break;
            }
            else
            {
                result = false;
            }
        }
        return result;
    }      
    public void SortAsc()
    {

        for (int i = 0; i < array.Length; i++) 
        {
            for (int j = 0; j < array.Length - i - 1; j++) 
            {
                if (array[j] > array[j + 1])  
                {
                    byte temp = array[j]; 
                    array[j] = array[j + 1];
                    array[j + 1] = temp;  
                }
            }
        }
        foreach (byte item in array)
        {
            Console.WriteLine(item);
        }

    }
    public void SortDesc()
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                if (array[j] < array[j + 1])
                {
                    byte temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        foreach (byte item in array)
        {
            Console.WriteLine(item);
        }
    }
    public void SortByParam(bool param)
    {
        if(param = true)
        {
            SortAsc();
        }
        else
        {
            SortDesc();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your message for array:");
        string info = Console.ReadLine();
        Console.WriteLine();
        MyArray myArray = new MyArray();
        myArray.ArrInicializ();
        myArray.Show();
        Console.WriteLine();
        Console.Write("Your message: ");
        myArray.Show(info);
        Console.WriteLine();
        Console.WriteLine("Enter value for search in array:");
        int searchValue = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine($"Max value = {myArray.Max()}");
        Console.WriteLine($"Min value = {myArray.Min()}");
        Console.WriteLine($"Avg all element in array = {myArray.Avg()}");
        Console.WriteLine($"Result searching {searchValue} is {myArray.Search(searchValue)}");
        Console.WriteLine();
        Console.WriteLine($"Sort array in Asc");
        myArray.SortAsc();
        Console.WriteLine();
        Console.WriteLine($"Sort array in Desc");
        myArray.SortDesc();
        Console.WriteLine();
        Console.WriteLine("Select type of sort:\nAsc - 1 \nDesc - 2");
        int chooseSort = Convert.ToInt32(Console.ReadLine());
        bool sort;
        if(chooseSort == 1)
        { 
            sort = true; 
        } 
        else 
        { 
            sort = false;
        }
        Console.WriteLine();
        myArray.SortByParam(sort);



    }
}