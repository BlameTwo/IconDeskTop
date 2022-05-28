using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IconDeskTop.Model
{
    public class AppSetupPathArgs
    {
        /// <summary>
        /// 可执行文件，包括图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 运行路径，如果有，启动时候包含上此路径
        /// </summary>
        public string DirectoryPath { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 发布公司
        /// </summary>
        public string Publisher { get; set; }

        public string lnk { get; set; }
    }
}
