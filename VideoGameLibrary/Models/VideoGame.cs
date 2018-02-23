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
        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [RegularExpression(@"(Jan(uary)?|Feb(ruary)?|Mar(ch)?|Apr(il)?|May|Jun(e)?|Jul(y)?|Aug(ust)?|Sep(tember)?|Oct(ober)?|Nov(ember)?|Dec(ember)?)\s+\d{1,2},\s+\d{4}", ErrorMessage = "Please enter a valid date (Month Name, Day, Year).")]
        public string ReleaseDate { get; set; }
        [Display(Name = "Release Year")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Please Enter a 4 digit year.")]
        public string ReleaseYear { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        [Display(Name = "Embeded YouTube Link")]
        [RegularExpression(@"(?:https?:\/\/)?(?:www\.)?youtu\.?be(?:\.com)?\/?.*(?:watch|embed)?(?:.*v=|v\/|\/)([\w\-_]+)\&?", ErrorMessage = "Please Enter a valid YouTube src embed link.")]
        public string YouTubeEmbedLink { get; set; }
    }
}