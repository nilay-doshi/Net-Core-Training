namespace demo_dependencyinjection.staticDbContext
{
    public interface Intf1
    {
            int GetTargetf1();
            void UpdateTargetf1();
    }

    public class MyService1 : Intf1
    {
        public int _target1;

        public MyService1()
        {
            _target1 = 0;
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
        }

        public int GetTargetf1()
        {
            return _target1;
        }

        public void UpdateTargetf1()
        {
            _target1++;
        }
    }

}
