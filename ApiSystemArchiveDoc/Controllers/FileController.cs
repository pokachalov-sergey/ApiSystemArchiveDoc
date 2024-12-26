using Microsoft.AspNetCore.Mvc;

namespace ApiSystemArchiveDoc.Controllers;

public class FileController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file,Guid storeObjectId
        , string fileType, string fileCategory)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Файл не выбран.");
        }

        string uploadFolder = Path.Combine("c://", "uploads");
        string fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine(uploadFolder, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        // Сохраните информацию о файле в базу данных...

        return Ok(new { message = "Файл успешно загружен." });
    }
}