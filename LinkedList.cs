using System.Text;
namespace LinkedList
{
    public class MyLinkedList<T>
    {
        public Elem<T> First { get; set; }


        public void AddFirst(T item)
        {
            Elem<T> newElem = new Elem<T>();
            newElem.Info = item;
            newElem.Next = First;

            First = newElem;
        }

        public void AddLast(T item)
        {
            if (First == null)
            {
                AddFirst(item);
                return;
            }
            var el = First;
            while (el.Next != null)
                el = el.Next;

            el.Next = new Elem<T> { Info = item };
        }

        public void RemoveValue(T x)
        {
            while (First != null && First.Info.Equals(x))
            {
                First = First.Next;
            }
            if (First == null)
            {
                return;
            }

            var elem = First;
            while (elem.Next != null)
            {
                if (elem.Next.Info.Equals(x))
                    elem.Next = elem.Next.Next;
                else
                    elem = elem.Next;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            var el = First;
            while (el != null)
            {
                sb.Append($"{el.Info} -> ");
                el = el.Next;
            }
            sb.Append("null");
            return sb.ToString();
        }

    }

    public class Elem<T>
    {
        public T Info { get; set; }
        public Elem<T> Next { get; set; }
    }
}

