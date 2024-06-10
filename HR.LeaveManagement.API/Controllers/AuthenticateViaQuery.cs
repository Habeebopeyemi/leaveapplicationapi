using HR.LeaveManagement.API.Constants;
using HR.LeaveManagement.API.Filters.CustomAttributes;
using HR.LeaveManagement.API.Interface;
using HR.LeaveManagement.API.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authenticate : ControllerBase
    {
        private readonly IApiKeyValidation _apiKeyValidation;
        public Authenticate(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }
        [HttpGet("AuthenticateViaQuery")]
        public IActionResult AuthenticateViaQuery(string apiKey) {
            if(string.IsNullOrWhiteSpace(apiKey))
            {
                return BadRequest();
            }

            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);

            if(!isValid)
            {
                return Unauthorized();
            }

            return Ok(new { apiKey});
        }

        [HttpPost("AuthenticateViaRequestBody")]
        public IActionResult AuthenticateViaRequestBody([FromBody] RequestModel model)
        {
            if(string.IsNullOrEmpty(model.ApiKey))
            {
                return BadRequest();
            }

            string apikKy = model.ApiKey;

            bool isValid = _apiKeyValidation.IsValidApiKey(apikKy);
            
            if(!isValid)return Unauthorized();

            return Ok(new { apikKy });
        }

        [HttpGet("AuthenticateViaHeader")]
        public IActionResult AuthenticateViaHeader() {
            string? apiKey = Request.Headers[Constants.Constants.ApiKeyHeaderName];

            if(string.IsNullOrEmpty(apiKey))return BadRequest();

            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);

            if(!isValid )return Unauthorized();

            return Ok(new { apiKey });
        }

        [HttpGet("AuthenticateViaCustomAttribute")]
        [ApiKey]
        public IActionResult AuthenticateViaCustomAttribute()
        {
            return Ok(new
            {
                statusCode = 200,
                message = "Authentication successful"
            });
        }

        [HttpGet("AuthenticateViaPolicy")]
        [Authorize(Policy = "ApiKeyPolicy")]
        public IActionResult AuthenticateViaPolicy()
        {
            return Ok(new
            {
                statusCode = 200,
                message = "Authentication successful"
            });
        }
    }
}
