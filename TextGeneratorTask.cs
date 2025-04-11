using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string generatedText = phraseBeginning;
            var input = phraseBeginning.Split(' ');
            generatedText = GetFirstNextWord(nextWords, wordsCount, generatedText, input);
            generatedText = GetContinuationText(nextWords, wordsCount, generatedText, input);
            return generatedText;
        }

        private static string GetContinuationText(Dictionary<string, string> nextWords,
            int wordsCount,
            string generatedText,
            string[] input)
        {
            var temp = generatedText.Split(' ');
            for (int i = temp.Length - input.Length; i < wordsCount; i++)
            {
                var wordsArray = generatedText.Split(' ');
                var lastWord = wordsArray.Length - 1;
                var key = wordsArray[lastWord];
                if (wordsArray.Length > 1)
                    key = wordsArray[lastWord - 1] + " " + wordsArray[lastWord];
                if (nextWords.ContainsKey(key))
                    generatedText += " " + nextWords[key];
                else
                    if (nextWords.ContainsKey(wordsArray[lastWord]))
                    generatedText += " " + nextWords[wordsArray[lastWord]];
            }

            return generatedText;
        }

        private static string GetFirstNextWord(
            Dictionary<string, string> nextWords,
            int wordsCount, string generatedText,
            string[] input)
        {
            if (wordsCount > 1)
            {
                if (input.Length == 1)
                {
                    if (nextWords.ContainsKey(input[0]))
                        generatedText += " " + nextWords[input[0]];
                }
                else
                {
                    var lastWord = input.Length - 1;
                    var key = input[lastWord - 1] + " " + input[lastWord];
                    if (nextWords.ContainsKey(key))
                        generatedText += " " + nextWords[key];
                }
            }

            return generatedText;
        }
    }
}