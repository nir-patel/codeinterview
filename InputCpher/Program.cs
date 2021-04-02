using System;
using System.Collections.Generic;
using System.Linq;
// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to
public class RotationalCipher
{

    static void Main(String[] args)
    {
        Console.Write("Enter rotation number:");
        int ip = int.Parse(Console.ReadLine());
        Console.WriteLine(rotationalCipher("nirav-649", ip));
        //Console.WriteLine(ReverseWords("Nirav Patel"));

        Longestsubstring("abcdabcdabcdefg");
    }

    private static void Longestsubstring(string str)
    {
        // abcdedkiuytreml
        string temp = string.Empty;
        Dictionary<string, int> strlookup = new Dictionary<string, int>();
        foreach(var c in str.ToCharArray())
        {

            if (!temp.Contains(c))
            {
                temp += c;
            }
            else
            {
                if (!strlookup.ContainsKey(temp))
                {
                    strlookup.Add(temp, temp.Length);
                }
                temp = string.Empty;
                temp += c;
            }
            
        }
        if (!strlookup.ContainsKey(temp))
        {
            strlookup.Add(temp, temp.Length);
        }
        string substr = strlookup.Keys.Max();
        Console.WriteLine($"Longest substring {substr}");

    }

    private static string rotationalCipher(String input, int rotationFactor)
    {

        string abcd = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "0123456789";
        int index;
        string result = "";

        foreach (char c in input.ToLower())
        {
            index = -1;
            if (abcd.Contains(c))
            {
                index = abcd.IndexOf(c);
                index = index + rotationFactor;
                if (index > 25)
                {
                    index = index - 25 - 1;
                }
                result = result + abcd[index];

            }
            else if (numbers.Contains(c))
            {
                index = numbers.IndexOf(c);
                index = index + rotationFactor;
                if (index > 9)
                {
                    index = index - 9 - 1;
                }
                result = result + numbers[index];

            }
            if (index == -1)
            {
                result = result + c;
            }

        }
        return result;
    }


    private static string ReverseWords(string s)
    {
        string op="";


        string[] words = s.Split(" ");
        foreach(string w in words)
        {
            for(int i = w.Length - 1; i>= 0; i--)
            {
                op = op + w[i];
            }
            op = op + " ";
        }

        return op;
    }


}