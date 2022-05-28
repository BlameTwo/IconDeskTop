using IconDeskTop.Models.IconDeskTop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            if (extion != ".exe")
            {
                BitmapImage image = new BitmapImage();
                Icon icon = GetSystemIcon.GetIconByFileType(Path.GetFileNameWithoutExtension("." + value.ToString()), true);
                MemoryStream m2 = new MemoryStream();
                icon.ToBitmap().Save(m2, System.Drawing.Imaging.ImageFormat.Png);
                image.StreamSource = m2;
                return image;
            }
            var bitmap = new BitmapImage();
            var iconTotalCount = PrivateExtractIcons(value.ToString(), 0, 0, 0, null, null, 0, 0);
            IntPtr[] hIcons = new IntPtr[iconTotalCount];
            int[] ids = new int[iconTotalCount];
            var successCount = PrivateExtractIcons(value.ToString(), 0, 256, 256, hIcons, ids, iconTotalCount, 0);
            MemoryStream ms = new MemoryStream();
            //遍历并保存图标
            for (var i = 0; i < successCount; i++)
            {
                //指针为空，跳过
                if (hIcons[i] == IntPtr.Zero) continue;
                using (var ico = Icon.FromHandle(hIcons[0]))
                {
                    using (var myIcon = ico.ToBitmap())
                    {
                        if (myIcon.Height == 0 || myIcon.Width == 0)
                            continue;
                        myIcon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.EndInit();
                        bitmap.Freeze();
                        return bitmap;
                    }
                }
            }
            return null;
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
