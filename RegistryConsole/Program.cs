using System;
using System.Diagnostics;
using System.IO;

namespace RegistryConsole
{
    class Program
    {
        public const string CLSID = "799f5a14-acc6-4f01-abea-80a097104ce5";
        public const string Folder = "GodDrive3";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RegistNavigationPane();
        }

        static void RegistNavigationPane()
        {
            // Create folder
            var pathWithEnv = @"%USERPROFILE%\" + Folder;
            var folderPath = Environment.ExpandEnvironmentVariables(pathWithEnv);
            Directory.CreateDirectory(folderPath);

            // Add folder to Navigation Pane
            Process p = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    
                }
            };
            p.Start();

            // Add your CLSID and name your extension
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "} /ve /t REG_SZ /d \"" + Folder + "\" /f");
            // Set the image for your icon
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "}\\DefaultIcon /ve /t REG_EXPAND_SZ /d %%SystemRoot%%\\system32\\imageres.dll,-111 /f");
            // Add your extension to the Navigation Pane and make it visible
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "} /v System.IsPinnedToNameSpaceTree /t REG_DWORD /d 0x1 /f");
            // Set the location for your extension in the Navigation Pane
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "} /v SortOrderIndex /t REG_DWORD /d 0x42 /f");
            // Provide the dll that hosts your extension.
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "}\\InProcServer32 /ve /t REG_EXPAND_SZ /d %%systemroot%%\\system32\\shell32.dll /f");
            // Define the instance object
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "}\\Instance /v CLSID /t REG_SZ /d {0E5AAE11-A475-4c5b-AB00-C66DE400274E} /f");
            // Provide the file system attributes of the target folder
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "}\\Instance\\InitPropertyBag /v Attributes /t REG_DWORD /d 0x11 /f");
            // Set the path for the sync root
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "}\\Instance\\InitPropertyBag /v TargetFolderPath /t REG_EXPAND_SZ /d \"%USERPROFILE%\\" + Folder + "\" /f");
            // Set appropriate shell flags
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "}\\ShellFolder /v FolderValueFlags /t REG_DWORD /d 0x28 /f");
            // Set the appropriate flags to control your shell behavior
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "}\\ShellFolder /v Attributes /t REG_DWORD /d 0xF080004D /f");
            // Register your extension in the namespace root
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\{" + CLSID + "} /ve /t REG_SZ /d \"" + Folder + "\" /f");
            // Hide your extension from the Desktop
            p.StandardInput.WriteLine("reg add HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel /v {" + CLSID + "} /t REG_DWORD /d 0x1 /f");

            p.WaitForExit();
        }

        static void RemoveNavigationPane()
        {
            Process p = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe")
                {
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            p.Start();
            p.StandardInput.WriteLine("reg delete HKCU\\Software\\Classes\\CLSID\\{" + CLSID + "} /f");
            p.StandardInput.WriteLine("reg delete HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\{" + CLSID + "} /f");
            p.StandardInput.WriteLine("delete HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel /f");
            p.StandardInput.WriteLine("exit");
            p.WaitForExit();
        }
    }
}
