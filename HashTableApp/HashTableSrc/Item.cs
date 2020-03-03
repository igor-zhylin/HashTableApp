namespace HashTableApp.HashTableSrc
{
    using System;

    /// <summary>
    /// HashTable item 
    /// </summary>
    public class Item
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public Item(string key,string value) 
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                throw new ArgumentNullException("Key or Value is empty");
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// Override ToString method 
        /// </summary>
        /// <returns>Item.Value</returns>
        public override string ToString()
            => Value;
    }
}
