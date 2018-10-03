using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using DataManagment.Services.Contracts;
using DataManagment.Database.Contracts;
using Models;
using Models.ViewModels;
using Models.Relations;
using Models.Identity;

namespace DataManagment.Services
{
  public class BookService : IBookService
    {
        private IPublisherService _PublisherService;
        private IAuthorService _AuthorService;
        private IApplicationContext _AppContext;

        public BookService(IApplicationContext appContext, 
                           IPublisherService publisherService, 
                           IAuthorService authorService)
        {
            _AppContext = appContext;
            _PublisherService = publisherService;
            _AuthorService = authorService;
        }

        public async Task<IEnumerable<Book>> GetBooksForUser(Guid id)
        {
            return await _AppContext.Books

                .Where(b => new Guid(b.User.Id) == id)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Publisher).ToListAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _AppContext.Books
                .Include(b => b.BookAuthors)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _AppContext.Books
                .Include(b => b.BookAuthors)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> Create(Book item)
        {
            await _AppContext.Books.AddAsync(item);
            await _AppContext.SaveAsync();
            return item;
        }
        public async Task Delete(Book item)
        {
            _AppContext.Books.Remove(item);
            await _AppContext.SaveAsync();
        }

        public async Task Delete(Guid id)
        {
            var book = _AppContext.Books.FirstOrDefault(b => b.Id == id);
            await Delete(book);
        }

        public async Task CreateFromViewModel(BookEditViewModel model, ApplicationUser user)
        {
            var book = new Book
            {
                Ebook = model.Ebook,
                Lent = model.Lent,
                //Genre = model.Genre,
                Isbn = model.Isbn,
                Place = model.Place,
                ReleaseYear = model.ReleaseYear,
                Series = model.Series,
                Seriesnumber = model.Seriesnumber,
                Subtitel = model.Subtitel,
                Titel = model.Titel,
                User = user
            };
            if (model.PublisherName != null)
            {
                book.Publisher = await GetOrGeneratePublisher(model.AuthorName);
            }

            if (model.AuthorName != null)
            {
                var authors = model.AuthorName.Split("; ");

                foreach (var item in authors)
                {
                    var author = await _AuthorService.FindByName(item);
                    if (author == null)
                    {
                        author = new Author
                        {
                            Name = item,
                            CreatedOn = DateTime.Now
                        };
                        author = await _AuthorService.Create(author);
                    }
                    book.BookAuthors.Add(new BookAuthor
                    {
                        BookId = book.Id,
                        AuthorId = author.Id
                    });
                }
            }
            _AppContext.Books.Add(book);
            await _AppContext.SaveAsync();
        }

        private async Task<Publisher> GetOrGeneratePublisher(string name)
        {
            var publisher = _PublisherService.FindByName(name);
            if (publisher == null)
            {
                publisher = await _PublisherService.Create(name);
            }
            return publisher;
        }

        public async Task Save(BookEditViewModel model)
        {
            var book = await GetById(new Guid(model.Id));

            book.Ebook = model.Ebook;
            book.Lent = model.Lent;
            //book.Genre = model.Genre;
            book.Isbn = model.Isbn;
            book.Place = model.Place;
            book.ReleaseYear = model.ReleaseYear;
            book.Series = model.Series;
            book.Seriesnumber = model.Seriesnumber;
            book.Subtitel = model.Subtitel;
            book.Titel = model.Titel;

            if (book.Publisher.Name != model.PublisherName)
            {
                book.Publisher = await GetOrGeneratePublisher(model.PublisherName);
            }

            if (model.AuthorName != null)
            {
                var authors = model.AuthorName.Split(";");
                var list = authors.Where(a => book.BookAuthors.Select(ab => ab.Author.Name).Contains(a));

                if (list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        var author = new Author
                        {
                            Name = item,
                            CreatedOn = DateTime.Now
                        };
                        author = await _AuthorService.Create(author);
                        book.BookAuthors.Add(new BookAuthor
                        {
                            AuthorId = author.Id,
                            BookId = book.Id
                        });
                    }
                }
            }
            _AppContext.Books.Update(book);
            await _AppContext.SaveAsync();
        }
    }
}