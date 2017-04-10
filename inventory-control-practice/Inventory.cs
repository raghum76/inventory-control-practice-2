using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_control_practice
{
    class Inventory
    {
        private Product _initProduct;
        private int _inventoryCounter;

        public Inventory()
        {
            _inventoryCounter = 0;
        }

        public override string ToString()
        {
            return "Número de productos en inventario: " + _inventoryCounter;
        }

        public void add(Product product)
        {
            if (_initProduct == null)
            {
                _initProduct = product;
            }
            else
            {
                Product temp = _initProduct;

                for (; temp.next != null; temp = temp.next) ;

                temp.next = product;
            }

            _inventoryCounter++;
        }

        public void addAtBegin(Product product)
        {
            if (_initProduct == null)
            {
                _initProduct = product;
            }
            else
            {
                insert(product, 0);
            }
        }

        private Product _specialSearch(string name)
        {
            if (_initProduct != null)
            {
                for (Product temp = _initProduct; temp.next != null; temp = temp.next)
                {
                    if (temp.next.name == name)
                        return temp;
                }
            }

            return null;
        }

        public Product search(string name)
        {
            if (_initProduct != null)
            {
                if (_initProduct.name == name)
                    return _initProduct;

                Product temp = _specialSearch(name);

                if (temp != null)
                    return temp.next;
            }

            return null;
        }

        public void delete(string name)
        {
            if (_initProduct != null)
            {
                if (_initProduct.name == name)
                {
                    _initProduct = _initProduct.next;
                    _inventoryCounter--;
                }
                else
                {
                    Product temp = _specialSearch(name);

                    if (temp != null)
                    {
                        temp.next = temp.next.next;
                        _inventoryCounter--;
                    }
                }
            }
        }

        public void insert(Product product, int position)
        {
            if (_initProduct != null && position >= 0 && position < _inventoryCounter)
            {
                if (position == 0)
                {
                    product.next = _initProduct;
                    _initProduct = product;
                }
                else
                {
                    Product temp = _initProduct;

                    for (int i = 1; i != position; temp = temp.next, i++) ;

                    product.next = temp.next;
                    temp.next = product;
                }

                _inventoryCounter++;
            }
        }

        public string report()
        {
            string str = ToString() + Environment.NewLine;

            Product temp = _initProduct;

            while (temp != null)
            {
                str += temp.ToString();
                str += "--------------------------------------------------------" + Environment.NewLine;
                temp = temp.next;
            }

            return str;
        }
    }
}
