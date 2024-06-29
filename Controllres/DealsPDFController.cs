using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class DealsController : ControllerBase
{
    [HttpGet("download")]
    public IActionResult DownloadDealsPdf()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Sample.pdf");
        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "application/pdf", "Deals.pdf");
    }
}