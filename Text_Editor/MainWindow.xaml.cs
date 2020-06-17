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
using System.IO;
using System.Drawing;
using Microsoft.Win32;
using FontFamily = System.Drawing.FontFamily;
using System.Drawing.Text;

namespace Text_Editor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   

        OpenFileDialog openFileDialog = new OpenFileDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public MainWindow()
        {
            InitializeComponent(); 

            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            List<float> size = new List<float>(); 

            for(float i = 0f; i < 100f; ++i)
            {
                size.Add(i);
                comboBox1.ItemsSource = size;
            }

            List<SolidColorBrush> colorBrushes = new List<SolidColorBrush>();

            SolidColorBrush greenBrush = new SolidColorBrush(Colors.Green);
            SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
            SolidColorBrush blueBrush = new SolidColorBrush(Colors.Blue);

            colorBrushes.Add(greenBrush);
            colorBrushes.Add(redBrush);
            colorBrushes.Add(blueBrush);

            comboBox2.ItemsSource = colorBrushes;

        }

        public void ChangeSize(TextBox tb1, ComboBox cb1)
        {

            float selectedItem = (float)cb1.SelectedItem;
            main_textBox.FontSize = selectedItem;

        }

        public void ChangeColor(TextBox tb1, ComboBox cb1)
        {
            tb1.Foreground = (System.Windows.Media.Brush)cb1.SelectedItem;
        }

    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeSize(main_textBox, comboBox1);
            ChangeColor(main_textBox, comboBox2);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult)
                return;
            string filename = saveFileDialog.FileName;
            System.IO.File.WriteAllText(filename, main_textBox.Text);
            MessageBox.Show("Файл сохранен");
        }
    }
}
