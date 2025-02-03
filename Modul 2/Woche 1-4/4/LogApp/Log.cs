namespace Log
{
    internal class Log
    {
        protected string message;
        public Log(string msg)
        {
            message = msg;
        }
        public virtual void Send()
        {
            sendMessage2Db();
        }
        private void sendMessage2Db()
        {
            Console.WriteLine($"Nachricht '{message}' wurde in der Datenbank gespeichert.");
        }
    }
}
