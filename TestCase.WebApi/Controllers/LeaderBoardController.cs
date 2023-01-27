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

    [HttpPost]
    public async Task<IActionResult> AddLeaderBoard()
    {
        await _leaderBoardService.AddToLeaderBoard();

        return NoContent();
    }

    [HttpGet]
    public IActionResult GetLeaderBoard([FromQuery] LeaderBoardParams lbParams)
    {
        var result = _leaderBoardService.GetLeaderBoard(lbParams);

        return Ok(result);
    }
}