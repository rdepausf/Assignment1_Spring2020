using System;
using System.Collections.Generic;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t + '\n');

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            //string[] words = new string[] { "bat", "tab", "cat" };
        PalindromePairs(words);

            Stones(5);


        }


        private static void PrintPattern(int n)
        {
            try
            {
                //Check if value entered is greater than or equal to 1.
                if ( n <=0)
                {
                    Console.WriteLine("Please enter a integer greater than or equal to 1");
                    Console.WriteLine();
                    return;
                }

                //outer loop to go from 1 to integer n to print each row
                for (int i =1; i <=n; i++)
                    {
                    string a = null;
                    //inner loop to prepare string to be printed for each row.
                    for (int j=n-i+1; j>=1; j--)
                    {
                        a += j.ToString();
                    }
                    Console.WriteLine(a);
                }

                Console.WriteLine();

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }

        private static void PrintSeries(int n2)
        {
            try
            {

                //Check if value entered is greater than or equal to 1.
                if (n2 <= 0)
                {
                    Console.WriteLine("Please enter a integer greater than or equal to 1");
                    Console.WriteLine();
                    return;
                }


                int[] result = new int[n2];

                //loop from 1 to integer value 
                for (int i=1; i<=n2; i++)
                {
                    int sum = 0;

                    //for each i sum from 1 to i.
                    for (int j=1; j <=i; j++)
                    {
                        sum += j;                                
                    }
                    result[i - 1] = sum;
                }

                //print contents in array with comma separator. 
                Console.WriteLine(string.Join(",", result));

                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }

        public static string UsfTime(string s)
        {
            string usf_time = string.Empty;
            try
            {
                //split the time string entered into three elements of array split
                //three elements are hour, min, and seconds with period.
                string[] split = s.Split(':');




                int total_sec = 0;

                //adjust total seconds based on period PM
                //adding 43200 seconds to total_seconds when period PM.
                if (split[2].Substring(2) == "PM")
                    {
                    total_sec = 43200;
                    }                

                //calculate total_sec by multiplying each element in array with
                //appropriate amount of seconds. Hour has 3600 seconds, Minute has
                //60 seconds.
                total_sec += int.Parse(split[0]) * 3600 + int.Parse(split[1]) * 60
                            + int.Parse(split[2].Substring(0, 2));

                //calculating planet USF hour, minute and seconds from earth
                //total seconds. Each U has 2700 F and S has 45F.
                int u_hr = 76535 / 2700;
                int s_min = (76535 - (u_hr * 2700)) / 45;
                int f_sec = 76535 - (u_hr * 2700) - (s_min * 45);

                //print USF planet time
                //Console.WriteLine(u_hr + ":" + s_min + ":" + f_sec);

                usf_time = u_hr + ":" + s_min + ":" + f_sec;

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }

            return usf_time;
        }

        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                //Check if value entered is greater than or equal to 1.
                if (n3 <= 0)
                {
                    Console.WriteLine("Please enter a integer greater than or equal to 1");
                    Console.WriteLine();
                    return;
                }

                string[] str_res = new string[n3];

                for (int i = 1; i <=n3; i++)
                {
                    //check if integer multiple of 3 and 5
                    if ( i % 3 == 0 && i % 5 == 0)
                    {
                        str_res[i-1] = "US";
                    }
                    //check if integer multiple of 5 and 7
                    else if (i % 5 == 0 && i % 7 == 0)
                    {
                        str_res[i-1] = "SF";
                    }
                    //check if integer multiple of 3 and 7
                    else if (i % 3 == 0 && i % 7 == 0)
                    {
                        str_res[i - 1] = "UF";
                    }
                    //checked if integer multiple of 3
                    else if (i % 3 == 0)
                    {
                        str_res[i - 1] = "U";
                    }
                    //check if integer multiple of 5
                    else if (i % 5 ==0)
                    {
                        str_res[i-1] = "S";
                    }
                    //check if integer multiple of 7
                    else if (i % 7 == 0)
                    {
                        str_res[i-1] = "F";
                    }
                    //default store integer value as string
                    else
                    {
                        str_res[i - 1] = i.ToString();
                    }
                }


                //loop through str_res array to print k number of values
                //per row.
                for (int i = 1; i <= n3; i++)
                {
                    if ( i % k == 0)
                    {
                        Console.WriteLine(str_res[i - 1]);
                    }
                    else
                    {
                        Console.Write(str_res[i - 1] + " ");
                    }

                }

                Console.WriteLine();
                //Console.WriteLine(string.Join(",", str_res));

            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }


        public static void PalindromePairs(string[] words)
        {

            if (words.Length == 0 || words.Length == 1)
            {
                Console.WriteLine("Need atleast two words in array for this program");
                Console.WriteLine();
                return;
            }

            //method to check if a string is palindrome
            bool Palindrome(string s)
            {
                //set len variable to string length minus 1
                int len = s.Length - 1;
                //split the string into two parts and compare if each letter
                //starting from left of first part matches with each letter starting
                //from right of second part.
                for (int i = 0; i <= s.Length / 2; i++)
                {
                    if (s[i] != s[len])
                    {
                        return false;
                    }
                    len--;
                }
                return true;
            }

            try
            {
                List<List<int>> result = new List<List<int>>();

                //for each word in the list create a string with combining
                //word with every other word in the list.
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < words.Length; j++)
                    {
                        //skip combining the same word
                        if (i == j)
                        {
                            continue;
                        }

                        string str = words[i] + words[j];

                        //add combination to result if combined string is
                        //palindrome.
                        if (Palindrome(str))
                        {
                            result.Add(new List<int> { i, j });
                        }


                    }

                 
                }

                //loop through list to print the contents of list with required
                //format.
                //example: [[0,1],[1,0]] .

                Console.Write('[');

                int outer_count = 0;
                
                foreach (var p in result)
                {

                    outer_count++;
                    int inner_count = 0;

                    Console.Write('[');
                    foreach (var l in p)
                    {
                        inner_count++;
                        
                        Console.Write(l);

                        //add comma till last element in inner list.
                        if (inner_count < p.Count)
                        {
                            Console.Write(",");
                        }
                    }
                    Console.Write("]");

                    //add comma till last element in outer list.
                    if (outer_count < result.Count)
                    {
                        Console.Write(",");
                    }
                }

                Console.WriteLine("]");

            }

            catch
            {

                Console.WriteLine("Exception occured while computing     PalindromePairs()");
            }
        }

        public static void Stones(int n4)
        {
            try
            {

         



            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }




    }
}
