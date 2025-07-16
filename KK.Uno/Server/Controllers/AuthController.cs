using KK.Uno.Contracts.Api;
using KK.Uno.Server.Services;
using Microsoft.AspNetCore.Mvc;
using KK.Uno.Contracts.Dtos.Auth;

namespace KK.Uno.Server.Controllers
{
    [ApiController]
    [Route("api/kk/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(KKApiResult<AuthResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<KKApiResult<AuthResponseDto>>> LoginAsync([FromBody] AuthRequestDto authRequestDto)
        {
            if (authRequestDto == null)
            {
                return KKApiResult<AuthResponseDto>.BadRequest("Requst BODY must not be NULL!");
            }

            var res = await _authService.LoginAsync(authRequestDto.Login, authRequestDto.Password);

            return res;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(KKApiResult<bool>), StatusCodes.Status200OK)]
        public async Task<ActionResult<KKApiResult<bool>>> RegisterUserAsync([FromBody] RegisterUserRequestDto registerUserRequest)
        {
            if (registerUserRequest == null)
            {
                return KKApiResult<bool>.BadRequest("Requst BODY must not be NULL!");
            }

            var res = await _authService.RegisterUserAsync(registerUserRequest);

            return res;
        }
    }
}
