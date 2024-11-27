namespace ComputerPracticum1;

public sealed class GraphMatrices(Graph graph)
{
   private Dictionary<int, IReadOnlyList<int>> Elements => graph.Elements;
   
   public int[,] Adjacency()
   {
      var matrix = new int[Elements.Count, Elements.Count];

      foreach (var (vertex, edges) in Elements)
      {
         foreach (var e in edges)
            matrix[vertex - 1, e - 1] = 1;
      }

      return matrix;
   }

   public int[,] Incidence()
   {
      int vertexCount = Elements.Count;
      var matrix = new int[vertexCount, graph.EdgesCount()];

      foreach (var (vertex, edges) in Elements)
      {
         foreach (var e in edges)
         {
            if (e == vertex)
               matrix[e - 1, e - 1] = 2;
            else
            {
               matrix[vertex - 1, e - 1] = matrix[vertex - 1, e - 1] == 0 ? -1 : 1;
               matrix[e - 1, vertex - 1] = 1;
            }
         }
      }

      return matrix;
   }

}