namespace RepeatableCharacterProject
{
    public class AnagramTest
    {
        public bool AnagramCheck(string input1, string input2)
        {
            var result1 = new int[256];
            var result2 = new int[256];

            foreach (var input1Char in input1)
            {
                result1[input1Char] += 1;
            }

            foreach (var input2Char in input2)
            {
                result2[input2Char] += 1;
            }

            for (int index = 0; index < 256; index++)
            {
                if (result1[index] != result2[index])
                {
                    return false;
                }
            }

            return true;
        }
    }
}