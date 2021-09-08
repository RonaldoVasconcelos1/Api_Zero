using System.Collections.Generic;
using api.Models;

namespace api
{
    public class MoviesDataStore
    {
        public static MoviesDataStore Current { get; private set; } = new MoviesDataStore();
        public List<MovieDto> Movies { get; set; }

        public MoviesDataStore()
        {
            Movies = new List<MovieDto>()
            {
                new MovieDto() {
                    Id = 1,
                    Name= "Pandas em New York",
                    Description = "Um panda louco",
                    Casts = new List<CastDto>() {
                        new CastDto { Id = 1, Name = "Daniel jose", Character = "Yes"},
                        new CastDto { Id = 2, Name = "Jose hohas", Character = "kikasdjh"},
                        new CastDto { Id = 3, Name = "Amarildo", Character = "inteligng"},
                    }
                },
                 new MovieDto() {
                    Id = 2,
                    Name= "Madagascar",
                    Description = "Aventura",
                    Casts = new List<CastDto>() {
                        new CastDto { Id = 1, Name = "Daniel jose", Character = "Yes"},
                        new CastDto { Id = 2, Name = "Jose hohas", Character = "kikasdjh"},
                        new CastDto { Id = 3, Name = "Amarildo", Character = "inteligng"},
                    }
                },
                 new MovieDto() {
                    Id = 3,
                    Name= "Sherek",
                    Description = "Ogro doidão",
                    Casts = new List<CastDto>() {
                        new CastDto { Id = 1, Name = "Daniel jose", Character = "Yes"},
                        new CastDto { Id = 2, Name = "Jose hohas", Character = "kikasdjh"},
                        new CastDto { Id = 3, Name = "Amarildo", Character = "inteligng"},
                    }
                },
                 new MovieDto() {
                    Id = 4,
                    Name= "Kung fu",
                    Description = "Panda",
                    Casts = new List<CastDto>() {
                        new CastDto { Id = 1, Name = "Daniel jose", Character = "Yes"},
                        new CastDto { Id = 2, Name = "Jose hohas", Character = "kikasdjh"},
                        new CastDto { Id = 3, Name = "Amarildo", Character = "inteligng"},
                    }
                },
            };
        }
    }
}
