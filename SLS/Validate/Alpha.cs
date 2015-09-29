using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLS.Validate
{
    class Alpha
    {
        public int checkString(String str)
        {
            int i;
            try
            {
                if (!(Char.IsLetter(str[0])))
                {
                    return 1;
                }
                else
                {
                    for (i = 1; i < str.Length; i++)
                    {
                        if (!(Char.IsLetter(str[i])))
                        {
                            if (!(Char.IsLetter(str[i + 1])))
                            {
                                return 1;
                            }
                        }
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
