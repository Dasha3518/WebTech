using Fedorova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedorova.Domain
{
    public class CartItem
    {
        public Dish Item { get; set; }
        public int Qty { get; set; }
    }
}
