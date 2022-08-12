namespace YemenExchangeApi.Models
{
     public class ReceiverTransformRequestDataModel
    {
        public bool SelectedOption { get; set; } = false;
        public string TransformNo { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
