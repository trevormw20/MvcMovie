using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                   
                    new Movie
                    {
                        Title = "Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("2002-3-12"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 8.99M,
                        ImageName = "heaven.jpg"
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-12"),
                        Genre = "Documentary",
                        Rating = "PG",
                        Price = 9.99M,
                        ImageName = "meet.jpg"
                    },

                    new Movie
                    {
                        Title = "The Testaments",
                        ReleaseDate = DateTime.Parse("2000-4-24"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 3.99M,
                        ImageName = "testements.jpg"
                    },

                     new Movie
                     {
                         Title = "The RM",
                         ReleaseDate = DateTime.Parse("2000-2-12"),
                         Genre = "Comedy",
                         Rating = "PG",
                         Price = 7.99M,
                         ImageName = "rm.jpg"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}