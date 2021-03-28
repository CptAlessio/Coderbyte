using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Globalization;

/// <summary>
/// Alessio Marziali
/// Project containing coding solutions challenge I have completed on Coderbyte (coding assessment platform)
/// URL : https://coderbyte.com/profile/RegiaMarinaAlex
/// </summary>
namespace CodingChallenges
{
    class Program
    {
        static void Main(string[] args) {
            int[] b = new int[] { 2, 2, 2, 2 };
            Console.WriteLine(SimpleMode(new int[] { 4, 4, 5, 6, 7, 8, 8, 8, 8, 8 }));
            Console.ReadLine();
        }


        public static int SimpleMode(int[] arr)
        {
            var query = arr.GroupBy(x => x)
           .Where(g => g.Count() > 1)
           .Select(y => y.Key)
           .ToList();

            
            if (query.Count >= 1)
            {
               
                return query.First();
            }
            return 0;
        }

        public static string AlphabetSoup(string str)
        {
            char[] stringToArray = str.ToCharArray();
            Array.Sort(stringToArray);

            StringBuilder b = new StringBuilder();

            foreach(char s in stringToArray)
            {
                b.Append(s);
            }

            return b.ToString();
        }

        public static int NumberSearch(string str)
        {
            // Numbers
            Regex ex = new Regex("-*[0-9]");
            MatchCollection coll = ex.Matches(str);

            int totalSum = 0;

            foreach (Match mtch in coll)
            {
                totalSum = totalSum + int.Parse(mtch.Value);
            }

            // letters
            Regex ex2 = new Regex("[a-zA-Z]");
            MatchCollection coll2 = ex2.Matches(str);
            List<string> outputNumberColl2 = new List<string>();
            foreach (Match mtch in coll2)
            {
                outputNumberColl2.Add(mtch.Value);
            }

            decimal output2 = decimal.Parse(totalSum.ToString()) / decimal.Parse(outputNumberColl2.Count().ToString());

            int output = int.Parse(Decimal.Round(output2).ToString());
            return output;
        }

        public static string BinaryConverter(string str)
        {
            //var output = Convert.ToInt32(str, 2).ToString(); ;
            return Convert.ToInt32(str, 2).ToString();
        }

        public static int Consecutive(int[] arr)
        {
            int a = arr.OrderBy(x => x).First();
            int b = arr.OrderBy(x => x).Last();

            int output = 0;

            List<int> myList2 = Enumerable.Range(a, b - a + 1).ToList();
            output = myList2.Except(arr).ToList().Count;

            return output;
        }

        public static int TripleDouble(int num1, int num2)
        {
            int output = 0;

            /// three in num1 and two in num2
            char[] firstString = num1.ToString().ToCharArray();
            char[] secondString = num2.ToString().ToCharArray();

            var query = firstString.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            int counter = 0;
            int secondCounter = 0;

            for (int i =0; i< firstString.Length;i++)
            {
                if (query.Count >= 1)
                {
                    if (firstString[i] == query.First())
                    {
                        counter++;
                    }
                }
            }

            for (int i = 0; i < secondString.Length; i++)
            {
                if (query.Count >=1)
                {
                    if (firstString[i] == query.First())
                    {
                        secondCounter++;
                    }
                }
            }

            if (counter >= 3 && secondCounter >= 2)
            {
                output = 1;
            }
            else
            {
                output = 0;
            }
            return output;
        }

        public static string FormattedDivision(int num1, int num2)
        {
            decimal a = num1, b = num2;
            decimal output = a / b;
            return output.ToString("###,###,###.####");
        }

