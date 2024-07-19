using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        List<Image> ImgObj = new List<Image>();
        List<Button> BtnObj = new List<Button>();
        List<string> imageNames;// = new List<string>()// יצירת אטוסף של שמות התמונות   שנרצה להציג 
        //{"cactus_wilting_md_wht.gif","m3_login_he.png","brownbear2_lg_clr.gof","anglkiss.gif"};
        //{"cactus_wilting_md_wht.gif","Car_1.png","brownbear.gif","anglkiss.gif"};
        List<string> imageNames_All = new List<string>()// יצירת אטוסף של שמות התמונות   שנרצה להציג 
        //{"cactus_wilting_md_wht.gif","m3_login_he.png","brownbear2_lg_clr.gof","anglkiss.gif"};
        {"cactus_wilting_md_wht.gif","Car_1.png","brownbear.gif","anglkiss.gif"};
        Random rnd = new Random();

        int mone = 0;// מונה למספר זוגות שנחשפו  
        int count = 4;//מספר זוגות הקלפים במשחק 
        int move = 0;
        Button btn1, btn2;
        public MainWindow()
        {
            InitializeComponent();

            BuildBtn_Click(null,null);
        }

        //private void build()
        //{
        //    //   < Grid Margin = "10" >
        //    //    < Grid.Background >
        //    //        < ImageBrush ImageSource = "Images/m3_login_he.png" />
        //    //    </ Grid.Background >
        //    //    < Button Click = "BtnClick" /> 

        //    //</ Grid >

        //    Grid grid = new Grid();
        //    grid.Margin = new Thickness(10);
        //    var uri = new Uri("pack://application:,,,/Images/" + "Images/m3_login_he.png");
        //    var bitmap = new BitmapImage(uri);
        //    grid.Background = new ImageBrush(bitmap);

        //    Button btn = new Button();
        //    btn.Click += BtnClick;
        //    grid.Children.Add(btn);
        //    this.myGrid.Children.Add(grid);
        //}
        private void build()
        {
            //   < Grid Margin = "10" >
            //    < Grid.Background >
            //        < ImageBrush ImageSource = "Images/m3_login_he.png" />
            //    </ Grid.Background >
            //    < Button Click = "BtnClick" /> 

            //</ Grid >
            this.myGrid.Children.Clear();
            BtnObj.Clear();
            for (int i = 0; i < this.count * 2; i++)
            {

                Grid grid = new Grid();
                grid.Margin = new Thickness(10);
                //var uri = new Uri("pack://application:,,,/Images/" + "Images/m3_login_he.png");
                //var bitmap = new BitmapImage(uri);
                //grid.Background = new ImageBrush(bitmap);

                Button btn = new Button();
                btn.Click += BtnClick;

                grid.Children.Add(btn);
                this.myGrid.Children.Add(grid);
                BtnObj.Add(btn);
            }
            imageNames = new List<string>(imageNames_All);
            int imgCount = 0;
            // while(imageNames.count > 0)
            while (imageNames.Count > 0 && imgCount < this.count)
            {
                int img = rnd.Next(imageNames.Count);// נבחר מספר תמונה רנדומלי  
                //ניצר בצוטרה דינמית את הכתובת (בדיסק) של התמונה בתוך הפרויקט  
                var uri = new Uri("pack://application:,,,/Images/"+imageNames[img]);
                var bitmap = new BitmapImage(uri); //  נייצר "תמונה"
                for (int i = 0; i < 2; i++)  // נבצע זאת פעמיים , כי יש לנו זוג כפתורים ותמונות
                {
                    int inx = findFreeBtn(); //ללא תמונה (ללא תג)  ,  ' נחפש מיקום של 'כפתור פנוי  

                    //  ImgObj[inx].Source = bitmap;   // נשים בו את התמונה 
                    Grid grid = BtnObj[inx].Parent as Grid;
                    grid.Background=new ImageBrush(bitmap);
                    BtnObj[inx].Tag = imageNames[img];// ונשים בתג שלו את השם התמונה , לזיהוי  
                }
                imgCount++;
                imageNames.RemoveAt(img);// נוריד את השם התמונה מהאוסף , כדי לוודא שלא ייבחר שוב 



            }
        }

        private int findFreeBtn()
        {
            int inx = -1;
            int x;

            while (inx < 0)
            {
                x = rnd.Next(BtnObj.Count);
                if (BtnObj[x].Tag == null)
                    inx = x;

            }
            return inx;
        }
        private void BuildBtn_Click(object sender, RoutedEventArgs e) {
            this.count = int.Parse(this.SizeTxt.Text);
            build();
        
        
        }


            private void BtnClick(object sender, RoutedEventArgs e)
            {
                Button btn = (Button)sender;
                move++;
                btn.Visibility = Visibility.Collapsed;  // לחשוף את הקלף שנלחץ 
                if (btn1 == null) //האם זה הקלף הראשון 
                {
                    btn1 = btn; //לשמור את הקלף הראשון  
                }
                else
                {
                    if (btn2 == null) // האם זהו הכלף השני  
                    {
                        btn2 = btn; // לשמור את הקלף השני                  

                        if (count == mone + 1)// האם המשחק הסתיים ??
                        {
                            MessageBox.Show("  כל הכבוד ,ניצחת ב " + move + "מהלכים !!!");
                        }
                    }

                    else
                    {
                        //if (int.Parse(btn1.Tag.ToString()) == int.Parse(btn2.Tag.ToString()))
                        //if (btn1.Tag.ToString() == btn2.Tag.ToString())
                        if (btn1.Tag.Equals(btn2.Tag)) //... אם נחשפו זוג קלפים 
                        {
                            mone = mone + 1;
                            // זוג שנחשף ישאר חשוף  
                        }
                        else  // הסתר את הזוג הקלפים שנחשפו
                        {

                            btn1.Visibility = Visibility.Visible;
                            btn2.Visibility = Visibility.Visible;
                        }
                        btn1 = btn; //שמור את הקלף שנלחץ כקלף ראשון  
                        btn2 = null; // אין לנו עדיין קלף שני 


                    }
                }
            }
        }
    } 
