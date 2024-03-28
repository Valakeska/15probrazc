using SchoolTraffic;
using SocialNetSchool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

namespace SocailNetSchool
{
    /// <summary>
    /// Логика взаимодействия для Event.xaml
    /// </summary>
    public partial class Event : Window
    {
        public Event()
        {
            InitializeComponent();
            poisk();
        }

        public void poisk()
        {
            StackPanel stackPanel = new StackPanel();

            StackMain.Children.Add(stackPanel);

            SqlClass sql = new SqlClass();
            if (PoiskPostov.Text == "")
            {
                DataTable IDPost = sql.Commands("SELECT [ID_Event] FROM [dbo].[Event] order by [ID_Event] DESC");
                DataTable IDContentPost = sql.Commands($"SELECT [Content] FROM [dbo].[Event]  order by [ID_Event] DESC");
                DataTable IDTitlePost = sql.Commands($"SELECT [Title] FROM [dbo].[Event]  order by [ID_Event] DESC");
                DataTable IDTimePost = sql.Commands("SELECT [Time] FROM [dbo].[Event] order by [ID_Event] DESC");
                DataTable IDPicturePost = sql.Commands("SELECT [Picture] FROM [dbo].[Event] order by [ID_Event] DESC");
                for (int i = 0; i < IDPost.Rows.Count; i++)
                {
                    string LinkPucture = IDPicturePost.Rows[i][0].ToString();
                    int idPost = Convert.ToInt32(IDPost.Rows[i][0]);

                    StackPanel Razdelit = new StackPanel();
                    StackPanel stackPanel2 = new StackPanel();
                    stackPanel2.Orientation = Orientation.Horizontal;
                    Grid dridd = new Grid();
                    StackPanel stackPanel1 = new StackPanel();
                    WrapPanel ForPicture = new WrapPanel();
                    Label time = new Label();
                    TextBlock Title = new TextBlock();
                    TextBlock Countain = new TextBlock();
                    Grid image = new Grid();
                    Label Otstyp = new Label();


                    Label Otstyp2 = new Label();
                    Otstyp2.Width = 300;

                    ForPicture.HorizontalAlignment = HorizontalAlignment.Center;
                    time.Content = IDTimePost.Rows[i][0].ToString();
                    time.FontSize = 15;
                    time.FontFamily = new FontFamily("Cambri");
                    time.HorizontalContentAlignment = HorizontalAlignment.Left;

                    image.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), LinkPucture)));
                    image.Width = 200;
                    image.Height = 200;
                    Otstyp.Width = 270;

                    Title.Text = IDTitlePost.Rows[i][0].ToString();
                    Title.TextWrapping = TextWrapping.Wrap;
                    Title.FontSize = 16;
                    Title.FontFamily = new FontFamily("Cambri");
                    Title.Width = 550;
                    Title.Background = new SolidColorBrush(Color.FromRgb(144, 168, 214));

                    Countain.Text = IDContentPost.Rows[i][0].ToString();
                    Countain.TextWrapping = TextWrapping.Wrap;
                    Countain.FontSize = 14;
                    Countain.FontFamily = new FontFamily("Cambri");
                    Countain.Width = 550;
                    Countain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    Razdelit.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    stackPanel.Children.Add(Razdelit);
                    stackPanel.Children.Add(Otstyp2);
                    Razdelit.Children.Add(stackPanel2);
                    Razdelit.Children.Add(stackPanel1);
                    Razdelit.Children.Add(ForPicture);
                    stackPanel1.Children.Add(Title);
                    stackPanel1.Children.Add(dridd);
                    stackPanel2.Children.Add(time);
                    ForPicture.Children.Add(image);
                    dridd.Children.Add(Countain);
                }
            }
            else
            {
                DataTable IDPost = sql.Commands($"SELECT [ID_Event] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%' or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC");
                DataTable IDTitlePost = sql.Commands($"SELECT [Title] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%' or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC");
                DataTable IDContentPost = sql.Commands($"SELECT [Content] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%'  order by [ID_Event] DESC");
                DataTable IDTimePost = sql.Commands($"SELECT [Time] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC");
                DataTable IDPicturePost = sql.Commands($"SELECT [Picture] FROM [dbo].[Event] where [Content] LIKE '%{PoiskPostov.Text}%'or  [Title] LIKE '%{PoiskPostov.Text}%' order by [ID_Event] DESC");
                for (int i = 0; i < IDPost.Rows.Count; i++)
                {
                    string LinkPucture = IDPicturePost.Rows[i][0].ToString();
                    int idPost = Convert.ToInt32(IDPost.Rows[i][0]);

                    StackPanel Razdelit = new StackPanel();
                    StackPanel stackPanel2 = new StackPanel();
                    stackPanel2.Orientation = Orientation.Horizontal;
                    Grid dridd = new Grid();
                    StackPanel stackPanel1 = new StackPanel();
                    WrapPanel ForPicture = new WrapPanel();
                    Label time = new Label();
                    TextBlock Countain = new TextBlock();
                    TextBlock Title = new TextBlock();

                    Grid image = new Grid();
                    Label Otstyp = new Label();



                    Label Otstyp2 = new Label();
                    Otstyp2.Width = 300;

                    ForPicture.HorizontalAlignment = HorizontalAlignment.Center;
                    time.Content = IDTimePost.Rows[i][0].ToString();
                    time.FontSize = 15;
                    time.FontFamily = new FontFamily("Cambri");
                    time.HorizontalContentAlignment = HorizontalAlignment.Left;

                    image.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), LinkPucture)));
                    image.Width = 200;
                    image.Height = 200;
                    Otstyp.Width = 270;

                    Title.Text = IDTitlePost.Rows[i][0].ToString();
                    Title.TextWrapping = TextWrapping.Wrap;
                    Title.FontSize = 16;
                    Title.FontFamily = new FontFamily("Cambri");
                    Title.Width = 550;
                    Title.Background = new SolidColorBrush(Color.FromRgb(144, 168, 214));

                    Countain.Text = IDContentPost.Rows[i][0].ToString();
                    Countain.TextWrapping = TextWrapping.Wrap;
                    Countain.FontSize = 14;
                    Countain.FontFamily = new FontFamily("Cambri");
                    Countain.Width = 550;
                    Countain.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    Razdelit.Background = new SolidColorBrush(Color.FromRgb(144, 193, 214));

                    stackPanel.Children.Add(Razdelit);
                    stackPanel.Children.Add(Otstyp2);
                    Razdelit.Children.Add(stackPanel2);
                    Razdelit.Children.Add(stackPanel1);
                    Razdelit.Children.Add(ForPicture);
                    stackPanel1.Children.Add(Title);
                    stackPanel1.Children.Add(dridd);
                    stackPanel2.Children.Add(time);
                    ForPicture.Children.Add(image);
                    dridd.Children.Add(Countain);
                }
            }
        }
        public void ClearDynamic()//очистить результаты поиска
        {
            StackMain.Children.Clear();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearDynamic();
            poisk();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            GlavMenu window1 = new GlavMenu();
            window1.Show(); Close();
        }

    
    }
}
