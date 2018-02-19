using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameLibrary.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        public string ReleaseDate { get; set; }
        public string ReleaseYear { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
    }
}