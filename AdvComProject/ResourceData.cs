using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Resource
{
    public class ResourceData
    {
        public string CourseId { get; set; }
        public string title  { get; set; }
        public JsonArray bookName { get; set; }
        public JsonArray bookPath { get; set; }
        public JsonArray bookCover { get; set; }
        public JsonArray videoName { get; set; }
        public JsonArray videoPath { get; set; }
        public JsonArray videoCover { get; set; }
        public JsonArray sheetName { get; set; }
        public JsonArray sheetPath { get; set; }
        public JsonArray sheetCover { get; set; }
    
    }
}
