// Padrão de Projeto Singleton
//
// Objetivo: Garantir que uma classe tenha apenas uma instância, enquanto fornece um
// ponto de acesso global a essa instância.

using System;

namespace Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            // O código cliente.
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton funcionou, ambas as variáveis contêm a mesma instância.");
            }
            else
            {
                Console.WriteLine("Singleton falhou, as variáveis contêm instâncias diferentes.");
            }
        }
    }

    // A classe Singleton define o método GetInstance, que serve como uma
    // alternativa ao construtor e permite que clientes acessem a mesma instância
    // desta classe repetidamente.

    // O Singleton sempre deve ser uma classe 'sealed' para evitar a herança de
    // classe por meio de classes externas e também por meio de classes aninhadas.
    public sealed class Singleton
    {
        // A instância do Singleton é armazenada em um campo estático. Existem
        // várias maneiras de inicializar este campo, todas elas têm vários
        // prós e contras. Neste exemplo, mostraremos a maneira mais simples
        // delas, que, no entanto, não funciona muito bem em programas
        // multithreaded.
        private static Singleton _instance;

        // O construtor do Singleton deve sempre ser privado para evitar
        // chamadas de construção diretas com o operador `new`.
        private Singleton()
        {
        }

        // Este é o método estático que controla o acesso à instância singleton.
        // Na primeira execução, ele cria um objeto singleton e o coloca no
        // campo estático. Em execuções subsequentes, ele retorna o objeto
        // existente armazenado no campo estático.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }

        // Finalmente, qualquer Singleton deve definir alguma lógica de negócio,
        // que pode ser executada em sua instância.
        public static void SomeBusinessLogic()
        {
            //...
        }
    }
}

