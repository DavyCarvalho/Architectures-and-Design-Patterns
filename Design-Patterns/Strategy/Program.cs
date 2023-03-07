using System;
using System.Collections.Generic;

namespace Strategy
{
    // A interface Strategy declara operações comuns a todas as versões
    // suportadas de algum algoritmo.
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    class Context
    {
        // O Contexto mantém uma referência a um dos objetos Strategy.
        // O Contexto não conhece a classe concreta de uma estratégia. Ele deve
        // trabalhar com todas as estratégias através da interface Strategy.
        private IStrategy _strategy;

        public Context()
        { }

        // Normalmente, o Contexto aceita uma estratégia através do construtor,
        // mas também fornece um setter para alterá-la em tempo de execução.
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Normalmente, o Contexto permite substituir um objeto Strategy em
        // tempo de execução.
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // O Contexto delega parte do trabalho ao objeto Strategy em vez de
        // implementar múltiplas versões do algoritmo por conta própria.
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Contexto: Classificando dados usando a estratégia (não sabe como irá fazê-lo)");
            var result = _strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });
            var resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    // As estratégias concretas implementam o algoritmo seguindo a interface base
    // Strategy. A interface torna-as intercambiáveis no contexto.
    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // O código do cliente escolhe uma estratégia concreta e a passa para
            // o contexto. O cliente deve estar ciente das diferenças
            // entre as estratégias para fazer a escolha certa.
            var context = new Context();

            Console.WriteLine("Cliente: Estratégia definida para ordenação normal.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Cliente: Estratégia definida para ordenação reversa.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}
