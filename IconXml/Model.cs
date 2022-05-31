using System;

namespace IconXml
{

    public class HomeIconArgs
    {
        /// <summary>
        /// 图标的名称
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 启动目标
        /// </summary>
        public string Prcess { get; set; }

        /// <summary>
        /// 启动参数
        /// </summary>
        public string ProcessArg { get; set; }
    }


    public class IconArgs
    {
        /// <summary>
        /// 快捷按钮磁盘位置
        /// </summary>
        public string Lnk { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标位置
        /// </summary>
        public string IconPath { get; set; }    

        /// <summary>
        /// 可执行文件路径
        /// </summary>
        public string AppProcess { get; set; }

        /// <summary>
        /// 启动参数
        /// </summary>
        public string AppArgs { get; set; }
    }

    public enum IconXml
    {
        Home, Icon
    }

    
}
