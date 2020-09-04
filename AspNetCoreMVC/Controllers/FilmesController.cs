using AspNetCoreMVC.Data;
using AspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMVC.Controllers
{
    public class FilmesController : Controller
    {
        private readonly FilmesContext _context;

        public FilmesController(FilmesContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index(string filmeGenero, string criterioDeBusca)
        {
            IQueryable<string> consultaGenero = from f in _context.Filmes orderby f.Genero select f.Genero;

            var filmes = from f in _context.Filmes select f;

            if (!string.IsNullOrWhiteSpace(criterioDeBusca))
                filmes = filmes.Where(f => f.Titulo.ToLower().Contains(criterioDeBusca.ToLower()));

            if (!string.IsNullOrWhiteSpace(filmeGenero))
                filmes = filmes.Where(f => f.Genero.ToLower().Contains(filmeGenero.ToLower()));


            var filmeGeneroVM = new FilmeGeneroViewModel();
            filmeGeneroVM.generos = new SelectList(await consultaGenero.Distinct().ToListAsync());
            filmeGeneroVM.filmes = await filmes.ToListAsync();

            return View(filmeGeneroVM);
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var filme = await _context.Filmes.FirstOrDefaultAsync(m => m.ID == id);

            if (filme == null)
                return NotFound();

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Lancamento,Genero,Preco,Classificacao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Lancamento,Genero,Preco,Classificacao")] Filme filme)
        {
            if (id != filme.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.ID))
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
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
            return _context.Filmes.Any(e => e.ID == id);
        }
    }
}
