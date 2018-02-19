using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace VideoGameLibrary.Models
{
    [XmlRoot("VideoGames")]
    public class VideoGames
    {
        [XmlElement("VideoGame")]
        public List<VideoGame> videoGames;
    }
}