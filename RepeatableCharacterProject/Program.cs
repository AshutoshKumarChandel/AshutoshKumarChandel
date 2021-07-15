using System;
using System.Collections.Generic;

namespace RepeatableCharacterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var anagram = new AnagramTest();
            Console.WriteLine($"anagram result: {anagram.AnagramCheck("ABCD", "CBDA$")}");
            
            RunUnitTestCases("Case_When_SubArray_With_Total_Zero_Present", new[] {4, 2, -3, 1, 6}, true);
            RunUnitTestCases("Case_When_SubArray_Contains_Zero_Number", new[] {4, 2, 0, 1, 6}, true);
            RunUnitTestCases("Case_When_SubArray_IsNotPresent_With_TotalZero", new[] {4, 2, 1, 1, 6}, false);
            RunUnitTestCases("Case_When_Only_Zero_Is_Present_At_First_Index", new[] {0}, true);
            RunUnitTestCases("Case_When_Only_Zero_Is_Present_Latest", new[] {0, 1}, true);
            RunUnitTestCases("Case_When_No_inputs_given", new int[]{}, false);

            Console.WriteLine(GetFirstRepeatableCharacter("ABCBCA"));
            Case_When_Atleast_One_Repeatable_Character();
            Case_When_Atleast_No_Repeatable_Character();
            Case_When_Input_Is_NULL_Or_Empty();
        }

        private static void RunUnitTestCases(string testCaseName, int[] numbers, bool expectedValue)
        {
            var subArray = new FindTheSubArrayForATargetValue();
            var result = subArray.GetSubArrayForaGivenTotal(numbers);

            if (result == expectedValue)
            {
                Console.WriteLine($"Unit test {testCaseName} passed");
            }
            else
            {
                Console.WriteLine($"Unit test {testCaseName} failed");
            }
        }

        private static void Case_When_Atleast_One_Repeatable_Character()
        {
            var result = GetFirstRepeatableCharacter("ABCBCA");
            if (result != "A")
            {
                Console.WriteLine($"A is expected, but actual value is {result}");
            }
            else
            {
                Console.WriteLine("Unit Test Case_When_Atleast_One_Repeatable_Character Passed");
            }
        }

        private static void Case_When_Input_Is_NULL_Or_Empty()
        {
            var result = GetFirstRepeatableCharacter("");
            if (result != null)
            {
                Console.WriteLine($"NULL was expected, but actual value is {result}");
            }
            else
            {
                Console.WriteLine("Unit Test Case_When_Input_Is_NULL_Or_Empty Passed");
            }
        }

        private static void Case_When_Atleast_No_Repeatable_Character()
        {
            var result = GetFirstRepeatableCharacter("123ABC");
            if (result != null)
            {
                Console.WriteLine($"NULL was expected, but actual value is {result}");
            }
            else
            {
                Console.WriteLine("Unit Test Case_When_Atleast_No_Repeatable_Character Passed");
            }
        }

        private static string GetFirstRepeatableCharacter(string input)
        {
            if (string.IsNullOrEmpty(input.Trim()))
            {
                return null;
            }

            var dictionary = new Dictionary<char, int>();
            var minimumIndex = int.MaxValue;

            for (var index = 0; index < input.Length; index++)
            {
                if (!dictionary.ContainsKey(input[index]))
                {
                    dictionary.Add(input[index], index);
                }
                else
                {
                    var current = dictionary[input[index]];
                    minimumIndex = minimumIndex > current ? current : minimumIndex;
                }
            }

            return minimumIndex == int.MaxValue ? null : Convert.ToString(input[minimumIndex]);
        }
    }
}