using System.Collections;

namespace _12
{
    public class MySortedSetExperemental<T> :
        ICollection<T>
    {
        private Node? root;
        private int count;

        private readonly IComparer<T> comparer;

        #region Constructors
        public MySortedSetExperemental() : this(Comparer<T>.Default) { }

        public MySortedSetExperemental(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
        }

        public MySortedSetExperemental(IEnumerable<T> collection) : this(collection, Comparer<T>.Default) { }

        public MySortedSetExperemental(IEnumerable<T> collection, IComparer<T> comparer) : this(comparer)
        {
            if (collection != null)
            {
                foreach (var item in collection) Add(item);
            }
        }
        #endregion

        #region IEnumerable<T> members

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var node in GetNodesAscending())
            {
                yield return node.Value;
            }

            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

        #endregion

        #region ICollection<T> members
        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(T value) => AddIfNotPresent(value);

        public bool Remove(T value)
        {
            Node? parent = null;
            Node? current = root;

            while (current != null && !EqualityComparer<T>.Default.Equals(current.Value, default))
            {
                int order = comparer.Compare(value, current.Value);
                if (order == 0)
                {
                    Node? node = (current.Left == null || EqualityComparer<T>.Default.Equals(current.Left.Value, default))
                        ? current.Right
                        : current.Left;

                    if (parent == null || EqualityComparer<T>.Default.Equals(parent.Value, default))
                        root = node;
                    else if (comparer.Compare(value, parent.Value) < 0)
                        parent.Left = node;
                    else
                        parent.Right = node;

                    PerformBalance(root);
                    return true;
                }

                parent = current;
                current = order < 0 ? current.Left : current.Right;
            }

            return false;
        }

        public void Clear()
        {
            foreach (var node in GetNodesAscending())
            {
                node.Value = default!;
            }

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
        private List<Node> GetNodesAscending()
        {
            List<Node> nodes = new();
            Stack<Node> stack = new();
            Node current = root!;

            while ((current != null && !EqualityComparer<T>.Default.Equals(current.Value, default)) || stack.Count > 0)
            {
                while (current != null && !EqualityComparer<T>.Default.Equals(current.Value, default))
                {
                    stack.Push(current);
                    current = current.Left!;
                }

                current = stack.Pop();
                nodes.Add(current);
                current = current.Right!;
            }

            return nodes;
        }

        private void AddIfNotPresent(T value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            if (root == null || root.Value == null)
            {
                root = new Node(value);
                count = 1;
                return;
            }

            if (EqualityComparer<T>.Default.Equals(root.Value, default))
            {
                root.Value = value;
                count = 1;
                return;
            }

            var current = root;
            var needAdd = true;

            while (needAdd)
            {
                var order = comparer.Compare(value, current!.Value);
                if (order == 0) return;

                if (order > 0)
                {
                    if (current.Right == null)
                    {
                        current.Right = new(value);
                        count++;
                        needAdd = false;
                    }
                    else if (EqualityComparer<T>.Default.Equals(current.Right.Value, default))
                    {
                        current.Right.Value = value;
                        count++;
                        needAdd = false;
                    }

                }
                else
                {
                    if (current.Left == null)
                    {
                        current.Left = new(value);
                        count++;
                        needAdd = false;
                    }
                    else if (EqualityComparer<T>.Default.Equals(current.Left.Value, default))
                    {
                        current.Left.Value = value;
                        count++;
                        needAdd = false;
                    }
                }

                current = order < 0 ? current.Left : current.Right;
            }
            PerformBalance(root);
        }

        private void PerformBalance(Node? node)
        {
            if (node == null || node.Value == null) return;

            PerformBalance(node.Left);
            PerformBalance(node.Right);

            if (node.BalanceRatio == 2)
            {
                if (node.Right != null && !EqualityComparer<T>.Default.Equals(node.Right.Value, default)
                    && node.Right.BalanceRatio < 0) Rotate(node.Right, false);
                Rotate(node, true);
            }
            else if (node.BalanceRatio == -2)
            {
                if (node.Left != null && !EqualityComparer<T>.Default.Equals(node.Left.Value, default)
                    && node.Left.BalanceRatio > 0) Rotate(node.Left, true);
                Rotate(node, false);
            }
        }

        private void Rotate(Node node, bool isLeft)
        {
            Node parent = isLeft ? node.Right! : node.Left!;
            if (isLeft)
            {
                node.Right = parent.Left;
                parent.Left = node;
            }
            else
            {
                node.Left = parent.Right;
                parent.Right = node;
            }
            if (node == root) root = parent;

        }

        public Node? FindNode(T value)
        {
            if (root == null || EqualityComparer<T>.Default.Equals(root.Value, default)) return null;

            Node? current = root;

            while (current != null && !EqualityComparer<T>.Default.Equals(current.Value, default))
            {
                var order = comparer.Compare(value, current.Value);
                if (order == 0) break;

                current = order < 0 ? current.Left : current.Right;
            }

            return current;
        }

        public override bool Equals(object? obj)
        {
            return obj is MySortedSetExperemental<T> set
                && comparer.Equals(set.comparer)
                && Count == set.Count
                && this.SequenceEqual(set);
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
        #endregion
    }
}