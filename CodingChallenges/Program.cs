using System;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// DESCRIPTION: Coderbyte Coding Challenges working project
/// URL : https://coderbyte.com/profile/RegiaMarinaAlex
/// </summary>
namespace CodingChallenges
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("================================");
            Console.WriteLine("  Coding Challenges Workspace   ");
            Console.WriteLine("================================");
            
            Console.WriteLine(ArrayRotation(new int[] {1,1,2}));
            
            Console.ReadLine();
        }
        
        /// <summary>
        /// Solution to challenge ArrayRotation
        /// Algorithms : Hard
        ///
        ///
        /// Have the function ArrayRotation(arr) take the arr parameter being passed which will be an
        /// array of non-negative integers and circularly rotate the array starting from the Nth
        /// element where N is equal to the first integer in the array.
        /// For example: if arr is [2, 3, 4, 1, 6, 10] then your program should rotate the array starting
        /// from the 2nd position because the first element in the array is 2.
        /// The final array will therefore be [4, 1, 6, 10, 2, 3], and your program should return the new
        /// array as a string, so for this example your program would return 4161023. The first element in
        /// the array will always be an integer greater than or equal to 0 and less than the size of the array.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ArrayRotation(int[] arr)
        {
            var rotateBy = arr.First();
            var arrOutputData = new List<int>();

            for (var numberAfter = rotateBy; numberAfter < arr.Length; numberAfter++)
            {
                arrOutputData.Add(arr[numberAfter]);
            }

            for (var numberBefore = 0; numberBefore < rotateBy; numberBefore++)
            {
                arrOutputData.Add(arr[numberBefore]);
            }

            var writer = new StringBuilder();
            foreach (var arrayItem in arrOutputData) { writer.Append(arrayItem); }
            
            return writer.ToString();
        }
        
        /// <summary>
        /// Solution to problem Caesar
        /// Category: Algorithms
        /// Difficult: Medium
        /// 
        /// perform a Caesar Cipher shift on it using the num parameter as the shifting number
        /// Punctuation, spaces, and capitalization should remain intact
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CaesarCipher(string str, int num)
        {
            var strArr = str.ToCharArray();
            var newChars = new List<char>();

            for (int i = 0; i < strArr.Length; i++)
            {
                if (char.IsLetterOrDigit(strArr[i]))
                {
                    char tChar = (char) (strArr[i]+num);
                    newChars.Add(char.IsUpper(strArr[i]) ? char.ToUpper(tChar) : tChar);
                }
                else
                {
                    newChars.Add(strArr[i]);
                }
            }

            StringBuilder bout = new StringBuilder();
            foreach (var c in newChars)
            {
                bout.Append(c);
            }
            return bout.ToString();
        }
        /// <summary>
        /// Overload to get around test cases where num would be passed as string instead of int
        /// </summary>
        /// <param name="str"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CaesarCipher(string str, string num) {
            return CaesarCipher(str, int.Parse(num));
        }
        /// <summary>
        /// Solution to problem BreacketMatcher
        ///
        /// Have the function BracketMatcher(str) take the str parameter being passed and return 1 if
        /// the brackets are correctly matched and each one is accounted for. Otherwise return 0.
        /// For example: if str is "(hello (world))", then the output should be 1, but if str is "((hello (world))"
        /// the the output should be 0 because the brackets do not correctly match up. Only "(" and ")"
        /// will be used as brackets. If str contains no brackets return 1.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string BracketMatcher(string str) {

            char[] strArr = str.ToArray();
            var b = strArr.Where(pp => pp.Equals('('));
            var c = strArr.Where(oo => oo.Equals(')'));
            return !c.Any() && !b.Any() ? "1" : c.Count() == b.Count() ? "1" : "0";
        }
        /// <summary>
        /// Solution to Test - SimplePassword
        /// return true if
        /// 1 - at least one capital letter
        /// 2 - at least one number
        /// 3 - one mathematical symbol or !
        /// 4 - does not have "password" anywhere
        /// 5 - must be longer than 7 characters and smaller than 31
        /// </summary>
        /// <param name="str">Password to test</param>
        /// <returns>true/false</returns>
        public static string SimplePassword(string str)
        {
            var one = false;
            var two = false;
            var three = false;
            var four = false;
            var five = false;

            var case_1 = new Regex("[A-Z]");
            var case_2 = new Regex("[0-9]");
            var case_3 = new Regex(@"(\x21)|(\x2A)|(\x2B)|(\x2D)|(\x2F)|(\x3D)");

            one = case_1.IsMatch(str);
            two = case_2.IsMatch(str);
            three = case_3.IsMatch(str);
            four = str.ToLower().Contains("password") switch { false => true, _ => four};
            five = str.Length switch {> 7 and < 31 => true, _ => five};

            return one switch {true when two && three && four && five => "true", _ => "false"};
        }
        /// <summary>
        /// Solution to Division Challenge
        ///
        /// 
        /// "Find Greatest Common factor, return the greatest number that evenly goes into both numbers
        /// with no remainder." 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static int Division(int num1, int num2) {
            var result1 = from a in Enumerable.Range(1, num1)
                where num1 % a == 0
                select a;

            var num1Numbers = result1.Select(divisor => (divisor)).ToList();

            var result2 = from a in Enumerable.Range(1, num2)
                where num2 % a == 0
                select a;

            var num2Numbers = result2.Select(divisor => (divisor)).ToList();
            
            var merged = (from currentNumber in num1Numbers
                select num2Numbers.Where(number => number == currentNumber)
                into find
                where find.Any()
                select find.First()).ToList();
            
            return merged.Max();
        }
        /// <summary>
        /// Solution to ArrayMatching challenge
        ///
        /// Have the function ArrayMatching(strArr) read the array of strings stored in strArr which will contain
        /// only two elements, both of which will represent an array of positive integers.
        /// For example: if strArr is ["[1, 2, 5, 6]", "[5, 2, 8, 11]"], then both elements in the input
        /// represent two integer arrays, and your goal for this challenge is to add the elements in corresponding
        /// locations from both arrays. For the example input, your program should do the
        /// following additions: [(1 + 5), (2 + 2), (5 + 8), (6 + 11)] which then equals [6, 4, 13, 17].
        /// Your program should finally return this resulting array in a string format with each element
        /// separated by a hyphen: 6-4-13-17.
        /// If the two arrays do not have the same amount of elements, then simply append the remaining
        /// elements onto the new array (example shown below). Both arrays will be in the format: [e1, e2, e3, ...]
        /// where at least one element will exist in each arr
        /// </summary>
        /// <param name="strArr"></param>
        /// <returns></returns>
        public static string ArrayMatching(string[] strArr)
        {
            var one = strArr[0];
            var two = strArr[1];
            Regex ex = new Regex("(,?)[0-9]{1,2}");
            MatchCollection oneExCollection = ex.Matches(one);
            MatchCollection twoExCollection = ex.Matches(two);

            int maxFindings = 0;
            maxFindings = oneExCollection.Count >= twoExCollection.Count
                ? oneExCollection.Count
                : twoExCollection.Count;
            
            int[] arrayOutput = new int[maxFindings];
            
            for (int i = maxFindings - 1; i >= 0; i--)
            {
                var firstValue = 0; 
                var secondValue = 0; 
                try
                {
                    firstValue= int.Parse(oneExCollection[i].Value);
                }
                catch
                {
                    firstValue = 0;
                }
                
                try
                {
                    secondValue = int.Parse(twoExCollection[i].Value);
                }
                catch
                {
                    secondValue = 0;
                }

                arrayOutput[i] = firstValue + secondValue;
            }

            StringBuilder b = new StringBuilder();
            foreach (int i in arrayOutput)
            {
                b.Append(i.ToString()+ "-");
            }

            return b.ToString().Substring(0, b.ToString().Length-1);;
        }
        /// <summary>
        /// Solution to Palindrome challenge
        ///
        /// Have the function Palindrome(str) take the str parameter being passed and return the string true
        /// if the parameter is a palindrome, (the string is the same forward as it is backward)
        /// otherwise return the string false. For example: "racecar" is also "racecar" backwards.
        /// Punctuation and numbers will not be part of the string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Palindrome(string str)
        {
            char[] cInStr = str.ToCharArray();
            Array.Reverse(cInStr);

            StringBuilder b = new StringBuilder();
            foreach (char c in cInStr)
            {
                b.Append(c);
            }
            
            var result = String.CompareOrdinal(str, b.ToString());
            if (result == 0)
            {
                return "true";
            }
            else
            {
                return "false";
            }

        }
        /// <summary>
        /// Solution to ExOh challenge
        ///
        /// Have the function ExOh(str) take the str parameter being passed and return the string true if
        /// there is an equal number of x's and o's, otherwise return the string false.
        /// Only these two letters will be entered in the string, no punctuation or numbers.
        /// For example: if str is "xooxxxxooxo" then the output should return false because
        /// there are 6 x's and 5 o's.
        /// </summary>
        /// <param name="str">Challenge input</param>
        /// <returns>true/false</returns>
        public static string ExOh(string str)
        {
            var output = "false";
            var letter_o = new Regex("[o]");
            var letter_x = new Regex("[x]");

            var mtcO = letter_o.Matches(str);
            var mtcX = letter_x.Matches(str);

            var oCounter = mtcO.Count;
            var xCounter = mtcX.Count;

            if (oCounter.Equals(xCounter))
            {
                output = "true";
            }
            return output;
        }
        /// <summary>
        /// Solution to SimpleMode Challenge
        /// Algorithms : Medium
        /// 
        /// Have the function SimpleMode(arr) take the array of numbers stored in arr and return
        /// the number that appears most frequently (the mode).
        /// For example: if arr contains [10, 4, 5, 2, 4] the output should be 4.
        /// If there is more than one mode return the one that appeared in the array
        /// first (ie. [5, 10, 10, 6, 5] should return 5 because it appeared first).
        /// If there is no mode return -1. The array will not be empty.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int SimpleMode(int[] arr)
        {
            var query = arr.GroupBy(x => x)
           .Where(g => g.Count() > 1)
           .Select(y => y.Key)
           .ToList();
            
            return query.Count >= 1 ? query.First() : 0;
        }
        /// <summary>
        /// Solution to AlphabetSoup challenge
        ///
        /// Have the function AlphabetSoup(str) take the str string parameter being passed and return the string
        /// with the letters in alphabetical order (ie. hello becomes ehllo). Assume numbers and punctuation symbols
        /// will not be included in the string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AlphabetSoup(string str)
        {
            var stringToArray = str.ToCharArray();
            Array.Sort(stringToArray);

            var writer = new StringBuilder();

            foreach(var s in stringToArray)
            {
                writer.Append(s);
            }

            return writer.ToString();
        }
        /// <summary>
        /// Solution to NumberSearch challenge
        /// Algorithms:Medium
        ///
        /// Have the function NumberSearch(str) take the str parameter, search for all the numbers in the string,
        /// add them together, then return that final number divided by the total amount of letters in the string.
        /// For example: if str is "Hello6 9World 2, Nic8e D7ay!" the output should be 2.
        /// First if you add up all the numbers, 6 + 9 + 2 + 8 + 7 you get 32.
        /// Then there are 17 letters in the string. 32 / 17 = 1.882, and the final answer should be rounded
        /// to the nearest whole number, so the answer is 2. Only single digit numbers separated by spaces
        /// will be used throughout the whole string (So this won't ever be the case: hello44444 world).
        /// Each string will also have at least one letter.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Solution to BinaryConverter challenge
        /// Algorithms:Medium
        ///
        /// Have the function BinaryConverter(str) return the decimal form of the binary value.
        /// For example: if 101 is passed return 5, or if 1000 is passed return 8.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string BinaryConverter(string str)
        {
            return Convert.ToInt32(str, 2).ToString();
        }
        /// <summary>
        /// Solution to Consecutive challenge
        /// Algorithms:Medium
        ///
        /// Have the function Consecutive(arr) take the array of integers stored in arr and return the minimum
        /// number of integers needed to make the contents of arr consecutive from the lowest number to the
        /// highest number. For example: If arr contains [4, 8, 6] then the output should be 2 because two
        /// numbers need to be added to the array (5 and 7) to make it a consecutive array of numbers from 4 to 8.
        /// Negative numbers may be entered as parameters and no array will have less than 2 elements.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int Consecutive(int[] arr)
        {
            var first_character = arr.OrderBy(x => x).First();
            var last_character = arr.OrderBy(x => x).Last();
            var output = 0;
            var myList2 = Enumerable.Range(first_character, last_character - first_character + 1).ToList();
            output = myList2.Except(arr).ToList().Count;
            return output;
        }
        /// <summary>
        /// Solution to TripleDouble challenge
        ///
        /// Have the function TripleDouble(num1,num2) take both parameters being passed, and return 1 if there
        /// is a straight triple of a number at any place in num1 and also a straight double of the same
        /// number in num2. For example: if num1 equals 451999277 and num2 equals 41177722899, then return 1
        /// because in the first parameter you have the straight triple 999 and you have a straight double, 99,
        /// of the same number in the second parameter. If this isn't the case, return 0.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static int TripleDouble(int num1, int num2)
        {
            var output = 0;

            var firstString = num1.ToString().ToCharArray();
            var secondString = num2.ToString().ToCharArray();

            var query = (from g in firstString.GroupBy(x => x) 
                where g.Count() > 1 
                select g.Key).ToList();
            
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
            
            if (counter >= 3 && secondCounter >= 2) { output = 1; } else { output = 0;}
            return output;
        }
        /// <summary>
        /// Solution to FormattedDivision challenge
        /// 
        /// Have the function FormattedDivision(num1,num2) take both parameters being passed, divide num1 by num2,
        /// and return the result as a string with properly formatted commas and 4 significant digits after the
        /// decimal place. For example: if num1 is 123456789 and num2 is 10000 the output should be "12,345.6789".
        /// The output must contain a number in the one's place even if it is a zero.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static string FormattedDivision(int num1, int num2)
        {
            decimal firstNumber = num1, secondNumber = num2;
            var output = firstNumber / secondNumber;
            return output.ToString("###,###,###.####");
        }
        /// <summary>
        /// Solution to Runlenght challenge
        /// Algorithms:Medium
        /// 
        /// Have the function RunLength(str) take the str parameter being passed and return a compressed version
        /// of the string using the Run-length encoding algorithm. This algorithm works by taking
        /// the occurrence of each repeating character and outputting that number along with a single character
        /// of the repeating sequence. For example: "wwwggopp" would return 3w2g1o2p.
        /// The string will not contain any numbers, punctuation, or symbols.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RunLength(string str)
        {
            var characters = str.ToCharArray();
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
                        stringBuilder.Append(counter + characters[i].ToString());
                        break;
                    case 1:
                        stringBuilder.Append("1" + characters[i]);
                        break;
                }
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Solution to DivisionStringified challenge
        /// Algorithms:Easy
        /// 
        /// Have the function DivisionStringified(num1,num2) take both parameters being passed,
        /// divide num1 by num2, and return the result as a string with properly formatted commas.
        /// If an answer is only 3 digits long, return the number with no commas (ie. 2 / 3 should output "1").
        /// For example: if num1 is 123456789 and num2 is 10000 the output should be "12,346".
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static string DivisionStringified(int num1, int num2)
        {
            var c = 0.0;
            c = (num1 / num2);

            if (c == 1) { c = 0; }

            var output = c.ToString(CultureInfo.InvariantCulture);

            if (output.Length > 3) { output = $"{c:#,0}"; }
            return output;
        }
        /// <summary>
        /// Solution to OtherProducts challenge
        ///
        /// Have the function OtherProducts(arr) take the array of numbers stored in arr and return a new list
        /// of the products of all the other numbers in the array for each element.
        /// For example: if arr is [1, 2, 3, 4, 5] then the new array, where each location in the new array is
        /// the product of all other elements, is [120, 60, 40, 30, 24]. The following calculations were performed
        /// to get this answer: [(2*3*4*5), (1*3*4*5), (1*2*4*5), (1*2*3*5), (1*2*3*4)]. You should generate this
        /// new array and then return the numbers as a string joined by a hyphen: 120-60-40-30-24. The array will
        /// contain at most 10 elements and at least 1 element of only positive integers.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Solution to FirstReverse challenge
        ///
        /// Have the function FirstReverse(str) take the str parameter being passed and return the
        /// string in reversed order. For example: if the input string is "Hello World and Coders"
        /// then your program should return the string sredoC dna dlroW olleH.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstReverse(string str)
        {
            var strArrayChar = str.ToCharArray();
            Array.Reverse(strArrayChar);

            var writer = new StringBuilder();
            foreach (var c in strArrayChar)
            {
                writer.Append(c);
            }
            return writer.ToString();
        }
        /// <summary>
        /// Solution to TreeConstructor Challenge
        ///
        /// Have the function TreeConstructor(strArr) take the array of strings stored in strArr,
        /// which will contain pairs of integers in the following format: (i1,i2), where i1 represents a
        /// child node in a tree and the second integer i2 signifies that it is the parent of i1.
        /// For example: if strArr is ["(1,2)", "(2,4)", "(7,2)"], then this forms the following tree:
        ///
        /// which you can see forms a proper binary tree. Your program should, in this case, return the string
        /// true because a valid binary tree can be formed. If a proper binary tree cannot be formed with the
        /// integer pairs, then return the string false. All of the integers within the tree will be unique,
        /// which means there can only be one node in the tree with the given integer value.
        /// </summary>
        /// <param name="strArr"></param>
        /// <returns></returns>
        public static string TreeConstructor(string[] strArr)
        {
            var treeObject = new Dictionary<string, int>();
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
        /// <summary>
        /// Solution to PrimeTime challenge
        ///
        /// Have the function PrimeTime(num) take the num parameter being passed and return the string
        /// true if the parameter is a prime number, otherwise return the string false. The range will
        /// be between 1 and 2^16.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Solution to LetterChanges challenge
        ///
        /// Have the function LetterChanges(str) take the str parameter being passed and modify it
        /// using the following algorithm. Replace every letter in the string with the letter following it
        /// in the alphabet (ie. c becomes d, z becomes a). Then capitalize every vowel in this new
        /// string (a, e, i, o, u) and finally return this modified string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Solution to WordCount challenge
        ///
        /// Have the function WordCount(str) take the str string parameter being passed and return the number
        /// of words the string contains (e.g. "Never eat shredded wheat or cake" would return 6).
        /// Words will be separated by single spaces.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
            return newtext.First();
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
        static int RecursiveCatalan(int n)
        {
            var res = 0;
            if (n <= 1)
            {
                return 1;
            }
            for (var i = 0; i < n; i++)
            {
                res += RecursiveCatalan(i) * RecursiveCatalan(n - i - 1);
            }
            return res;
        }
        public static string AbCheck(string str)
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
        static void Reverse()
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
        static string ExamMethod5()
        {
            var str = "acc?7??sss?3rr1??????5";

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
        static int ExamMethod4()
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
        static string Usernamevalidator(string str)
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
        static string ExamMethod2()
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
        static void ExamMethod() {

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