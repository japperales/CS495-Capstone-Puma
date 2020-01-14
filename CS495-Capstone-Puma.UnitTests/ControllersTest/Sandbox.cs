using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS495_Capstone_Puma.DataStructure.Asset;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;
using Xunit.Abstractions;

namespace CS495_Capstone_Puma.UnitTests.ControllersTest
{
    public class Sandbox
    {

        private readonly ITestOutputHelper output;

        public Sandbox(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        public async Task<int> Task1()
        {
            output.WriteLine("Task1 started");
            System.Threading.Thread.Sleep(5000);

            return 100;
        }

        public async Task Task2()
        {
            output.WriteLine("Task2 Started");
            System.Threading.Thread.Sleep(500);
        }

        [Fact]
        public async void TestThreading()
        {
            Task<int> task1 = Task1();
            Task task2 = Task2();

            var allTasks = new List<Task> {task1, task2};
            output.WriteLine(allTasks.Count.ToString());
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == task1)
                {
                    int a = task1.Result;
                    output.WriteLine("Task1 Complete");
                    output.WriteLine(a.ToString());
                }
                else if (finished == task2)
                {
                    output.WriteLine("Task2 Complete");
                }
                allTasks.Remove(finished);
                output.WriteLine(allTasks.Count.ToString());
            }
            output.WriteLine("Done");
        }
    }
}