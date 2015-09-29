using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Validate
{
    class NoWhiteSpace
    {
        public Int32 Check(String str)
        {
            int i;
            try
            {
                for(i = 0 ; i < str.Length ; i++)
                {
                    if((Char.IsWhiteSpace(str[i])))
                    {
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                return 1;
            }

        }
    }
}
