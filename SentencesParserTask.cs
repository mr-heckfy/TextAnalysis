using System.Collections.Generic;
using System.Text;
using System;
using System.Globalization;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var param = new char[] { '.', '!', '?', ':', ';', '(', ')' };
            var sentencesArray = text.Split(param, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sentencesArray.Length; i++)
            {
                var sentence = sentencesArray[i];
                bool sentenceHasLetter = false;
                foreach (var c in sentence)
                    if (Char.IsLetter(c))
                        sentenceHasLetter = true;
                if (sentence == null || sentence == "" || sentence.Length == 0 || !sentenceHasLetter)
                    continue;
                var list = new List<string>();
                string[] words = CreateNewWords(sentence);
                foreach (var word in words)
                    list.Add(word);
                sentencesList.Add(list);
            }
            return sentencesList;
        }

        private static string[] CreateNewWords(string sentence)
        {
            var words = new List<string>();
            string temp = null;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (Char.IsLetter(sentence[i]) || sentence[i] == '\'')
                    temp += sentence[i];
                else
                {
                    if (temp != null)
                        words.Add(temp.ToLower());
                    temp = null;
                }
            }
            if (temp != null)
                words.Add(temp.ToLower());
            return words.ToArray();
        }
    }
}