using Application.RotaEntries.Create;
using Application.RotaEntries.Delete;
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

    [HttpPost]
    public async Task<IActionResult> AddRotaEntry([FromBody] CreateRotaEntryCommand entry)
    {
        await _sender.Send(entry);
        return (IActionResult)Results.Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRotaEntry([FromBody] Guid id)
    {
        try
        {
            await _sender.Send(new DeleteRotaEntryCommand(id));
            return (IActionResult)Results.Ok();
        }
        catch (RotaEntryNotFoundException e)
        {
            return (IActionResult)Results.NotFound(e.Message);
        }
    }
}