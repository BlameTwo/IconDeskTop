using IconDeskTop.Model;
using IconDeskTop.Models.IconDeskTop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace IconDeskTop.Convert
{
    [ValueConversion(typeof(string),typeof(BitmapImage))]
    public class IconConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string extion = System.IO.Path.GetExtension(value.ToString().ToLower());
            var icon = IconHelper.GetIcon(value.ToString());
            MemoryStream ms = new MemoryStream();
            if(icon != null)
            {
                icon.Save(ms, ImageFormat.Png);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
            return new BitmapImage();
        }



        [DllImport("User32.dll")]
        public static extern int PrivateExtractIcons(
            string lpszFile, //文件名可以是exe,dll,ico,cur,ani,bmp
            int nIconIndex,  //从第几个图标开始获取
            int cxIcon,      //获取图标的尺寸x
            int cyIcon,      //获取图标的尺寸y
            IntPtr[] phicon, //获取到的图标指针数组
            int[] piconid,   //图标对应的资源编号
            int nIcons,      //指定获取的图标数量，仅当文件类型为.exe 和 .dll时候可用
            int flags);        //标志，默认0就可以，具体可以看LoadImage函数);





        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
