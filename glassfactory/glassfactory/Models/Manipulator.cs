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
        public Random Random = new Random();

        public IEnumerable<string> BreakIntoSentences (int id)
        {
            TextEntry thisTextEntry = DbContext.TextEntries.FirstOrDefault(x => x.Id == id);
            string entryBody = thisTextEntry.EntryBody;
            return entryBody.ToLower().Split(new char[]{ '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public IEnumerable<IEnumerable<string>> BreakSentenceIntoWords(IEnumerable<string> sentences)
        {
            List<List<string>> sentencesInWords = new List<List<string>>();
            foreach (string sentence in sentences)
            {
                List<string> words = sentence.Split(new char[] { ' ', '.', ',', '!', ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                sentencesInWords.Add(words);
            }
            return sentencesInWords;
        }

        public IEnumerable<IEnumerable<string>> BreakSentencesInHalf(List<List<string>> sentencesInWords)
        {
            List<List<string>> halfSentences = new List<List<string>>();
            foreach (List<string> sentence in sentencesInWords)
            {
                int midPoint = sentence.Count()/2;
                List<string> firstHalf = new List<string>();
                List<string> secondHalf = new List<string>();
                for (int i = 0; i < midPoint; i++)
                {
                    firstHalf.Add(sentence[i]);
                }
                for (int i = midPoint; i < sentence.Count; i++)
                {
                    secondHalf.Add(sentence[i]);
                }
                halfSentences.Add(firstHalf);
                halfSentences.Add(secondHalf);
            }
            return halfSentences;
        }

        public IEnumerable<IEnumerable<string>> ShuffleHalfSentences(List<List<string>> halfSentences)
        {
            int nextRandom;
            int halfSentencesCount = halfSentences.Count;
            List<List<string>> shuffledHalfSentences = new List<List<string>>();
            List<string> emptyList = new List<string>() {"empty"};
            for (int i = 0; i < halfSentencesCount; i++)
            {
                shuffledHalfSentences.Add(emptyList);
            }
            for (int i = 0; i < halfSentencesCount; i++)
            {
                nextRandom = Random.Next(0, halfSentences.Count);
                shuffledHalfSentences[i] = halfSentences[nextRandom];
                halfSentences.RemoveAt(nextRandom);
            }
            return shuffledHalfSentences;
        }

        public string Stringify(List<List<string>> shuffledHalfSentences)
        {
            string shuffled = "";
            foreach (List<string> halfSentence in shuffledHalfSentences)
            {
                foreach (string word in halfSentence)
                {
                    shuffled += word;
                }
            }
            return shuffled;
        }

    }
}