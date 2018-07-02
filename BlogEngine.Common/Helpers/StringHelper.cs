namespace BlogEngine.Common.Helpers
{
    public static class StringHelper
    {
        public static int CountWords(string text)
        {
            int countWords = 0;
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsWhiteSpace(text[i - 1]) == true)
                {
                    if (char.IsLetterOrDigit(text[i]) == true ||
                        char.IsPunctuation(text[i]))
                    {
                        countWords++;
                    }
                }
            }
            if (text.Length > 2)
            {
                countWords++;
            }
            return countWords;
        }       
    }
}
