using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для ItemForEventPage.xaml
    /// </summary>
    public partial class ItemForEventPage : Page
    {
        Event events;
        public ItemForEventPage(Event events)
        {
            InitializeComponent();
            this.events = events;
        }




        private void addItemForEvent_Click(object sender, RoutedEventArgs g)
        {
            // Проверяем, что в таблице выбрана строка
            if (dataGridBase.SelectedItem == null || countItems.Text.Length == 0)
                return;

            // Получаем выбранный элемент (объект класса Items)
            Item item = dataGridBase.SelectedItem as Item;

            // Получаем значение количества из текстового поля и преобразуем в int
            int countTBox = Convert.ToInt32(countItems.Text);

            // Получаем список всех ItemsForEvents, связанных с данной датой начала мероприятия
            List<ItemsForEvent> itemsForEvent = DBEntities.GetContext().ItemsForEvents
                .Where(e => e.Event.DateStart == events.DateStart).ToList();

            // Вычисляем общее количество доступного инвентаря данного типа
            int count = 0;
            foreach (ItemsForEvent itemForEvent in itemsForEvent.Where(i => i.Item == item))
            {
                count += (int)itemForEvent.Quantity;
            }
            count = (int)item.Count - count;

            // Проверяем, достаточно ли инвентаря для добавления в мероприятие
            if (count >= countTBox)
            {
                try
                {
                    // Создаем новый объект ItemsForEvents и заполняем его поля
                    ItemsForEvent ife = new ItemsForEvent();
                    ife.Item = item;
                    ife.Quantity = countTBox;
                    ife.Event = events;

                    // Добавляем объект в базу данных
                    DBEntities.GetContext().ItemsForEvents.Add(ife);
                    // Сохраняем изменения в базе данных
                    DBEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Недостаточно инвентаря!");
            }
            UpdateGrid();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
            //eventIdTBox.Text = events.ID.ToString();
            //eventNameTBox.Text = events.Name.ToString();
        }

        private void UpdateGrid()
        {
            // Получаем список Items, у которых Count больше нуля
            List<Item> items = DBEntities.GetContext().Items
                .ToList();

            // Получаем список ItemsForEvents из базы данных
            List<ItemsForEvent> itemsForEvent = DBEntities.GetContext().ItemsForEvents.ToList();

            // Отображаем только те ItemsForEvents, которые связаны с событием events.ID
            dataGridEvent.ItemsSource = itemsForEvent.Where(e => e.EventsID == events.ID).ToList();

            // Фильтруем список itemsForEvent по событиям, начало которых совпадает с началом события events
            itemsForEvent = itemsForEvent.Where(e => e.Event.DateStart.ToShortDateString() == events.DateStart.ToShortDateString()).ToList();

            // Создаем новый список Items, который будет использоваться для отображения в пользовательском интерфейсе
            List<Item> viewItems = new List<Item>();

            // Для каждого элемента из списка items выполняем следующее:
            foreach (Item item in items)
            {
                // Получаем суммарное количество элементов, которые используются в событиях из списка itemsForEvent
                
                int count = Convert.ToInt32(item.Count);
                foreach (ItemsForEvent itemForEvent in itemsForEvent.Where(i => i.Item == item))
                {
                    count -= (int)itemForEvent.Quantity;
                }

                // Если количество доступных элементов больше нуля, добавляем элемент в список viewItems
                if (count > 0)
                    viewItems.Add(item);
            }
            dataGridEvent.ItemsSource = viewItems;
            dataGrid_SelectionChanged(null, null);   
        }

        private void delItemForEvent_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridEvent.SelectedItem == null)
                return;

            var ItemForEvents = dataGridEvent.SelectedItems.Cast<ItemsForEvent>().ToList();

            if (MessageBox.Show($"Вы уверены? Удалится {ItemForEvents.Count()} элемент(ов)?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DBEntities.GetContext().ItemsForEvents.RemoveRange(ItemForEvents);
                    DBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены! ");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
            UpdateGrid();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs g)
        {
            //dataGridBase.SelectedItem = null;
            //if (dataGrid.SelectedItem == null)
            //    return;

            //Item _item = ((Item)dataGrid.SelectedItem);
            //List< ItemsForEvent> itemsForEvent =  DBEntities.GetContext().ItemsForEvents.ToList().
            //    Where(e => e.Event.DateStart.ToShortDateString() == events.DateStart.ToShortDateString()).ToList();
            //int count = Convert.ToInt32(_item.Count);
            //foreach (ItemsForEvent itemForEvent in itemsForEvent.Where(i => i.Item == _item))
            //{
            //    count -= (int)itemForEvent.Quantity;
            //}



            //delItemForEvent.Visibility = Visibility.Collapsed;
            //addItemForEvent.Visibility = Visibility.Visible;
            //countItems.Visibility = Visibility.Visible;

        }
      

        private void dataGridEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dataGrid.SelectedItem = null;
            //if (dataGridEvents.SelectedItem == null)
            //    return;
            //Item _item = ((ItemsForEvent)dataGridEvents.SelectedItem).Item;

            //itemIdTBox.Text = _item.ID.ToString();
            //itemNameTBox.Text = _item.Name.ToString();
            //descriptionTBox.Text = _item.Description.ToString();
            //if (_item.Image != null)
            //{
            //    //конвертация из базы
            //    MemoryStream ms = new MemoryStream(_item.Image, 0, _item.Image.Length);
            //    ms.Write(_item.Image, 0, _item.Image.Length);
            //    imageItemImg.Source = ConvertToBitmap(_item.Image);
            //}

            //delItemForEvent.Visibility = Visibility.Visible;
            //addItemForEvent.Visibility = Visibility.Collapsed;
            //countItems.Visibility = Visibility.Collapsed;
            //countTBlock.Visibility = Visibility.Collapsed;
        }

        private void dataGridBase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
