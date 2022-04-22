using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnToolsJp1Ajs_FromJpMon
{
    class Servers
    {
        //プロパティ
        public List<string> SeverList { get; set; } = new List<string>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Servers()
        {
            // this.SeverList.Add("one");
        }

        public void AddNewServer(string name)
        {
            this.SeverList.Add(name);
        }

    }
}
