// See https://aka.ms/new-console-template for more information
        

public delegate bool StringCondition(string x);
public class StringLogic
{
    public static string[] GetDataByConditionString(string[] array, StringCondition condition)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (condition(array[i]))
            {
                count++;
            }
        }

        string[] result = new string[count];

        int j = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (condition(array[i]))
            {
                result[j++] = array[i];
            }
        }

        return result;
    }


    public static void Print(string[] array)
    {

        for (int i = 0; i < array.Length; i++)
        {

            Console.WriteLine(array[i]);

        }
    }
}