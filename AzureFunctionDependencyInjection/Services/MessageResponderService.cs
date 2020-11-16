﻿using AzureFunctionDependencyInjection.Configurations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureFunctionDependencyInjection.Services
{
    public class MessageResponderService : IMessageResponderService
    {
        //private MessageResponderConfiguration _messageResponderConfiguration;
        private ILogger<MessageResponderService> _logger;

        //public MessageResponderService(IOptions<MessageResponderConfiguration> messageResponderConfiguration, ILogger<MessageResponderService> logger)
        public MessageResponderService(ILogger<MessageResponderService> logger)
        {
            //_messageResponderConfiguration = messageResponderConfiguration.Value;
            _logger = logger;
        }

        public string GetPositiveMessage()
        {
            _logger.LogInformation("Very Positive!");
            return "positivo";
            //return _messageResponderConfiguration.PositiveResponseMessage;
        }

        public string GetNegativeMessage()
        {
            _logger.LogInformation("Very negative!");
            //return _messageResponderConfiguration.NegativeResponseMessage;
            return "negativo";

        }
    }
}