using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows;

namespace SignalRChatClient
{
    public partial class MainWindow : Window
    {
        static HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:44317/chathub")
            .Build();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.On<string>("ReceiveMessage", data =>
            {
                Console.WriteLine($"Received: {data}");
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                await connection.InvokeAsync("SendMessage", "Hello there");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
