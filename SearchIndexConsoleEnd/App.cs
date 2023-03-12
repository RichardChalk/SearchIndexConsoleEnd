using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using Azure.Search.Documents;
using SearchIndexConsoleEnd.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using SearchIndexConsoleEnd.Helpers;

namespace SearchIndexConsoleEnd
{
    public class App
    {
        public void Run()
        {
            // Info from my Azure Portal
            string serviceName = "azure-search-demo";
            string apiKey = "BnKvEo0tIarB0UGWTuD14M0gwm0FJgGERVH6kzANHxAzSeB59L99";
            string indexName = "hotels-search";

            // ///////////////////////////////////////////////////////////////////////////////////
            // Skapa två klienter:
            //
            // 1. SearchIndexClient skapar indexet och
            // 2. SearchClient läser in och frågar ett befintligt index.
            // Båda behöver tjänstslutpunkten och en API-administratörsnyckel för autentisering med
            // behörighet att skapa/ta bort.

            // Create a SearchIndexClient to send create/delete index commands
            Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
            AzureKeyCredential credential = new AzureKeyCredential(apiKey);
            SearchIndexClient adminClient = new SearchIndexClient(serviceEndpoint, credential);

            // Create a SearchClient to load and query documents
            SearchClient srchclient = new SearchClient(serviceEndpoint, indexName, credential);

            // Delete index if it exists /////////////////////////////////////////////////////////
            Console.WriteLine("{0}", "Deleting index...\n");
            DeleteIndex.DeleteIndexIfExists(indexName, adminClient);

            // ///////////////////////////////////////////////////////////////////////////////////
            // Create index
            Console.WriteLine("{0}", "Creating index...\n");
            CreateNewIndex.CreateIndex(indexName, adminClient);

            // ///////////////////////////////////////////////////////////////////////////////////
            // Load documents
            // An ingestor is a program that reads data entering the system through a communications port. 
            SearchClient ingesterClient = adminClient.GetSearchClient(indexName);
            Console.WriteLine("{0}", "Uploading documents...\n");
            UploadDocs.UploadDocuments(ingesterClient);

            // Eftersom det här är en konsolapp som kör alla kommandon sekventiellt lägger du till en
            // väntetid på 2 sekunder mellan indexering och frågor.
            // (for demo and console-app purposes only)
            Console.WriteLine("Waiting for indexing...\n");
            System.Threading.Thread.Sleep(2000);

            // Call the RunQueries method to invoke a series of queries
            Console.WriteLine("Starting queries...\n");
            Queries.RunQueries(srchclient);

            // End the program
            Console.WriteLine("{0}", "Complete. Press any key to end this program...\n");
            Console.ReadKey();
        }
    }
}
