using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace CMP1001M_SD_A1___Text_Anlysis_Program
{
    public static class Program
    {
        public static class MainClass
        {
            public static void Main()
            {
                //welcome text
                Console.WriteLine("\t\t\tText Analysis Program");
                Console.WriteLine("\nThis program will output the frequency of individual letters, sentences,\nvowels, consonants, uppercase letters, lower case letters\nand digits of any text entered.");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("\nDo you want to enter the text via keyboard? (press 'k') \nOr do you want to read text from a file? (press 'f')");

                Variables.option_entered = Console.ReadLine();

                if (Variables.option_entered == "k" || Variables.option_entered == "K")
                {

                    Console.WriteLine("\nYou have selected to enter via keyboard. \nPlease enter your text now and press enter when you are finished.");
                    Console.WriteLine("\nUse either full stops, exclamation marks or question marks to \nsignal the end of a sentence.\n");
                    Variables.text_entered = Console.ReadLine();
                    Console.WriteLine("----------------------------------------------------------\n");

                    //calls all of the methods used (except LongWords())
                    Calculations.LetterFrequency();
                    Calculations.NumOfSentences();
                    Calculations.NumOfConsonants();
                    Calculations.NumOfVowels();
                    Calculations.NumOfUpperCase();
                    Calculations.NumOfLowerCase();
                    Calculations.NumOfDigits();
                    Calculations.DisplayCalculations();
                    Console.ReadLine();

                }

                {
                    if (Variables.option_entered == "f" || Variables.option_entered == "F")
                    {
                        //exception handling
                        try
                        {
                            Console.WriteLine("\nYou have selected to read from a file. \nPlease enter the file's location.\n");
                            Variables.text_entered = File.ReadAllText(Console.ReadLine());
                            Console.WriteLine("\nPlease select the output destination for the Long Words\n");
                            Variables.long_words_output = Console.ReadLine();
                            Console.WriteLine("\nFile text: \n\n{0}", Variables.text_entered);
                            Console.WriteLine("----------------------------------------------------------\n");
                        }
                        //file not found is the only exception that can happen here
                        catch (Exception NoFile)
                        {
                            Console.WriteLine("\n" + NoFile.Message);
                            Console.WriteLine("Please try again\n");
                            Console.WriteLine("----------------------------------------------------------\n");
                            Main();
                        }
                        {
                            Calculations.LetterFrequency();
                            Calculations.NumOfSentences();
                            Calculations.NumOfConsonants();
                            Calculations.NumOfVowels();
                            Calculations.NumOfUpperCase();
                            Calculations.NumOfLowerCase();
                            Calculations.NumOfDigits();
                            Calculations.LongWords();
                            Calculations.DisplayCalculations();
                            Console.WriteLine("\n\nAny long words found have been outputted to " + @"C:\Users\Ryan\Desktop\LongWords.txt");
                            Console.ReadLine();
                        }
                    }

                    else Console.WriteLine("\nInvalid input, please try again\n");
                    Console.WriteLine("----------------------------------------------------------\n");
                    {
                        //using recursion for error handling - this will restart the program
                        Main();

                    }
                }
            }

            //I have created an individual class for all of the calculations that the program will be carrying out
            public class Calculations
            {
                //method to calculate the number of sentences
                public static int NumOfSentences()
                {
                    foreach (char c in Variables.text_entered)
                    {
                        if (c == '.' || c == '?' || c == '!')
                        {

                            Variables.num_of_sentences++;
                        }
                    }
                    return Variables.num_of_sentences;
                }

                //method to count the number of vowels
                public static int NumOfVowels()
                {
                    foreach (char v in Variables.text_entered)
                    {


                        if (v == 'a' || v == 'A' || v == 'e' || v == 'E' || v == 'i' || v == 'I'
                            || v == 'o' || v == 'O' || v == 'u' || v == 'U')
                        {
                            Variables.num_of_vowels++;
                        }
                    }
                    return Variables.num_of_vowels;
                }
                //method to count the number of consonants
                public static int NumOfConsonants()
                {
                    foreach (char c in Variables.text_entered)
                    {
                        if (c == 'b' || c == 'B' || c == 'c' || c == 'C' || c == 'd' || c == 'D'
                            || c == 'f' || c == 'F' || c == 'g' || c == 'G' || c == 'h' || c == 'H'
                            || c == 'j' || c == 'J' || c == 'k' || c == 'K' || c == 'l' || c == 'L'
                            || c == 'm' || c == 'M' || c == 'n' || c == 'N' || c == 'p' || c == 'P'
                            || c == 'q' || c == 'Q' || c == 'r' || c == 'R' || c == 's' || c == 'S'
                            || c == 't' || c == 'T' || c == 'v' || c == 'V' || c == 'w' || c == 'W'
                            || c == 'x' || c == 'X' || c == 'y' || c == 'Y' || c == 'z' || c == 'Z')
                        {

                            Variables.num_of_consonants++;
                        }
                    }
                    return Variables.num_of_consonants;
                }

                //method for counting the number of uppercase letters
                public static int NumOfUpperCase()
                {
                    for (int i = 0; i < Variables.text_entered.Length; i++)
                    {
                        //Counting the number of uppercase letters using the IsUpper function
                        if (char.IsUpper(Variables.text_entered[i]))
                        {
                            Variables.num_of_uppercase++;
                        }
                    }
                    return Variables.num_of_uppercase;
                }

                //method for counting the number of lowercase letters
                public static int NumOfLowerCase()
                {
                    for (int i = 0; i < Variables.text_entered.Length; i++)
                    {
                        //Counting the number of lowercase letters using the IsLower function
                        if (char.IsLower(Variables.text_entered[i]))
                        {
                            Variables.num_of_lowercase++;
                        }
                    }
                    return Variables.num_of_lowercase;
                }

                //method to cound the number of digits
                public static int NumOfDigits()
                {

                    foreach (char d in Variables.text_entered)

                        if (char.IsDigit(d))
                        {
                            Variables.num_of_digits++;
                        }
                    return Variables.num_of_digits;
                }

                //method for counting and outputting the frequency of each individual letter
                //(Dotnetpeals, date unknown)


                public static void LetterFrequency()
                {
                    {
                        foreach (char t in Variables.text_entered)
                        {
                            Variables.frequency[(int)t]++;
                        }
                        for (int i = 0; i < (int)char.MaxValue; i++)


                            if (Variables.frequency[i] > 0 && char.IsLetter((char)i))
                            {
                                Console.WriteLine("Letter {0} frequency: {1}", (char)i, Variables.frequency[i]);
                            }
                    }
                }

                //method to count the number of long words
                public static void LongWords()
                {
                    //using Regular Expressions to strip the text entered of punctuation
                    //[^\w\s] finds any character that is not a word or space character
                    //I have then replaced these characters with "" (nothing)
                    //(Stackoverflow, 2011)


                    string trimmedWord = Regex.Replace(Variables.text_entered, @"[^\w\s]", "");

                    //this splits the trimmed word up every time a space character is found and then stores the substrings in an array

                    string[] splitWord = trimmedWord.Split(' ');

                    //checking the length of the invividual substrings
                    foreach (string s in splitWord)
                    {
                        if (s.Length >= 7)
                        {
                            
                            Console.WriteLine(s);
                            File.AppendAllText(Variables.long_words_output, s + " ");
                        }
                    }
                }


                //void method to display the results of the calculations 
                public static void DisplayCalculations()
                {
                    Console.WriteLine("\nNumber of sentences = {0}", Variables.num_of_sentences);
                    Console.WriteLine("\nNumber of vowels = {0}", Variables.num_of_vowels);
                    Console.WriteLine("\nNumber of consonants = {0}", Variables.num_of_consonants);
                    Console.WriteLine("\nNumber of upper case letters = {0}", Variables.num_of_uppercase);
                    Console.WriteLine("\nNumber of lower case letters = {0}", Variables.num_of_lowercase);
                    Console.WriteLine("\nNumber of digits = {0}", Variables.num_of_digits);
                }
            }

            //Declaring variables at in a public class so they can be easily used throughout the program
            public static class Variables
            {
                //each individual variable is declared as public static

                public static int num_of_sentences = 0;
                public static int num_of_vowels = 0;
                public static int num_of_consonants = 0;
                public static int num_of_lowercase = 0;
                public static int num_of_uppercase = 0;
                public static int num_of_digits = 0;
                public static int[] frequency = new int[(int)char.MaxValue];
                public static string text_entered;
                public static string option_entered;
                public static string long_words_output;
            }
        }
    }
}