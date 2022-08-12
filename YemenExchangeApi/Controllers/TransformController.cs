using Microsoft.AspNetCore.Mvc;
using YemenExchangeApi.Models;
using YemenExchangeApi.Services;
using YemenExchangeApi.Utilities;
using YemenExchangeApi.Utils;

namespace YemenExchangeApi.Controllers
{
    [ApiController,Route("api/[controller]")]
    public class TransformController : ControllerBase
    {
        private readonly TransformRepository transformRepository;
        private readonly CityRepository cityRepository;
        private readonly AreaRepository areaRepository;
        private readonly CompanyRepository companyRepository;
        private readonly CustomerRepository customerRepository;
        private readonly Localizer localizer;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TransformController(TransformRepository transformRepository , CityRepository cityRepository , AreaRepository areaRepository , CompanyRepository companyRepository , CustomerRepository customerRepository , Localizer localizer , IWebHostEnvironment  webHostEnvironment)
        {
            this.transformRepository = transformRepository;
            this.cityRepository = cityRepository;
            this.areaRepository = areaRepository;
            this.companyRepository = companyRepository;
            this.customerRepository = customerRepository;
            this.localizer = localizer;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(nameof(Index))]
        public IActionResult Index()
        {
            try
            {
                return Ok(new
                {
                    Cities = cityRepository.GetShortData(),
                    Areas = areaRepository.GetShortData(),
                    Companies = companyRepository.GetShortData(),
                    Customers = customerRepository.GetShortData() 
                });
            }catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendTransform([FromBody] TransformRequestModel requestModel)
        {
            string senderCode, receiverCode;
            try
            {
                if (requestModel != null)
                {
                    var newTransformCode = transformRepository.GenerateTransformCode(requestModel.SelectedCompany);
                    // find the customers
                    if (string.IsNullOrEmpty(requestModel.SenderData?.Id))
                    {
                        if (!Stuff.IsMatchedSegmentParts(requestModel.SenderData.FullName))
                        {
                            return BadRequest(new MessageModel() { State = 400, Message = localizer.GetString("sender_forth_names_error") });
                        }
                        else
                        {
                            // create account for customer
                            senderCode = customerRepository.GenerateCode();
                            await customerRepository.AddAsync(new Customer
                            {
                                Id = senderCode,
                                FullName = requestModel.SenderData.FullName.Trim()
                            });

                        }

                    }
                    else
                    {
                        senderCode = requestModel.SenderData.Id;
                    }

                    // find the customers
                    if (string.IsNullOrEmpty(requestModel.ReceiverData?.Id))
                    {
                        if (!Stuff.IsMatchedSegmentParts(requestModel.ReceiverData.FullName))
                        {
                            return BadRequest(new MessageModel() { State = 400, Message = localizer.GetString("receiver_forth_names_error") });
                        }
                        else
                        {
                            // create account for customer
                            receiverCode = customerRepository.GenerateCode(new List<string>() {senderCode});
                            await customerRepository.AddAsync(new Customer
                            {
                                Id = receiverCode,
                                FullName = requestModel.ReceiverData.FullName.Trim()
                            });

                        }
                    }
                    else
                    {
                        receiverCode = requestModel.ReceiverData.Id;
                    }
                    float total = requestModel.Fees + requestModel.TransformAmount;
                    var transformData = new Transform
                    {
                        TransformNo = newTransformCode,
                        CityId = requestModel.SelectedCity,
                        AreaId = requestModel.SelectedArea,
                        CompanyId = requestModel.SelectedCompany,
                        Amount = requestModel.TransformAmount,
                        Fees = requestModel.Fees,
                        UserId = "Emp1",
                        SentDate =  DateTime.Now,
                        SenderId = senderCode,
                        SenderPhoneNumber = requestModel.SenderData.PhoneNumber,
                        RecieverPhoneNumber = requestModel.ReceiverData.PhoneNumber,
                        RecieverId = receiverCode,
                        Total = total,
                        Note = requestModel.Note
                    };
                    await transformRepository.AddAsync(transformData);
                    var rowAffected = await transformRepository.CompleteAsync();
                    if (rowAffected > 0)
                    {
                        return Ok(transformRepository.SummaryReport(newTransformCode));
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpGet("All")]
        public IActionResult GetAllTransformReports()
        {
            try
            {
               return Ok(transformRepository.GetAllSummaryReports());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateTransform")]
        public async Task<IActionResult> UpdateTransformData([FromForm]ReceiverTransformRequestDataModel requestDataModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(requestDataModel.TransformNo))
                {
                    var transformResult = await transformRepository.GetByIdAsync(requestDataModel.TransformNo);

                    if (transformResult == null)
                    {
                        return NotFound(new MessageModel { State = 404, Message = localizer.GetString("transform_not_found") });
                    }
                    else
                    {
                        var receiverResult = await customerRepository.GetByIdAsync(transformResult.RecieverId);
                        if (requestDataModel.SelectedOption)
                        {
                            if (string.IsNullOrEmpty(receiverResult?.IdentityCardPath))
                            {
                                return BadRequest(new MessageModel { State = 400, Message = localizer.GetString("identity_not_found") });
                            }
                            else
                            {
                                transformResult.IdentityCardPath = receiverResult.IdentityCardPath;
                            }
                        }
                        else
                        {
                            var filePath = await SaveFileAsync(requestDataModel.ImageFile);
                            if (string.IsNullOrEmpty(filePath))
                            {
                                return BadRequest(new MessageModel { State = 400, Message = localizer.GetString("image_not_set") });
                            }
                            transformResult.IdentityCardPath = filePath;
                        }
                        transformResult.Done = true;
                        transformResult.RecievedDate = DateTime.Now;
                    }
                    transformRepository.Update(transformResult);
                    var affectedRows = await transformRepository.CompleteAsync();
                    if (affectedRows > 0)
                    {
                        return Ok(transformRepository.SummaryReport(transformResult.TransformNo));
                    }
                }
            }
            catch
            {
                return BadRequest();
            }

            return BadRequest(new MessageModel { State = 400, Message = localizer.GetString("transform_empty") });

        }
        [HttpGet("Summary")]
        public  IActionResult GetTransformReport(string transformNo)
        {
            if(string.IsNullOrEmpty(transformNo))
                return BadRequest(new MessageModel { State = 400, Message = localizer.GetString("transform_empty") });
            try
            {
                return Ok(transformRepository.SummaryReport(transformNo));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Daily")]
        public IActionResult GetDailyReport(string startDate , string endDate)
        {
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
                return BadRequest(new MessageModel { State = 400, Message = localizer.GetString("mandatory_field") });
            try
            {
                if(!DateTime.TryParse(startDate, out var formatStartDate) || !DateTime.TryParse(endDate, out var formatEndDate))
                    return BadRequest(new MessageModel { State = 400, Message = localizer.GetString("format_error") });

                return Ok(transformRepository.GetDailyReports(formatStartDate, formatEndDate));

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Special")]
        public IActionResult GetSpecialReport(string search)
        {
            if (string.IsNullOrEmpty(search))
                return BadRequest(new MessageModel { State = 400, Message = localizer.GetString("mandatory_field") });
            try
            {
                return Ok(transformRepository.GetSpecialReports(search.ToLower()));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Home")]
        public IActionResult GetHomeSummary()
        {
            try
            {
                return Ok(new
                {
                    SentTransformCount = transformRepository.SentTransformCount,
                    ReceiveTransformCount = transformRepository.ReceiveTransformCount,
                    SentAmountTotal = transformRepository.SentAmountTotal,
                    ReceiveAmountTotal = transformRepository.ReceiveAmountTotal,
                    CurrentTransforms = transformRepository.GetSpecialReports(DateTime.Now)
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [NonAction]
        public async Task<string> SaveFileAsync(IFormFile file)
        {

            if (file == null)
                return string.Empty;
            var fullFileName = string.Concat("Identity_",DateTime.Now.ToString("yyyy-MM-D"),"_", Guid.NewGuid().ToString(), Path.GetExtension(file.FileName));
            var filePath = Path.Combine(webHostEnvironment.WebRootPath, "Files", fullFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
               await file.CopyToAsync(fileStream);
            }
            var request = HttpContext.Request;
            var baseUrl = string.Concat((request.IsHttps ? "https://" : "http://"), request.Host.ToString(), "/Files/", fullFileName);
            return baseUrl;
        }
    }
}
