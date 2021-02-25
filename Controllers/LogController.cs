using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Demo_LogAPI.DTOs;
using Demo_LogAPI.Models;
using Demo_LogAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo_LogAPI.Controllers
{
    [ApiController]
    [Route("Messages")]
    [Authorize]
    public class LogController : ControllerBase
    {

        private readonly ApiClient apiClient;
        private readonly IMapper mapper;
        public LogController(ApiClient ApiClient, IMapper Mapper)
        {
            apiClient = ApiClient;
            mapper = Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogMessages()
        {
            var messagesDTO = await apiClient.GetLogMessages();
            var messages = mapper.Map<List<Message>>(messagesDTO);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SaveLogMessage(Message Message)
        {
            Message.ReceivedAt = DateTime.UtcNow.ToString("o");
            Message.Id = Guid.NewGuid().ToString("N");

            var messagesDTO = await apiClient.SaveLogMessage(mapper.Map<MessageDTO>(Message));
            List<Message> messages = null;
            if (messagesDTO != null)
                messages = mapper.Map<List<Message>>(messagesDTO);
            return Ok(messages);
        }
    }
}
