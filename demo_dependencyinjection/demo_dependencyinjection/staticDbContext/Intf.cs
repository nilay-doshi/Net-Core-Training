namespace demo_dependencyinjection.staticDbContext
{
    public interface IService
    {
        int GetTarget();

        void UpdateTarget();
    }
    public class MyService : IService
    {
        public int _target;

        public MyService()
        {
            _target = 0;
        }

        public int GetTarget()
        {
            return _target;
        }

        public void UpdateTarget()
        {
            _target++;
        }
    }

}
