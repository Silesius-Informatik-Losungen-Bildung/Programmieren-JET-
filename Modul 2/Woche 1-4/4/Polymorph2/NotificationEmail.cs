
namespace Polymorph
{
    public class NotificationEmail: Notification
    {
        public override void Notify()
        {
            base.Notify();
            Console.WriteLine("Notification E-Mail");
        }

        public void DoIt()
        {
            Console.WriteLine("Doit");
        }


        public override void Notify2()
        {
            Console.WriteLine("Notification E-Mail");
        }
    }
    
}
