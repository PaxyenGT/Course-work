using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace курсовая
{
    internal class Total
    {
        private double volume;
        private double quantity;
        private double salary_new;
        private double total_salary;

        public Total(double volume, double quantity)
        {
            this.volume = volume;
            this.quantity = quantity;
        }

        public double Quantity
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Значение должно быть положительным!");
                }
                else
                {
                    this.quantity = value;
                }
            }
            get => this.quantity;
        }

        public double Volume
        {
            set => this.volume = value;
            get => this.volume;
        }

        public double TotalSalary
        {
            get => this.total_salary;
            set => this.total_salary = value;
        }

        public double UpSalary()
        {
            if (this.volume > 11)
            {
                return this.salary_new = this.quantity * 25;
            }
            else
            {
                return this.salary_new = this.quantity * 20;
            }
        }

        public void AddToTotalSalary()
        {
            this.total_salary += UpSalary();
        }

        public override string ToString()
        {
            return TotalSalary.ToString("F2") + " руб.";
        }
    }
}