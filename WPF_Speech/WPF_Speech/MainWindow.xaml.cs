using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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


using Microsoft.CognitiveServices.Speech;

using Microsoft.CognitiveServices.Speech.Translation;


namespace WPF_Speech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        

     
        public string InputLanguage { get; set; }

        public string OutputLanguage { get; set; }


       


        public async void CreateRecognizer()
        {

            var config = SpeechTranslationConfig.FromSubscription("3b8301ddb4d844209a6ff2bbb20d13d7", "koreacentral");


            config.SpeechRecognitionLanguage = InputLanguage;
            config.SpeechRecognitionLanguage = OutputLanguage;

         
            config.AddTargetLanguage(OutputLanguage);

            using (var recognizer = new TranslationRecognizer(config))
            {
               
                var result = await recognizer.RecognizeOnceAsync();

            }
        }

       
        

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
         
        }

       
       
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            Panel panel = new Panel();
            panel.Show();

            this.InputLanguage = ((ComboBoxItem)InputCombo.SelectedItem).Tag.ToString();
            this.OutputLanguage = ((ComboBoxItem)OutputCombo.SelectedItem).Tag.ToString();

            this.CreateRecognizer();
      
        }

       
    }
}
