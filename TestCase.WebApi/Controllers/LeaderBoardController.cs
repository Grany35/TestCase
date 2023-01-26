using Microsoft.AspNetCore.Mvc;
using TestCase.Business.Abstract;
using TestCase.Core.Utilities.Params;

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

    [HttpPost("[action]")]
    public async Task<IActionResult> AddLeaderBoard()
    {
        await _leaderBoardService.AddToLeaderBoard();

        return NoContent();
    }

    [HttpGet("[action]")]
    public IActionResult GetLeaderBoard([FromQuery] LeaderBoardParams lbParams)
    {
        var leaderBoard = _leaderBoardService.GetLeaderBoard(lbParams);

        return Ok(leaderBoard);
    }
}