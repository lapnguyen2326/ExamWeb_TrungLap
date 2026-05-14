using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamWeb_TrungLap.Data;
using ExamWeb_TrungLap.Models;

namespace ExamWeb_TrungLap.Controllers
{
    public class MusicController : Controller
    {
        private readonly AppDbContext _context;

        public MusicController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Music/Index
        public async Task<IActionResult> Index()
        {
            var danhSach = await _context.DiaNhacs.ToListAsync();
            return View(danhSach);
        }

        // GET: Music/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: Music/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DiaNhac model)
        {
            if (ModelState.IsValid)
            {
                _context.DiaNhacs.Add(model);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm đĩa nhạc thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Music/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var diaNhac = await _context.DiaNhacs.FindAsync(id);
            if (diaNhac == null) return NotFound();
            return View(diaNhac);
        }

        // POST: Music/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, DiaNhac model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật đĩa nhạc thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.DiaNhacs.Any(e => e.Id == id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // POST: Music/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var diaNhac = await _context.DiaNhacs.FindAsync(id);
            if (diaNhac != null)
            {
                _context.DiaNhacs.Remove(diaNhac);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa đĩa nhạc thành công!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
