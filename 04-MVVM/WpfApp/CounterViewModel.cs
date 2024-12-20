using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public partial class CounterViewModel : ObservableObject
    {
        // Observable property with private setter
        [ObservableProperty]
        private int count;

        // Command to increment the counter
        [RelayCommand]
        public void Increment()
        {
            Count++;
        }
    }
}
