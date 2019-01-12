using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CBS_Teror_Olayları
{
    [ComVisible(true)]
    public class BilgiButonuClass
    {
        turkiye _tr;
        public BilgiButonuClass(turkiye _turkiye)
        {
            _tr = _turkiye;
        }

        public void bilgiSaglayaci(string bilgi)
        {
            int k = Convert.ToInt32(turkiye.mi.Eval("searchpoint("+turkiye.win_id+",commandinfo(1),commandinfo(2))"));
            string tabloadi = "";
            for (int i = 1; i <= k; i++)
            {
                tabloadi = turkiye.mi.Eval("SearchInfo(" + i.ToString() + ",1)");
                String row_id = turkiye.mi.Eval("SearchInfo(" + i.ToString() + ",2)");
                turkiye.mi.Do("Fetch rec " + row_id + " From " + tabloadi);
                if ((tabloadi == "Iller"))
                {
                    _tr.Invoke(new mapinfo(_tr._bilgiTR.fill_form));
                }
            }
        }
        delegate void mapinfo();
    }
}
