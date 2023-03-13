using Azure.Search.Documents.Models;
using Azure.Search.Documents;
using SearchIndexConsoleEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;

namespace SearchIndexConsoleEnd.Helpers
{
    public class Queries
    {
        // Run queries, use WriteDocuments to print output /////////////////////////////////////////////////
        public static void RunQueries(SearchClient srchclient)
        {
            SearchOptions options;
            SearchResults<Hotel> response;

            // Query 1 ///////////////////////////////////////////////////////////////////
            //Console.WriteLine("Query #1: Search on empty term '*' to return all documents, " +
            //    "showing a subset of fields...\n");

            //options = new SearchOptions()
            //{
            //    IncludeTotalCount = true,
            //    Filter = "",
            //    OrderBy = { "" }
            //};

            //options.Select.Add("HotelId");
            //options.Select.Add("HotelName");
            //options.Select.Add("Rating");
            //options.Select.Add("Address");

            //response = srchclient.Search<Hotel>("*", options);
            //WriteResults.WriteDocuments(response);

            // Query 2 ///////////////////////////////////////////////////////////////////
            // söker du efter en term, lägger till ett filter som väljer dokument där
            // Klassificering är större än 4 och sorterar sedan efter Klassificering i
            // fallande ordning. Filter är ett booleskt uttryck som utvärderas över
            // IsFilterable-fält i ett index. Filterfrågor inkluderar eller exkluderar värden. 
            //Console.WriteLine("Query #2: Search on 'hotels', filter on 'Rating gt 4', " +
            //    "sort by Rating in descending order...\n");

            //options = new SearchOptions()
            //{
            //    Filter = "Rating gt 4",
            //    OrderBy = { "Rating desc" }
            //};

            //options.Select.Add("HotelId");
            //options.Select.Add("HotelName");
            //options.Select.Add("Rating");
            //options.Select.Add("Address");

            //response = srchclient.Search<Hotel>("hotels", options);
            //WriteResults.WriteDocuments(response);

            // Query 3 ////////////////////////////////////////////////////////////////////
            //  visar searchFields, som används för att begränsa en fulltextsökningsåtgärd
            //  till specifika fält.
            //Console.WriteLine("Query #3: Limit search to specific fields " +
            //    "(pool in Tags field)...\n");

            //options = new SearchOptions()
            //{
            //    SearchFields = { "Tags" }
            //};

            //options.Select.Add("HotelId");
            //options.Select.Add("HotelName");
            //options.Select.Add("Tags");
            //options.Select.Add("Address");

            //response = srchclient.Search<Hotel>("pool", options);
            //WriteResults.WriteDocuments(response);

            // Query 4 /////////////////////////////////////////////////////////////////////
            // visar faser, som kan användas för att strukturera en aspektbaserad
            // navigeringsstruktur.
            //Console.WriteLine("Query #4: Facet on 'Category'...\n");

            //options = new SearchOptions()
            //{
            //    Filter = ""
            //};

            //options.Facets.Add("Category");

            //options.Select.Add("HotelId");
            //options.Select.Add("HotelName");
            //options.Select.Add("Category");
            //options.Select.Add("Address");

            //response = srchclient.Search<Hotel>("*", options);
            //WriteResults.WriteDocuments(response);

            // Query 5 ///////////////////////////////////////////////////////////////////////
            // Returnerar du ett specifikt dokument. En dokumentsökning är ett typiskt svar
            // på OnClick-händelsen i en resultatuppsättning.
            //Console.WriteLine("Query #5: Look up a specific document...\n");

            //Response<Hotel> lookupResponse;
            //lookupResponse = srchclient.GetDocument<Hotel>("3");

            //Console.WriteLine(lookupResponse.Value.HotelId);

            // Query 6 ///////////////////////////////////////////////////////////////////////
            // Visar syntaxen för automatisk komplettering, vilket simulerar en partiell
            // användarinmatning av "sa" som matchar två möjliga matchningar i de sourceFields som är associerade med den förslagsanvändare som du definierade i indexet.
            //Console.WriteLine("Query #6: Call Autocomplete on HotelName that starts with " +
            //    "'sa'...\n");

            //var autoresponse = srchclient.Autocomplete("sa", "sg");
            //WriteResults.WriteDocuments(autoresponse);


            // Query 7 /////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Query #7: Let user search for a specific telephone number " +
                "showing this subset of fields...Hotel name, telephone number & Rating\n" +
                "Låt användaren väljer om Rating ska sorteras asc eller desc\n" +
                "Also return total number of results\n");


            Console.WriteLine("Telephone number to search for:");
            var TelNumUserChoice = Console.ReadLine();

            Console.WriteLine("Sort Rating:");
            Console.WriteLine("1. Asc");
            Console.WriteLine("2. Desc");
            var sortOrderUserChoice = Console.ReadLine();
            string sortOrderUserChoiceStr = (sortOrderUserChoice == "1") ? "asc" : "desc";

            options = new SearchOptions()
            {
                IncludeTotalCount = true, // Behövs för att visa total antal svar
                SearchFields = { "Address/TelNum" }, // Sök endast i denna field
                Filter = "",
                OrderBy = { $"Rating {sortOrderUserChoiceStr}" }
            };

            options.Select.Add("HotelName");
            options.Select.Add("Address");
            options.Select.Add("Rating");

            response = srchclient.Search<Hotel>(TelNumUserChoice, options);
            WriteResults.WriteDocuments(response);
        }
    }
}
