using Microsoft.AspNetCore.Mvc;
using TestCase.Business.Abstract;

namespace TestCase.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaderBoardController : ControllerBase
{
    private readonly ILeaderBoardService _leaderBoardService;

    public LeaderBoardController(ILeaderBoardService leaderBoardService)
    {
        _leaderBoardService = leaderBoardService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> AddLeaderBoard()
    {
        await _leaderBoardService.AddToLeaderBoard();

        return NoContent();
    }
}