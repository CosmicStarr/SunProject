using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunProject.Mapper
{
    public class PagiNation<T> where T : class
    {

        public PagiNation(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
