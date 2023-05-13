using ChronoMedic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;
using Telegram.Bot.Types;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace ChronoMedic.View
{
    /// <summary>
    /// Логика взаимодействия для CallObjectView.xaml
    /// </summary>
    public partial class CallObjectView : UserControl
    {
        public CallObjectView()
        {
            InitializeComponent();
        }
        Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: System.Windows.Application.Current.MainWindow,
                corner: Corner.TopRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = System.Windows.Application.Current.Dispatcher;
        });

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            notifier.ShowInformation("New Call");
            SoundPlayer Ding = new SoundPlayer(@"C:\Windows\Media\tada.wav");
            Ding.Play();

            var botToken = "5853799689:AAGeb0c8fxZoA3vgVXVU2XG01VaQvimCc38";
            var chatId = "1107158461"; // Id чата, в который вы хотите отправить сообщение
            var messageText = "Был добавлен новый вызов, ожидайте информации, и спасибо за работу!"; // Текст сообщения

            var botClient = new TelegramBotClient(botToken);

            await  botClient.SendTextMessageAsync(chatId, messageText);

        }
    }
}
