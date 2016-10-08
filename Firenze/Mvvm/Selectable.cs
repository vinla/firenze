using System;

namespace Firenze.Mvvm
{
    public class Selectable<T> where T : class
    {
        public Selectable(T item)
        {
            Item = item;
        }

        public Boolean Selected { get; set; }

        public T Item { get; }
    }
}