using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDataGridViewDataTable.Model
{
    public class DataModel
    {
        public int DataPointId { get; set; }
        public string Description { get; set; }
        public bool InAlarm { get; set; }
        public DateTime LastUpdate { get; set; }
        public double ScalingMultiplier { get; set; }
        public decimal Price { get; set; }
    }
}
