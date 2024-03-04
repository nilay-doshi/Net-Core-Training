using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team.Repo.Interface;
using Team.Service.DTO;
using Team.Service.Interface;

namespace Team_Project_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamService _teamService;


        public TeamController(IUserRepository userRepository, ITeamService teamService)
        {
            _userRepository = userRepository;
            _teamService = teamService;
        }

        [AllowAnonymous]
        [HttpPost("CreateTeamPlayers")]
        public async Task<IActionResult> CreateTeamPlayers(CreateTeamDTO teamdto)
        {
            try
            {
                var players = await _teamService.SavePlayers(teamdto);

                Console.WriteLine("Players made successfully now create for captain");
                if (players == null)
                {
                    return BadRequest();
                }

                return Ok(players);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                throw new NotImplementedException(errorMessage);
            }
        }

        [AllowAnonymous]
        [HttpPost("CreateCaptain")]
        public async Task<IActionResult> CreateCaptain(CreateTeamDTO teamdto)
        {
            try
            {
                var captain = await _teamService.SaveCaptain(teamdto);
                if (captain == null)
                {
                    return BadRequest(captain);
                }
                return Ok(captain);
            }
            catch(Exception ex)
            {
                string errorMessage = ex.Message;
                throw new NotImplementedException(errorMessage);
            }
        }






    }
}
