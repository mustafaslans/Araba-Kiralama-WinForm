using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaKiralamaWinUI.Enums
{
    public enum VitesEnum
    {
        [Description("Manuel")]
        Manuel = 1,
        [Description("Otomatik")]
        Otomatik = 2,
        [Description("Yarı-Otomatik")]
        YarıOtomatik = 3
    }
}
