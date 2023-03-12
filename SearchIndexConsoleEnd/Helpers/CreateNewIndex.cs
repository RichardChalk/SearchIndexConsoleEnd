using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using SearchIndexConsoleEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchIndexConsoleEnd.Helpers
{
    public class CreateNewIndex
    {
        // Create hotels-quickstart index ////////////////////////////////////////////////////////
        public static void CreateIndex(string indexName, SearchIndexClient adminClient)
        {
            FieldBuilder fieldBuilder = new FieldBuilder();
            var searchFields = fieldBuilder.Build(typeof(Hotel));

            var definition = new SearchIndex(indexName, searchFields);

            var suggester = new SearchSuggester("sg", new[] { "HotelName", "Category", "Address/City", "Address/StateProvince" });
            definition.Suggesters.Add(suggester);

            adminClient.CreateOrUpdateIndex(definition);
        }
    }
}
