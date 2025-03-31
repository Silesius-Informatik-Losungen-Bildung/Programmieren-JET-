namespace Exceptions_und_Exceptionhandling
{
    public class WrongRuleException : Exception
    {
        public WrongRuleException(): base("Sie sind kein Admin und nicht berechtigt diese Anwendung auszuführen!")
        {
        }
    }
}
