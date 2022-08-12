namespace YemenExchangeApi.Models
{
    public class BaseModel<T1,T2>
    {
        public string Label { get; set; }
        public T1 Value { get; set; }
        public T2 ExtraValue { get; set; }
    }
}
