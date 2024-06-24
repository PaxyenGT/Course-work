using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace курсовая
{
    public partial class MainWindow : Window
    {
        private Total total;
        private int orderNumberCounter = 0; // Счетчик для порядковых номеров

        public MainWindow()
        {
            InitializeComponent();
            total = new Total(0, 0); // Инициализация total
        }

        private void add_product_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double volumeValue = Convert.ToDouble(volume.Text);
                double quantityValue = Convert.ToDouble(quantity.Text);

                orderNumberCounter++;
                Salary newProduct = new Salary(orderNumberCounter, product_name.Text, volumeValue, quantityValue);
                product_list.Items.Add(newProduct);

                // Создание временного экземпляра Total для текущего продукта
                Total tempTotal = new Total(volumeValue, quantityValue);
                tempTotal.AddToTotalSalary();

                // Добавление к общей сумме
                total.TotalSalary += tempTotal.TotalSalary;

                // Обновление Label
                total_salary.Content = total.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для объема и количества.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear_list_Click(object sender, RoutedEventArgs e)
        {
            product_list.Items.Clear();
            total.TotalSalary = 0; // Сброс общей суммы
            total_salary.Content = total.ToString(); // Обновление Label
            orderNumberCounter = 0; // Сброс счетчика порядковых номеров
        }

        private void remove_product_Click(object sender, RoutedEventArgs e)
        {
            if (product_list.SelectedItem != null)
            {
                Salary selectedProduct = (Salary)product_list.SelectedItem;
                product_list.Items.Remove(selectedProduct);

                // Обновление общей суммы после удаления
                Total tempTotal = new Total(selectedProduct.Volume, selectedProduct.Quantity);
                tempTotal.AddToTotalSalary();
                total.TotalSalary -= tempTotal.TotalSalary;

                // Обновление Label
                total_salary.Content = total.ToString();

                // Обновление порядковых номеров в ListBox
                ReorderProducts();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите продукт для удаления.");
            }
        }

        private void ReorderProducts()
        {
            orderNumberCounter = 0;
            foreach (Salary product in product_list.Items)
            {
                orderNumberCounter++;
                product.OrderNumber = orderNumberCounter; // Обновление порядкового номера
            }
            product_list.Items.Refresh(); // Обновление отображения в ListBox
        }
    }
}