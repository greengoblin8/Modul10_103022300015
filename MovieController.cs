using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using modul10_103022300015;

namespace modul10_103022300015.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> Movies = new List<Movie>
        {
            new Movie ("The Shawsank Redemption", "Frank Darabont", ["Tim Robbins", "Morgan Freeman", "Bob Gunton"], "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." ),
            new Movie ("The Godfather", "Francis Ford Coppola", ["Marlon Brando, Al Pacino, James Caan"], "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son" ),
            new Movie ("The Dark Knight", "Christopher Nolan", ["Christian Bale, Heath Ledger, Aaron Eckhart"], "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."),
        };

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return Movies;
        }

        [HttpGet("{index}")]

        public ActionResult<Movie> Get(int index)
        {
            if (index < 0 || index >= Movies.Count)
            {
                return NotFound();
            }
            return Movies[index];
        }

        [HttpPost]

        public void Post([FromBody] Movie MovieBaru)
        {
            Movies.Add(MovieBaru);
        }

        [HttpDelete("{index}")]

        public void Delete(int index)
        {
            if (index >= 0 && index < Movies.Count)
            {
                Movies.RemoveAt(index);
            }
        }
    }
}
