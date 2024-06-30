using System.Diagnostics;
using System.Text;
namespace OrderedList
{
    public class OrderedList<T> where T : IComparable
    {
        public Elem<T> First { get; set; }


        public void Add(T item)
        {
            if (First == null) 
                First = new Elem<T>() { Info = item };
            else
            {
                if (First.Info.CompareTo(item) == 0) 
                    return;
                if (First.Info.CompareTo(item) > 0) 
                {
                    var newElem = new Elem<T> { Info = item, Next = First };
                    First = newElem;
                    return;
                }
                var cur = First;
                while (cur.Next != null)
                {
                    if (cur.Next.Info.CompareTo(item) == 0) 
                        return;
                    if (cur.Next.Info.CompareTo(item) > 0) 
                    {
                        cur.Next = new Elem<T> { Info = item, Next = cur.Next };
                        return;
                    }
                    else
                        cur = cur.Next;
                }
                cur.Next = new Elem<T> { Info = item };
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



        public bool Contains(T item)
        {
            if (First == null) return false;
            var cur = First;
            while (cur != null)
            {
                if (cur.Info.CompareTo(item) == 0)
                {
                    return true;
                }

                cur = cur.Next;
            }
            return false;
        }

        public bool Remove(T item)
        {
            if (First == null)
            {
                return false;
            }

            if (First.Info.CompareTo(item) == 0)
            {
                First = First.Next;
                return true;
            }

            var cur = First;
            while (cur.Next != null)
            {
                if (cur.Next.Info.CompareTo(item) == 0)
                {
                    cur.Next = cur.Next.Next;
                    return true;
                }

                cur = cur.Next;
            }

            return false;
        }

        public void Merge(OrderedList<T> list)
        {
            var curBase = First;
            var current = list.First;
            Elem<T> predCur = null;
            while (curBase != null && current != null)
            {
                if (curBase.Info.CompareTo(current.Info) > 0)
                {
                    var temp = current;
                    current = current.Next;
                    if (predCur == null)
                    {
                        temp.Next = curBase;
                        First = temp;
                    }
                    else
                    {
                        predCur.Next = temp;
                        temp.Next = curBase;
                    }

                    predCur = temp;
                }
                else
                {
                    predCur = curBase;
                    curBase = curBase.Next;
                }
            }

            if (current != null)
            {
                predCur = current;
            }
        }

    }

    public class Elem<T>
    {
        public T Info { get; set; }
        public Elem<T> Next { get; set; }
    }

}

