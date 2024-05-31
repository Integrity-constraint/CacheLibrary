using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheLibrary
{
    public interface IReplacementAlgorithm<TKey>
    {
        void Touch(TKey key);
        TKey GetKeyToReplace();
    }
}
