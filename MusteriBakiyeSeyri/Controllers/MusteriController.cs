using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusteriBakiyeSeyri.Controllers
{
    public class MusteriController : Controller
    {
        private readonly IMusteriService _musteriService;

        public MusteriController(IMusteriService musteriService)
        {
            _musteriService = musteriService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var musteriler = await _musteriService.GetAllMusterilerAsync();
            ViewBag.Musteriler = new SelectList(musteriler, "Id", "Unvan");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBakiyeSeyri(int musteriId)
        {
            var bakiyeSeyriDto = await _musteriService.GetMusteriBakiyeSeyriAsync(musteriId);

            if (bakiyeSeyriDto == null)
            {
                return NotFound();
            }

            return View("BakiyeDetay", bakiyeSeyriDto);
        }
    }
}