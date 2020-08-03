using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPF_Speech
{
    /// <summary>
    /// Panel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Panel : Window
    {


        public Panel()
        {
            InitializeComponent();
            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            secondGrid.Opacity = e.NewValue;
           
        }
    }
}
