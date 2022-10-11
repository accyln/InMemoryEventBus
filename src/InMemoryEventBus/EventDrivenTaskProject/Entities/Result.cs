namespace EventDrivenTaskProject.Entities
{
    public class Result<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public int ErrorCode { get; set; }
        public T? ResultValue { get; set; }

    }
}
