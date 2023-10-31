using Application.RotaEntries.Create;
using Application.RotaEntries.Delete;
using Application.RotaEntries.Get;
using Domain.RotaEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("RotaEntry")]
public class RotaEntry
{
    private ISender _sender;

    public RotaEntry(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IResult> GetRotaEntry([FromQuery] Guid id)
    {
        var entry = await _sender.Send(new GetRotaEntryQuery(id));
        return Results.Ok(entry);
    }
        
    [HttpPost]
    public async Task<IResult> AddRotaEntry([FromBody] CreateRotaEntryCommand entry)
    {
        await _sender.Send(entry);
        return Results.Ok();
    }

    [HttpDelete]
    public async Task<IResult> DeleteRotaEntry([FromBody] Guid id)
    {
        try
        {
            await _sender.Send(new DeleteRotaEntryCommand(id));
            return Results.Ok();
        }
        catch (RotaEntryNotFoundException e)
        {
            return Results.NotFound(e.Message);
        }
    }
}