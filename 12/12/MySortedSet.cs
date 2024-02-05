using System.Collections;
using System.Collections.Generic;

namespace _12
{
    public class MySortedSet<T> :
        ICollection<T>
    {
        private Node? root;
        private int count;

        private readonly IComparer<T> comparer;

        #region Constructors
        public MySortedSet() : this(Comparer<T>.Default) { }

        public MySortedSet(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public MySortedSet(IEnumerable<T> collection) : this(collection, Comparer<T>.Default) { }

        public MySortedSet(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
            if (collection != null)
            {
                foreach (var item in collection) Add(item);
            }
        }
        #endregion

        #region IEnumerable<T> members

        public Enumerator GetEnumerator() => new(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

        #endregion

        #region ICollection<T> members
        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(T value) => AddIfNotPresent(value);

        public bool Remove(T value)
        {
            if (value == null || root == null) return false;

            if (comparer.Compare(value, root.Value) == 0) return true;//What to do?

            var parent = root;

            while (parent != null)
            {
                var next = comparer.Compare(value, parent.Value) < 0 ? parent.Left : parent.Right;
                if (next != null && comparer.Compare(value, next.Value) == 0) break;
                parent = next;
            }

            if (parent == null) return false;

            if (comparer.Compare(value, parent!.Value) < 0)
            {
                var left = parent.Left!.Left!;
                parent.Left = parent.Left!.Right!;
                if (parent.Left != null) parent.Left.Left = left;
                else parent.Left = left;
            }
            else
            {
                var right = parent.Right!.Right!;
                parent.Right = parent.Right!.Left!;
                if (parent.Right != null) parent.Right.Right = right;
                else parent.Right = right;
            }
            //PerformBalance(root!);

            return true;
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public bool Contains(T value) => FindNode(value) != null;

        public void CopyTo(T[] array) => CopyTo(array, 0, Count);

        public void CopyTo(T[] array, int index) => CopyTo(array, index, Count);

        public void CopyTo(T[] array, int index, int count)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(count);

            foreach (var item in this.Take(count))
            {
                array[index++] = item;
            }
        }

        void ICollection<T>.CopyTo(T[] array, int index) => CopyTo(array, index, Count);

        #endregion

        #region Specific operations
        private void AddIfNotPresent(T value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            if (root == null)
            {
                root = new Node(value);
                count = 1;
                return;
            }

            var current = root;
            var needAdd = true;

            while (needAdd)
            {
                var order = comparer.Compare(value, current!.Value);
                if (order == 0) return;

                if (order > 0 && current.Right == null)
                {
                    current.Right = new(value);
                    count++;
                    needAdd = false;
                }
                else if (order < 0 && current.Left == null)
                {
                    current.Left = new(value);
                    count++;
                    needAdd = false;
                }

                current = order < 0 ? current.Left : current.Right;
            }
            //PerformBalance(root);
        }

        private void PerformBalance(Node? node)
        {
            if (node == null) return;

            PerformBalance(node.Left);

            var current = node;
            while (current != null)
            {
                if (current.BalanceRatio == 2)
                {
                    if (current!.Right!.BalanceRatio < 0) Rotate(current.Right);
                    Rotate(current);
                }
                else if (current.BalanceRatio == -2)
                {
                    if (current!.Left!.BalanceRatio > 0) Rotate(current.Left);
                    Rotate(current);
                }
            }

            PerformBalance(node.Right);
        }

        private void Rotate(Node node)
        {
            //
        }

        public Node? FindNode(T value)
        {
            if (root == null) return null;

            Node? current = root;

            while (current != null)
            {
                var order = comparer.Compare(value, current.Value);
                if (order == 0) break;

                current = order < 0 ? current.Left : current.Right;
            }

            return current;
        }

        public override bool Equals(object? obj)
        {
            return obj is MySortedSet<T> set
                && comparer.Equals(set.comparer)
                && Count == set.Count
                && this
                .Zip(set, (first, second) =>
                comparer.Compare(first, second) == 0)
                .All(t => t);
        }
        #endregion

        #region Helper Classes
        public sealed class Node(T value)
        {
            public T Value { get; set; } = value;

            public Node? Left { get; set; }

            public Node? Right { get; set; }

            public int Height => 1 + (Left?.Height ?? 0) + (Right?.Height ?? 0);

            public int BalanceRatio => (Right?.Height ?? 0) - (Left?.Height ?? 0);
        }

        public sealed class Enumerator : IEnumerator<T>
        {
            private Queue<Node> queue;
            private Node? current;

            public Enumerator(MySortedSet<T> set)
            {
                ArgumentNullException.ThrowIfNull(nameof(set));
                queue = new(set.Count);
                current = null;

                FillQueue(set.root!);
            }

            public Enumerator(Enumerator enumerator)//Specific method
            {
                queue = new(enumerator.queue);
                current = new Node(enumerator.Current);
            }

            private void FillQueue(Node current)
            {
                if (current == null) return;

                FillQueue(current.Left!);
                queue.Enqueue(current);
                FillQueue(current.Right!);
            }

            #region IEnumerator<T> members
            public T Current
            {
                get
                {
                    ArgumentNullException.ThrowIfNull(nameof(current));

                    return current!.Value;
                }
            }

            object? IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (queue.TryDequeue(out current)) return true;

                current = null;
                return false;
            }

            public void Dispose() { }

            public void Reset()
            {
                queue.Clear();
                current = null;
            }
            #endregion
        }
        #endregion
    }
}