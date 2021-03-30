using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Globalization;

/// <summary>
/// Alessio Marziali
/// solutions to coding challenges  I have completed on Coderbyte (coding assessment platform)
/// URL : https://coderbyte.com/profile/RegiaMarinaAlex
/// </summary>
namespace CodingChallenges
{
    class Program
    {
        static void Main(string[] args) {
            var b = new int[] { 2, 2, 2, 2 };
            Console.WriteLine(SimpleMode(new int[] { 4, 4, 5, 6, 7, 8, 8, 8, 8, 8 }));
            Console.ReadLine();
        }

        public static int SimpleMode(int[] arr)
        {
            var query = arr.GroupBy(x => x)
           .Where(g => g.Count() > 1)
           .Select(y => y.Key)
           .ToList();
            
            return query.Count >= 1 ? query.First() : 0;
        }

        public static string AlphabetSoup(string str)
        {
            var stringToArray = str.ToCharArray();
            Array.Sort(stringToArray);

            var b = new StringBuilder();

            foreach(var s in stringToArray)
            {
                b.Append(s);
            }

            return b.ToString();
        }

        public static int NumberSearch(string str)
        {
            var ex = new Regex("-*[0-9]");
            var coll = ex.Matches(str);
            var totalSum = 0;

            foreach (Match mtch in coll)
            {
                totalSum += int.Parse(mtch.Value);
            }

            var ex2 = new Regex("[a-zA-Z]");
            var coll2 = ex2.Matches(str);
            var outputNumberColl2 = new List<string>();
            foreach (Match mtch in coll2)
            {
                outputNumberColl2.Add(mtch.Value);
            }

            var output2 = decimal.Parse(totalSum.ToString()) / decimal.Parse(outputNumberColl2.Count.ToString());
            var output = int.Parse(decimal.Round(output2).ToString());
            return output;
        }

        public static string BinaryConverter(string str)
        {
            return Convert.ToInt32(str, 2).ToString();
        }

        public static int Consecutive(int[] arr)
        {
            var a = arr.OrderBy(x => x).First();
            var b = arr.OrderBy(x => x).Last();
            var output = 0;
            var myList2 = Enumerable.Range(a, b - a + 1).ToList();
            output = myList2.Except(arr).ToList().Count;
            return output;
        }

