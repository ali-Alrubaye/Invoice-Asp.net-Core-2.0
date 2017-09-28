using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InvoiceTow.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryMapper _CategoryMapper { get; }

        public CategoryController(ICategoryMapper categoryMapper)
        {
            _CategoryMapper = categoryMapper;
        }
        public async Task<IActionResult> Index()
        {

            var comp = _CategoryMapper.BlGetAll();
            //return View(comp);
            return View(await comp);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            //ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId");
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,CategoryName,Description,Picture")] CategoryVm post)
        {
            if (ModelState.IsValid)
            {
                await _CategoryMapper.BlInser(post);

                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await _CategoryMapper.BlGetById(id);
            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await _CategoryMapper.BlGetById(id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,CategoryName,Description,Picture")] CategoryVm Category)
        {
            if (id != Category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _CategoryMapper.BlUpdateAsync(Category);

                }
                catch (DbUpdateConcurrencyException)
                {
                    var Exists = _CategoryMapper.CategoryExists((Category.CategoryId));
                    if (!Exists)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await _CategoryMapper.BlGetById(id);

            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _CategoryMapper.BlDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}