using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace process_manager
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
               //  string option = Console.ReadLine();
               //  string process_path = Console.ReadLine();

                string option = args[0];
                if (option == null)
                {
                    Console.WriteLine("Enter processname and operation, example: [status] [notepad.exe]");
                }
                if (option == "status")
                {
                    string process_name = args[1];
                    Process[] localByName = Process.GetProcessesByName(process_name);
                    if (localByName.Length == 0)
                    {
                        Console.WriteLine("Process {0} is NOT running",process_name);
                    }
                    else
                        Console.WriteLine("Process {0} is Running", process_name);
                }

                if (option  == "run")
                {
                    string process_path = args[1]; //Second passing argument is the path
                    try
                    {
                        using (Process myProcess = new Process())
                        {
                            myProcess.StartInfo.UseShellExecute = false;
                            myProcess.StartInfo.FileName = process_path;
                            myProcess.StartInfo.CreateNoWindow = false;
                           //myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized; //Launch minimized process
                            myProcess.Start();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (option == "run_minimized")
                {
                    string process_path = args[1]; //Second passing argument is the path
                    try
                    {
                        using (Process myProcess = new Process())
                        {
                            myProcess.StartInfo.UseShellExecute = false;
                            myProcess.StartInfo.FileName = process_path;
                            myProcess.StartInfo.CreateNoWindow = false;
                            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized; //Launch minimized process
                            myProcess.Start();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Enter processname and operation, example: [status] [notepad.exe]");
                Console.WriteLine(e.Message);
            }


        }
    }
}
