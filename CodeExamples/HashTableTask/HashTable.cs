using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        readonly private List<T>[] _data;

        private int _modCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable() : this(20)
        {
        }

        public HashTable(int arrayLength)
        {
            if (arrayLength <= 0)
            {
                throw new ArgumentException("Массив хэш-таблицы не может быть меньше или равен нулю", nameof(arrayLength));
            }

            _data = new List<T>[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                _data[i] = new List<T>();
            }
        }

        private int GetKey(T item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % _data.Length);
        }

        public void Add(T item)
        {
            int key = GetKey(item);

            _data[key].Add(item);

            Count++;

            _modCount++;
        }

        public void Clear()
        {
            foreach (List<T> e in _data)
            {
                e.Clear();
            }

            Count = 0;

            _modCount++;
        }

        public bool Contains(T item)
        {
            int key = GetKey(item);

            return _data[key].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array имеет значение null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Значение параметра arrayIndex меньше 0.");
            }

            if (array.Length < arrayIndex + Count)
            {
                throw new ArgumentException("Число элементов в исходной коллекции ICollection<T> больше доступного места от положения, заданного значением параметра arrayIndex, до конца массива назначения array.");
            }

            int currentIndex = arrayIndex;

            foreach (T data in this)
            {
                array[currentIndex] = data;

                currentIndex++;
            }
        }

        public bool Remove(T item)
        {
            int key = GetKey(item);

            bool isDeleted = _data[key].Remove(item);

            if (isDeleted)
            {
                Count--;

                _modCount++;
            }

            return isDeleted;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentModCount = _modCount;

            foreach (List<T> list in _data)
            {
                foreach (T e in list)
                {
                    if (currentModCount != _modCount)
                    {
                        throw new InvalidOperationException("Список был изменен, нельзя продолжить цикл.");
                    }

                    yield return e;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < _data.Length; i++)
            {
                stringBuilder.Append(i);
                stringBuilder.Append(" - ");

                if (_data[i].Count == 0)
                {
                    stringBuilder.Append("пусто");
                }
                else
                {
                    foreach (T e in _data[i])
                    {
                        stringBuilder.Append($"[ {e} ] ");
                    }
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}