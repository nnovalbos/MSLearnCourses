using GreatQuotes.Infrastructure;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GreatQuotes.Data;
using System.Linq;

namespace GreatQuotes.ViewModels
{
    public class MainViewModel : SimpleViewModel
    {
        QuoteViewModel _selectedQuote;

        public IList<QuoteViewModel> Quotes { get; private set; }

        
        public MainViewModel()
        {
            Quotes = new ObservableCollection<QuoteViewModel>(
                QuoteManager.Load()
                            .Select(q => new QuoteViewModel(q)));
        }

        
        public QuoteViewModel SelectedQuote
        {
            get
            {
                return _selectedQuote;
            }
            set
            {
                SetPropertyValue(ref _selectedQuote, value);
            }
        }
    }
}

