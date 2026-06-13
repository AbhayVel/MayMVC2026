using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LearningBasics
{

  public  delegate bool Condition(int x);
    public class NumberLogic
    {
        public static bool IsGreaterThan(int x)
        {
            return x > 3;
        }


        public static bool IsLessThan5(int x)=>x<5;
        //{
        //    return x <5;
        //}

        public static int[] GetDataByConditionNumber(int[] array, Condition condition)
        {
            //int[] result = new int[array.Length];

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    count++;
                }
            }

            int[] result = new int[count];

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



        public static int[] GetDataByConditionLessNumber(int[] array, int n)
        {
            //int[] result = new int[array.Length];

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < n)
                {
                    count++;
                }
            }

            int[] result = new int[count];

            int j = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < n)
                {
                    result[j++] = array[i];
                }
            }

            return result;
        }


        public static int[] GetDataByConditionGreateNumber(int[] array, int n)
        {
            //int[] result = new int[array.Length];

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > n)
                {
                    count++;
                }
            }

            int[] result = new int[count];

            int j= 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > n)
                {
                    result[j++] = array[i];
                }
            }

            return result;
        }


        public static void Print(int[] array)
        {
             
            for (int i = 0; i < array.Length; i++)
            {
                
                    Console.WriteLine(array[i]);
                
            }
        }


        public static void PrintNumberIfexists(int[] array,int number)
        {
            Console.WriteLine($"Take record is equal {number}");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    Console.WriteLine(array[i]);
                }
            }
        }
    }
}
