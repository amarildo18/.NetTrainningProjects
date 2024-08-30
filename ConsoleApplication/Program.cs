using System;
using System.Threading.Tasks;

namespace AsyncBreakfast{

    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    public class Program
    {
        public static void Main(string[] args)
        {
            Coffee cup = new Coffee();
            Console.WriteLine("O café está pronto");

            Egg eggs = FryEggs(2);
            Console.WriteLine("Os ovos estão prontos");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon está pronto");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("A tosta está pronta");

            Juice oj = PourJ();
            Console.WriteLine("oj está pronta");
            Console.WriteLine("O pequeno almoço está pronto!");
        }

        private static Juice PourJ()
        {
            Console.WriteLine("Derramando suco de laranja");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => Console.WriteLine("Colocando geleia na torrada");

        private static void ApplyButter(Toast toast) => Console.WriteLine("Colocando manteiga na torrada");

        private static Toast ToastBread(int slices)
        {
            for(int slice = 0; slice < slices; slice++) {
                Console.WriteLine("Colocando uma fatia de pão na torradeira");
            }
            Console.WriteLine("Iniciando a tostar...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Retire a torrada da torradeira");

            return new Toast();
        }
        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"colocando {slices} fatias de bacon na frigideira");
            Console.WriteLine("cozinhando o primeiro lado do bacon...");
            Task.Delay(3000).Wait();
            

            for(int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("virando uma fatia de bacon");
            }

            Console.WriteLine("cozinhando o segundo lado do bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Colocando o bacon no prato");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Aquecendo a Frigideira de ovos...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"quebrando {howMany} ovos");
            Console.WriteLine("Cozinhando os ovos...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Colocando os ovos no prato");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Derramando café");

            return new Coffee();
        }
    }
}
