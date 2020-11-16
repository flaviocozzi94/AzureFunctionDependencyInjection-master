using AzureFunctionDependencyInjection.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionDependencyInjection
{
    public class MessageFunction
    {
        private IMessageResponderService _messageResponderService;
        private readonly ILogger<MessageFunction> _logger;

        public MessageFunction(IMessageResponderService messageResponderService, ILogger<MessageFunction> logger)
        {
            _messageResponderService = messageResponderService;
            _logger = logger;
        }

        [FunctionName("MessageFunction")]
        public void Run([TimerTrigger("*/15 * * * * *")] TimerInfo myTimer)
        {
            _logger.LogWarning(_messageResponderService.GetPositiveMessage());
            //_logger.Debug("positive function");
            //new OkObjectResult(_messageResponderService.GetPositiveMessage());
        }

        //[FunctionName("negative")]
        //public async Task<IActionResult> GetNegativeMessage(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        //    ILogger log)
        //{
        //    _logger.Debug("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");

        //    return new OkObjectResult(_messageResponderService.GetNegativeMessage());
        //}
    }
}