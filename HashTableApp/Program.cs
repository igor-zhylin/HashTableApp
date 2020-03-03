
namespace HashTableApp
{
    using System;
    using HashTableApp.HashTableSrc;
    
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable();

            hashTable.Insert("Captain", "Anyone who reads Old and Middle English literary texts will be familiar with the mid-brown volumes of the EETS,");
            hashTable.Insert("Radio staff", "As its name states, EETS was begun as a 'club', and it retains certain features of that even now...");
            hashTable.Insert("Medical staff", "Many comparable societies, with different areas of interest, were founded in the nineteenth century (several of them also by Furnivall);");
            hashTable.Insert("Junior mate (fourth mate)", "We hope you will maintain your membership, and will encourage both the libraries you use and also other individuals to join");

            //Write all table 
            IPrinter printer = new ConsolePrinter();
            printer.Print(hashTable, "All in Collection");
            Console.WriteLine();

            hashTable.Delete("Radio staff");
            printer.Print(hashTable,"Delete item test");
            Console.WriteLine();

            var searchTestItem = hashTable.Search("Junior mate (fourth mate)");
            printer.Print(searchTestItem, "SearchTest");

            Console.ReadKey();

        }
    }
}
