﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GreatQuotes.Contracts;
using GreatQuotes.Loaders;
using GreatQuotes.ViewModels;

namespace GreatQuotes.Managers
{
    public class QuoteManager
    {
        IQuoteLoader loader;

        public IList<GreatQuoteViewModel> Quotes { get; set; }

        static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());

        public static QuoteManager Instance { get => instance.Value; }

        private QuoteManager()
        {
            loader = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuoteViewModel>(loader.Load());
        }

        public void Save()
        {
            loader.Save(Quotes);
        }

        public void SayQuote(GreatQuoteViewModel quote)
        {
            if (quote == null)
                throw new ArgumentNullException("No quote set");

            ITextToSpeech tts = ServiceLocator.Instance.Resolve<ITextToSpeech>();

            if (tts != null)
            {
                var text = quote.QuoteText;

                if (!string.IsNullOrWhiteSpace(quote.Author))
                    text += $" by {quote.Author}";

                tts.Speak(text);
            }
        }
    }
}
