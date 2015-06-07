using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace glassfactory.Models
{
    public class Manipulator
    {
        public ApplicationDbContext DbContext { get; set; }

        public IEnumerable<string> BreakIntoSentences (int id)
        {
            TextEntry thisTextEntry = DbContext.TextEntries.FirstOrDefault(x => x.Id == id);
            string entryBody = thisTextEntry.EntryBody;
            return entryBody.Split('.');
        }

        public IEnumerable<IEnumerable<string>> BreakIntoWords(IEnumerable<string> sentences)
        {
            IEnumerable<IEnumerable<string>> sentencesInWords = new List<List<string>>();
            foreach (string sentence in sentences)
            {
                
            }
            return sentencesInWords;
        }
    }
}