        public static string RunLength(string str)
        {

            char[] characters = str.ToCharArray();
            var distinctstr = new List<char>(characters.Distinct());            
            StringBuilder stringBuilder = new StringBuilder();
            int counter = 0;
            for (int i =0;i<characters.Length;i++)
            {
                counter = 0;
                char corrente = characters[i];
                for (int i2 = i+1; i < characters.Length; i++)
                {
                    if (corrente.Equals(characters[i2]))
                    {
                        counter++;
                    }
                }

                if (counter > 1)
                {
                    stringBuilder.Append(counter.ToString() + characters[i].ToString());
                }

                if (counter == 1)
                {
                    stringBuilder.Append("1" + characters[i]);
                }

            }
            return stringBuilder.ToString();
        }

        public static string RunLengthOld(string str)
        {
            char[] characters = str.ToCharArray();
            var distinctstr = new List<char>(characters.Distinct());
            StringBuilder stringBuilder = new StringBuilder();

            //foreach (char c in query)
            for (int i = 0; i < distinctstr.Count; i++)
            {
                int counter = 0;
                foreach (char c2 in characters)
                {
                    if (distinctstr[i].Equals(c2))
                    {
                        counter++;
                    }
                }

                if (counter > 1)
                {
                    stringBuilder.Append(counter.ToString() + distinctstr[i].ToString());
                }

                if (counter == 1)
                {
                    stringBuilder.Append("1" + distinctstr[i]);
                }

            }
            // code goes here  
            return stringBuilder.ToString();
        }


        public static string DivisionStringified(int num1, int num2)
        {
            double c = 0.0;
            

            if (num1 >= 10 && num1 <=100)
            {

            }

            c = (num1 / num2);

            if (c == 1) { c = 0; }

            var output = c.ToString();

            if (output.Length > 3) { output = string.Format("{0:#,0}", c); }
            return output;
        }

        public static string OtherProducts(int[] arr)
        {
            var arrOutput = new List<int>();
            var total = 1;
            
            foreach (int rr in arr)
            {
                total = 1;
                List<int> inizialeArray = arr.ToList<int>();
                inizialeArray.Remove(rr);

                foreach(int numero in inizialeArray)
                {
                    total = total * numero;
                    
                }
                arrOutput.Add(total);
            }

            StringBuilder b = new StringBuilder();
            foreach(int ccc in arrOutput)
            {
                b.Append(ccc.ToString() + " ");
            }
            var output =  b.ToString().Replace(" ", "-");
            output = output.Remove(output.Length - 1, 1);
            return output;
        }

        public static string FirstReverse(string str)
        {
            char[] strArrayChar = str.ToCharArray();
            Array.Reverse(strArrayChar);

            StringBuilder b = new StringBuilder();
            foreach (char c in strArrayChar)
            {
                b.Append(c.ToString());
            }
            return b.ToString();
        }


        public static string TreeConstructor(string[] strArr)
        {
            var treeObject = new Dictionary<string, int>();
            var output = string.Empty;
            foreach(string singleInputValue in strArr)
            {
                string[] currentvalue = singleInputValue.Split(',');
                string parent = currentvalue[1].Remove(currentvalue[1].Length-1,1);
           
                if (!treeObject.ContainsKey(parent))
                {
                    treeObject[parent] = 0;
                }
                treeObject[parent] = treeObject[parent] + 1;
                if (treeObject[parent] > 2)
                {
                    return "false";
                }
            }
            return "true";
        }

