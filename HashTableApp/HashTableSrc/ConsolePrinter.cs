

namespace HashTableApp.HashTableSrc
{
    using System;

    public class ConsolePrinter : IPrinter
    {
        public void Print(HashTable hTable, string title)
        {
            if (hTable == null)
                throw new ArgumentNullException("HashTable is NULL");

            Console.WriteLine(title);

            foreach (var item in hTable.Items)
            {
                Console.WriteLine(item.Key);
                foreach (var value in item.Value)
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
            }
            Console.WriteLine();
        }

        public void Print(string item, string title)
        {
            Console.WriteLine(title);
            Console.WriteLine($"\t{item}");
        }
    }
}
