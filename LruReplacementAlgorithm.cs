using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLibrary
{
    public class LruReplacementAlgorithm<TKey> : IReplacementAlgorithm<TKey>
    {
        private readonly LinkedList<TKey> _lruList = new LinkedList<TKey>();

        public void Touch(TKey key)
        {
            _lruList.Remove(key);
            _lruList.AddLast(key);
        }

        public TKey GetKeyToReplace()
        {
            var key = _lruList.First.Value;
            _lruList.RemoveFirst();
            return key;
        }
    }
}
