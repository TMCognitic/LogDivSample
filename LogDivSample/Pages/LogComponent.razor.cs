using LogDivSample.Infrastructure;
using LogDivSample.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace LogDivSample.Pages
{
    public partial class LogComponent : IDisposable
    {
        [Inject]
        private LogMessenger LogMessenger { get; set; } = null!;

        private ObservableCollection<Message> Items { get; set; } = new();

        protected override void OnInitialized()
        {
            Items.CollectionChanged += OnCollectionChanged;
            LogMessenger.NewMessageSended += OnNewMessageSended;
        }

        public async void OnNewMessageSended(Message message)
        {
            Items.Add(message);

            await Task.Delay(message.Duree * 1000);
            Items.Remove(message);
        }

        private void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            StateHasChanged();
        }

        public void Dispose()
        {
            Items.CollectionChanged -= OnCollectionChanged;
            LogMessenger.NewMessageSended -= OnNewMessageSended;
            GC.SuppressFinalize(this);
        }
    }
}