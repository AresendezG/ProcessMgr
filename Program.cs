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

                if (option == "kill")
                {
                    string process_name = args[1];
                    Process[] localByName = Process.GetProcessesByName(process_name);
                    
                    try
                    {
                        localByName[0].Kill();
                        Console.WriteLine("Successfully Closed {0} process", process_name);
                    }

                    /*
                     Win32Exception
                              The associated process could not be terminated.
                              The process is terminating.

                     NotSupportedException
                              You are attempting to call Kill() for a process that is running on a remote computer. The method is available only for processes running on the local computer.

                    InvalidOperationException
                     
                     */

                    catch (Win32Exception e)
                    {
                        Console.WriteLine("Access Denied for terminating this process: ");
                        Console.WriteLine(e.Message);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("You can't terminate remote process: ");
                        Console.WriteLine(e.Message);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("This process cannot be terminated: ");
                        Console.WriteLine(e.Message);
                    }
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
