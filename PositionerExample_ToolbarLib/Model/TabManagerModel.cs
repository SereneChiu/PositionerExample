using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PositionerExample_ToolbarLib.View;

namespace PositionerExample_ToolbarLib.Model
{
    public class TabManagerModel
    {
        public ObservableCollection<TabItemModel> Tabs { get; set; }

        public TabManagerModel()
        {
            Tabs = new ObservableCollection<TabItemModel>
            {
                new TabItemModel { Header = "Move", Content = new MovePage() },
                new TabItemModel { Header = "Calibration", Content = new CalibrationPage() },
            };
        }

        public void AddTab()
        {
            int tabCount = Tabs.Count + 1;
            Tabs.Add(new TabItemModel
            {
                Header = $"Tab {tabCount}",
            });
        }

        public void RemoveTab(TabItemModel selectedTab)
        {
            if (selectedTab != null)
            {
                Tabs.Remove(selectedTab);
            }
        }
    }
}
