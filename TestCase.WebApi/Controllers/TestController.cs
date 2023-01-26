using Microsoft.AspNetCore.Mvc;
using TestCase.Business.Abstract;

namespace TestCase.WebApi.Controllers;

[ApiController]
public class TestController : ControllerBase
{
    private readonly IPointService _pointService;
    private readonly ILeaderBoardService _leaderBoardService;

    public TestController(IPointService pointService, ILeaderBoardService leaderBoardService)
    {
        _pointService = pointService;
        _leaderBoardService = leaderBoardService;
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
         await _leaderBoardService.AddToLeaderBoard();
        return Ok("");
    }
    
}   