        public static int TripleDouble(int num1, int num2)
        {
            var output = 0;

            /// three in num1 and two in num2
            var firstString = num1.ToString().ToCharArray();
            var secondString = num2.ToString().ToCharArray();

            var query = (from g in firstString.GroupBy(x => x) where g.Count() > 1 select g.Key).ToList();
            var counter = firstString.Where(t => query.Count >= 1).Count(t => t == query.First());
            var secondCounter = 0;

            for (var i = 0; i < secondString.Length; i++)
            {
                if (query.Count < 1) continue;
                if (firstString[i] == query.First())
                {
                    secondCounter++;
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
            var output = a / b;
            return output.ToString("###,###,###.####");
        }

        public static string RunLength(string str)
        {
            var characters = str.ToCharArray();
            var chars = new List<char>(characters.Distinct());
            var stringBuilder = new StringBuilder();
            for (var i =0;i<characters.Length;i++)
            {
                var counter = 0;
                var corrente = characters[i];
                for (var i2 = i+1; i < characters.Length; i++)
                {
                    if (corrente.Equals(characters[i2]))
                    {
                        counter++;
                    }
                }

                switch (counter)
                {
                    case > 1:
                        stringBuilder.Append(counter.ToString() + characters[i].ToString());
                        break;
                    case 1:
                        stringBuilder.Append("1" + characters[i]);
                        break;
                }
            }
            return stringBuilder.ToString();
        }

        public static string RunLengthOld(string str)
        {
            var characters = str.ToCharArray();
            var distinctstr = new List<char>(characters.Distinct());
            var stringBuilder = new StringBuilder();

            foreach (var t in distinctstr)
            {
                var counter = characters.Count(c2 => t.Equals(c2));
                switch (counter)
                {
                    case > 1:
                        stringBuilder.Append(counter.ToString() + t.ToString());
                        break;
                    case 1:
                        stringBuilder.Append("1" + t);
                        break;
                }
            }
            return stringBuilder.ToString();
        }

        public static string DivisionStringified(int num1, int num2)
        {
            var c = 0.0;
           
            if (num1 >= 10 && num1 <=100)
            {

            }

            c = (num1 / num2);

            if (c == 1) { c = 0; }

            var output = c.ToString(CultureInfo.InvariantCulture);

            if (output.Length > 3) { output = $"{c:#,0}"; }
            return output;
        }

        public static string OtherProducts(int[] arr)
        {
            var arrOutput = new List<int>();

            foreach (var rr in arr)
            {
                var inizialeArray = arr.ToList<int>();
                inizialeArray.Remove(rr);

                var total = inizialeArray.Aggregate(1, (current, numero) => current * numero);
                arrOutput.Add(total);
            }

            var b = new StringBuilder();
            foreach(var ccc in arrOutput)
            {
                b.Append(ccc.ToString() + " ");
            }
            var output =  b.ToString().Replace(" ", "-");
            output = output.Remove(output.Length - 1, 1);
            return output;
        }

        public static string FirstReverse(string str)
        {
            var strArrayChar = str.ToCharArray();
            Array.Reverse(strArrayChar);

            var b = new StringBuilder();
            foreach (var c in strArrayChar)
            {
                b.Append(c);
            }
            return b.ToString();
        }


        public static string TreeConstructor(string[] strArr)
        {
            var treeObject = new Dictionary<string, int>();
            var output = string.Empty;
            foreach(var singleInputValue in strArr)
            {
                var currentvalue = singleInputValue.Split(',');
                var parent = currentvalue[1].Remove(currentvalue[1].Length-1,1);
           
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
            var output = "false";
            var a = 0;
            for (var i = 1; i <= num; i++)
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
            var list = new List<char>();
            foreach(var c in str)
            {
                var ex = new Regex("[a-z]");
                if (ex.IsMatch(c.ToString()))
                {
                    var newChar = (char)(c + 1);
                    list.Add(newChar);
                }
                else
                {
                    list.Add(c);
                }    
            }
            
            var b = new StringBuilder();
            foreach(var c1 in list)
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
            return output;
        }

        public static string WordCount(string str)
        {
            return str.Split(" ").Length.ToString();
        }

        public static int SimpleAdding(int num)
        {
            var totalSum = 0;
            for(var i = 0; i<= num; i++)
            {
                totalSum += i; 
            }
            return totalSum;
        }

        public static string LetterCapitalize(string str)
        {
            var text = str.Split(" ");
            var newtext = text.Select(s => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower())).ToList();
            return newtext.First().ToString();
        }

        public static string CountingMinutesI(string str)
        {
            var inputTimes = str.Split("-");
            var firstDate = DateTime.Parse(inputTimes[0]);
            var secondDate = DateTime.Parse(inputTimes[1]);

            if (secondDate < firstDate) { secondDate = secondDate.AddDays(1);}
            var difference = secondDate - firstDate;
            return difference.TotalMinutes.ToString();
        }

        public static string CheckNums(int num1, int num2)
        {
            if (num1 > num2)
            {
                return "true";
            }
            return num1 == num2 ? "-1" : "false";
        }

        public static string TimeConvert(int num)
        {
            var before = DateTime.Now;
                var after = DateTime.Now.AddMinutes(num);
                var timedifference =  after - before;
                var output = timedifference.TotalHours.ToString().Substring(0,1) + ":" + timedifference.Minutes;
           
            return output;
        }

        public static string SecondGreatLow(int[] arr)
        {
            var minimumValue = arr.Min();
            var maxvalue = arr.Max();
            var secondLowest = arr.Where(r => r > minimumValue).OrderBy(r => r);
            var secondHighest = arr.Where(h => h < maxvalue).OrderByDescending(h => h);
            var secondLowestValue = 0; 
            var secondHighestValue = 0;

            if (!secondLowest.Any() && !secondHighest.Any())
            {
                secondLowestValue = arr[0];
                secondHighestValue = arr[1];
            }
            else
            {
                secondLowestValue = secondLowest.First();
                secondHighestValue = secondHighest.First();
            }

            return secondLowestValue + " " + secondHighestValue;
        }

        public static string ArrayAddition(int[] arr)
        {
            var maxValue = arr.Max();
            var sumvalue = 0;
            var filtered = arr.Where(r => r != maxValue);

            var filteredArray = filtered.ToArray<int>();

            foreach(var currentInt in filteredArray)
            {
                sumvalue += currentInt;

                for (var arrIndex = 1; arrIndex < filteredArray.Length; arrIndex++)
                {
                    sumvalue += filteredArray[arrIndex];
                    if (sumvalue == maxValue) 
                    { 
                        return "true"; 
                    }
                }
            }
            return sumvalue == maxValue ? "true" : "false";
        }

        public static string LetterCount(string str)
        {
            var collection = new Dictionary<string, int>();

            var output = string.Empty;
            var ar = str.Split(" ");
            foreach(var s in ar)
            {
                var repetition = s.Length - s.ToCharArray().Distinct().Count();
                collection.Add(s, repetition);
            }

            var result = collection.OrderByDescending(b => b.Value);


            if (result.Any())
            {
                output = result.First().Value > 0 ? result.First().Key : "-1";
            }
            else
            {
                output = "-1";
            }
            return output;           
        }

        public static string VowelCount(string str)
        {
            var counter = 0;
            for (var index = 0; index < str.ToCharArray().Length; index++)
            {
                var c = str.ToCharArray()[index];
                if ("aeiouAEIOU".Contains(c))
                {
                    counter++;
                }
            }
            return counter.ToString();
        }

        static int recursiveCatalan(int n)
        {
            var res = 0;
            if (n <= 1)
            {
                return 1;
            }
            for (var i = 0; i < n; i++)
            {
                res += recursiveCatalan(i) * recursiveCatalan(n - i - 1);
            }
            return res;
        }

        public static string ABCheck(string str)
        {
            var ex = new Regex("a.{3}b");
            return ex.IsMatch(str) ? "true" : "false";
        }
        public static string SimpleSymbols2(string str)
        {
            for (var i = 0; i < str.Length; i++)
            {
                if (!char.IsLetter(str[i])) continue;
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
            return string.Empty;
            
        }
        public static string SimpleSymbols(string str)
        {
            var returnValue = false;
            var ex1 = new Regex("[a-zA-Z]");
            var totalLettersInWord = ex1.Matches(str).Count;

            if (totalLettersInWord == 0)
            {
                return returnValue.ToString(); // false
            }

            var ex2 = new Regex(@"(\x2B[\w]\x2b)");
            var totalCorrectFormat = ex2.Matches(str).Count;

            returnValue = totalLettersInWord == totalCorrectFormat;
            return returnValue.ToString();
        }
        static void ciaociao()
        {
            var args = new string[6];
            args[0] = "5";
            args[1] = "Hi Alex how are you doing";
            args[2] = "hI dave how are you doing";
            args[3] = "Good by Alex";
            args[4] = "hidden agenda";
            args[5] = "Alex greeted Martha by saying Hi Martha";

            var output = string.Empty;
            try
            {
                var ex = new Regex(@"^(H|h)(I|i)\s{1}[^D|d]+.+");
                foreach (var s in args)
                {
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
            var factorial = num;
            for (var i = num-1; i>= 1; i--)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
            return factorial;
        }   
        static void reverse()
        {
            var str = "alessio";
            var strArrayChar = str.ToCharArray();
            Array.Reverse(strArrayChar);

            var b = new StringBuilder();
            foreach(var c in strArrayChar)
            {
                b.Append(c);
            }
            Console.WriteLine(b.ToString());
        }
        static string examMethod5()
        {
            var str = "acc?7??sss?3rr1??????5";
            var stringaArray = str.ToArray();

            var something = 0;

            var startCounting = false;
            var counter = 0;


            foreach (var t in str)
            {
                if (!startCounting)
                {
                    // if you find another number break;
                    var isNumber = new Regex("[0-9]");
                    if (isNumber.IsMatch(t.ToString()))
                    {
                        startCounting = true;
                        continue;
                    }
                }

                if (!startCounting) continue;
                {
                    // if you find another number break;
                    var isNumber = new Regex("[0-9]");
                    if (isNumber.IsMatch(t.ToString()))
                    {
                        break;
                    }

                    // it's a string or number
                    var ex = new Regex("[a-zA-Z0-9]");
                    if (ex.IsMatch(str[1].ToString()))
                    {
                        // do nothing
                    }

                    // question mark
                    var ex2 = new Regex("[\x3F]");
                    if (ex2.IsMatch(t.ToString()))
                    {
                        counter++;
                    }
                }
            }

            return counter == 3 ? "true" : "false";
        }
        static int examMethod4()
        {
            var test = "(coder)(byte))";
            var provasplit = test.ToArray();
            var b = provasplit.Where(pp => pp.Equals('('));
            var c = provasplit.Where(oo => oo.Equals(')'));

            if (!c.Any() && !b.Any())
            {
                return 1;
            }

            return c.Count() == b.Count() ? 1 : 0;
        }
        static string usernamevalidator(string str)
        {
            var test_1 = false;
            var test_3 = false;
            var test_4 = false;
            var test_2 = false;
            
            if (str.Length >= 4 && str.Length <= 25) 
            {
                test_1 = true;
            }

            var b = new Regex("^[a-z]");
            if (b.IsMatch(str))
            {
                test_2 = true;
            }

            var c = new Regex("([a-zA-Z]+)|([0-9]+)|([_]+)");
            if (c.IsMatch(str))
            {
                test_3 = true;
            }

            if (!str.EndsWith("_"))
            {
                test_4 = true;
            }

            var output = string.Empty;

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
            var input = new string[] { "aaffhkksemckelloe", "fhea" };
            var N = input[0];
            var K = input[1];
            for (var i = 1; i < N.Length; i++)
            {
                var prova = N.Substring(0, i);
                var good = 0;
                var bad = 0;

                foreach (var zz in K)
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

                if (good == K.Length) //?
                {
                    var provasplit = prova.ToArray();
                }

            }
            return string.Empty;
        }
        static string examMethod2()
        {
            var input = new string[] { "aaffhkksemckelloe", "fhea" };
            var N = input[0];
            var K = input[1];

            for (var i = 1; i < N.Length; i++)
            {
                var prova = N.Substring(0, i);
                var good = 0;
                var bad = 0;
          
                foreach (var zz in K)
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

            var input = new string[] { "aaffhkksemckelloe", "fhea" };
            var N = input[0];
            var K = input[1];
            var charactersNeeded = new char[K.Length];
            for (var i = 0; i < K.Length; i++)
            {
                charactersNeeded[i] = K[i];
            }

            var totalCharactersINeed            = charactersNeeded.Length;
            var charactersNlookedthrough        = 0;
            var charactersFound                 = 0;

            foreach (var c in N)
            {
                // look into k
                charactersFound += K.Count(c1 => c == c1);
                charactersNlookedthrough++;
                if (charactersFound == totalCharactersINeed)
                {
                    break;
                }
            }

            // I have all the letters I need
            var output = N.Substring(0, charactersNlookedthrough);
            Console.WriteLine(output);
        }
   
    }
}