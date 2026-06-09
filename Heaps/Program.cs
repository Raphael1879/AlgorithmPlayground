var testHeap = new MinHeap();
var numbersToAdd = new int[] { 80, 70, 18, 30, 40 };

foreach (int i in numbersToAdd) { 
    testHeap.Add(i);
}

testHeap.PrintTree();

var removedValue = testHeap.Pop();
Console.WriteLine("Removed Value: " + removedValue);

testHeap.PrintTree();

class MinHeap
{
    public List<int> Heap = new List<int>();

    public void Add(int value)
    {
        Heap.Add(value);
        SiftUp(Heap.Count - 1);
    }

    public int Pop()
    {
        if (Heap.Count == 0)
            throw new InvalidOperationException("Heap is empty");

        var oldRoot = Heap[0];

        if (Heap.Count == 1)
        {
            Heap.RemoveAt(0);
            return oldRoot;
        }

        Heap[0] = Heap[Heap.Count - 1];
        Heap.RemoveAt(Heap.Count - 1);

        SiftDown(0);

        return oldRoot;
    }

    public void SiftDown(int index) {

        var currentIndex = index;

        while(true)
        {
            var leftIndex = GetLeftIndex(currentIndex);
            var rightIndex = GetRightIndex(currentIndex);

            var smallest = currentIndex;

            if(leftIndex < Heap.Count && Heap[leftIndex] < Heap[smallest])
            {
                smallest = leftIndex;
            }

            if(rightIndex < Heap.Count && Heap[rightIndex] < Heap[smallest])
            {
                smallest = rightIndex;
            }

            if(smallest == currentIndex)
            {
                break;
            }

            Swap(smallest, currentIndex);
            currentIndex = smallest;
        }
    }

    public void SiftUp(int index)
    {

        var currentIndex = index;

        while (currentIndex > 0)
        {

            var parentIndex = GetParentIndex(index);

            if (Heap[parentIndex] > Heap[index])
            {

                Swap(index, parentIndex);

                currentIndex = parentIndex;

            }
            else
            {
                break;
            }

        }

    }

    private void Swap(int a, int b)
    {
        var temp = Heap[a];
        Heap[a] = Heap[b];
        Heap[b] = temp;
    }

    private int GetParentIndex(int index)=>(index - 1) / 2;
    private int GetLeftIndex(int index) => (index * 2) + 1;
    private int GetRightIndex(int index) => (index * 2) + 2;


    //Cha- Gpt generierte Hilfsmethode für das anzeigen des Trees
    public void PrintTree()
    {
        if (Heap.Count == 0)
        {
            Console.WriteLine("(empty heap)");
            return;
        }

        int level = 0;
        int index = 0;

        while (index < Heap.Count)
        {
            int nodesInLevel = (int)Math.Pow(2, level);

            // Some spacing to make it look tree-like
            int leadingSpaces = (int)Math.Pow(2, Math.Max(0, 4 - level));

            Console.Write(new string(' ', leadingSpaces));

            for (int i = 0; i < nodesInLevel && index < Heap.Count; i++)
            {
                Console.Write($"{Heap[index],3}");

                int betweenSpaces = (int)Math.Pow(2, Math.Max(0, 5 - level));
                Console.Write(new string(' ', betweenSpaces));

                index++;
            }

            Console.WriteLine();
            Console.WriteLine();

            level++;
        }
    }

}
