using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab10_2;
using Lab12_2;

namespace Lab13_2
{

        public class Journal
        {
            List<JournalEntry> journals = new List<JournalEntry>();
            public void CollectionCountChanged(object source, MyNewNewCollectionEventArgs args)
            {
            JournalEntry nwE = new JournalEntry(args.NameCollections, args.TypeEvent, args.NameEvent, args.Object);
                journals.Add(nwE);
            }
            public void CollectionReferenceChanged(object source, MyNewNewCollectionEventArgs args)
            {
            JournalEntry nwE = new JournalEntry(args.NameCollections, args.TypeEvent, args.NameEvent, args.Object);
                journals.Add(nwE);
            }

            public override string ToString()
            {
                if (journals.Count == 0) return "Журнал пуст!";
                string s = "";
                foreach (JournalEntry it in journals)
                {
                    s += it + "\n\n";
                }
                return s;
            }
            public void Clear()
            {
                journals.Clear();
            }
        }

    
}
