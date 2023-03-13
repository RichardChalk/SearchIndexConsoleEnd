using Azure.Search.Documents.Models;
using SearchIndexConsoleEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchIndexConsoleEnd.Helpers
{
    public class WriteResults
    {
        // Write search results to console //////////////////////////////////////////////////////////
        public static void WriteDocuments(SearchResults<Hotel> searchResults)
        {
            Console.WriteLine($" Total Hotels: {searchResults.TotalCount}");
            Console.WriteLine("*****************");
            foreach (SearchResult<Hotel> result in searchResults.GetResults())
            {
                Console.WriteLine(result.Document);
            }

            Console.WriteLine();
        }

        public static void WriteDocuments(AutocompleteResults autoResults)
        {
            foreach (AutocompleteItem result in autoResults.Results)
            {
                Console.WriteLine(result.Text);
            }

            Console.WriteLine();
        }

    }
}
