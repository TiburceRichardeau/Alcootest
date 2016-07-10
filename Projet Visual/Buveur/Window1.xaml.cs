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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Buveur
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // Constructeur pour les fenetres de message d'erreur
        public Window1(string textErreur)
        {
            InitializeComponent();
            // Permet de remplir le label avec le message a afficher
            labelErreur.Content = textErreur;
            labelErreur.Height = textErreur.Length;
            // Permet de placer la fentre au centre de l'écran
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Permet de définir la hauteur max de la fenetre
            this.MaxHeight = 150;
            this.MinHeight = 150;

            // Permet de ne pas couper le messages a afficher a l'utilisateur
            if (textErreur.Length > 410) { // Permet d'agrandir la fentre si le message est long
                this.MaxWidth = textErreur.Length * 8 + 50; // length est en nombre de caractère or un carcatère est en police 8 ou 9px et maxWidth et minWidth est en px et on rajoute 50px par sécurité
                this.MinWidth = textErreur.Length * 8 + 50;
            }else
            {
                this.MaxWidth = 410;
                this.MinWidth = 410;
            }

            if (textErreur.ToString() == "Vous n'avez pas correctement saisi la quantité \n La quantité doit être un entier (en cl)")
            {
                this.MaxWidth = "Vous n'avez pas correctement saisi la quantité".Length * 8 + 50;
                this.MinWidth = "Vous n'avez pas correctement saisi la quantité".Length * 8 + 50;
            }
        }
        
        
        // Constructeur pour la fenetre info 
        public Window1(string info, string type)
        {
            InitializeComponent();
            labelErreur.Content = info;
            labelErreur.Height = info.Length;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.MaxHeight = 250;
            this.MaxWidth = 500;
            this.MinHeight = 250;
            this.MinWidth = 500;
            buttonlienFlaticon.Visibility = Visibility.Visible;
            buttonlienTheme.Visibility = Visibility.Visible;
        }
        
        // Constructeur pour message erreur sql
        public Window1(string erreurSQL, int type)
        {
            InitializeComponent();
            labelErreur.Content = erreurSQL;
            labelErreur.Height = erreurSQL.Length;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (erreurSQL.Length>400) { 
                this.MaxWidth = erreurSQL.Length*8+50;
                this.MinWidth = erreurSQL.Length*8+50;
                this.Width = erreurSQL.Length * 8 + 50;
                labelErreur.Content = "width : " + this.Width + "height : " + this.Height;
            }
            else
            {
                this.MaxWidth = 410;
                this.MinWidth = 410;
            }

            
        }

        // action du bouton Ok
        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Lien vers flaticon, utiliser dans le constructeur pour la fenetre info
        private void lienFlaticon_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.flaticon.com/");
        }

        //Lien vers gitHub Theme, utiliser dans le constructeur pour la fenetre info
        private void buttonlienTheme_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ButchersBoy/MaterialDesignInXamlToolkit");
        }

        // Permet de déplacer la fenetre avec la souris
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
