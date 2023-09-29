using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Models
{
    public class AlgoProduct
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //token for description
        public float[] CombinedTFIDFVector { get; set; }
    }
}
