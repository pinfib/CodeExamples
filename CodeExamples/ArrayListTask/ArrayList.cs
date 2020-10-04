using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private T[] _items;

        private int _modCount;

        public int Count { get; private set; }

        private int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Передано значение вместимости {value}, количество элементов в списке {Count}. Вместимость нельзя установить меньше количества элементов.");
                }

                if (_items.Length == value)
                {
                    return;
                }

                Array.Resize(ref _items, value);

                _modCount++;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Передано значение [{index}], допустимое значение от 0 до {Count - 1}");
                }

                return _items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Передано значение [{index}], допустимое значение от 0 до {Count - 1}");
                }

                _items[index] = value;

                _modCount++;
            }
        }

        public bool IsReadOnly => false;

        public ArrayList() : this(5)
        {
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Передано значение [{capacity}]. Значение параметра capacity не может быть меньше нуля.");
            }

            _items = new T[capacity];
        }

        public void Add(T item)
        {
            if (Count >= _items.Length)
            {
                IncreaseCapacity();
            }

            _items[Count] = item;

            Count++;

            _modCount++;
        }

        private void IncreaseCapacity()
        {
            if (Capacity == 0)
            {
                Capacity = 2;
            }
            else
            {
                Capacity *= 2;
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                _items[i] = default;
            }

            Count = 0;

            _modCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Целевой массив имеет значение null", nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Передано значение [{arrayIndex}]. Допустимое значение от 0 до {array.Length - 1}");
            }

            if (array.Length < Count + arrayIndex)
            {
                throw new ArgumentException("Число элементов в исходной коллекции ICollection<T> больше доступного места от положения, заданного значением параметра arrayIndex, до конца массива назначения array.");
            }

            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(_items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Передано значение [{index}], значение индекса должно быть от 0 до {Count}");
            }

            if (Count >= _items.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(_items, index, _items, index + 1, Count - index);

            _items[index] = item;

            Count++;

            _modCount++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Передано значение [{index}], значение индекса должно быть от 0 до {Count - 1}");
            }

            if (index < Count - 1)
            {
                Array.Copy(_items, index + 1, _items, index, Count - index - 1);
            }

            Count--;

            _items[Count] = default;

            _modCount++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = _modCount;

            for (int i = 0; i < Count; ++i)
            {
                if (currentModCount != _modCount)
                {
                    throw new InvalidOperationException("Список был изменен, нельзя продолжить цикл.");
                }

                yield return _items[i];
            }
        }

        public void TrimExcess()
        {
            Capacity = Count;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[ ");

            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append($"{_items[i]:0.##}");

                if (i != Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append(" ]");

            stringBuilder.Append($" длина списка - {Count}, вместимость - {Capacity}");

            return stringBuilder.ToString();
        }
    }
}