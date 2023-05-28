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
        private object locker = new object();   
        public DAO()
        {
            Debug.WriteLine("create dao");
            writingQueue = new BlockingCollection<String>();
            writer = new StreamWriter(filePath, append: false);
            loggingTask = Task.Run(writeToFile);
        }

        public void addToQueue(IBall ball)
        {
            if (ball == null )
            {
                return;
            }
            String time = DateTime.Now.ToString("HH:mm:ss.ff");
            String ballInfo = JsonSerializer.Serialize(ball);
            String log = "{" + string.Format("\n\t\"Time\": \"{0}\",\n\t\"BallInfo\": {1}\n", time, ballInfo) + "},";
            if (!writingQueue.IsAddingCompleted)
            {
                writingQueue.Add(log);
            }
            
        }

        private async void writeToFile()
        {
            writer.WriteLine("[");
            try
            {
                foreach (string item in writingQueue.GetConsumingEnumerable())
                {
                    writer.WriteLine(item);
                    await writer.FlushAsync();
                }
            } 
            finally
            {
                
                this.Dispose();
            }
            
            
        }

        public void stopAdding()
        {
            writingQueue.CompleteAdding();
        }

        public void Dispose()
        {
            writer.Flush();
            writer.Dispose();
            string content = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(content))
            {
                content = content.Remove(content.Length - 3);
                File.WriteAllText(filePath, content + "\n]");
            }
            loggingTask.Wait();
            loggingTask.Dispose();
        }
    }
}
