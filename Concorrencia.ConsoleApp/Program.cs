using System;
using System.Threading;
using System.Threading.Tasks;

namespace Concorrencia.ConsoleApp
{
    internal class Program
    {
        private static object lockObject = new object();        

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
                Task.Run(() => { GetNewAnimal(); });

            //Task.WaitAll();
            //Task.WhenAll();           
            
            Thread.Sleep(19000);
            Console.WriteLine("\nTodos os animais já comeram!");   
        }

        static void GetNewAnimal()
        {
            var animal = new Animal().Nome;

            // a seção crítica (que pode ter muitos acessos ao mesmo tempo)deve ficar dentro do lock
            // O lock é usado para garantir que apenas uma thread por vez possa acessar a seção crítica do código, evitando a concorrência
            lock (lockObject)
            {
                Console.WriteLine($"{(animal)} vai agora comer a carne | ID: {Task.CurrentId}"); //Thread.CurrentThread.ManagedThreadId
                Thread.Sleep(1500);
            }
        }

        /* outra forma de escrever uma thread
         * 
        Thread thread1 = new Thread(GetNewAnimal);
        Thread thread2 = new Thread(GetNewAnimal);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        hreads são unidades de execução em um processo, a concorrência refere-se à coordenação de várias tarefas intercaladas para melhorar a eficiência,
        enquanto o paralelismo envolve a execução real de múltiplas tarefas ao mesmo tempo, frequentemente em núcleos de CPU separados. Esses conceitos
        são frequentemente usados em conjunto para criar sistemas eficientes e responsivos.
         */

    }
}
