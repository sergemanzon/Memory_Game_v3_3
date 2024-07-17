using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Memory_Game_v3_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            build();
        }

         private void build() {
        //   < Grid Margin = "10" >
        //    < Grid.Background >
        //        < ImageBrush ImageSource = "Images/m3_login_he.png" />
        //    </ Grid.Background >
        //    < Button Click = "BtnClick" />

        //</ Grid >

        Grid grid =new Grid();  
            grid.Margin=new Thickness(10);  
            var uri = new Uri("pack://application:,,,/Images/" + "Images/m3_login_he.png");
            var bitmap = new BitmapImage(uri);
            grid.Background = new ImageBrush(bitmap);

            Button btn = new Button();
            btn.Click += BtnClick;



    

        }
         

        private void BtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
