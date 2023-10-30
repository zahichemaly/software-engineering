namespace TD5
{
    public class Maximier
    {
        private int[] heap;
        private int maxSize;
        private int currentSize;

        public Maximier(int maxSize)
        {
            this.maxSize = maxSize;
            this.currentSize = 0;
            this.heap = new int[maxSize + 1];
        }

        public void push(int x)
        {
            if (currentSize >= maxSize)
            {
                throw new Exception("Maximier is full");
            }

            currentSize++;
            int i = currentSize;
            while (i > 1 && x > heap[i / 2])
            {
                heap[i] = heap[i / 2];
                i = i / 2;
            }
            heap[i] = x;
        }

        public int pop()
        {
            if (currentSize <= 0)
            {
                throw new Exception("Maximier is empty");
            }

            int root = heap[1];
            heap[1] = heap[currentSize];
            currentSize--;
            int i = 1;
            while (true)
            {
                int leftChild = 2 * i;
                int rightChild = 2 * i + 1;
                int largest = i;

                if (leftChild <= currentSize && heap[leftChild] > heap[largest])
                {
                    largest = leftChild;
                }
                if (rightChild <= currentSize && heap[rightChild] > heap[largest])
                {
                    largest = rightChild;
                }

                if (largest != i)
                {
                    int temp = heap[i];
                    heap[i] = heap[largest];
                    heap[largest] = temp;
                    i = largest;
                }
                else
                {
                    break;
                }
            }

            return root;
        }

        public int size()
        {
            return currentSize;
        }

        public int value(int idx)
        {
            if (idx < 1 || idx > currentSize)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return heap[idx];
        }
        static void Main(string[] args)
        {
            Maximier maxHeap = new Maximier(10);

            maxHeap.push(4);
            maxHeap.push(8);
            maxHeap.push(2);
            maxHeap.push(10);
            maxHeap.push(5);
            maxHeap.push(7);

            Console.WriteLine("Heap size: " + maxHeap.size());

            while (maxHeap.size() > 0)
            {
                int max = maxHeap.pop();
                Console.WriteLine("Popped: " + max);
            }

            Console.WriteLine("Heap size after popping all elements: " + maxHeap.size());

            maxHeap.push(9);
            maxHeap.push(3);
            maxHeap.push(6);

            Console.WriteLine("Value at index 1: " + maxHeap.value(1));
            Console.WriteLine("Value at index 2: " + maxHeap.value(2));
            Console.WriteLine("Value at index 3: " + maxHeap.value(3));
        }
    }
}