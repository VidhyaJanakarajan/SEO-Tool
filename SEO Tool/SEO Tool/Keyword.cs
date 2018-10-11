using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO_Tool
{
    class keyword
    {
        private string link;

        private int postion;

        public keyword()
        {

        }
        public keyword(string link, int postion)
        {
            this.Link = link;
            this.Postion = postion;
        }

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }

        public int Postion
        {
            get
            {
                return postion;
            }

            set
            {
                postion = value;
            }
        }
    }
}
