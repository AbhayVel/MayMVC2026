// See https://aka.ms/new-console-template for more information


public delegate bool CommonCondition<T>(T x);
public static class CommonLogic
{


    public static IEnumerable<T> GetMyWhere<T>(this IEnumerable<T> array, CommonCondition<T> condition)
    {
        foreach (var item in array)
        {
            if (condition(item))
            {
                yield return item;
            }
        }

    }


    public static IEnumerable<T> GetDataByWhereCondition<T>(this IEnumerable<T> array, CommonCondition<T> condition)
    {
        int count = 0;

        foreach (var item in array)
        {
            if (condition(item))
            {
                count++;
            }
        }
        T[] result = new T[count];

        int j = 0;

        foreach (var item in array)
        {
            if (condition(item))
            {
                result[j++] = item;
            }
        }

        return result;
    }



    public static T[] GetDataByCondition<T>(this T[] array, CommonCondition<T> condition)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (condition(array[i]))
            {
                count++;
            }
        }

        T[] result = new T[count];

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


    public static void Print<T>(this IEnumerable<T> array)
    {
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }

        //for (int i = 0; i < array.Length; i++)
        //{

        //    Console.WriteLine(array[i]);

        //}
    }
}