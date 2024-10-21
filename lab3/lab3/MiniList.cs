using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class Node<T>
    {
        public T content;
        public Node<T> Next = null;
    }

    internal class MiniList<T> : IEnumerable<T>
    {

        static int num = 0;
        public Node<T> Top;
        public int Append(T s)
        {
            Node<T> p = new Node<T>();
            p.content = s;
            if (Top != null) p.Next = Top;
            Top = p;
            return num++;
        }
        public IEnumerator<T> GetEnumerator() => new MiniListEnum<T>(Top);
        IEnumerator IEnumerable.GetEnumerator() => new MiniListEnum<T>(Top);
    }


    internal class MiniListEnum<T> : IEnumerator<T>
    {
        public Node<T> Top;
        public Node<T> ENode;


        public MiniListEnum(Node<T> top)
        {
            Top = top;
            ENode = top;
        }

        public T Current
        {
            get
            {
                return ENode.content;
            }
        }

        object IEnumerator.Current => ENode.content;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            ENode = ENode.Next;
            return ENode != null;
        }

        public void Reset()
        {
            ENode = Top;
        }
    }
}
