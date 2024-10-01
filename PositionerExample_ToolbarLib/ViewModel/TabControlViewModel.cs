using PositionerExample_ToolbarLib.Model;
using PositionerExample_ToolbarLib.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PositionerExample_ToolbarLib.ViewModel
{
    public class TabControlViewModel : ViewModelBase
    {
        private readonly TabManagerModel _tabManager;

        public ObservableCollection<TabItemModel> Tabs => _tabManager.Tabs;


        private TabItemModel _selectedTab;
        public TabItemModel SelectedTab
        {
            get => _selectedTab;
            set => Set(ref _selectedTab, value, nameof(SelectedTab));
        }

        public RelayCommand AddTabCommand { get; }
        public RelayCommand RemoveTabCommand { get; }

        public TabControlViewModel()
        {
            _tabManager = new TabManagerModel();

            AddTabCommand = new RelayCommand(AddTab);
            RemoveTabCommand = new RelayCommand(RemoveTab, CanRemoveTab);
        }

        private void AddTab(object param)
        {
            _tabManager.AddTab();
        }

        private bool CanRemoveTab(object param)
        {
            return SelectedTab != null;
        }

        private void RemoveTab(object param)
        {
            _tabManager.RemoveTab(SelectedTab);
        }
    }
}
