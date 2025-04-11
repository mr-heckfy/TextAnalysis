using NUnitLite;

namespace TextAnalysis;

public static class Program
{
    public static void Main(string[] args)
    {
        var testsToRun = new[]
        {
            "TextAnalysis.SentencesParser_Tests",
            "TextAnalysis.FrequencyAnalysis_Tests",
            "TextAnalysis.TextGenerator_Tests",
        };
        new AutoRun().Execute(new[]
        {
            "--stoponerror",
            "--noresult",
            "--test=" + string.Join(",", testsToRun)
        });

        var text = File.ReadAllText("HarryPotterText.txt");
        var sentences = SentencesParserTask.ParseSentences(text);
        var frequency = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);

        while (true)
        {
            Console.Write("Write a first word: ");
            var beginning = Console.ReadLine();
            if (string.IsNullOrEmpty(beginning)) return;
            var phrase = TextGeneratorTask.ContinuePhrase(frequency, beginning.ToLower(), 10);
            Console.WriteLine(phrase);
        }
    }
}