using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using SearchIndexConsoleEnd;
using SearchIndexConsoleEnd.Data;

// Den här appen skapar ett Hotels-index som du läser in med hotelldata och kör frågor mot.
// https://learn.microsoft.com/sv-se/azure/search/search-get-started-dotnet

class Program
{
    static void Main(string[] args)
    {
        var gogogo = new App();
        gogogo.Run();
    }
}