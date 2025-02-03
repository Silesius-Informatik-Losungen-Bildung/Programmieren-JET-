namespace Log
{
    internal class LogVers2 : Log
    {
        public LogVers2(string msg) : base(msg) { }
        
        public override void Send()
        {
            base.Send();
            sendMail();
        }

        private void sendMail()
        {
            Console.WriteLine($"E-Mail mit Nachricht '{message}' wurde versdendet.");
        }
    }
}
