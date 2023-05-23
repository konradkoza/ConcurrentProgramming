using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Data
{
    internal class DAO : IDisposable
    {
        private Task loggingTask;
        private StreamWriter writer;
        private BlockingCollection<string> writingQueue;
        private string filePath = "../../../../Dane/log.txt";
        private bool finish = false;
        public DAO()
        {
            Debug.WriteLine("create dao");
            writingQueue = new BlockingCollection<String>();
            writer = new StreamWriter(filePath, append: false);
            loggingTask = Task.Run(writeToFile);
        }

        public void addToQueue(Ball ball)
        {
            if (ball == null)
            {
                return;
            }
            String ballInfo = JsonSerializer.Serialize(ball);
            String time = DateTime.Now.ToString("HH:mm:ss");
            String log = string.Format("\n\t\"Time\": \"{0}\",\n\t\"BallInfo\": {1}\n", time, ballInfo);
            writingQueue.Add(log);
        }

        private void writeToFile()
        {
            //writer.WriteLine("[");
         
                foreach (string item in writingQueue.GetConsumingEnumerable())
                {
                    writer.WriteLine(item);
                    
                    if (finish && writingQueue.Count == 0) 
                {
                    writer.Flush();
                    break; 
                }
                }
            

        }

        public void Dispose()
        {
            finish = true;
            loggingTask.Wait();
            writer.Dispose();
           // string content = File.ReadAllText(filePath);
            //if (!string.IsNullOrEmpty(content))
            //{
              //  content = content.Remove(content.Length - 3);
                //File.WriteAllText(filePath, content + "\n]");

            //}
            loggingTask.Dispose();
        }
    }
}
