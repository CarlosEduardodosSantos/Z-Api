using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Zip.Models
{
    public class RootResult
    {
        public int TotalPage { get; set; }
        public IEnumerable<object> Results { get; set; }
        public IEnumerable<object> Extras { get; set; }
    }
}
