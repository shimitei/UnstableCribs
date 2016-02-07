using AutocompleteMenuNS;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Translator.Command;
using Translator.Database;

namespace COIME
{
    public class SuggestCollection : IEnumerable<AutocompleteItem>, IDisposable
    {
        private TextBoxBase textBox;
        private DatabaseConnection db;

        public SuggestCollection(TextBoxBase tb)
        {
            textBox = tb;
            db = DatabaseConnection.Open();
        }

        public IEnumerator<AutocompleteItem> GetEnumerator()
        {
            return CreateSuggestList().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<AutocompleteItem> CreateSuggestList()
        {
            var search = GetSearchString();
            if (!string.IsNullOrEmpty(search))
            {
                const uint limit = 100;
                var list = TranslatorCommand.Translate(db, search, limit);
                foreach (var r in list)
                {
                    var item = new SugestItem();
                    item.Text = r.Word;
                    item.MenuText = string.Format("{0}:{1}", r.Word, r.Translator);
                    item.Tag = r;
                    yield return item;
                }
            }
        }

        private string GetSearchString()
        {
            //split by white-space
            var ar = textBox.Text.Split(null);
            string result = ar[ar.Length -1]; //last
            return result;
        }

        public void Dispose()
        {
            textBox = null;
            db.Dispose();
        }
    }

    class SugestItem : AutocompleteItem
    {
        override public CompareResult Compare(string fragmentText)
        {
            return CompareResult.Visible;
        }
    }
}
