namespace ComputerPracticum1;

public sealed class Graph(Dictionary<int, IReadOnlyList<int>> elements)
{
   public readonly Dictionary<int, IReadOnlyList<int>> Elements = elements;

   public int EdgesCount() => 
      (int)Elements.Sum(i => i.Value.Sum(edge => Elements[edge].Contains(i.Key) ? 0.5f : 1));
}
