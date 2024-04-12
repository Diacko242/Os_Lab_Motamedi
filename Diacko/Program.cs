using System;
using System.Management;

namespace USBWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a WMI event watcher to monitor for USB device insertion events
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            watcher.EventArrived += USBInserted;

            // Start listening for events
            watcher.Query = query;
            watcher.Start();

            Console.WriteLine("USBWatcher is running. Press any key to exit.");
            Console.ReadKey();

            // Stop watching for events
            watcher.Stop();
        }

        static void USBInserted(object sender, EventArrivedEventArgs e)
        {
            // This method will be called when a USB device is inserted
            Console.WriteLine("USB device inserted!");

            // Replace "your_program.exe" with the path to the program you want to execute
            string programPath = "mspaint.exe";

            // Execute the program
            System.Diagnostics.Process.Start(programPath);
        }

        static string FindPaintShortcut()
        {
            // Get the Start Menu Programs directory path
            string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);

            // Search for the Paint shortcut (*.lnk) in the Start Menu Programs directory
            string[] paintShortcuts = Directory.GetFiles(startMenuPath, "Paint.lnk", SearchOption.AllDirectories);

            // Check if any Paint shortcuts are found
            if (paintShortcuts.Length > 0)
            {
                // Return the first found Paint shortcut path
                return paintShortcuts[0];
            }

            return null;
        }
    }
}
