using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public static class ExtensionMethods
    {
        public static LinkedListNode<T> RemoveAt<T>(this LinkedList<T> list, int index)
        {
            LinkedListNode<T> currentNode = list.First;
            for (int i = 0; i <= index && currentNode != null; i++)
            {
                if (i != index)
                {
                    currentNode = currentNode.Next;
                    continue;
                }

                list.Remove(currentNode);
                return currentNode;
            }

            throw new IndexOutOfRangeException();
        }
    }
}
