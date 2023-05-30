﻿using System;
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

namespace ShiraRDKWork
{
    /// <summary>
    /// Логика взаимодействия для VersteckPage.xaml
    /// </summary>
    public partial class VersteckPage : Page
    {
        int role;
        public VersteckPage(int role)
        {
            this.role = role;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridAdd.ItemsSource = DBEntities.GetContext().WareHouses.ToList();
            dataGridRemove.ItemsSource = DBEntities.GetContext().WareHouses.ToList();
        }



        private void deletBtn_Click(object sender, RoutedEventArgs e)
        {

            WareHouse ClientForRemoving;
            if (dataGridAdd.SelectedItem != null)
                ClientForRemoving = dataGridAdd.SelectedItem as WareHouse;
            else if (dataGridRemove.SelectedItem != null)
                ClientForRemoving = dataGridRemove.SelectedItem as WareHouse;
            else
                return;

           

            if (MessageBox.Show($"Не рекомендуем удолять старые записи, это может повлечь ошибку с данными. \nВы уверены?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Item items = ClientForRemoving.Item;
                        items.Count -= ClientForRemoving.Quantity;

                    DBEntities.GetContext().WareHouses.Remove(ClientForRemoving);
                    DBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены! ");
                    dataGridAdd.ItemsSource = DBEntities.GetContext().WareHouses.ToList();
                    dataGridRemove.ItemsSource = DBEntities.GetContext().WareHouses.ToList();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditVersteckPage(null));
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            WareHouse selectedOrder;
            if (dataGridAdd.SelectedItem != null)
                selectedOrder = dataGridAdd.SelectedItem as WareHouse;
            else if (dataGridRemove.SelectedItem != null)
                selectedOrder = dataGridRemove.SelectedItem as WareHouse;
            else
                return;

            NavigationService.Navigate(new AddEditVersteckPage(selectedOrder));
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (startDatePicer.SelectedDate == null &&
                endDatePicer.SelectedDate == null)
                return;

            List<WareHouse> wareHouses = DBEntities.GetContext().WareHouses.ToList();
         
            if (startDatePicer.SelectedDate != null)
                wareHouses = (List<WareHouse>)wareHouses.Where(eve => eve.DateOfReceipt >= startDatePicer.SelectedDate).ToList();
            if (endDatePicer.SelectedDate != null)
                wareHouses = (List<WareHouse>)wareHouses.Where(eve => eve.DateOfReceipt <= endDatePicer.SelectedDate).ToList();

            dataGridAdd.ItemsSource = DBEntities.GetContext().WareHouses.ToList();
            dataGridRemove.ItemsSource = DBEntities.GetContext().WareHouses.ToList();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {

            startDatePicer.SelectedDate = null;
            endDatePicer.SelectedDate = null;


            dataGridAdd.ItemsSource = DBEntities.GetContext().WareHouses.ToList();
            dataGridRemove.ItemsSource = DBEntities.GetContext().WareHouses.ToList();
        }
    }
}
