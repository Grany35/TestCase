using Microsoft.AspNetCore.Mvc;
using TestCase.Business.Abstract;
using TestCase.Core.Utilities.Params;

namespace TestCase.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AwardsController : ControllerBase
{
    private readonly IAwardService _awardService;

    public AwardsController(IAwardService awardService)
    {
        _awardService = awardService;
    }

    [HttpGet]
    public IActionResult GetAwards([FromQuery] AwardParams awardParams)
    {
        var result = _awardService.GetAwards(awardParams);

        return Ok(result);
    }
}