namespace ComputerPracticum1;

public sealed class GraphVertexPower(Graph graph)
{
   private readonly GraphMatrices _matrices = new(graph);
   private Dictionary<int, IReadOnlyList<int>> Elements => graph.Elements;

   public int[] Full()
   {
      List<int> powers = [];

      var adjacency = _matrices.Adjacency();

      for (var vertex = 0; vertex < Elements.Count; vertex++)
      {
         var column = Enumerable
            .Range(0, adjacency.GetLength(0))
            .Select(x => adjacency[x, vertex]);

         powers.Add(column.Where(i => i == 1).Sum());
      }

      return powers.ToArray();
   }

   public int[] Enter() =>
      HalfPower(1, 2);

   public int[] Exit() =>
      HalfPower(-1);

   private int[] HalfPower(params int[] elements)
   {
      var powers = new int[Elements.Count];
      var adjacency = _matrices.Incidence();

      for (var vertex = 0; vertex < Elements.Count; vertex++)
      {
         var column = Enumerable
            .Range(0, adjacency.GetLength(0))
            .Select(y => adjacency[vertex, y]);

         foreach (var i in column)
         {
            if (elements.Contains(i))
               powers[vertex] += 1;
         }
      }

      return powers;
   }
}