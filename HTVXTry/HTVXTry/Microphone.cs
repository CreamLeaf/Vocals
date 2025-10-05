using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Speech;
using System.Speech.Recognition;
using System.Diagnostics;

namespace HTVXTry
{
    public class Microphone
    {
        public static SpeechRecognizer speechRecognizer = new SpeechRecognizer();
        //static SpeechRecognitionEngine Recognition = new SpeechRecognitionEngine();
        static SpeechRecognitionEngine Rec = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
        static Grammar Gramm;
        public static string Word = " ";
        public static string[] VariationWords;
        public TextBox RecText;

        public static bool AlwaysMic = false; // Determine if the microphone should always be on.

        public Microphone()
        {
            Gramm = new Grammar(new GrammarBuilder());
        }

        // Got help from Microsoft .NET documentation
        public static void MakeMenuGrammar()
        {
            // Make the variations of acceptable words
            VariationWords = new string[2]{ "Starrrt", "Sssstarrrt" };

            GrammarBuilder builder = new GrammarBuilder();
            builder.Append("Start");
            builder.Append("Begin");
            builder.Append("How");
            builder.Append("Credits");
            builder.Append("End");

            

            Gramm = new Grammar(builder);
            //Recognition.LoadGrammar(Gramm);
            Rec.LoadGrammar(Gramm);

            //Recognition.SpeechDetected += Recognition_SpeechDetected;
            //Recognition.SpeechRecognized += Recognition_SpeechRecognized;
            Rec.SpeechRecognized += Recognition_SpeechRecognized;
        }

        private static void Recognition_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e)
        {
            //Word = e.Result.Text;
        }

        private static void Recognition_SpeechDetected(object? sender, SpeechDetectedEventArgs e)
        {
            //Recognition.EmulateRecognize("Credits");
     
        }

        // Use the microphone to detect audio
        public static string Mic(TextBox Message)
        {
            //using (Recognition = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers()[0]))
            
            {
                Message.Text = "Startebebe";
                Console.WriteLine("\nStartebebebeb");
                Thread.Sleep(2000);
                Message.Text = "RE";

                //Recognition = new SpeechRecognitionEngine();
                //Recognition.SetInputToDefaultAudioDevice();
                //Recognition.LoadGrammar(Gramm);
                //RecognitionResult Result = Recognition.Recognize(TimeSpan.FromSeconds(3.0));
                //RecognitionResult Result = Recognition.EmulateRecognize("Begin");

                Rec.SetInputToDefaultAudioDevice();
                RecognitionResult ResultRec = Rec.Recognize(TimeSpan.FromSeconds(2));

                // Try to get the word from the RecognitionResult
                if (ResultRec == null)
                {
                    Message.FontSize = 50.0;
                    Word = "null";
                }
                else
                {
                    Word = ResultRec.Text;
                    Message.Text = Word;
                    
                }
            }
            return Word;
        }
    }
}
