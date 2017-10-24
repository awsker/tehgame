using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace tehgame.game.util
{
    public class SparseGrid<T> : IEnumerable<T>
    {
        private int _minX, _maxX, _minY, _maxY;
        private IDictionary<Point, List<T>> _values;

        public SparseGrid()
        {
            _values = new Dictionary<Point, List<T>>();
        }

        public IList<T> GetValues(int x, int y)
        {
            return GetValues(new Point(x, y));
        }

        public IList<T> GetValues(Point p)
        {
            List<T> list;
            if (_values.TryGetValue(p, out list))
            {
                return list.AsReadOnly();
            }
            return new ReadOnlyCollection<T>(new List<T>());
        }

        public void AddValue(T value, int x, int y)
        {
            AddValue(value, new Point(x, y));
        }

        public void AddValue(T value, Point p)
        {
            List<T> list;
            if (_values.TryGetValue(p, out list))
            {
                list.Add(value);
            }
            else
            {
                _values[p] = new List<T> { value };
            }

        }

        private void updateBounds(Point p)
        {
            if (_values.Count == 0)
            {
                _minX = 0;
                _maxX = 0;
                _minY = 0;
                _maxY = 0;
            }
            if (_values.Count == 1)
            {
                _minX = p.X;
                _maxX = p.X;
                _minY = p.Y;
                _maxY = p.Y;
            }
            else
            {
                _minX = Math.Min(_minX, p.X);
                _maxX = Math.Max(_maxX, p.X);
                _minY = Math.Min(_minY, p.Y);
                _maxY = Math.Max(_maxY, p.Y);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _values.Values.SelectMany(list => list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _values.Values.SelectMany(list => list).GetEnumerator();
        }

        public int Width => _values.Count == 0 ? 0 : _maxX - _minX + 1;
        public int Height => _values.Count == 0 ? 0 : _maxY - _minY + 1;
    }
}
