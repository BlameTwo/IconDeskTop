﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IconXml
{
    public static class AppIconXml
    {
        public static async  Task CreateHeader(IconXml enumxml,string filename,ObservableCollection<IconArgs> args)
        {
            await Task.Run(async () =>
            {
                var xmldoc =  new XmlDocument();
                XmlNode header = xmldoc.CreateXmlDeclaration("1.0", "utf-8", "");
                xmldoc.AppendChild(header);
                XmlElement icons = xmldoc.CreateElement("AppIcons");
                xmldoc.AppendChild(icons);
                xmldoc.Save(filename);
                await AddArgs(enumxml, filename, args);
               
            });
        }




        public static async Task AddArgs(IconXml enumxml,string filename,ObservableCollection<IconArgs> args)
        {
            await Task.Run(() =>
            {
                var xmldoc = new XmlDocument();
                xmldoc.Load(filename);
                var icons = xmldoc.SelectSingleNode("AppIcons");
                if (args.Count > 0)
                {
                    foreach (var item in args)
                    {
                        //11个图标
                        var lists = icons.SelectNodes(".//IconArgs");
                        if(lists.Count >= 11)           //最大十一个图标，超过十一个就退出方法
                        {
                            return;
                        }
                        foreach (var item2 in lists)
                        {
                            var txt = ((XmlElement)item2).SelectSingleNode("IconPath").InnerText;
                            if (txt == item.IconPath)
                            {
                                return;
                            };
                        }
                        XmlDocument xmldoc2 = new XmlDocument();
                        xmldoc2.LoadXml(XmlSerialize(item));
                        icons.AppendChild(xmldoc.ImportNode(xmldoc2.SelectSingleNode("IconArgs"), true));
                    }
                }
                xmldoc.Save(filename);
            });
        }




        public static async Task<bool> ExistsAppIcon(IconXml enumxml,string filename, IconArgs args)
        {
            return await Task.Run(() =>
            {
                var xmldoc = new XmlDocument();
                //IconPath
                xmldoc.Load(filename);
                var lists = xmldoc.SelectNodes("//AppIcons//IconArgs");
                foreach (XmlNode item in lists)
                {
                    var arg = Deserialize(item.OuterXml);
                    if (arg.IconPath == args.IconPath)
                        return true;
                }
                return false;
            });
        }

        public static async Task<ObservableCollection<IconArgs>> ReadArgs(string filename)
        {
            return await Task.Run(() =>
            {
                var relist = new ObservableCollection<IconArgs>();
                var xmldoc = new XmlDocument();
                if (File.Exists(filename))
                {
                    xmldoc.Load(filename);
                    XmlNodeList lists = xmldoc.SelectNodes("//AppIcons//IconArgs");
                    foreach (XmlNode item in lists)
                    {
                        string a = item.OuterXml;
                        relist.Add(Deserialize(item.OuterXml));
                    }
                    return relist;
                }
                else
                {
                    CreateIconHeader(filename);
                }
                return relist;
            });
        }

        /// <summary>
        /// 生成原始空的ICON
        /// </summary>
        private static void CreateIconHeader(string filename)
        {
            var xmldoc = new XmlDocument();
            XmlNode header = xmldoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmldoc.AppendChild(header);
            xmldoc.AppendChild(xmldoc.CreateElement("AppIcons"));
            xmldoc.Save(filename);
        }

        public static IconArgs Deserialize(string xmlstr)
        {
            using(StringReader reader = new StringReader(xmlstr))
            {
                XmlSerializer xz = new XmlSerializer(typeof(IconArgs));
                var aa = (IconArgs)xz.Deserialize(reader);
                return aa;
            }
        }



        public static  string  XmlSerialize(IconArgs arg)
        {
            StringWriter sw = new StringWriter();
            XmlSerializerNamespaces name = new XmlSerializerNamespaces();
            name.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(IconArgs));
            serializer.Serialize(sw, arg,name);
            return sw.ToString();
        }
        
    }
}
