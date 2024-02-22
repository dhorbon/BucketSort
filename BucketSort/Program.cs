Console.Write("pdaj ilosc cyfr: ");
int size = Convert.ToInt32(Console.ReadLine());

List<int> tab = new List<int>();


Random x = new Random();
for (int i = 0; i < size; i++)
{
    tab.Add(x.Next(1,100));
    Console.Write(tab[i]+" ");
}

Console.WriteLine();

tab = BucketSort(tab);

for (int i = 0; i < tab.Count; i++)
{
    Console.Write(tab[i] + " ");
}
Console.WriteLine();

List<int> BucketSort(List<int> tab)
{
    //if there is only one element or none then return
    if(tab.Count <= 1)
    {
        return tab;
    }

    //min and max value are calculated for later use
    int max = tab[0];
    int min = tab[0];

    for(int i = 1; i < tab.Count; i++)
    {
        if (tab[i] > max)
        {
            max = tab[i];
        }
        else if (tab[i] < min)
        {
            min = tab[i];
        }
    }

    //if all elements are the same return
    if (max-min == 0) return tab;

    //number of buckets is the square root of number of elements rounded up
    int numBuckets = Convert.ToInt16(Math.Ceiling(Math.Sqrt(tab.Count)));

    List<int> thresholds = new();
    List<List<int>> buckets = new();
    List<int> sorted = new();

    var values = tab;

    for (int i = 0; i < numBuckets; i++)
    {
        thresholds.Add(min + (max - min) / numBuckets * (i + 1));
        buckets.Add(new());
    }

    thresholds[thresholds.Count - 1] = max;

    for (int i = 0; i < tab.Count; i++)
    {
        for(int j = 0; j < buckets.Count; j++)
        {
            if (tab[i] <= thresholds[j])
            {
                buckets[j].Add(tab[i]);
                break;
            }
        }
    }

    for(int i = 0; i < buckets.Count; i++)
    {
        buckets[i] = BucketSort(buckets[i]);
        for (int j = 0;j < buckets[i].Count; j++)
        {
            sorted.Add(buckets[i][j]);
        }
    }

    return sorted;
}