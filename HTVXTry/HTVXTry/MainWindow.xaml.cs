using System.Speech.Synthesis.TtsEngine;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTVXTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Microphone.MakeMenuGrammar();
        }

        // Click function to start
        private void StartClick(object sender, RoutedEventArgs e)
        {
            Start();
        }

        // Activate the microphone if AlwaysMic is false
        private void MicButton_Click(object sender, RoutedEventArgs e)
        {
            if (Microphone.AlwaysMic) { return; }

            Microphone.Mic(CommandText);
            switch (Microphone.Word)
            {
                case "Start":
                    Start();
                    break;
                case "Begin":
                    Start();
                    break;
                case "Starrrt":
                    Start();
                    break;
                case "Sssstarrrt":
                    Start();
                    break;
                case "How":
                    HowToPlay();
                    break;
                case "HTP":
                    HowToPlay();
                    break;
                case "Credits":
                    Credits();
                    break;
                case "null":
                    DisplayAudioError();
                    break;
                default:
                    DisplayAudioError();
                    break;
            }
        }

        // Start the project
        public void Start()
        {
            CommandText.Text = "Start!";
        }

        // Menu methods
        public void HowToPlay()
        {
            CommandText.Text = "HTP";
        }

        public void Credits()
        {
            CommandText.Text = "ERRO";
        }

        public void End()
        {

        }

        // Error method for audio
        public void DisplayAudioError()
        {
            CommandText.Text = "Error processing your audio. Try again.";
        }
    }
}