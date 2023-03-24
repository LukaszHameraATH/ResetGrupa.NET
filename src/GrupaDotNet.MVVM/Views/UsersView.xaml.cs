using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GrupaDotNet.MVVM.Services;
using GrupaDotNet.MVVM.ViewModel;

namespace GrupaDotNet.MVVM.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        public UsersView()
        {
            InitializeComponent();
            DataContext = new UsersViewModel(new ImMemoryUserRepository());
        }
    }
}
