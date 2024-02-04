using System.Collections;

namespace _12
{
    public class MySortedSet<T> :
        ICollection<T>//{ IEnumerable<T>, IEnumerable }
    {
        private Node? root;
        private int count;

        public IComparer<T> Comparer { get; set; }

        public MySortedSet(IEnumerable<T>? collection = null, IComparer<T>? comparer = null)
        {
            Comparer = comparer ?? Comparer<T>.Default;

            if (collection != null)
            {
                var enumerator = collection.GetEnumerator();

                do
                {
                    Add(enumerator.Current);
                } while (enumerator.MoveNext());
            }
        }

        #region IEnumerable<T> members

        public Enumerator GetEnumerator() => new(this);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

        #endregion

        #region ICollection<T> members
        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                count = 1;
                return;
            }

            var current = root;
            while (Comparer.Compare(value, current!.Value) != 0)
            {
                var order = Comparer.Compare(value, current!.Value);
                if (order == 0 || (order == 1 && current.Right == null))
                {
                    current.Right = new(value) { Right = current.Right! };
                    count++;
                }
                else if (order == -1 && current.Left == null)
                {
                    current.Left = new(value);
                    count++;
                }

                current = order < 0 ? current.Left : current.Right;
            }
            PerformBalance();
        }

        public bool Remove(T value)
        {
            var parent = FindPossibleParent(value);

            if (parent == null)
            {
                return false;
            }

            //What to do?
            //Delete with Balance by conditions OR:
            if (Comparer.Compare(value, parent.Value) < 0)
            {
                var left = parent.Left!.Left!;
                parent.Left = parent.Left!.Right!;
                parent.Left.Left = left;
            }
            else
            {
                var right = parent.Right!.Right!;
                parent.Right = parent.Right!.Left!;
                parent.Right.Right = right;
            }
            PerformBalance();

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
            ArgumentNullException.ThrowIfNull(array);

            ArgumentOutOfRangeException.ThrowIfNegative(index);

            ArgumentOutOfRangeException.ThrowIfNegative(count);

            if (count > array.Length - index)
            {
                throw new ArgumentException(nameof(count));
            }

            count += index;

            //Симметричный обход
        }

        void ICollection<T>.CopyTo(T[] array, int index)
        {
            ArgumentNullException.ThrowIfNull(array);

            if (array.Rank != 1)
            {
                throw new ArgumentException(nameof(array));
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException(nameof(array));
            }

            ArgumentOutOfRangeException.ThrowIfNegative(index);

            if (array.Length - index < Count)
            {
                throw new ArgumentException(nameof(array.Length));
            }

            T[]? tarray = array as T[];
            if (tarray != null)
            {
                CopyTo(tarray, index);
            }
            else
            {
                object?[]? objects = array as object[];
                if (objects == null)
                {
                    throw new ArgumentException(nameof(array));
                }

                try
                {
                    //Симметричный обход
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException(nameof(array));
                }
            }
        }

        #endregion

        #region Tree-specific operations
        private void PerformBalance()
        {
            //
        }

        private Node? FindPossibleParent(T value)
        {
            if (root == null) return null;

            var current = root;
            var order = Comparer.Compare(value, current.Value);

            while (!(order > 0 &&
                    (current.Right == null
                    || Comparer.Compare(value, current.Right.Value) < 0)
                    || current.Left == null
                    || Comparer.Compare(value, current.Left.Value) > 0))
            {
                current = order < 0 ? current.Left : current.Right;
                order = Comparer.Compare(value, current!.Value);
            }

            return current;
        }

        public Node? FindNode(T value)
        {
            Node? current = root;
            var order = -1;

            while (current != null && order != 0)
            {
                order = Comparer.Compare(value, current.Value);
                current = order < 0 ? current.Left : current.Right;
            }

            return current;
        }

        public override bool Equals(object? obj)
        {
            return obj is MySortedSet<T> set
                && HasEqualComparer(set)
                && this
                .Zip(set, (first, second) =>
                Comparer.Compare(first, second) == 0)
                .All(t => t == true);
        }

        private bool HasEqualComparer(MySortedSet<T> set) => Comparer == set.Comparer;

        #endregion

        #region Helper Classes
        public sealed class Node(T value)
        {
            public T Value { get; set; } = value;

            public Node? Left { get; set; }

            public Node? Right { get; set; }

            private int Height => 1 + (Left?.Height ?? 0) + (Right?.Height ?? 0);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private Queue<Node> queue;
            private Node? current;

            public Enumerator(MySortedSet<T> set)
            {
                queue = new(set.Count);
                current = null;

                FillQueue(set.root!);
            }

            private void FillQueue(Node current)
            {
                if (current.Left != null) FillQueue(current.Left);
                queue.Enqueue(current);
                if (current.Right != null) FillQueue(current.Right);
            }

            #region IEnumerator<T> members
            public bool MoveNext()
            {
                if (queue.TryDequeue(out current)) return true;

                current = null;
                return false;
            }

            public readonly void Dispose() {}

            public T Current
            {
                get
                {
                    ArgumentNullException.ThrowIfNull(nameof(current));

                    return current!.Value;
                }
            }

             object? IEnumerator.Current => Current;

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