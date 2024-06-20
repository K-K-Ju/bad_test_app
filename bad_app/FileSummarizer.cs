namespace bad_app
{
    public class FileSummarizer
    {
        public required string FilePath { get; set; }

        public Summary GetSummary() 
        {
            var nums = _getNums(this.FilePath);

            var max = nums.Max();
            var min = nums.Min();
            var avg = (long)Math.Round(nums.Average());
            var _nums = new List<long>();
            
            var incSeq = _getSequences(nums, true);
            var decSeq = _getSequences(nums, false);
            
            long median = 0;
            nums.Sort();
            if (nums.Count % 2 == 0)
            {
                var middle = nums.Count / 2;
                median = (nums[middle] + nums[middle + 1]) / 2;
            }
            else
            {
                median = nums[nums.Count / 2 + 1];
            }

            return new Summary { 
                Max = max, Min = min, 
                Median=median, Avg = avg, 
                IncSeq = incSeq, DecSeq = decSeq 
            };
        }
        private List<long> _getNums(string filePath)
        {
            var text = File.ReadAllText(filePath);
            var lines = text.Split('\n');
            var numArr = new long[lines.Length - 1];

            for (int i = 0; i < numArr.Length; i++)
            {
                long res = 0;
                if (!Int64.TryParse(lines[i], out res))
                {
                    Console.WriteLine("Some error in data!");
                    break;
                }
                numArr[i] = res;
            }

            return new List<long>(numArr);
        }

        private List<long> _getSequences(List<long> nums, bool increasing)
        {
            var bestSeq = new List<long>();
            for (int i = 0; i < nums.Count; i++)
            {
                var seq = new List<long>() { nums[i] };
                for (int j = i + 1; j < nums.Count; j++)
                {
                    if ((nums[j] > seq[j - i - 1]) ^ increasing)
                    {
                        seq.Add(nums[j]);
                    }
                    else
                    {
                        i = j;
                        break;
                    }
                }

                if (seq.Count > bestSeq.Count)
                {
                    bestSeq = seq;
                }
            }
            return bestSeq;
        }

        public struct Summary
        {
            public long Max;
            public long Min;
            public long Avg;
            public long Median;
            public List<long> IncSeq;
            public List<long> DecSeq;
        }
    }
}
