﻿using System;
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
        public string ReleaseDate { get; set; }
        [Display(Name = "Release Year")]
        public string ReleaseYear { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        [Display(Name = "Embeded YouTube Link")]
        public string YouTubeEmbedLink { get; set; }
    }
}