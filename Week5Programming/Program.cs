using System;

namespace Week5Programming
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Program prog = new Program();
            // Sync
            //Coffee cup = prog.pourCoffee();
            //Console.WriteLine("Your coffee is ready");
            //Eggs eggs = prog.fryEggs();
            //Console.WriteLine("Your eggs are ready");
            //Bacon bacon = prog.fryBacon();
            //Console.WriteLine("Your bacon is ready");
            //Toast toast = prog.toastBread();
            //Console.WriteLine("Your toast is ready");
            //Juice juice = prog.pourJuice();
            //Console.WriteLine("Your Juice is ready");

            // Async
            //Coffee cup = prog.pourCoffee();
            //Console.WriteLine("Coffee's done.");
            //var eggsTask = prog.FryEggsAsync(1);
            //var baconTask = prog.FryBaconAsync(10);
            //var toastTask = prog.MakeToastAsync(2);

            //var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };

            //while (breakfastTasks.Count > 0)
            //{
            //    Task finishedTask = await Task.WhenAny(breakfastTasks); // return task that finishes first
            //    if (finishedTask == eggsTask)
            //    {
            //        Console.WriteLine("The eggs are ready");
            //    }
            //    else if (finishedTask == baconTask)
            //    {
            //        Console.WriteLine("The bacon is ready");
            //    }
            //    else if (finishedTask == toastTask)
            //    {
            //        Console.WriteLine("The toast is ready");
            //    }
            //    breakfastTasks.Remove(finishedTask);
            //}

            await APIExample.APIExampleRunAsync();
        }

        private Coffee pourCoffee()
        {
            Console.WriteLine("Pouring your coffee");
            return new Coffee(); 
        }

        private Eggs fryEggs()
        {
            Console.WriteLine("Your eggs are frying");
            return new Eggs();
        }

        private Bacon fryBacon()
        {
            Console.WriteLine("Your bacon is frying");
            return new Bacon();
        }

        private Toast toastBread()
        {
            Console.WriteLine("Toasting your bread");
            return new Toast();
        }

        private Juice pourJuice()
        {
            Console.WriteLine("Pouring your juice");
            return new Juice();
        }

        //two very important keywords
        // async and await - IMPORTANT
        // async is applied to a method
        // await is applied to an action in a method
        // Task - similar to a thread, actions you want to run async

        private async Task<Eggs> FryEggsAsync(int numOfEggs)
        {
            Console.WriteLine("Heating the pan...");
            await Task.Delay(1000); // wait 1000 ms
            Console.WriteLine($"Cracking {numOfEggs} into pan...");
            Console.WriteLine("Frying eggs...");
            await Task.Delay(3000);
            Console.WriteLine("Putting eggs on a plate for eating!");
            return new Eggs();
        }

        private async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine("Warming the pan...");
            await Task.Delay(200);
            Console.WriteLine("Cooking first side of bacon...");
            await Task.Delay(4000);
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking second side of bacon...");
            await Task.Delay(4000);
            Console.WriteLine("Putting bacon on a plate for eating!");
            return new Bacon();
        }

        private async Task<Toast> MakeToastAsync(int slices)
        {
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Putting slice of toast into the toaster");
            }
            Console.WriteLine("Start toasting");
            await Task.Delay(6000);
            Console.WriteLine("Removing toast from toaster");
            return new Toast();
        }


        private class Coffee {}
        private class Juice { }
        private class Bacon { }
        private class Toast { }
        private class Eggs { }
    }
}