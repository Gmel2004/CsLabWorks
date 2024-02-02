using System.Collections;

namespace _12
{
    public class MySortedSet<T> :
        IEnumerable<T>, ICollection<T>
    {
        private Node? root;
        private readonly IComparer<T> comparer = default!;
        private int count;

        public IComparer<T> Comparer => comparer;

        #region Constructors
        public MySortedSet() => comparer = Comparer<T>.Default;

        public MySortedSet(IComparer<T>? comparer) => this.comparer = comparer ?? Comparer<T>.Default;
        #endregion

        #region IEnumerable<T> members

        public Enumerator GetEnumerator() => new Enumerator(this);

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
            //
        }

        public bool Remove(T value)
        {
            if (root == null)
            {
                return false;
            }

            //
            return true;
        }

        public void Clear()
        {
            root = null;
            count = 0;
            //
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
        private void InsertionBalance(Node current, ref Node parent, Node grandParent, Node greatGrandParent)
        {
            //
        }

        public Node? FindNode(T value)
        {
            Node? current = root;
            while (current != null)
            {
                int order = comparer.Compare(value, current.Value);
                if (order == 0)
                {
                    return current;
                }

                current = order < 0 ? current.Left : current.Right;
            }

            return null;
        }

        public static bool SortedSetEquals(MySortedSet<T>? set1, MySortedSet<T>? set2, IComparer<T> comparer)
        {
            if (set1 == null)
            {
                return set2 == null;
            }

            if (set2 == null)
            {
                return false;
            }

            if (set1.HasEqualComparer(set2))
            {
                return set1.Count == set2.Count;// && set1.SetEquals(set2);
            }

            bool found;
            foreach (T value1 in set1)
            {
                found = false;
                foreach (T value2 in set2)
                {
                    if (comparer.Compare(value1, value2) == 0)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    return false;
                }
            }

            return true;
        }

        private bool HasEqualComparer(MySortedSet<T> other)
        {
            return Comparer == other.Comparer || Comparer.Equals(other.Comparer);
        }

        #endregion

        #region Helper Classes
        public sealed class Node
        {
            #region Properties
            public T Value { get; set; }

            public Node? Left { get; set; }

            public Node? Right { get; set; }
            #endregion

            public Node(T value) => Value = value;

            public Node DeepClone(int count)
            {
                Node newRoot = ShallowClone();

                //Обход

                return newRoot;
            }

            public Node ShallowClone() => new(Value);

            private int GetCount() => 1 + (Left?.GetCount() ?? 0) + (Right?.GetCount() ?? 0);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private readonly MySortedSet<T> tree;
            private readonly Stack<Node> stack;
            private Node? current;

            public Enumerator(MySortedSet<T> set)
            {
                tree = set;
                stack = new Stack<Node>(2 * (int)Math.Log2(set.Count() + 1));
                current = null;

                Initialize();
            }

            #region IEnumerator<T> members
            public bool MoveNext()
            {
                if (stack.Count == 0)
                {
                    current = null;
                    return false;
                }

                //Симметричный обход
                return true;
            }

            public void Dispose() { }//!!!

            public T Current
            {
                get
                {
                    if (current != null)
                    {
                        return current.Value;
                    }
                    return default!;
                }
            }

            readonly object? IEnumerator.Current
            {
                get
                {
                    ArgumentNullException.ThrowIfNull(nameof(current));

                    return current!.Value;
                }
            }

            public void Reset()
            {
                stack.Clear();
                Initialize();
            }
            #endregion

            private void Initialize()
            {
                //Симметричный обход
            }

            public readonly bool NotStartedOrEnded => current == null;
        }
        #endregion
    }
}