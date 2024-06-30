using System;
using System.Net.NetworkInformation;
class Program
{
    static void Main()
    {
        string[] array = { "banana", "apple", "pen" };
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (Compare(array[j], array[j + 1]) > 0)
                {
                    string temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        foreach (string e in array)
        {
            Console.WriteLine(e);
        }
    }

    static int Compare(string str1, string str2)
    {
        int minLength = Math.Min(str1.Length, str2.Length);
        for (int i = 0; i < minLength; i++)
        {
            if (str1[i] != str2[i])
            {
                return str1[i].CompareTo(str2[i]);
            }
        }
        return str1.Length.CompareTo(str2.Length);
    }
}

class InsertionSort
{
    static int[] InsertSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (arr[j - 1] > arr[j - 1])
                {
                    int temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                }
                else
                {
                    break;
                }
            }
        }
        return arr;
    }
}
