using System;
// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to
public class RotationalCipher
{

    static void Main(String[] args)
    {
        //Console.WriteLine(rotationalCipher("Znirav-64", 3));
        Console.WriteLine(ReverseWords("Nirav Patel"));
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