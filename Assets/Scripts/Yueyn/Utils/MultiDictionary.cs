using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Yueyn.Utils
{
    public sealed class MultiDictionary<TKey, TValue>:IEnumerable<KeyValuePair<TKey,List<TValue>>>,IEnumerable
    {
        private readonly List<TValue> _list = new();
        private readonly Dictionary<TKey,List<TValue>> _dict = new();
        public List<TValue> this[TKey key]=>_dict[key];

        public void Clear()
        {
            _list.Clear();
            _dict.Clear();
        }
        public bool Contains(TKey key)=>_dict.ContainsKey(key);
        public bool Contains(TKey key,TValue value)=>_dict.ContainsKey(key)&&_dict[key].Contains(value);
        public bool TryGetValue(TKey key,out List<TValue> value)=>_dict.TryGetValue(key, out value);

        public void Add(TKey key, TValue value)
        {
            if (_dict.TryGetValue(key, out var list))
            {
                list.Add(value);
            }
            else
            {
                list=new List<TValue> { value };
                _dict.Add(key,list);
            }
        }

        public bool Remove(TKey key, TValue value)
        {
            if (_dict.TryGetValue(key, out var list))
            {
                return list.Remove(value);
            }
            return false;
        }

        public bool RemoveAll(TKey key)
        {
            if (_dict.Remove(key, out var list))
            {
                list.Clear();
                return true;
            }
            return false;
        }
        public Enumerator GetEnumerator()=>new Enumerator(_dict);


        IEnumerator<KeyValuePair<TKey, List<TValue>>> IEnumerable<KeyValuePair<TKey, List<TValue>>>.GetEnumerator()
            => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [StructLayout(LayoutKind.Auto)]
        public struct Enumerator : IEnumerator<KeyValuePair<TKey, List<TValue>>>, IEnumerator
        {
            private Dictionary<TKey, List<TValue>>.Enumerator _enumerator;

            internal Enumerator(Dictionary<TKey, List<TValue>> dict)
            {
                if (dict == null)
                {
                    throw new System.ArgumentNullException(nameof(dict));
                }
                _enumerator = dict.GetEnumerator();
            }
            public KeyValuePair<TKey, List<TValue>> Current => _enumerator.Current;
            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            public void Reset()=>((IEnumerator<KeyValuePair<TKey, List<TValue>>>)_enumerator).Reset();


            object IEnumerator.Current => _enumerator.Current;

            public void Dispose()
            {
                _enumerator.Dispose();
            }
        }
    }
}