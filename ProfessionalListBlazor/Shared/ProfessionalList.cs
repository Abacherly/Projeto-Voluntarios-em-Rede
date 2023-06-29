using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalListBlazor.Shared
{
    public class ProfessionalList
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Style? Style { get; set; }
        public int StyleId { get; set; }
    }
}
