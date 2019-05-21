using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.Core;
using Cosmos.HAL.Drivers.PCI.Video;
using Cosmos.Debug.Kernel;
using System.IO;



namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Bootloader run successfully. Welcome to the beta OS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Cyan;
        }

    
        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "about":
                    {
                        Console.WriteLine("Welcome to the OS(TBD)");
                        Console.WriteLine("Made by Jatin and Ishaan");
                        break;
                    }
                case "help":
                    {
                        Console.WriteLine("about: Tells about the OS");
                        Console.WriteLine("help: list all the available commands");
                        Console.WriteLine("calc: Basic calculator");
                        Console.WriteLine("echo: Repeats the given input");
                        break;
                    }

                case "echo":
                    {
                        var echo = Console.ReadLine();
                        Console.Write("Text typed: ");
                        Console.WriteLine(echo);
                        break;
                    }
                case "shutdown":
                    {
                        ACPI.Shutdown();
                        break;
                    }

                case "mkdir":
                    {
                        string dirpath = @"D:\Testdir4";

                        try

                        {

                            if (Directory.Exists(dirpath))

                            {

                                Console.WriteLine("That path exists already.");

                                return;

                            }



                            System.IO.Directory.CreateDirectory(dirpath);

                            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(dirpath));

                        }



                        catch (Exception e)

                        {

                            Console.WriteLine("The process failed: {0}", e.ToString());

                        }
                   

                        break;

                    }


                case "calc":
                    {
                     
                        double a, b;
                        char c;
                        Console.Write("Enter First Number: ");
                        a = Double.Parse(Console.ReadLine());
                        Console.Write("Enter Second Number: ");
                        b = Double.Parse(Console.ReadLine());
                        Console.Write("Enter Sign (+ - * /): ");
                        c = Char.Parse(Console.ReadLine());
                        switch (c)
                        {
                            case '+':
                                Console.WriteLine("{0}+{1}={2}", a, b, a + b);
                                break;
                            case '-':
                                Console.WriteLine("{0}-{1}={2}", a, b, a - b);
                                break;
                            case '*':
                                Console.WriteLine("{0}*{1}={2}", a, b, a * b);
                                break;
                            case '/':
                                Console.WriteLine("{0}/{1}={2}", a, b, a / b);
                                break;
                            default:
                                Console.WriteLine("Unknown sign!");
                                break;
                        }
                        break;

                    }


                 default:
                    Console.WriteLine("Unknown command");
                    break;


                    
            }
            


        }
    }
}
