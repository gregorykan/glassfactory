using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace glassfactory.Models
{
    public class TextEntry
    {
        public int Id { get; set; }
        public string EntryName { get; set; }
        public string AuthorName { get; set; }
        public string EntryBody { get; set; }
    }
}