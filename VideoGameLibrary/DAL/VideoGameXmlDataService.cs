using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using VideoGameLibrary.Models;

namespace VideoGameLibrary.DAL
{
    public class VideoGameXmlDataService : IVideoGameDataServices, IDisposable
    {
        public List<VideoGame> Read()
        {
            // a VideoGames model is defined to pass a type to the XmlSerializer object
            VideoGames videoGamesObject;

            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            // initialize a XML serializer object
            XmlSerializer deserializer = new XmlSerializer(typeof(VideoGames));

            using (sReader)
            {
                // deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                // cast the generic object to the list class
                videoGamesObject = (VideoGames)xmlObject;
            }

            return videoGamesObject.videoGames;
        }

        public void Write(List<VideoGame> videoGames)
        {
            // initialize a FilePath object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<VideoGame>), new XmlRootAttribute("VideoGames"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, videoGames);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}