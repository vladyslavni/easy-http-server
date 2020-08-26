using System;
namespace easy_http_server
{
    public class Timer
    {
        private DateTime start;
        private DateTime end;

        public void Start()
        {
            this.start = DateTime.Now;
        }
        
        public void End()
        {
            this.end = DateTime.Now;
        }

        public TimeSpan GetTime()
        {
            return (end - start);
        }
    }
}