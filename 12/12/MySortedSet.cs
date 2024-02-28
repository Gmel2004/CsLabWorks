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

        public MySortedSet(IComparer<T> comparer) => this.comparer = comparer ?? Comparer<T>.Default;

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

            while (current != null || stack.Count > 0)
            {
                while (current != null)
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

        IEnumerator IEnumerable.GetEnumerator() => throw new Exception();

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
            }
            else AddIfNotPresent(root, value);
        }

        public bool Remove(T value)
        {
            Node node = FindNode(value)!;
            if (node == null) return false;

            count--;
            if (count == 0) root = null;
            else RemoveNode(node);
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
            var order = comparer.Compare(value, current!.Value);

            if (order == 0)
            {
                current.Value = value;
                return false;
            }

            var next = order < 0 ? current.Left : current.Right;
            if (next == null)
            {
                next = new Node(value) { Parent = current };
                if (order < 0) current.Left = next;
                else current.Right = next;
                count++;
                PerformBalance(current);
                return true;
            }
            if (AddIfNotPresent(next, value))
            {
                PerformBalance(current);
                return true;
            }
            return false;
        }

        private void RemoveNode(Node node)
        {
            if (node.Left == null || node.Right == null)
            {
                var next = node.Left ?? node.Right;
                if (next != null) next!.Parent = node.Parent;
                if (node.Parent != null)
                {
                    if (comparer.Compare(node.Value, node.Parent.Value) <= 0)
                        node.Parent.Left = next;
                    else node.Parent.Right = next;
                }
                else root = next;
                if (next != null) PerformBalance(next);
            }
            else
            {
                var maxLeftNode = node.Left;
                while (maxLeftNode.Right != null)
                    maxLeftNode = maxLeftNode.Right;

                node.Value = maxLeftNode.Value;
                RemoveNode(maxLeftNode);
                PerformBalance(node);
            }
        }

        private void PerformBalance(Node node)
        {
            var balanceRatio = node.BalanceRatio;
            if (Math.Abs(balanceRatio) != 2) return;

            var isLeftTurn = balanceRatio < 0;
            var next = isLeftTurn ? node.Left : node.Right;
            var nextBalanceRatio = next!.BalanceRatio;
            if (balanceRatio == -2 * nextBalanceRatio) Rotate(next, isLeftTurn);
            Rotate(node, !isLeftTurn);
        }

        private void Rotate(Node node, bool isLeftTurn)
        {
            var next = isLeftTurn ? node.Right : node.Left;
            next!.Parent = node.Parent;
            if (node.Parent != null)
            {
                if (comparer.Compare(node.Value, node.Parent!.Value) < 0)
                    node.Parent.Left = next;
                else node.Parent.Right = next;
            }
            else root = next;
            node.Parent = next;
            Node? temp;
            if (isLeftTurn)
            {
                temp = next.Left;
                next.Left = node;
                node.Right = temp;
            }
            else
            {
                temp = next.Right;
                next.Right = node;
                node.Left = temp;
            }
            if (temp != null) temp.Parent = node;
        }

        private Node? FindNode(T value)
        {
            if (value == null) return null;

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

        public object Clone() => new MySortedSet<T>(this, comparer);

        public object ShallowCopy() => MemberwiseClone();
        #endregion

        public sealed class Node(T value)
        {
            public T Value { get; set; } = value;

            public Node? Left { get; set; }

            public Node? Right { get; set; }

            public Node? Parent { get; set; }

            public int Height =>
                1 + Math.Max(
                    Left == null ? -1 : Left.Height, Right == null ? -1 : Right.Height);

            public int BalanceRatio =>
                (Right == null ? -1 : Right.Height) - (Left == null ? -1 : Left.Height);
        }
    }
}