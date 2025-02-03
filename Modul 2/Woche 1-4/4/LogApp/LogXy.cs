namespace Log
{
    internal class LogXy : Log
    {
        public LogXy(string msg) : base(msg) { }
        
        public override void Send()
        {
            sendSms();
        }

        private void sendSms()
        {
            Console.WriteLine($"Eine SMS mit Nachricht '{message}' wurde versdendet.");
        }
    }
}
