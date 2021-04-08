using Kabuwler.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kabuwler.DAO
{
    public class HomeDAO
    {
        public KabuwlerContext _context { get; set; }

        public HomeDAO(KabuwlerContext context)
        {
            _context = context;
        }
    }
}
