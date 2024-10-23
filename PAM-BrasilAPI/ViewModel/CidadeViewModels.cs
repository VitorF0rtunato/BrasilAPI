using CommunityToolkit.Mvvm.ComponentModel;
using PAM_BrasilAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAM_BrasilAPI.ViewModel
{
    public partial class CidadeViewModels : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Cidade> cidade;
        [ObservableProperty]
        string cidadePesquisada;
    }
}
