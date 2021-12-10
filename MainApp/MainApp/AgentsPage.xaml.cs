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

namespace MainApp
{
    /// <summary>
    /// Логика взаимодействия для AgentsPage.xaml
    /// </summary>
    public partial class AgentsPage : Page
    {
        IEnumerable<Agents> agentsSearch;
        IEnumerable<Agents> agents;
        int someTakeAgents = 0;
        int TakeAgents = 10;
        int maxAgents;
        int pages;
        public AgentsPage()
        {
            InitializeComponent();
            maxAgents = user4Entities.GetContext().Agents.ToList().Count();
            someTakeAgents = maxAgents / 10;
            pages = maxAgents / 10;
            agents = user4Entities.GetContext().Agents.Take(TakeAgents).ToList();
            mainListView.ItemsSource = agents;
            agentsSearch = user4Entities.GetContext().Agents.ToList();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(someTakeAgents < 10)
            {
                someTakeAgents = 10;
            }
            
            someTakeAgents -= 10;
            
            if (someTakeAgents > 10)
            {
                if (1 < Convert.ToInt32(countText.Text))
                {
                    countText.Text = Convert.ToString(Convert.ToInt32(countText.Text) - 1);
                }
                mainListView.ItemsSource = user4Entities.GetContext().Agents.OrderBy(x => x.Id).Skip(someTakeAgents).Take(TakeAgents).ToList();
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            someTakeAgents += 10;
            
            if (someTakeAgents < maxAgents - 10)
            {
                if (pages > Convert.ToInt32(countText.Text))
                {
                    countText.Text = Convert.ToString(Convert.ToInt32(countText.Text) + 1);
                }
                mainListView.ItemsSource = user4Entities.GetContext().Agents.OrderBy(x => x.Id).Skip(someTakeAgents).Take(TakeAgents).ToList();
            } else
            {
                someTakeAgents = maxAgents;
            }
        }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SearchTxt.Text == "")
            {
                mainListView.ItemsSource = user4Entities.GetContext().Agents.ToList();
            } else
            {
                agentsSearch = agents.ToList().Where(x => x.NameAgent.Contains(SearchTxt.Text));
                mainListView.ItemsSource = agentsSearch;
            }
        }
    }
}
