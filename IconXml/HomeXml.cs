using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IconXml
{
    public static class HomeXml
    {
        public async static Task<ObservableCollection<HomeIconArgs>> GetRead(string filename)
        {
            return await Task.Run(async () =>
            {
                ObservableCollection<HomeIconArgs> args = new ObservableCollection<HomeIconArgs>();
                XmlDocument xmldoc = null;
                if (!File.Exists(filename))
                {
                    await CreateHeader(IconXml.Home, filename);
                }
                xmldoc = new XmlDocument();
                xmldoc.Load(filename);
                XmlElement node = (XmlElement)xmldoc.SelectSingleNode("/Icons/HomeIcon");
                if (node.GetAttribute("MyComputer") == "True")
                    args.Add(new HomeIconArgs() { Icon = "/Assets/Computer.svg", Name="此电脑", Prcess = "explorer.exe" ,ProcessArg ="" });
                if(node.GetAttribute("Control") == "True")
                    args.Add(new HomeIconArgs() { Icon = "/Assets/Control.svg", Name = "设置", Prcess = "control",ProcessArg = "system" });
                if(node.GetAttribute("Recycle") == "True")
                    args.Add(new HomeIconArgs() { Icon = "/Assets/Recycle.svg", Name = "回收站", Prcess = "explorer.exe",ProcessArg= " ::{645FF040-5081-101B-9F08-00AA002F954E}" });
                return args;
            });
        }

        public async  static Task  CreateHeader(IconXml enums,string filename)
        {
            await Task.Run(() =>
            {
                XmlDocument xnldoc = new XmlDocument();
                XmlNode header = xnldoc.CreateXmlDeclaration("1.0", "utf-8", "");
                XmlElement icons = xnldoc.CreateElement("Icons");
                xnldoc.AppendChild(header);
                switch (enums)
                {
                    case IconXml.Home:
                        XmlElement xmlel = xnldoc.CreateElement("HomeIcon");
                        xmlel.SetAttribute("MyComputer", "True");
                        xmlel.SetAttribute("Control", "True");
                        xmlel.SetAttribute("Recycle", "True");
                        icons.AppendChild(xmlel);
                        break;
                    case IconXml.Icon:
                        XmlElement xmlel2 = xnldoc.CreateElement("AppIcon");
                        icons.AppendChild(xmlel2);
                        break;
                }
                xnldoc.AppendChild(icons);
                xnldoc.Save(filename);
            });
        }


       
    }
}
