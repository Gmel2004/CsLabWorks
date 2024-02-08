using System.Collections;

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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
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
                yield return current.Value;
                current = current.Right!;
            }

            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

        #endregion

        #region ICollection<T> members
        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(T value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            if (root == null)
            {
                root = new Node(value);
                count = 1;
                return;
            }

            AddIfNotPresent(root, value);
        }

        public bool Remove(T value)
        {
            Node node = FindNode(value)!;
            if (node == null) return false;

            count--;
            RemoveNode(node);
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
        private bool AddIfNotPresent(Node current, T value)
        {
            var Added = true;
            var order = comparer.Compare(value, current!.Value);
            if (order == 0) return false;
            if (order < 0)
            {
                if (current.Left == null)
                {
                    current.Left = new Node(value) { Parent = current };
                    count++;
                    return true;
                }
                Added = AddIfNotPresent(current.Left, value);
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new Node(value) { Parent = current };
                    count++;
                    return true;
                }
                Added = AddIfNotPresent(current.Right, value);
            }

            if (Added) PerformBalance(current);
            return Added;
        }

        private void RemoveNode(Node node)
        {
            if (count == 1 && comparer.Compare(node.Value, root!.Value) == 0)
                Clear();

            if (node.Left == null && node.Right == null)
            {
                if (comparer.Compare(node.Parent!.Value, node.Value) <= 0)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
            }
            else if (node.Left == null || node.Right == null)
            {
                if (comparer.Compare(node.Parent!.Value, node.Value) < 0)
                {
                    node.Parent.Left = node.Left ?? node.Right;
                    node.Parent.Left!.Parent = node.Parent;
                    PerformBalance(node.Parent.Left);
                }
                else
                {
                    node.Parent.Right = node.Left ?? node.Right;
                    node.Parent.Right!.Parent = node.Parent;
                    PerformBalance(node.Parent.Right);
                }
            }
            else
            {
                var maxLeftNode = node.Left;

                while (maxLeftNode.Left != null)
                    maxLeftNode = maxLeftNode.Left;

                node.Value = maxLeftNode.Value;
                RemoveNode(maxLeftNode);
                PerformBalance(node);
            }
        }

        private void PerformBalance(Node? node)
        {
            ArgumentNullException.ThrowIfNull(node);

            if (node.BalanceRatio == -2)
            {
                if (node.Left != null && node.Left.BalanceRatio == 1)
                    Rotate(node.Left, true);
                else Rotate(node, false);
            }
            else if (node.BalanceRatio == 2)
            {
                if (node.Right != null && node.Right.BalanceRatio == -1)
                    Rotate(node.Right, false);
                else Rotate(node, true);
            }
        }

        private void Rotate(Node node, bool isLeft)
        {
            if (isLeft)
            {
                var value = node.Value;
                node.Value = node.Right!.Value;
                node.Right.Value = value;
                Node temp = node.Left!;
                node.Left = node.Right;
                node.Right = node.Left.Right;
                node.Right!.Left = node.Right.Right;
                node.Left.Right = node.Left.Left;
                node.Left.Left = temp;
            }
            else
            {
                var value = node.Value;
                node.Value = node.Left!.Value;
                node.Left.Value = value;
                Node temp = node.Right!;
                node.Right = node.Left;
                node.Left = node.Right.Left;
                node.Right!.Left = node.Right.Right;
                node.Right.Right = temp;
            }
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
                && this.SequenceEqual(set);
        }
        #endregion

        #region Helper Classes
        public sealed class Node(T value)
        {
            public T Value { get; set; } = value;

            public Node? Left { get; set; }

            public Node? Right { get; set; }
            public Node? Parent { get; set; }

            public int Height =>
                1 + Math.Max(
                    Left == null ? -1 : Left.Height, Right == null ? - 1 : Right.Height);

            public int BalanceRatio =>
                (Right == null ? -1 : Right.Height) - (Left == null ? -1 : Left.Height);
        }
        #endregion
    }
}