using System;
using System.Collections.Generic;


namespace PR1
{
    class WriteOnScreen
    {
        public void WriteAnswerOnScreen<T>(IEnumerable<T> type)
        {
            foreach (var x in type)
            {
                Console.WriteLine(x.ToString());
            }
        }

        public void WriteAnswerOnScreen<T>(T obj)
        {
            Console.WriteLine(obj);
        }

        public void WriteAnswerOnScreen<T,Q>(Dictionary <T, List<Q>> dictionary)
        {
            foreach (var groupQuere in dictionary)
            {
                Console.WriteLine("\nKey = " + groupQuere.Key);
                foreach (var answer in groupQuere.Value)
                {
                    Console.WriteLine("\n" + answer.ToString());
                }

            }
        }

    }
}
