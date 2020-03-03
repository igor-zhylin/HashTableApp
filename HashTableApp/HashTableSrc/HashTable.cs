namespace HashTableApp.HashTableSrc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable
    {
        private readonly byte _KeyMaxSize = 255;
        private Dictionary<int, List<Item>> _items;
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items 
            => _items?.ToList()?.AsReadOnly();


        public HashTable()
        {
            _items = new Dictionary<int, List<Item>>();
        }

        /// <summary>
        /// Insert Item to collection 
        /// </summary>
        /// <param name="key">Key, MaxLength = 255</param>
        /// <param name="value">Value</param>
        public void Insert(string key, string value)
        {
            if (KeyAndValueIsValid(key, value))
            {
                int hash = GetHash(key);
                Item item = new Item(key, value);
                List<Item> hTableItem;

                if (_items.ContainsKey(hash))
                {
                    hTableItem = _items[hash];
                    var ItemExists = hTableItem.SingleOrDefault(_ => _.Key == item.Key);
                    if (ItemExists != null)
                        throw new ArgumentException("Item is already exists");
                    _items[hash].Add(item);
                }
                else
                {
                    hTableItem = new List<Item> { item };
                    _items.Add(hash, hTableItem);
                }
            }
        }

        /// <summary>
        /// Delete item if it exists
        /// </summary>
        /// <param name="key">Item key</param>
        public void Delete(string key)
        {
            if (KeyIsValid(key))
            {
                var hash = GetHash(key);

                if (!_items.ContainsKey(hash))
                    return;

                var hTableItem = _items[hash];
                var item = hTableItem.SingleOrDefault(_ => _.Key == key);

                if (item != null)
                    hTableItem.Remove(item);
            }
        }

        /// <summary>
        /// Search item by key 
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Items founded by Key</returns>
        public string Search(string key)
        {
            if (KeyIsValid(key))
            {
                var hash = GetHash(key);
                if (!_items.ContainsKey(hash))
                    return string.Empty;
                var hTableItem = _items[hash];

                if (hTableItem != null)
                {
                    var item = hTableItem.SingleOrDefault(i => i.Key == key);
                    if (item != null)
                    {
                        return item.Value;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Validate key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>True if valid, exception if is not valid.</returns>
        private bool KeyIsValid(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key is empty");
            if (key.Length > _KeyMaxSize)
                throw new ArgumentException($"Length of the key must be between 0 and {_KeyMaxSize}");

            return true;
        }

        /// <summary>
        /// Validate key and value
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns>True if valid, exception if is not valid.</returns>
        private bool KeyAndValueIsValid(string key, string value)
        {
            if (String.IsNullOrEmpty(key) || String.IsNullOrEmpty(value))
                throw new ArgumentNullException("Key or Value is empty");
            if (key.Length > _KeyMaxSize)
                throw new ArgumentException($"Max length key is {_KeyMaxSize}", nameof(key));

            return true;
        }

        /// <summary>
        /// Get hash function 
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Value Length</returns>
        private int GetHash(string value)
        {
            if (value.Length > _KeyMaxSize)
                throw new ArgumentException($"Value is too long. Max value length is {_KeyMaxSize}");
            return value.Length;
        }
    }
}
