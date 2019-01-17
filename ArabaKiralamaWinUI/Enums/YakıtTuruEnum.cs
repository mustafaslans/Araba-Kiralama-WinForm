using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralamaWinUI.Enums
{
    public enum YakıtTuruEnum
    {
        [Description("Benzin")]
        Benzin = 1,
        [Description("Dizel")]
        Dizel = 2,
        [Description("Elektrik")]
        Elektrik = 3
    }
}
