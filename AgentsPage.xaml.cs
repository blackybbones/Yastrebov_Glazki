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

namespace Yastrebov_Glazki
{
    /// <summary>
    /// Логика взаимодействия для AgentsPage.xaml
    /// </summary>
    public partial class AgentsPage : Page
    {
        public AgentsPage()
        {
            InitializeComponent();
            var currentAgents = Yastrebov_GlazkiSaveEntities.GetContext().Agent.ToList();
            AgentsListView.ItemsSource = currentAgents;

            ComboType.SelectedIndex = 0;
            ComboAgentType.SelectedIndex = 0;
            UpdateAgents();
        }

        private void UpdateAgents()
        {
            var currentAgents = Yastrebov_GlazkiSaveEntities.GetContext().Agent.ToList();

            currentAgents = currentAgents.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            AgentsListView.ItemsSource = currentAgents.ToList();

            if (ComboAgentType.SelectedIndex == 1)
            {
                currentAgents = currentAgents.Where(p => p.AgentType.Title == "МФО").ToList();
            }

            if (ComboAgentType.SelectedIndex == 2)
            {
                currentAgents = currentAgents.Where(p => p.AgentType.Title == "ООО").ToList();
            }

            if (ComboAgentType.SelectedIndex == 3)
            {
                currentAgents = currentAgents.Where(p => p.AgentType.Title == "ЗАО").ToList();
            }

            if (ComboAgentType.SelectedIndex == 4)
            {
                currentAgents = currentAgents.Where(p => p.AgentType.Title == "МКК").ToList();
            }

            if (ComboAgentType.SelectedIndex == 5)
            {
                currentAgents = currentAgents.Where(p => p.AgentType.Title == "ОАО").ToList();
            }

            if (ComboAgentType.SelectedIndex == 6)
            {
                currentAgents = currentAgents.Where(p => p.AgentType.Title == "ПАО").ToList();
            }

            if (ComboType.SelectedIndex == 1)
            {
                AgentsListView.ItemsSource = currentAgents.OrderBy(p => p.Title).ToList();
            }

            if (ComboType.SelectedIndex == 2)
            {
                AgentsListView.ItemsSource = currentAgents.OrderByDescending(p => p.Title).ToList();
            }

            if (ComboType.SelectedIndex == 3)
            {
                AgentsListView.ItemsSource = currentAgents.OrderBy(p => p.Email).ToList();
            }

            if (ComboType.SelectedIndex == 4)
            {
                AgentsListView.ItemsSource = currentAgents.OrderByDescending(p => p.Email).ToList();
            }

            if (ComboType.SelectedIndex == 5)
            {
                AgentsListView.ItemsSource = currentAgents.OrderBy(p => p.Phone).ToList();
            }

            if (ComboType.SelectedIndex == 6)
            {
                AgentsListView.ItemsSource = currentAgents.OrderByDescending(p => p.Phone).ToList();
            }

            if (ComboType.SelectedIndex == 7)
            {
                AgentsListView.ItemsSource = currentAgents.OrderBy(p => p.Priority).ToList();
            }

            if (ComboType.SelectedIndex == 8)
            {
                AgentsListView.ItemsSource = currentAgents.OrderByDescending(p => p.Priority).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Mainframe.Navigate(new AddEditPage());
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void ComboAgentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }
    }
}
