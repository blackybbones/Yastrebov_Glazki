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
using System.Windows.Shapes;

namespace Yastrebov_Glazki
{
    /// <summary>
    /// Логика взаимодействия для ChangePriorityWindow.xaml
    /// </summary>
    public partial class ChangePriorityWindow : Window
    {
        public ChangePriorityWindow(int maxPriority)
        {
            InitializeComponent();
            NewPriorityTextBox.Text = maxPriority.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public int NewPriority
        {
            get
            {
                if (string.IsNullOrWhiteSpace(NewPriorityTextBox.Text))
                    return 0;
                return Convert.ToInt32(NewPriorityTextBox.Text);

            }
        }
    }
}
