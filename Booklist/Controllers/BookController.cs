using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Models.ViewModels;
using DataManagment.Services.Contracts;
using Models.Identity;

namespace Controllers
{
  [Authorize]
    public class BookController : Controller
    {
        private IBookService _BookService;
        private UserManager<ApplicationUser> _UserManager;

        public BookController(IBookService bookService,
                                UserManager<ApplicationUser> userManager)
        {
            _BookService = bookService;
            _UserManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var model = new BooksViewModel();
            var userID = _UserManager.GetUserId(this.User);

            model.Books = await _BookService.GetBooksForUser(new Guid(userID));
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id = null)
        {
            var model = new BookEditViewModel();
            if (id == null)
            {
                return View(model);
            }

            var book = await _BookService.GetById(new Guid(id));
            model.Id = id;
            model.Titel = book.Titel;
            model.Subtitel = book.Subtitel;
            model.Isbn = book.Isbn;
            model.PublisherName = book.Publisher?.Name;
            model.AuthorName = book.GetAuthorString();
            model.Series = book.Series;
            model.Seriesnumber = book.Seriesnumber;
            //model.Genre = book.Genre;
            model.Ebook = book.Ebook;
            model.Lent = book.Lent;
            model.Edit = true;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Edit)
                {
                    await _BookService.Save(model);
                    return Redirect("/book");
                }
                await _BookService.CreateFromViewModel(model, await _UserManager.GetUserAsync(User));
                return Redirect("/book");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _BookService.Delete(new Guid(id));
            return Redirect("/book/Index");
        }
    }
}