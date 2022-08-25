
List<string> logs = new List<string>();
List<string> logReturns = new List<string>();

logs.Add("88 99 200");
logs.Add("88 12 300");
logs.Add("12 88 512");
logs.Add("99 99 400");
logs.Add("99 23 782");

Demo demo = new Demo();
logReturns = demo.limitBreach(logs, 2);

foreach (string logReturn in logReturns)
{
    Console.WriteLine(logReturn);
}

class Demo
{
    public List<string> limitBreach(List<string> logs, int terms)
    {
        List<string> newLog = new List<string>();
        List<string> distinctLog = new List<string>();
        List<string> entryArrays = new List<string>();

        foreach (string log in logs)
        {
            entryArrays = log.Split(' ').ToList();
            entryArrays.RemoveAt(entryArrays.Count - 1);
            distinctLog.AddRange(entryArrays.Distinct());
        }

        var duplicates = from dup in distinctLog
                         group dup by dup into g
                         let count = g.Count()
                         orderby count descending
                         select new {Value = g.Key, Count = count};

        foreach (var d in duplicates)
        {
            
            if (newLog.Count() < terms)
            {
                newLog.Add(d.Value);
            }
        }

        return newLog;
    }
}