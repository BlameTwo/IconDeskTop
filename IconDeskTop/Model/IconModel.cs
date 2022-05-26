using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IconDeskTop.Model
{
    public class IconModel
    {
        public string Name { get; set; }

        public BitmapImage Icon { get; set; }

        public string FilePath { get; set; }

    }
}
