using System;
using System.Collections.Generic;

namespace Concorrencia.ConsoleApp
{
    internal class Animal
    {
        public string Nome { get; set; }

        public Animal()
        {
            Nome = ObterAnimal();
        }

        string ObterAnimal()
        {
            List<string> lista = new List<string>();
            lista.Add("onca");
            lista.Add("tigre");
            lista.Add("leopardo");
            lista.Add("leao");
            lista.Add("tigre");
            lista.Add("pantera");
            lista.Add("lobo-guara");

            Random random = new Random();

            // Gerar um número aleatório inteiro no intervalo de 0 a 7
            int numeroAleatorio = random.Next(0, 7);                       

            return lista[numeroAleatorio];
        }
    }
}
