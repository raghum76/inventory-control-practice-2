using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_control_practice
{
    class Product
    {
        private int _code;
        private string _name;
        private int _quantity;
        private double _price;

        public Product next {get;set;} //no se usan varaibles publicas, se usan propiedades

        public int code
        {
            get
            {
                return _code;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
        }

        public int quantity
        {
            get
            {
                return _quantity;
            }
        }

        public double price
        {
            get
            {
                return _price;
            }
        }

        public Product(int code, string name, int quantity, double price)
        {
            _code = code;
            _name = name;
            _quantity = quantity;
            _price = price;
            next = null;
        }

        public override string ToString()
        {
            string str = "";

            str += "Código: " + _code + Environment.NewLine;
            str += "Nombre: " + _name + Environment.NewLine;
            str += "Cantidad: " + _quantity + Environment.NewLine;
            str += "Precio: " + _price + Environment.NewLine;

            return str;
        }
    }
}
