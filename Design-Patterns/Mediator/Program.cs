// Padrão de Design Mediator
//
// Objetivo: Permite reduzir dependências caóticas entre objetos. O padrão
// restringe comunicações diretas entre os objetos e força-os a colaborar apenas
// através de um objeto mediador.

using System;

namespace Mediator
{
    // A interface Mediator declara um método usado pelos componentes para notificar
    // o mediador sobre vários eventos. O mediador pode reagir a esses eventos e
    // passar a execução para outros componentes.
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }

    // Mediadores concretos implementam comportamento cooperativo coordenando
    // vários componentes.
    class ConcreteMediator : IMediator
    {
        private Component1 _component1;

        private Component2 _component2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            _component1 = component1;
            _component1.SetMediator(this);
            _component2 = component2;
            _component2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("O mediador reage em A e desencadeia as seguintes operações:");
                _component2.DoC();
            }
            if (ev == "D")
            {
                Console.WriteLine("O mediador reage em D e desencadeia as seguintes operações:");
                _component1.DoB();
                _component2.DoC();
            }
        }
    }

    // O Componente Base fornece a funcionalidade básica de armazenar a instância do mediador
    // dentro dos objetos do componente.
    class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            _mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    // Componentes Concretos implementam várias funcionalidades. Eles não dependem
    // de outros componentes. Eles também não dependem de quaisquer classes de mediador
    // concretas.
    class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Componente 1 faz A.");

            _mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Componente 1 faz B.");

            _mediator.Notify(this, "B");
        }
    }

    class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Componente 2 faz C.");

            _mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Componente 2 faz D.");

            _mediator.Notify(this, "D");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Código do cliente.
            Component1 componente1 = new Component1();
            Component2 componente2 = new Component2();
            new ConcreteMediator(componente1, componente2);

            Console.WriteLine("O cliente aciona a operação A.");
            componente1.DoA();

            Console.WriteLine();

            Console.WriteLine("O cliente aciona a operação D.");
            componente2.DoD();
        }
    }
}