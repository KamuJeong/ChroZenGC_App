using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YC_ChroZenGC_Type
{
    public class ConcurrentList<T>
    {
        List<T> _list = new List<T>();
        object _lock = "";
        public ConcurrentList()
        {

        }
        public ConcurrentList(List<T> list)
        {
            lock (_lock)
            {
                _list = list;
            }
        }
        public void RemoveAt(int index)
        {
            lock (_lock)
            {
                _list.RemoveAt(index);
            }
        }
        public T[] ToArray()
        {
            lock (_lock)
            {
                return _list.ToArray();
            }
        }
        public void Add(T item)
        {
            lock (_lock)
            {
                _list.Add(item);
            }
        }

        public T this[int index]
        {
            get
            {
                lock (this)
                {
                    return _list[index];
                }
            }
            set
            {
                lock (this)
                {
                    _list[index] = value;
                }
            }
        }
        public T[] GetRange(int startIndex, int dataCount)
        {
            lock (_lock)
            {
                return _list.GetRange(startIndex, dataCount).ToArray();
            }
        }
        public void RemoveRange(int startIndex, int dataCount)
        {
            lock (_lock)
            {
                _list.RemoveRange(startIndex, dataCount);
            }
        }
        public int Count { get { return _list.Count; } }
    }
}
