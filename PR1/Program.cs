using System;

namespace PR1
{
    static class Program
    {
        static void Main(string[] args)
        {
            ExecuteQueries executeQueres = new ExecuteQueries();
            executeQueres.Execute();
            Console.ResetColor();
        }
    }
}
