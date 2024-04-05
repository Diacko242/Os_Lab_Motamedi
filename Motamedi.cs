
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select a number between 1 to 4:");
            int Adad = int.Parse(Console.ReadLine());
            Process[] plist = Process.GetProcesses();
            if(Adad == 1)//Runngin a Process
            {
                Console.WriteLine("Please enter the process name that you want to start:");
                String nameProcess = Console.ReadLine();
                Process.Start(nameProcess);
            }
            else if ( Adad == 2)//all processs
            {
                Console.WriteLine("showing the process Lists:");
                foreach (Process p in plist)
                    Console.WriteLine(p.Id + "\t" + p.ProcessName);
                
            }
            else if( Adad == 3)//Killing a process by using the name of that process
            {
                Console.WriteLine("Name a Process to kill it:");
                String name0 = Console.ReadLine();
                foreach(Process p in plist)
                    if (p.ProcessName ==name0)
                        p.Kill();
               
            }
            else if(Adad == 4)
            {
    //Parent List by using Processs Name
                Console.WriteLine("Please enter the name of process:");
                String child = Console.ReadLine();
                foreach (Process p in plist)
                    if (p.ProcessName == child)
                    {
                        Console.WriteLine("The parent process is:"+p.Handle);
                        

                    }
            }
            
            Console.ReadKey();
            
        }
       
       
    }
}