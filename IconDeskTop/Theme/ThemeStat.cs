using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IconDeskTop.Theme
{
    public static class ThemeStat
    {
        public static void ThemeApply(Theme theme)
        {
            ResourceDictionary resource = new ResourceDictionary();
            switch (theme)
            {
                case Theme.Light:
                    resource.Source = new Uri("pack://application:,,,/IconDeskTop;component/Theme/Light.xaml");
                    foreach (ResourceDictionary item in Application.Current.Resources.MergedDictionaries)
                    {
                        if (item.Source.ToString() == "pack://application:,,,/IconDeskTop;component/Theme/Dark.xaml")
                        {
                            Application.Current.Resources.MergedDictionaries.Remove(item);
                        }
                        Application.Current.Resources.MergedDictionaries.Add(resource);
                        return;
                    }
                    break;
                case Theme.Dark:
                    resource.Source = new Uri("pack://application:,,,/IconDeskTop;component/Theme/Dark.xaml");
                    foreach (ResourceDictionary item in Application.Current.Resources.MergedDictionaries)
                    {
                        if (item.Source.ToString() == "pack://application:,,,/IconDeskTop;component/Theme/Light.xaml")
                        {
                            Application.Current.Resources.MergedDictionaries.Remove(item);
                        }
                        Application.Current.Resources.MergedDictionaries.Add(resource);
                        return;
                    }
                    break;
            }
            
        }

    }

    public enum Theme
    {
        Light,Dark
    }
}
