using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLibrary
{
    public class Cache<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _cache;
        private readonly IReplacementAlgorithm<TKey> _replacementAlgorithm;
        private readonly int _capacity;
        public int Count
        {
            get { return _cache.Count; }
        }
        public IEnumerable<TKey> GetKeys()
        {
            return _cache.Keys;
        }
        public Cache(int capacity, IReplacementAlgorithm<TKey> replacementAlgorithm)
        {
            _cache = new Dictionary<TKey, TValue>(capacity);
            _replacementAlgorithm = replacementAlgorithm;
            _capacity = capacity;
        }

        public TValue Get(TKey key)
        {
            if (_cache.TryGetValue(key, out var value))
            {
                _replacementAlgorithm.Touch(key);
                return value;
            }

            return default(TValue);
        }

        public void Add(TKey key, TValue value)
        {
            if (_cache.Count >= _capacity)
            {
                var keyToReplace = _replacementAlgorithm.GetKeyToReplace();
                _cache.Remove(keyToReplace);
            }

            _cache.Add(key, value);
            _replacementAlgorithm.Touch(key);
        }
    }
}
