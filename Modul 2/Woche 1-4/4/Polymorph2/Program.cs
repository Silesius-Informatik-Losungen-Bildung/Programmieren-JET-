namespace Polymorph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notification sms = new NotificationSms();
            Notification email = new NotificationEmail();


            Notification[] arr = [sms, email];


            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Notify();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Notify2();
            }
        }
    }
}
