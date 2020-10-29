using System;
using System.Collections.Generic;
using System.Text;

namespace Academits.Dorosh.TreeTask
{
    class Tree<T>
    {
        private TreeNode<T> _root;

        private readonly IComparer<T> _comparer;

        public int Count { get; private set; }

        public Tree()
        {
        }

        public Tree(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public Tree(T data)
        {
            _root = new TreeNode<T>(data);

            Count++;
        }

        public Tree(T data, IComparer<T> comparer)
        {
            _root = new TreeNode<T>(data);

            _comparer = comparer;

            Count++;
        }

        private int Compare(T data1, T data2)
        {
            if (_comparer != null)
            {
                return _comparer.Compare(data1, data2);
            }

            if (data1 == null && data2 == null)
            {
                return 0;
            }

            if (data1 == null)
            {
                return -1;
            }

            return ((IComparable<T>)data1).CompareTo(data2);
        }

        public void Add(T data)
        {
            if (_root == null)
            {
                _root = new TreeNode<T>(data);

                Count++;

                return;
            }

            var current = _root;

            while (true)
            {
                if (Compare(data, current.Data) < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new TreeNode<T>(data);

                        Count++;

                        return;
                    }

                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new TreeNode<T>(data);

                        Count++;

                        return;
                    }

                    current = current.Right;
                }
            }
        }

        public bool Contains(T data)
        {
            var current = _root;

            while (current != null)
            {
                var compareResult = Compare(data, current.Data);

                if (compareResult == 0)
                {
                    return true;
                }

                if (compareResult < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return false;
        }

        private void ReplaceNode(TreeNode<T> parentNode, TreeNode<T> removedNode, TreeNode<T> insertNode, bool insertNodeIsSubtree)
        {
            if (parentNode == null) // удаление корня
            {
                _root = insertNode;
            }
            else
            {
                if (ReferenceEquals(parentNode.Left, removedNode))  // определить removedNode - это левый или правый узел у своего родителя
                {
                    parentNode.Left = insertNode;
                }
                else
                {
                    parentNode.Right = insertNode;
                }
            }

            if (!insertNodeIsSubtree) // если встраиваемый узел не является поддеревом, то нужно обновить связи
            {
                insertNode.Left = removedNode.Left;
                insertNode.Right = removedNode.Right;
            }
        }

        public bool Remove(T data)
        {
            if (_root == null)
            {
                return false;
            }

            var removedNode = _root;
            TreeNode<T> parentRemovedNode = null;

            while (true)
            {
                var compareResult = Compare(data, removedNode.Data);

                if (compareResult == 0)
                {
                    break;
                }

                parentRemovedNode = removedNode;

                if (compareResult < 0)
                {
                    removedNode = removedNode.Left;
                }
                else
                {
                    removedNode = removedNode.Right;
                }

                if (removedNode == null)
                {
                    return false;
                }
            }

            if (removedNode.Right == null)                                  // узел с одним ребенком или без детей
            {
                ReplaceNode(parentRemovedNode, removedNode, removedNode.Left, true);

                Count--;

                return true;
            }

            if (removedNode.Left == null)                                   // узел с одним ребенком
            {
                ReplaceNode(parentRemovedNode, removedNode, removedNode.Right, true);

                Count--;

                return true;
            }

            var insertNode = removedNode.Right;                             // узел с двумя детьми
            var parentInsertNode = removedNode;

            while (insertNode.Left != null)                                         // найти самый левый узел в правом поддереве
            {
                parentInsertNode = insertNode;
                insertNode = insertNode.Left;
            }

            ReplaceNode(parentInsertNode, insertNode, insertNode.Right, true);      // удалить самый левый узел, и поставить на его место его правого ребенка, если он есть
            ReplaceNode(parentRemovedNode, removedNode, insertNode, false);         // на место удаляемого элемента записываем самый левый элемент

            Count--;

            return true;
        }

        public void BreadthFirstTraversal(Action<T> action) // обход в ширину
        {
            if (_root == null)
            {
                return;
            }

            var queue = new Queue<TreeNode<T>>(Count);

            queue.Enqueue(_root);

            while (queue.Count != 0)
            {
                var treeNode = queue.Dequeue();

                action(treeNode.Data);

                if (treeNode.Left != null)
                {
                    queue.Enqueue(treeNode.Left);
                }

                if (treeNode.Right != null)
                {
                    queue.Enqueue(treeNode.Right);
                }
            }
        }

        public void RecursiveDepthFirstTraversal(Action<T> action) // обход в глубину с рекурсией 
        {
            if (_root == null)
            {
                return;
            }

            RecursiveDepthFirstTraversal(_root, action);
        }

        private void RecursiveDepthFirstTraversal(TreeNode<T> treeNode, Action<T> action)
        {
            action(treeNode.Data);

            if (treeNode.Left != null)
            {
                RecursiveDepthFirstTraversal(treeNode.Left, action);
            }

            if (treeNode.Right != null)
            {
                RecursiveDepthFirstTraversal(treeNode.Right, action);
            }
        }

        public void DepthFirstTraversal(Action<T> action) // обход в глубину без рекурсии
        {
            if (_root == null)
            {
                return;
            }

            var stack = new Stack<TreeNode<T>>(Count);

            stack.Push(_root);

            while (stack.Count != 0)
            {
                var treeNode = stack.Pop();

                action(treeNode.Data);

                if (treeNode.Right != null)  // положить в стек всех детей элемента в обратном порядке
                {
                    stack.Push(treeNode.Right);
                }

                if (treeNode.Left != null)
                {
                    stack.Push(treeNode.Left);
                }
            }
        }

        private static string ToString(TreeNode<T> node, List<StringBuilder> list, int level)
        {
            var stringLength = level * 4 + 3;

            var stringLeft = new StringBuilder();
            stringLeft.Insert(0, " ", stringLength);

            var stringRight = new StringBuilder();
            stringRight.Insert(0, " ", stringLength);

            if (node.Right != null)
            {
                list.Insert(list.Count, stringRight.Append($"[R]: {ToString(node.Right, list, level + 1)}"));
            }

            if (node.Left != null)
            {
                list.Insert(list.Count, stringLeft.Append($"[L]: {ToString(node.Left, list, level + 1)}"));
            }

            return node.ToString();
        }

        public override string ToString()
        {
            var list = new List<StringBuilder>(Count)
            {
                new StringBuilder("[root]: ")
            };

            if (_root == null)
            {
                list[0].Append("null");
            }
            else
            {
                list[0].Append(ToString(_root, list, 1));
            }

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Количество элементов в дереве - {Count}");

            foreach (var e in list)
            {
                stringBuilder.AppendLine(e.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}