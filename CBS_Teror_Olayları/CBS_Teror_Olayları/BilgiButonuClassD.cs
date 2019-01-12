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
    public class BilgiButonuClassD
    {
        Form2 _D;
        public BilgiButonuClassD(Form2 _dunya)
        {
            _D = _dunya;
        }

        public void bilgiSaglayaci(string bilgi)
        {
            int k = Convert.ToInt32(Form2.mi.Eval("searchpoint(" + Form2.win_id + ",commandinfo(1),commandinfo(2))"));
            string tabloadi = "";
            for (int i = 1; i <= k; i++)
            {
                tabloadi = Form2.mi.Eval("SearchInfo(" + i.ToString() + ",1)");
                String row_id = Form2.mi.Eval("SearchInfo(" + i.ToString() + ",2)");
                Form2.mi.Do("Fetch rec " + row_id + " From " + tabloadi);
                if ((tabloadi == "Dunya"))
                {
                    _D.Invoke(new mapinfo(_D._bilgiD.fill_form));
                }
            }
        }
        delegate void mapinfo();
    }
}
