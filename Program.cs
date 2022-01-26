using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

string PATH = @"C:\Users\Александр\Desktop\GG.txt";
string STR;
FileReading(PATH);
TakingPercantage(MakingString(STR));

void FileReading(string PATH)
{
    using (StreamReader sr = new StreamReader(PATH))
    {
        STR = sr.ReadToEnd();
    }
}
List<string> MakingString(string str)
{
    List<string> words = new List<string>();
    StringBuilder word = new StringBuilder();
    foreach (var item in str)
    {
        if ((Convert.ToString(item) == " ") || (Convert.ToString(item) == ",") || (Convert.ToString(item) == ".")
            || (Convert.ToString(item) == "\t") || (Convert.ToString(item) == "?") || (Convert.ToString(item) == "!"))
        {
            words.Add(word.ToString());
            word.Clear();
        }
        else
        {
            word.Append(item);
        }
    }

    return (words);
}
void TakingPercantage(List<string> words)
{
    const string ruVowels = "АаЕеЁёИиОоУуЫыЭэЮюЯя";
    decimal maxPer = 0;
    string maxPerWord = "";

    foreach (var item in words)
    {
        decimal k = 0;
        decimal kV = 0;

        foreach (var letter in item)
        {
            k += 1;
            if (ruVowels.Contains(letter))
            {
                kV += 1;
            }

        }
        try
        {
            decimal currectPer = kV / k;
            if (currectPer > maxPer)
            {
                maxPer = currectPer;
                maxPerWord = item;
            }
        }
        catch
        {

        }
    }
    string Percantage = string.Format("{0:0.00}", maxPer * 100) + "%";
    Console.WriteLine(maxPerWord + " " + Percantage);
}