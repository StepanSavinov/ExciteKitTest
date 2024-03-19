using ExciteKit.API.Models;
using ExciteKit.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExciteKit.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    [Route("/EventsList")]
    public async Task<IActionResult> GetEventsList()
    {
        return Ok(await context.Events
            .OrderByDescending(x => x.CaptureDt)
            .ToListAsync()
        );
    }
    
    [HttpGet]
    [Route("/EventsListUnique")]
    public async Task<IActionResult> GetUniqueUrlsEventsList()
    {
        var events = await context.Events
            .OrderByDescending(x => x.CaptureDt)
            .ToListAsync();
        
        return Ok(events.DistinctBy(x => x.Url));
    }
    
    [HttpGet]
    [Route("/EventsListByDate")]
    public async Task<IActionResult> GetEventsListByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        return Ok(await context.Events
            .OrderByDescending(x => x.CaptureDt)
            .Where(x => x.CaptureDt.Date >= startDate.Date && x.CaptureDt.Date <= endDate.Date)
            .ToListAsync()
        );
    }

    [HttpGet]
    [Route("/EventsUserUrls")]
    public async Task<IActionResult> GetUserEvents(int userId)
    {
        var events = await context.Events
            .Where(x => x.UserId == userId)
            .GroupBy(x => x.Url)
            .Select(x => new UrlCountVm{ Url = x.Key, Count = x.Count() })
            .ToListAsync();

        return Ok(events);
    }
    
    [HttpGet]
    [Route("/EventsUserIds")]
    public async Task<IActionResult> GetUsersIds()
    {
        var usersIds = await context.Events
            .Select(x => x.UserId)
            .ToListAsync();

        return Ok(usersIds.DistinctBy(x => x));
    }

    [HttpGet]
    [Route("/EventsGetUsersSteps")]
    public async Task<IActionResult> GetUsersSteps()
    {
        var data = await context.UserSteps
            .FromSqlRaw("EXEC GetUserEventSteps")
            .ToListAsync();
        
        return Ok(data);
    }
}