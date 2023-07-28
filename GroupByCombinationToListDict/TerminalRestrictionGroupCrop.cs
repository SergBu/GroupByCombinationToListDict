using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByCombinationToListDict
{
    public class TerminalRestrictionGroupCrop 
    {
        public TerminalRestrictionGroupCrop()
        {
        }

        [Comment("Идентификатор ограничения терминала")]
        public int TerminalRestrictionId { get; set; }

        [Comment("Идентификатор культуры")]
        public int CropId { get; set; }
    }
}