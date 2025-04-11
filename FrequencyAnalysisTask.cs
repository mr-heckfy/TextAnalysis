using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var keys = GetAllKeysList(text);
            var values = GetAllValueList(text);

            var frequency = GetFrequencyCountDictionary(keys, values);
            var result = GetSortDictionary(frequency);

            return result;
        }

        private static Dictionary<string, string>
            GetSortDictionary(Dictionary<string, Dictionary<string, int>> frequencyCountDictionary)
        {
            var result = new Dictionary<string, string>();
            foreach (var key in frequencyCountDictionary)
            {
                string value = null;
                int maxCount = 0;
                foreach (var item in key.Value)
                {
                    if (item.Value > maxCount)
                    {
                        maxCount = item.Value;
                        value = item.Key;
                    }
                    else if (item.Value == maxCount)
                    {
                        int temp = String.CompareOrdinal(value, item.Key);
                        value = temp < 0 ? value : item.Key;
                    }
                }
                result.Add(key.Key, value);
            }
            return result;
        }

        private static Dictionary<string, Dictionary<string, int>>
            GetFrequencyCountDictionary(List<string> keys, List<string> values)
        {
            var result = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];
                var value = values[i];
                var repCount = new Dictionary<string, int>();
                if (!result.ContainsKey(key))
                {
                    if (!repCount.ContainsKey(value))
                        repCount.Add(value, 1);
                    else
                        repCount[value]++;
                    result.Add(key, repCount);
                }
                else
                {
                    if (!result[key].ContainsKey(value))
                        result[key].Add(value, 1);
                    else
                        result[key][value]++;
                }
            }
            return result;
        }

        private static List<string> GetAllKeysList(List<List<string>> text)
        {
            var result = new List<string>();
            var temp = new List<string>();
            for (int i = 0; i < text.Count; i++)
            {
                for (int ii = 0; ii + 1 < text[i].Count; ii++)
                    result.Add(text[i][ii]);
                for (int ii = 0; ii + 2 < text[i].Count; ii++)
                {
                    var value = text[i][ii] + " " + text[i][ii + 1];
                    temp.Add(value);
                }
            }
            foreach (var item in temp)
                result.Add(item);
            return result;
        }

        private static List<string> GetAllValueList(List<List<string>> text)
        {
            var result = new List<string>();
            var temp = new List<string>();
            for (int i = 0; i < text.Count; i++)
            {
                for (int ii = 1; ii < text[i].Count; ii++)
                    result.Add(text[i][ii]);
                for (int ii = 2; ii < text[i].Count; ii++)
                {
                    var value = text[i][ii];
                    temp.Add(value);
                }
            }
            foreach (var item in temp)
                result.Add(item);
            return result;
        }
    }
}