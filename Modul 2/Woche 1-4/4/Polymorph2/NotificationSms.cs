
namespace Polymorph
{
    public class NotificationSms: Notification
    {
        public override void Notify()
        {
            base.Notify();
            Console.WriteLine("Notification SMS");
        }

        public void DoIt()
        {
            Console.WriteLine("Doit");
        }

        public override void Notify2()
        {
            Console.WriteLine("Notification SMS");
        }
    }
}
