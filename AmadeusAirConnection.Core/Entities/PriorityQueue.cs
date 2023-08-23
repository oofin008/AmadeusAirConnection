using System;
namespace AmadeusAirConnection.Domain.Entities
{
	public class PriorityQueue<T>
	{
        private List<T> heap;
        private Comparison<T> comparison;

        public PriorityQueue(Comparison<T> comparison)
        {
            this.heap = new List<T>();
            this.comparison = comparison;
        }

        public int Count => heap.Count;

        public void Enqueue(T item)
        {
            heap.Add(item);
            int i = heap.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (comparison(heap[parent], heap[i]) <= 0)
                    break;
                Swap(parent, i);
                i = parent;
            }
        }

        public T Dequeue()
        {
            T result = heap[0];
            int last = heap.Count - 1;
            heap[0] = heap[last];
            heap.RemoveAt(last);
            int i = 0;
            while (true)
            {
                int left = 2 * i + 1;
                int right = 2 * i + 2;
                int smallest = i;
                if (left < heap.Count && comparison(heap[left], heap[smallest]) < 0)
                    smallest = left;
                if (right < heap.Count && comparison(heap[right], heap[smallest]) < 0)
                    smallest = right;
                if (smallest == i)
                    break;
                Swap(i, smallest);
                i = smallest;
            }
            return result;
        }

        public void UpdatePriority(T item)
        {
            int i = heap.IndexOf(item);
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (comparison(heap[parent], heap[i]) <= 0)
                    break;
                Swap(parent, i);
                i = parent;
            }
        }

        private void Swap(int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}

