using Azure.Search.Documents.Models;
using Azure.Search.Documents;
using SearchIndexConsoleEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchIndexConsoleEnd.Helpers
{
    public class Queries
    {
        // Run queries, use WriteDocuments to print output /////////////////////////////////////////////////
        public static void RunQueries(SearchClient srchclient)
        {
            SearchOptions options;
            SearchResults<Hotel> response;

            // Query 1 /////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Query #1: Search on empty term '*' to return all documents, showing a subset of fields...\n");

            options = new SearchOptions()
            {
                IncludeTotalCount = true,
                Filter = "",
                OrderBy = { "" }
            };

            options.Select.Add("HotelId");
            options.Select.Add("HotelName");
            options.Select.Add("Rating");
            options.Select.Add("Address");

            response = srchclient.Search<Hotel>("*", options);
            WriteResults.WriteDocuments(response);

            // Query 2 /////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Query #2: Search on 'hotels', filter on 'Rating gt 4', sort by Rating in descending order...\n");

            options = new SearchOptions()
            {
                Filter = "Rating gt 4",
                OrderBy = { "Rating desc" }
            };

            options.Select.Add("HotelId");
            options.Select.Add("HotelName");
            options.Select.Add("Rating");

            response = srchclient.Search<Hotel>("hotels", options);
            WriteResults.WriteDocuments(response);
        }
    }
}
