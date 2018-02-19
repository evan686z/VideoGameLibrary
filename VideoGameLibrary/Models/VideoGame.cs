using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameLibrary.Models
{
    public class VideoGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
    }
}