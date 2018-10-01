using System;

namespace Models.ViewModels
{
  public class BookEditViewModel
    {
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public Genre Genre { get; set; }
        public string PublisherName { get; set; }
        public string Titel { get; set; }
        public string Subtitel { get; set; }
        public string Series { get; set; }
        public int Seriesnumber { get; set; }
        public string Isbn { get; set; }
        public bool Ebook { get; set; }
        public bool Lent { get; set; }
        public bool Edit { get; set; }
        public string Place { get; set; }
        public DateTime ReleaseYear { get; set; }

    }
}