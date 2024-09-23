namespace users.RestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaasController : ControllerBase
{
    private readonly ISaasRepository _saasRepository;
    private readonly UploadService _uploadService;

    public SaasController(ISaasRepository saasRepository, UploadService uploadService)
    {
        _saasRepository = saasRepository;
        _uploadService = uploadService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Saas>>> GetAllSaas()
    {
        var saas = await _saasRepository.GetAllAsync();
        return Ok(saas);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Saas>> CreateSaas([FromForm] Saas saas)
    {
        if (saas.ImgUrl != null)
        {
            var filePath = await _uploadService.UploadFileAsync(saas.ImgUrl);
            saas.ImgUrl = filePath;
        }

        var createdSaas = await _saasRepository.AddAsync(saas);
        return CreatedAtAction(nameof(GetSaasById), new { id = createdSaas.Id }, createdSaas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Saas>> GetSaasById(int id)
    {
        var saas = await _saasRepository.GetByIdAsync(id);
        if (saas == null)
            return NotFound();
        return Ok(saas);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSaas(int id, [FromForm] Saas saas)
    {
        if (id != saas.Id)
            return BadRequest();

        if (saas.ImgUrl != null)
        {
            var filePath = await _uploadService.UploadFileAsync(saas.ImgUrl);
            saas.ImgUrl = filePath;
        }

        await _saasRepository.UpdateAsync(saas);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSaas(int id)
    {
        await _saasRepository.DeleteAsync(id);
        return NoContent();
    }
}