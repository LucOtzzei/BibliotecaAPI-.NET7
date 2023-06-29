using Azure;
using Azure.Core;
using FluentResults;
using Otzzei.Biblioteca.Domain.Entities;
using Otzzei.Biblioteca.Domain.Interfaces.IRepository;
using Otzzei.Biblioteca.Domain.Interfaces.IServices;
using Otzzei.Biblioteca.Domain.Requests;
using Otzzei.Biblioteca.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Otzzei.Biblioteca.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublishingCompanyRepository _publisherRepository;
        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IPublishingCompanyRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<Result<BookResponse>> CreateBookAsync(BookRequest request)
        {
            var book = new Book(request);
            await _bookRepository.CreateBookAsync(book);

            var count = request.Genres.Count();
            for (int i = 0; i < count; i++)
            {
                var genre = new Genre(request.Genres[i], book.Id);
                await _bookRepository.AddGenreInBookAsync(genre);
            };

            var response = await CreateBookResponse(book);
            return Result.Ok();
        }

        public async Task<Result<List<BookResponse>>> GetAllBooksAsync()
        {
            var booksList = _bookRepository.GetAllBooks();
            var response = await CreateSeveralBookResponse(booksList);

            return Result.Ok(response);
        }

        public async Task<Result<BookResponse>> GetBookByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            var response = await CreateBookResponse(book);

            return Result.Ok(response);
        }

        public async Task<Result<BookResponse>> UpdateBookAsync(Guid id, BookRequest request)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            book.Update(request);
            await _bookRepository.UpdateBookAsync(book);

            var updatedBook = await _bookRepository.GetBookByIdAsync(id);
            var response = await CreateBookResponse(updatedBook);

            return Result.Ok(response);
        }

        private async Task<List<BookResponse>> CreateSeveralBookResponse(List<Book> books)
        {
            var response = new List<BookResponse>();
            foreach (var book in books)
            {
                var author = await _authorRepository.GetAuthorById(book.AuthorId);
                var publisher = await _publisherRepository.GetByIdPublishingCompanyAsync(book.PublishingCompanyId);
                var genres = await _bookRepository.GetGenresBooksById(book.Id);

                var add = new BookResponse(book.Name, genres, new AuthorResponse(author), new PublishingCompanyResponse(publisher));
                response.Add(add);
            }
            return response;
        }
        private async Task<BookResponse> CreateBookResponse(Book book)
        {
            var author = await _authorRepository.GetAuthorById(book.AuthorId);
            var publisher = await _publisherRepository.GetByIdPublishingCompanyAsync(book.PublishingCompanyId);
            var genres = await _bookRepository.GetGenresBooksById(book.Id);

            return new BookResponse(book.Name, genres, new AuthorResponse(author), new PublishingCompanyResponse(publisher));
        }
    }
}
