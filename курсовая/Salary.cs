using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace курсовая
{
    internal class Salary
    {
        public int OrderNumber { get; set; }
        public string ProductName { get; set; }
        public double Volume { get; set; }
        public double Quantity { get; set; }
        public double Salary_new { get; set; }

        public Salary(int orderNumber, string productName, double volume, double quantity)
        {
            OrderNumber = orderNumber;
            ProductName = productName;
            Volume = volume;
            Quantity = quantity;
        }

        public double UpSalary()
        {
            if (this.Volume > 11)
            {
                return this.Salary_new = this.Quantity * 25;
            }
            else
            {
                return this.Salary_new = this.Quantity * 20;
            }
        }

        public override string ToString()
        {
            return $"{OrderNumber}) {ProductName} {Volume}л, Кол-во - {Quantity}шт, Ценна - {UpSalary()}руб.";
        }
    }
}