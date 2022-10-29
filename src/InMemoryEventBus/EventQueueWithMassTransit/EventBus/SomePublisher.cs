using EventQueueWithMassTransit.EventBus.Event;

namespace EventQueueWithMassTransit.EventBus
{
    public class SomePublisher
    {
        DataContext.DataContext _dataContext;
        public SomePublisher(DataContext.DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public event EventHandler<DoSomethingEventArg> Doit;
        public async Task<bool> DoSomethingPublisher()
        {
            var runs = _dataContext.TestRuns.ToList();
            foreach (var run in runs)
            {
               Doit.Invoke(this, new DoSomethingEventArg() { Id=run.Id,
                    Name = run.RunCode });
                
            }
            return true;
        }
    }
}
