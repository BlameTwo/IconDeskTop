using IconDeskTop.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace IconDeskTop.Models
{
    public static class AppSetupPath
    {

        //可以使用不同的注册表位置来检索应用
        public static Task<ObservableCollection<AppSetupPathArgs>> GetAllAppSetup()
        {
#pragma warning disable CS8619 // 值中的引用类型的为 Null 性与目标类型不匹配。
            return Task.Run(() =>
            {
                var list = new ObservableCollection<AppSetupPathArgs>();
                string folder =  System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                RegistryKey key = Registry.Users;
                var key2 = key.OpenSubKey(@"S-1-5-21-741255448-2691159960-1889481200-1001\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders");
                string MenuPath = key2.GetValue("Start Menu").ToString()+ @"\Programs";
                DirectoryInfo dirinfo = new DirectoryInfo(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs");
                var dirs =  dirinfo.GetDirectories();
                var files = dirinfo.GetFiles("*.lnk");
                foreach (var item in files)
                {
                    WshShell wshShell = new WshShell(); 
                    IWshShortcut lnk = (IWshShortcut)wshShell.CreateShortcut(item.FullName);
                    if (!System.IO.File.Exists(lnk.TargetPath))
                    {
                        continue;
                    }
                    list.Add(GetLnk(item.FullName));
                }

                foreach (var item2 in dirs)
                {
                    foreach (var item3 in item2.GetFiles("*.lnk"))
                    {
                        WshShell wshShell = new WshShell();
                        IWshShortcut lnk = (IWshShortcut)wshShell.CreateShortcut(item3.FullName);
                        string path = lnk.TargetPath;
                        if (!System.IO.File.Exists(lnk.TargetPath) || String.IsNullOrWhiteSpace(lnk.TargetPath))
                        {
                            continue;
                        }
                        string extension = System.IO.Path.GetExtension(path);
                        if (extension.ToLower() != ".exe")
                            continue;
                        list.Add(GetLnk(item3.FullName));
                    } 
                }
                return list;
            });
        }


        static AppSetupPathArgs GetLnk(string path)
        {
            WshShell wshShell = new WshShell();
            IWshShortcut lnk = (IWshShortcut)wshShell.CreateShortcut(path);
            AppSetupPathArgs arg = new AppSetupPathArgs();
            arg.AppName = System.IO.Path.GetFileNameWithoutExtension(lnk.FullName);
            arg.DirectoryPath = lnk.WorkingDirectory;
            arg.Icon = lnk.TargetPath;
            arg.lnk = path;
            return arg;
        }


    }
}
