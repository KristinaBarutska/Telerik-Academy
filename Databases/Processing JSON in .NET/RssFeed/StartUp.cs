namespace RssFeed
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            string xmlUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            string xmlFilePath = "../../rss-feed.xml";
            string jsonFilePath = "../../rss-feed-json.json";
            string htmlFilePath = "../../videos.html";

            DownloadXmlFile(xmlUrl, xmlFilePath);

            string json = GetJsonFromXml(xmlFilePath);
            var jsonObject = JObject.Parse(json);

            WriteJsonToFile(json, jsonFilePath);
            PrintAllVideoTitles(jsonObject);

            Video[] videos = GetVideos(jsonObject);
            string html = GetHtml(videos);

            WriteHtmlToFile(htmlFilePath, html);
        }

        private static void DownloadXmlFile(string url, string fileName)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(url, fileName);
        }

        private static string GetJsonFromXml(string xmlFilePath)
        {
            var document = XDocument.Load(xmlFilePath);
            string json = JsonConvert.SerializeXNode(document);

            return json;
        }

        private static void WriteJsonToFile(string json, string jsonFilePath)
        {
            var writer = new StreamWriter(jsonFilePath);
            writer.WriteLine(json);
        }

        private static void PrintAllVideoTitles(JObject jsonObject)
        {
            string[] videoTitles = (from element in jsonObject["feed"]["entry"]
                                    select (element["title"]).ToString()).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, videoTitles));
        }

        private static Video[] GetVideos(JObject jsonObject)
        {
            var videos = jsonObject["feed"]["entry"]
                .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()))
                .ToArray();

            return videos;
        }

        private static string GetHtml(Video[] videos)
        {
            var html = new StringBuilder();
            string htmlBegin = "<!DOCTYPE html><html><body>";
            string htmlEnd = "</body></html>";

            html.Append(htmlBegin);

            for (int i = 0; i < videos.Length; ++i)
            {
                Video currentVideo = videos[i];
                string currentVideoBody = string.Format("<div style=\"float:left; width: 400px; height: 430px; padding:10px;" +
                                  "margin:5px;border-radius:10px\">" +
                                  "<iframe width=\"400\" height=\"325\" " +
                                  "src=\"http://www.youtube.com/embed/{2}?autoplay=0\" " +
                                  "frameborder=\"0\" allowfullscreen></iframe>" +
                                  "<h3>{1}</h3><a href=\"{0}\"><button>" +
                                  "<strong>Go to YouTube</strong></button></a></div>",
                                  currentVideo.Link.Href, currentVideo.Title, currentVideo.Id);

                html.Append(currentVideoBody);
            }

            html.Append(htmlEnd);
            return html.ToString();
        }

        private static void WriteHtmlToFile(string htmlFilePath, string html)
        {
            var writer = new StreamWriter(htmlFilePath);
            writer.WriteLine(html);
        }
    }
}