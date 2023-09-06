
int x = 5;

if (x < 5)
{
    Console.WriteLine("yes");
}
else
{
    Console.WriteLine("no");
}

int[] array = {1,2,3,4,5};

for (int i = 0; i < array.Length; i++)
{
    array[i]++;
}

Console.WriteLine(String.Join(" ", array));

