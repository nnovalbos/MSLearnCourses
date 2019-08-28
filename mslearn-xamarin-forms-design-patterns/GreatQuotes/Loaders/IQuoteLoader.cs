using System;
using System.Collections.Generic;
using GreatQuotes.ViewModels;

namespace GreatQuotes.Loaders
{
    public interface IQuoteLoader
    {
        IEnumerable<GreatQuoteViewModel> Load();
        void Save(IEnumerable<GreatQuoteViewModel> quotes);
    }
}
