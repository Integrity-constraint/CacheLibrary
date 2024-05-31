using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLibrary
{
    public class MruReplacementAlgorithm<TKey> : IReplacementAlgorithm<TKey>
    {

        private readonly LinkedList<TKey> _mruList = new LinkedList<TKey>();

        public void Touch(TKey key)
        {
            _mruList.Remove(key);
            _mruList.AddLast(key);
        }

        public TKey GetKeyToReplace()
        {
            var key = _mruList.Last.Value;
            _mruList.RemoveLast();
            return key;
        }
    }
}
