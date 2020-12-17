using System;
using System.Threading;

namespace ThreadSyncTask1
{
    class Program
    {
        static int count = 0;
        static object key = new object();

        static void Main(string[] args)
        {
            while (true)
            {
                // Create two threads that call methods increase and decrease.
                Thread thread1 = new Thread(Increase);
                thread1.Start();
                Thread thread2 = new Thread(Decrease);
                thread2.Start();

                // Main thread sleeps for 1 second.
                Thread.Sleep(1000);
                Console.WriteLine(count);
            }
        }

        // Method to decrease 'count' by 1.
        private static void Decrease()
        {
            // Check if 'key' is available. if 'key' is available run code.
            lock (key)
            {
                count--;
            }
        }

        // Method to increase 'count' by 2.
        static void Increase()
        {
            // Check if 'key' is available. if 'key' is available run code.
            lock (key)
            {
                count += 2;
            }
        }
    }
}