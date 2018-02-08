using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun.Core.Dto
{
    public class CommonAjaxArgs : BaseAjaxArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public CommonAjaxArgs()
        {

        }
        /// <summary>
        /// 
        /// </summary>

        public List<BaseSearchItem> Filter { get; set; }

        public string[] Include { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; }


        public string SortField { get; set; }

        public string SortOrder { get; set; }

        /// <summary>
        /// 导出参数
        /// </summary>
        public ExportArg Export { get; set; }
    }
    
    public class Sorter
    {
        /// <summary>
        /// 
        /// </summary>
        public Sorter()
        {
            //this.SortOrder = System.Data.SqlClient.SortOrder.Ascending;
        }

        /// <summary>
        /// 排序字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public bool Asc  { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class ExportArg
    {
        public List<int> Ids { get; set; }

        public List<string> Columns { get; set; }
    }
}

