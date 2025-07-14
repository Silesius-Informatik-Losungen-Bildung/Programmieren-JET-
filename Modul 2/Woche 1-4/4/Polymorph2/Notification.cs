
namespace Polymorph
{
    public abstract class Notification
    {
        public virtual void Notify()
        {
            Console.WriteLine("Standardnotification DB");
        }

        public virtual void Abc()
        {
            Console.WriteLine("Abc");
        }

        public abstract void Notify2();
    }
}
