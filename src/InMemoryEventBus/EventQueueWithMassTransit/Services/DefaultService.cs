using EventQueueWithMassTransit.EventBus.Event;

namespace EventQueueWithMassTransit.Services
{
    public class DefaultService
    {
        

        public async Task<bool> DoSomethingLongJob(DoSomethingEventArg doSomethingEventArg) 
        {
            try
            {
                Thread.Sleep(3000);
                Console.WriteLine($"AppService: your food '{doSomethingEventArg.Id}' ve '{doSomethingEventArg.Name.ToLower()}' is consumed.");

                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        
        }







    }
}
