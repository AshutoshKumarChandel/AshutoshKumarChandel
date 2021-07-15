namespace RepeatableCharacterProject
{
    public class FindTheSubArrayForATargetValue
    {
        public bool GetSubArrayForaGivenTotal(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return false;
            }

            if (numbers.Length == 1 && numbers[0] == 0)
            {
                return true;
            }
            
            for (var i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 0)
                {
                    return true;
                }
                
                var runningSum = numbers[i];
                for (var j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] == 0)
                    {
                        return true;
                    }
                    
                    runningSum += numbers[j];

                    if (runningSum == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}