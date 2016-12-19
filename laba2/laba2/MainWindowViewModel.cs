using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using laba2.ViewModel.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region menu pages
        private StartPageViewModel startPageViewModel;
        #endregion

        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { currentViewModel = value; }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
            CurrentViewModel = startPageViewModel;
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "startPage":
                    CurrentViewModel = startPageViewModel;
                    break;
                default:
                    break;
            }
        }
    }
}