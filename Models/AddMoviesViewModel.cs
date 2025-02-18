﻿namespace SampleCrudApplication.Models
{
    public class AddMoviesViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string DirectorName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
