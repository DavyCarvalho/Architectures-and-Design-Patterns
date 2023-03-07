// Factory Method Design Pattern
//
// Objetivo: Fornece uma interface para criar objetos em uma superclasse, mas
// permite que as subclasses alterem o tipo de objetos que serão criados.

using System;

namespace Factory
{
    // A interface Product declara as operações que todos os produtos concretos devem implementar.
    public interface IProduct
    {
        string Operation();
    }

    // A classe abstrata Creator declara o método de fábrica que deve
    // retornar um objeto da classe Product. As subclasses de Creator geralmente
    // fornecem a implementação desse método.
    abstract class Creator
    {
        // Observe que o Creator também poderia fornecer alguma implementação padrão
        // do método de fábrica.
        public abstract IProduct FactoryMethod();

        // Observe também que, apesar do nome, a responsabilidade principal do Creator
        // não é criar produtos. Geralmente, ele contém alguma lógica de negócios central
        // que depende de objetos Product, retornados pelo método de fábrica. As subclasses
        // podem alterar indiretamente essa lógica de negócios substituindo o método de fábrica
        // e retornando um tipo diferente de produto a partir dele.
        public string SomeOperation()
        {
            // Chama o método de fábrica para criar um objeto Product.
            var product = FactoryMethod();
            // Agora, usa o produto.
            return "Creator: O mesmo código do Creator acabou de trabalhar com " + product.Operation();
        }
    }

    // Os Concrete Creators substituem o método de fábrica para mudar o tipo de produto resultante.
    class ConcreteCreator1 : Creator
    {
        // Observe que a assinatura do método ainda usa o tipo de produto abstrato,
        // embora o produto concreto seja retornado pelo método. Dessa forma, o Creator
        // pode ficar independente das classes de produtos concretos.
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct1();
        }
    }

    class ConcreteCreator2 : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProduct2();
        }
    }

    // Os produtos concretos fornecem várias implementações da interface Product.
    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Resultado do ConcreteProduct1}";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Resultado do ConcreteProduct2}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Aplicativo: Iniciado com ConcreteCreator1.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("Aplicativo: Iniciado com ConcreteCreator2.");
            ClientCode(new ConcreteCreator2());
        }

        // O código do cliente funciona com uma instância de um criador concreto,
        // embora por meio de sua interface base. Contanto que o cliente continue
        // trabalhando com o criador via a interface base, você pode passar qualquer
        // subclasse de criador para ele.
        public static void ClientCode(Creator creator)
        {
            Console.WriteLine("Cliente: Não estou ciente da classe do creator, mas ainda funciona.\n" + creator.SomeOperation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}