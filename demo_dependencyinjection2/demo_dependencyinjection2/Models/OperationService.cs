namespace demo_dependencyinjection2.Models
{
    public class OperationService: ITransientService,
    IScopedService,IScopedService2,
    ISingletonService
    {
        Guid id;
        public OperationService()
        {
            id = Guid.NewGuid();
        }
        public Guid GetOperationID()
        {
            return id;
        }
    }
}
