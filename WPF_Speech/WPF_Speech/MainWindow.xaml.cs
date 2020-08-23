using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
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

     
        public string fromLanguage { get; set; }

        public string toLanguage { get; set; }

        

        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            GetLogfiles();
        }      
       
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.fromLanguage = ((ComboBoxItem)InputCombo.SelectedItem).Tag.ToString();
            this.toLanguage = ((ComboBoxItem)OutputCombo.SelectedItem).Tag.ToString();


            Panel panel = new Panel(this.fromLanguage, this.toLanguage);
            panel.Show();       
      
        }

        private void GetLogfiles()
        {
            this.logs.Items.Clear();
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                try
                {             
                    foreach (string file in GetAllFiles("log_*", isoStore))
                    {
                        this.logs.Items.Add(file);
                    }
                }
                catch (FileNotFoundException)                {
                   
                }
            }
        }
        private static List<String> GetAllFiles(string pattern, IsolatedStorageFile storeFile)
        {
            List<String> fileList = new List<String>(storeFile.GetFileNames(pattern));          

            return fileList;
        } // End of GetFiles.


    }
}
