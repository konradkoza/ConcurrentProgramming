using System.Collections.Concurrent;
using System.Diagnostics;
using System.Dynamic;
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
        private int Width;
        private int Height;
        public DAO(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            writingQueue = new BlockingCollection<String>();
            writer = new StreamWriter(filePath, append: false);
            loggingTask = Task.Run(writeToFile);
        }

        public void addToQueue(IBall ball)
        {
            if (ball == null)
            {
                return;
            }
            String time;
            String ballInfo;
            String log;
            lock (locker)
            {
                time = DateTime.Now.ToString("HH:mm:ss.ff");
                ballInfo = JsonSerializer.Serialize(ball);
                log = "{" + string.Format("\n\t\"Time\": \"{0}\",\n\t\"BallInfo\": {1}\n", time, ballInfo) + "},";
                
            }
            if (!writingQueue.IsAddingCompleted)
            {
                writingQueue.Add(log);
            }

        }

        private void writeToFile()
        {
            writer.WriteLine("[");
            writer.WriteLine("{" + string.Format("\n\t\"Width\": {0},\n\t\"Height\": {1}\n", Width, Height) + "},");
            try
            {
                foreach (string item in writingQueue.GetConsumingEnumerable())
                {
                    writer.WriteLine(item);
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
