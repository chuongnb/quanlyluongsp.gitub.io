using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace frmMain
{
    public static class clsCheck
    {
        public static Boolean NameCheck(this String s)
        {
            return Regex.Match(s, @"^([A-Z][a-zA-Z]+(\s[A-Z][a-zA-Z]+)*)$").Success;
        }
        public static Boolean FulNameCheckCuaTui(this String s)
        {
            return Regex.Match(s, @"^([A-Z][a-zA-Z]+(\s[A-Z][a-zA-Z]+)+)$").Success;
        }
        public static Boolean DOBCheck(this String s)// kiem tra ngay thang
        {// hoac|
            // [1-2] khoang 
            return Regex.Match(s, @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$").Success;
        }
        public static Boolean IDNVCheck(this String s)
        {
            return Regex.Match(s, @"^([Nn][Vv][0-9][0-9][0-9])$").Success;
        }
        public static Boolean IDCNCheck(this String s)
        {
            return Regex.Match(s, @"^([Cc][nN][0-9][0-9][0-9])$").Success;
        }
    }
}
