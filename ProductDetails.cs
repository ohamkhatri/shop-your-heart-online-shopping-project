using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopping.User
{
    public class ProductDetails
    {
        public string Prod_Name { get; set; }
        public string Prod_Descp { get; set; }
        public int Price { get; set; }
        public int Availabe { get; set; }
        public int Catid { get; set; }
        public int MaxQty { get; set; }
        public int MinQty { get; set; }
        public string imgpath { get; set; }
    }
}