        public static string PrimeTime(int num)
        {
            string output = "false";
            int a = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    a++;
                }
            }
            if (a == 2)
            {
                output = "true";
            }
            return output;
        }

        public static string LetterChanges(string str)
        {
            // 1. replace every letter with following alphabet
            List<char> list = new List<char>();
            foreach(char c in str)
            {
                Regex ex = new Regex("[a-z]");
                if (ex.IsMatch(c.ToString()))
                {
                    char newChar = (char)(c + 1);
                    list.Add(newChar);
                }
                else
                {
                    list.Add(c);
                }    
            }
            
            StringBuilder b = new StringBuilder();
            foreach(char c1 in list)
            {
                b.Append(c1);
            }
            var output = b.ToString();
            // 2. capitalize every vowel
            output = output.Replace("a", "A");
            output = output.Replace("e", "E");
            output = output.Replace("i", "I");
            output = output.Replace("o", "O");
            output = output.Replace("u", "U");

            // code goes here  
            return output;
        }

        public static string WordCount(string str)
        {
            return str.Split(" ").Length.ToString();
        }

        public static int SimpleAdding(int num)
        {
            int totalSum = 0;
            for(int i = 0; i<= num; i++)
            {
                totalSum += i; 
            }
            return totalSum;
        }


        public static string LetterCapitalize(string str)
        {
            string[] text = str.Split(" ");

            List<string> newtext = new List<string>();
            foreach(string s in text)
            {
                newtext.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower()));
            }
            return newtext.First().ToString();
        }


        public static string CountingMinutesI(string str)
        {
            string[] inputTimes = str.Split("-");
            var firstDate = DateTime.Parse(inputTimes[0]);
            var secondDate = DateTime.Parse(inputTimes[1]);

            if (secondDate < firstDate) { secondDate = secondDate.AddDays(1);}
            TimeSpan difference = secondDate - firstDate;
            return difference.TotalMinutes.ToString();
        }

        public static string CheckNums(int num1, int num2)
        {
            if (num1 > num2)
            {
                return "true";
            }

            if (num1 == num2)
            {
                return "-1";
            }
            return "false";
        }

        public static string TimeConvert(int num)
        {
            string output = string.Empty;
                DateTime before = DateTime.Now;
                DateTime after = DateTime.Now.AddMinutes(num);
                TimeSpan timedifference =  after - before;
                output = timedifference.TotalHours.ToString().Substring(0,1) + ":" + timedifference.Minutes;
           
            return output;
        }

        public static string SecondGreatLow(int[] arr)
        {
            int minimumValue = arr.Min();
            int maxvalue = arr.Max();

            var secondLowest = from r in arr
                               where r > minimumValue
                               orderby r
                               select r;

            var secondHighest = from h in arr
                                where h < maxvalue
                                orderby h descending
                                select h;

            int secondLowestValue = 0; 
            int secondHighestValue = 0;

            if (secondLowest.Count() == 0 && secondHighest.Count() == 0)
            {
                secondLowestValue = arr[0];
                secondHighestValue = arr[1];
            }
            else
            {
                secondLowestValue = secondLowest.First();
                secondHighestValue = secondHighest.First();
            }

            return secondLowestValue.ToString() + " " + secondHighestValue.ToString();
        }

        public static string ArrayAddition(int[] arr)
        {
            int maxValue = arr.Max();
            int minvalue = arr.Min();

            int sumvalue = 0;

            var filtered = from r in arr
                           where r != maxValue
                           select r;

            int[] filteredArray = filtered.ToArray<int>();

            foreach(int currentInt in filteredArray)
            {
                sumvalue += currentInt;

                for (int arrIndex = 1; arrIndex < filteredArray.Length; arrIndex++)
                {
                    sumvalue += filteredArray[arrIndex];
                    if (sumvalue == maxValue) 
                    { 
                        return "true"; 
                    }
                    else
                    {
                        continue;
                    }    
                }
            }

            if (sumvalue == maxValue) { return "true"; } else { return "false";}
            return string.Empty;
        }


        public static string LetterCount(string str)
        {
            Dictionary<string, int> collection = new Dictionary<string, int>();

            int repetition = 0;
            string output = string.Empty;
            string[] ar = str.Split(" ");
            foreach(string s in ar)
            {
                repetition = s.Length - s.ToCharArray().Distinct().Count();
                collection.Add(s, repetition);
            }

            var result = from b in collection
                         orderby b.Value descending                         
                         select b;


            if (result.Count() != 0)
            {
                if (result.First().Value > 0)
                {
                    output = result.First().Key;
                }
                else
                {
                    output = "-1";
                }        
            }
            else
            {
                output = "-1";
            }
            return output;           
        }


        public static string VowelCount(string str)
        {
            int counter = 0;
            foreach(char c in str.ToCharArray())
            {
                if( "aeiouAEIOU".IndexOf(c) >= 0)
                {
                    counter++;
                }
            }
            return counter.ToString();
        }

        static int recursiveCatalan(int n)
        {
            int res = 0;

            if (n <= 1)
            {
                return 1;
            }
            for (int i = 0; i < n; i++)
            {
                res += recursiveCatalan(i) * recursiveCatalan(n - i - 1);
            }
            return res;
        }

        public static string ABCheck(string str)
        {
            Regex ex = new Regex("a.{3}b");
            if (ex.IsMatch(str))
            {
                return "true";
            }
            return "false";
        }
        public static string SimpleSymbols2(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    if (i == 0 || i == str.Length - 1)
                    {
                        // first or last letter auto false
                        return "false";
                    }
                    else
                    {
                        // check before after = +                    
                        if ((str[i-1].ToString().Equals("+")) && (str[i+1].ToString().Equals("+")))
                        {
                            return "true";
                        }
                        else
                        {
                            return "false";
                        }
                    }
                }
            }
            return string.Empty;
            
        }
        public static string SimpleSymbols(string str)
        {
            bool returnValue = false;


            Regex ex1 = new Regex("[a-zA-Z]");
            int totalLettersInWord = ex1.Matches(str).Count;

            if (totalLettersInWord == 0)
            {
                return returnValue.ToString(); // false
            }

            Regex ex2 = new Regex(@"(\x2B[\w]\x2b)");
            int totalCorrectFormat = ex2.Matches(str).Count;

            if (totalLettersInWord == totalCorrectFormat)
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
            }

            return returnValue.ToString();

        }
        static void ciaociao()
        {
            string[] args = new string[6];
            args[0] = "5";
            args[1] = "Hi Alex how are you doing";
            args[2] = "hI dave how are you doing";
            args[3] = "Good by Alex";
            args[4] = "hidden agenda";
            args[5] = "Alex greeted Martha by saying Hi Martha";

            string output = string.Empty;

            try
            {
                foreach (string s in args)
                {
                    Regex ex = new Regex(@"^(H|h)(I|i)\s{1}[^D|d]+.+");
                    if (ex.IsMatch(s))
                    {
                        output = ex.Match(s).Value;
                    }
                }
                
            }
            catch (ArgumentException)
            {
                
            }

            Console.WriteLine(output);
        }
        public static int FirstFactorial(int num)
        {
            int factorial = num;
            for (int i = num-1; i>= 1; i--)
            {
                factorial = factorial * i;
            }

            Console.WriteLine(factorial);
            return factorial;
        }   
        static void reverse()
        {
            string str = "alessio";
            char[] strArrayChar = str.ToCharArray();
            Array.Reverse(strArrayChar);

            StringBuilder b = new StringBuilder();
            foreach(char c in strArrayChar)
            {
                b.Append(c.ToString());
            }
            Console.WriteLine(b.ToString());
        }
        static string examMethod5()
        {
            string str = "acc?7??sss?3rr1??????5";
            char[] stringaArray = str.ToArray();

            int something = 0;

            bool startCounting = false;
            int counter = 0;


            for (int i = 0; i < str.Length; i++)
            {
                if (!startCounting)
                {
                    // if you find another number break;
                    Regex isNumber = new Regex("[0-9]");
                    if (isNumber.IsMatch(str[i].ToString()))
                    {
                        startCounting = true;
                        continue;
                    }
                }

                if (startCounting)
                {

                    // if you find another number break;
                    Regex isNumber = new Regex("[0-9]");
                    if (isNumber.IsMatch(str[i].ToString()))
                    {
                        break;
                    }

                    // it's a string or number
                    Regex ex = new Regex("[a-zA-Z0-9]");
                    if (ex.IsMatch(str[1].ToString()))
                    {
                        // do nothing
                    }

                    // question mark
                    
                    Regex ex2 = new Regex("[\x3F]");
                    if (ex2.IsMatch(str[i].ToString()))
                    {
                        counter++;
                    }
                }
            }

            if (counter == 3)
            {
                return "true";
            }
            else
            {
                return "false";
            }


        }
        static int examMethod4()
        {
            string test = "(coder)(byte))";
            char[] provasplit = test.ToArray();
            var b = from pp in provasplit
                    where pp.Equals('(')
                    select pp;

            var c = from oo in provasplit
                    where oo.Equals(')')
                    select oo;

            if (c.Count() == 0 && b.Count() == 0)
            {
                return 1;
            }

            if (c.Count() == b.Count())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static string usernamevalidator(string str)
        {
            // u__hello_world123
            // test 1 len 4-25

            bool test_1 = false;
            bool test_3 = false;
            bool test_4 = false;
            bool test_2 = false;
            
            if (str.Length >= 4 && str.Length <= 25) 
            {
                test_1 = true;
            }

            Regex b = new Regex("^[a-z]");
            if (b.IsMatch(str))
            {
                test_2 = true;
            }

            Regex c = new Regex("([a-zA-Z]+)|([0-9]+)|([_]+)");
            if (c.IsMatch(str))
            {
                test_3 = true;
            }

            if (!str.EndsWith("_"))
            {
                test_4 = true;
            }

            string output = string.Empty;

            if (test_1 && test_2 && test_3 && test_4)
            {
                output = "true";
            }
            else
            {
                output = "false";
            }

            return output;

        }
        static string examMethod3()
        {
            string[] input = new string[] { "aaffhkksemckelloe", "fhea" };
            string N, K;
            N = input[0];
            K = input[1];
            char[] charactersNeeded = new char[K.Length];
            for (int i = 1; i < N.Length; i++)
            {
                string prova = N.Substring(0, i);
                int good = 0;
                int bad = 0;

                foreach (char zz in K)
                {
                    if (prova.Contains(zz))
                    {
                        good++;
                    }
                    else
                    {
                        bad++;
                    }

                    if (bad > 0)
                    {
                        break;
                    }
                }

                if (good == K.Length)
                {
                    char[] provasplit = prova.ToArray();

                }

            }
            return string.Empty;
        }
        static string examMethod2()
        {
            string[] input = new string[] { "aaffhkksemckelloe", "fhea" };
            string N, K;
            N = input[0];
            K = input[1];

            for (int i = 1; i < N.Length; i++)
            {
                string prova = N.Substring(0, i);
                int good = 0;
                int bad = 0;
          
                foreach (char zz in K)
                {
                    if (prova.Contains(zz))
                    {
                        good++;
                    }
                    else
                    {
                        bad++;
                    }

                    if (bad > 0)
                    {
                        break;
                    }
                }

                if (good == K.Length)
                {
                    return prova;
                }
            }
            return string.Empty;
        }
        static void examMethod() {

            string[] input = new string[] { "aaffhkksemckelloe", "fhea" };
            string N, K;
            N = input[0];
            K = input[1];

            char[] charactersNeeded = new char[K.Length];

            for (int i = 0; i < K.Length; i++)
            {
                charactersNeeded[i] = K[i];
            }

            int totalCharactersINeed            = charactersNeeded.Length;
            int charactersNlookedthrough        = 0;
            int charactersFound                 = 0;

            foreach (char c in N)
            {
                // look into k
                foreach (char c1 in K)
                {
                    if (c == c1)
                    {
                        charactersFound++;
                    }
                }

                charactersNlookedthrough++;
                if (charactersFound == totalCharactersINeed)
                {
                    break;
                }
            }

            // I have all the letters I need
            string output = N.Substring(0, charactersNlookedthrough);
            Console.WriteLine(output);

        }
    
    }
}