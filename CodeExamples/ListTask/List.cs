using System;
using System.Text;

namespace Academits.Dorosh.ListTask
{
    public class List<T>
    {
        private ListItem<T> _head;

        public int Count { get; private set; }

        public List()
        {
        }

        public List(T data)
        {
            _head = new ListItem<T>(data);

            Count++;
        }

        private ListItem<T> GetListItemByIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Передан индекс [{index}], допустимые значения индекса от 0 до {Count - 1}.");
            }

            ListItem<T> current = _head;

            for (int i = 0; i != index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public T GetFirstData()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }

            return _head.Data;
        }

        public T GetData(int index)
        {
            ListItem<T> listItem = GetListItemByIndex(index);

            return listItem.Data;
        }

        public T SetData(int index, T data)        // Выдает старое значение
        {
            ListItem<T> listItem = GetListItemByIndex(index);

            T oldData = listItem.Data;
            listItem.Data = data;

            return oldData;
        }

        public void AddFirst(T data)
        {
            _head = new ListItem<T>(data, _head);

            Count++;
        }

        public void Insert(int index, T data)
        {
            if (index == 0)
            {
                AddFirst(data);

                return;
            }

            ListItem<T> previous = GetListItemByIndex(index - 1);
            ListItem<T> current = previous.Next;

            previous.Next = new ListItem<T>(data, current);

            Count++;
        }

        public T RemoveAt(int index)                // Выдает старое значение
        {
            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previous = GetListItemByIndex(index - 1);
            ListItem<T> current = previous.Next;

            T oldData = current.Data;
            previous.Next = current.Next;

            Count--;

            return oldData;
        }

        public bool Remove(T data)                  // Выдает true, если элемент был удален
        {
            if (_head == null)
            {
                return false;
            }

            for (ListItem<T> current = _head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (Equals(current.Data, data))
                {
                    if (previous == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;

                        Count--;
                    }

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirst()                      // Выдает старое значение
        {
            if (_head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }

            T oldData = _head.Data;

            _head = _head.Next;

            Count--;

            return oldData;
        }

        public void Reverse()
        {
            if (_head == null || _head.Next == null) // список пуст или состоит из одного элемента
            {
                return;
            }

            ListItem<T> current = _head.Next;
            _head.Next = null;

            while (current != null)
            {
                ListItem<T> next = current.Next;    // сохранить ссылку на следущий элемент после текущего
                current.Next = _head;                // поменять местами текущий элемент и голову
                _head = current;
                current = next;                     // текущий элемент указывает на оставшуюся часть списка
            }
        }

        public List<T> GetCopy()
        {
            if (_head == null)
            {
                return new List<T>();
            }

            List<T> newList = new List<T>(_head.Data);

            newList.Count = Count;

            ListItem<T> currentThisList = _head.Next;
            ListItem<T> currentCopyList = newList._head;

            while (currentThisList != null)
            {
                currentCopyList.Next = new ListItem<T>(currentThisList.Data);

                currentThisList = currentThisList.Next;
                currentCopyList = currentCopyList.Next;
            }

            return newList;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("[ ");

            for (ListItem<T> current = _head; current != null; current = current.Next)
            {
                stringBuilder.Append(current);

                if (current.Next != null)
                {
                    stringBuilder.Append(", ");
                }
            }

            stringBuilder.Append(" ]");

            stringBuilder.Append($" (Длина - {Count})");

            return stringBuilder.ToString();
        }
    }
}