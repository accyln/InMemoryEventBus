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
        public async Task<List<DoSomethingEventArg>> DoSomethingPublisher()
        {
            List<DoSomethingEventArg> doSomethingEventArgList = new List<DoSomethingEventArg>();
            var runs = _dataContext.TestRuns.Take(10).ToList();
            foreach (var run in runs)
            {
                var args = new DoSomethingEventArg()
                {
                    Id = run.Id,
                    Name = run.RunCode
                };
                Doit.Invoke(this, args);
                doSomethingEventArgList.Add(args);
                
            }
            return doSomethingEventArgList;
        }
    }
}
