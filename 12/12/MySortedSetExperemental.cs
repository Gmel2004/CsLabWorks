using System.Collections;

namespace _12
{
    public class MySortedSetExperemental<T> :
        ICollection<T>, ICloneable
    {
        private Node? root;

        private readonly IComparer<T> comparer;

        #region Constructors
        public MySortedSetExperemental() : this(Comparer<T>.Default) { }

        public MySortedSetExperemental(IComparer<T> comparer) => this.comparer = comparer ?? Comparer<T>.Default;

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
                yield return node.Value!;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

        #endregion

        #region ICollection<T> members
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T value)
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));

            if (NullOrDefault(root))
            {
                if (root == null) root = new Node(value);
                else
                {
                    root.Value = value;
                    root.IsInitialized = true;
                }
                Count = 1;
            }
            else AddIfNotPresent(root!, value);
        }

        public bool Remove(T value)
        {
            Node node = FindNode(value)!;
            if (NullOrDefault(node)) return false;

            if (--Count == 0) root = null;
            else RemoveNode(node);
            return true;
        }

        public void Clear()
        {
            foreach (var node in GetNodesAscending())
            {
                node.Value = default!;
                node.IsInitialized = false;
            }

            Count = 0;
        }

        public bool Contains(T value) => !NullOrDefault(FindNode(value));

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
            if (NullOrDefault(next))
            {
                if (next == null)
                {
                    next = new Node(value) { Parent = current };
                    if (order < 0) current.Left = next;
                    else current.Right = next;
                }
                else
                {
                    next.Value = value;
                    next.IsInitialized = true;
                }
                Count++;
                PerformBalance(current);
                return true;
            }
            if (AddIfNotPresent(next!, value))
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
                if (next != null) next.Parent = node.Parent;
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
                Node? relevantNode;
                if (NullOrDefault(node.Left) && NullOrDefault(node.Right)
                    || !NullOrDefault(node.Left))
                {
                    relevantNode = node.Left;
                    while (!NullOrDefault(relevantNode!.Right))
                        relevantNode = relevantNode.Right;
                }
                else
                {
                    relevantNode = node.Right;
                    while (!NullOrDefault(relevantNode!.Left))
                        relevantNode = relevantNode.Left;
                }
                node.Value = relevantNode.Value;
                RemoveNode(relevantNode);
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
            while (!NullOrDefault(current))
            {
                var order = comparer.Compare(value, current!.Value);
                if (order == 0) break;

                current = order < 0 ? current.Left : current.Right;
            }

            return current;
        }

        private static bool NullOrDefault(Node? node) =>
            node == null || !node.IsInitialized;

        private List<Node> GetNodesAscending()
        {
            List<Node> nodes = new();
            Stack<Node> stack = new();
            Node current = root!;
            while (!NullOrDefault(current) || stack.Count > 0)
            {
                while (!NullOrDefault(current))
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

        public override bool Equals(object? obj)
        {
            return obj is MySortedSetExperemental<T> set
                && comparer.Equals(set.comparer)
                && Count == set.Count
                && this.SequenceEqual(set);
        }

        public object Clone() => new MySortedSetExperemental<T>(this, comparer);
        #endregion

        public sealed class Node(T value)
        {
            public T Value { get; set; } = value;

            public Node? Left { get; set; }

            public Node? Right { get; set; }

            public Node? Parent { get; set; }

            public bool IsInitialized { get; set; } = true;

            public int Height =>
                1 + Math.Max(
                    NullOrDefault(Left) ? -1 : Left!.Height, NullOrDefault(Right) ? -1 : Right!.Height);

            public int BalanceRatio =>
                (NullOrDefault(Right) ? -1 : Right!.Height) - (NullOrDefault(Left) ? -1 : Left!.Height);
        }
    }
}