using Azure.Search.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchIndexConsoleEnd.Helpers
{
    public class DeleteIndex
    {
        // Delete the hotels-quickstart index to reuse its name /////////////////////////////////
        public static void DeleteIndexIfExists(string indexName, SearchIndexClient adminClient)
        {
            adminClient.GetIndexNames();
            {
                adminClient.DeleteIndex(indexName);
            }
        }
    }
}
