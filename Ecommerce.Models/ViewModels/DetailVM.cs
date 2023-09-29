using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.ViewModels
{
    public class DetailVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public List<Product> RecommendedProducts { get; set; }
    }
}
