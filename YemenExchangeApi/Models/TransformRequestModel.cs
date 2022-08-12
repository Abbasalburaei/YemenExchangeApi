using System.ComponentModel.DataAnnotations;
using YemenExchangeApi.Resources;

namespace YemenExchangeApi.Models
{
    public class TransformRequestModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "mandatory_field")]
        public int SelectedCity { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "mandatory_field")]
        public int SelectedArea { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "mandatory_field")]
        public string SelectedCompany { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "mandatory_field")]
        public float TransformAmount { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "mandatory_field")]
        public float Fees { get; set; }
        public string? Note { get; set; }
        public Person SenderData { get; set; } = new Person();
        public Person ReceiverData { get; set; } = new Person();
       
    }

    public class Person
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "mandatory_field")]

        public string Id { get; set; }

        public string? FullName { get; set; }
        [Required(ErrorMessageResourceType = typeof(SharedResource) , ErrorMessageResourceName = "mandatory_field")]
        public string PhoneNumber { get; set; }
    } 
}
