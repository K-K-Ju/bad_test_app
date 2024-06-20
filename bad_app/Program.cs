using bad_app;
using System.Text;

class Program
{
    static string FILE_PATH = "C:\\Users\\tusen\\Developing\\C#\\bad_app\\bad_app\\resources\\10m.txt";

    public static void Main(string[] args)
    {
        var summarizer = new FileSummarizer() { FilePath = FILE_PATH };
        var summary = summarizer.GetSummary();
        
        var resStr = new StringBuilder();
        summary.IncSeq.ForEach(n => resStr.Append(n.ToString() + " "));
        var resStr2 = new StringBuilder();
        summary.DecSeq.ForEach(n => resStr2.Append(n.ToString() + " "));

        Console.WriteLine(String.Format("Max: {0}\nMin: {1}\nAvg: {7}\nMedian: {2}\nIncSeq({3}): [ {4} ]\nDecSeq({5}): [ {6} ]", 
            summary.Max, summary.Min, summary.Median, summary.IncSeq.Count, resStr, summary.DecSeq.Count, resStr2, summary.Avg));
        
    }
 
}