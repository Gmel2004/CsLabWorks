using Task;
using _12;

namespace _13
{
    public class MyNewCollection : MySortedSet<Animal>
    {
        public enum eventType
        {
            AddItem,
            RemoveItem
        }

        public delegate void ActionCollection(eventType type, Animal animal);
        public event ActionCollection? OnItemAdded;
        public event ActionCollection? OnItemRemoved;

        public string CollectionName { get; set; }
        private static Journal journal = new Journal();

        public MyNewCollection(string collectionName) => CollectionName = collectionName;

        public new void Add(Animal animal)
        {
            base.Add(animal);
            HandleEvent(eventType.AddItem, animal);
        }

        public new bool Remove(Animal animal)
        {
            bool isRemove = base.Remove(animal);
            if (isRemove) HandleEvent(eventType.RemoveItem, animal);
            return isRemove;
        }

        public void HandleEvent(eventType type, Animal animal)
        {
            switch (type)
            {
                case eventType.AddItem:
                    if (OnItemAdded != null) OnItemAdded(type, animal);
                    break;
                case eventType.RemoveItem:
                    if (OnItemRemoved != null) OnItemRemoved(type, animal);
                    break;
            }
        }

        public void RememberChanges(eventType type, Animal animal) =>
            journal.Add(new JournalEntry(CollectionName, type, animal));

        public static string Changes => journal.ToString();

        private class Journal
        {
            public List<JournalEntry> Entries { get; private set; } = new List<JournalEntry>();

            public void Add(JournalEntry entry) => Entries.Add(entry);

            public void Clear() => Entries.Clear();

            public override string ToString()
            {
                return $"Entries:\n{string.Join("\n\n", Entries)}";
            }
        }

        private class JournalEntry
        {
            public string CollectionName { get; private set; }
            public eventType ActionType { get; private set; }
            public object ChangedData { get; private set; }

            public JournalEntry(string collectionName, eventType type, object changedData)
            {
                CollectionName = collectionName;
                ActionType = type;
                ChangedData = changedData;
            }

            public override string ToString()
            {
                return
                    $"""
                    Collection: {CollectionName}
                    Change Type: {ActionType}
                    Changed Data:
                    {ChangedData}
                    """;
            }
        }
    }
}
