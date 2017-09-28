using BusinessLayers.MapperClass;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace InvoiceTow.Controllers
{
    public class ProductController : Controller
    {
        private IProductMapper _ProductMapper { get; }
        private ICategoryMapper _categorymapper { get; }

        public ProductController(IProductMapper productMapper, ICategoryMapper categoryMapper)
        {
            _ProductMapper = productMapper;
            _categorymapper = categoryMapper;
        }
        public async Task<IActionResult> Index()
        {

            var comp = _ProductMapper.BlGetAll();
            //return View(comp);
            return View(await comp);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            var company = _categorymapper.BlGetAllCategory();
            //var comp = _ProductMapper.BlGetAll2();

            ViewData["CategoryId"] = new SelectList(company, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,SupplierName,CategoryID,QuantityPerUnit,UnitPrice,UnitsOnOrder")] ProductVm post)
        {
            if (ModelState.IsValid)
            {
                await _ProductMapper.BlInser(post);

                return RedirectToAction(nameof(Index));
            }
            var company = _categorymapper.BlGetAllCategory();
            //var comp = _ProductMapper.BlGetAll2();

            ViewData["CategoryID"] = new SelectList(company, "CategoryID", "CategoryName", post.CategoryId);
           
            return View(post);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _ProductMapper.BlGetById(id);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _ProductMapper.BlGetById(id);
            if (Product == null)
            {
                return NotFound();
            }
            var company = _categorymapper.BlGetAllCategory();
            ViewData["CategoryId"] = new SelectList(company, "CategoryId", "CategoryName");
            return View(Product);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierName,CategoryId,QuantityPerUnit,UnitPrice,UnitsOnOrder")] ProductVm Product)
        {
            if (id != Product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ProductMapper.BlUpdateAsync(Product);

                }
                catch (DbUpdateConcurrencyException)
                {
                    var Exists = _ProductMapper.ProductExists((Product.ProductId));
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
            var company = _categorymapper.BlGetAllCategory();
            ViewData["CategoryId"] = new SelectList(company, "CategoryId", "CategoryName");
            return View(Product);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _ProductMapper.BlGetById(id);

            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ProductMapper.BlDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}