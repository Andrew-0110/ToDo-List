using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Ежедневник.Models;
using Ежедневник.Services;

namespace Ежедневник
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoData.json";
        private BindingList<ToDoModel> toDoData;
        private FileIOService fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fileIOService = new FileIOService(PATH);
            try
            {
                toDoData = fileIOService.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            dtgTodoList.ItemsSource = toDoData;
            toDoData.ListChanged += ToDoData_ListChanged;
        }

        private void ToDoData_ListChanged(object sender, ListChangedEventArgs e)
        {
            switch (e.ListChangedType)
            {
                case ListChangedType.Reset:
                    try
                    {
                        fileIOService.SaveData(sender);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Close();
                    }
                    break;
                case ListChangedType.ItemAdded:
                    try
                    {
                        fileIOService.SaveData(sender);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Close();
                    }
                    break;
                case ListChangedType.ItemChanged:
                    try
                    {
                        fileIOService.SaveData(sender);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Close();
                    }
                    break;
                case ListChangedType.ItemDeleted:
                    try
                    {
                        fileIOService.SaveData(sender);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Close();
                    }
                    break;
                case ListChangedType.ItemMoved:
                    try
                    {
                        fileIOService.SaveData(sender);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Close();
                    }
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                    break;
                case ListChangedType.PropertyDescriptorChanged:
                    break;
                case ListChangedType.PropertyDescriptorDeleted:
                    break;
                default:
                    break;
             }
        }
    }
}
