using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParserFortTelecom.Entity;

namespace ParserFortTelecom.Parsers.Interfaces
{
    interface ISwitchParser
    {
        Task<List<SwitchData>> ParseAsync();
    }
}