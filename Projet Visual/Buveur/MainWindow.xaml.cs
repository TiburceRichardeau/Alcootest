using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Data.SQLite;


namespace Buveur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLite connexion = new SQLite("ListeAlcool");
        

        // MySQL
        MySqlConnection conn;
        public void mysqlconn() {
            // Permet de se connecter a la base de donnée Alcool_richardeau avec l'utilisateur root sans mot de passe sur le serveur localhost
            string myConnectionString = "server=localhost;uid=root;" + "database=Alcool_richardeau;";

            try
            {
                //On essaye de se connecter
                conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                conn.Open(); // Si la conexion marche ou l'ouvre
            }
            catch (MySqlException ex) // Sinon on affiche l'erreur
            {
                Window1 win = new Window1("Base de données inaccessible", 1);
                win.ShowDialog();
                //MessageBox.Show(ex.Message);
            }
        }
        bool sexeBuveur;
        string StringsBuveur = "";
        int poidsBuveur = 0;
        bool creationbuveur = false; // Bolean qui permet de savoir si la personne avec son poids et son sexe a bien été saisi
        CBuveur JeanMichel = new CBuveur(false, 0); // Creation de l'objet Buveur 
        int qte = 0;
        double taux = 0;


        public void InitBoisson()
        {
            qte = Int32.Parse(textBoxquantite.Text); // On recupère la quantité saisi et on la convertie en Int (champ texte a la base)
            taux = Double.Parse(textBoxtaux.Text); // On recupère le taux saisi et on le converti en double (champ texte a la base)
            JeanMichel.MAJ_alcoolemie(qte, taux); // On met a jour le taux d'alcool dans le sang de la personne avec les données récupèrée
        }

        // Permet de récupèrer le taux
        public double getTaux()
        {
            return taux;
        }

        // Permte de récupèrer la quantité
        public int getQte()
        {
            return qte;
        }

        // Permet de créer le buveur
        public void InitBuveur()
        {
            poidsBuveur = Int32.Parse(textBoxPoids.Text); // On vérifi que le poids a bien été saisi correctement
            if (femme.IsChecked == true) // si l'utilisateur a coché femme
            {
                sexeBuveur = false; // on défini le booléan a false (ce qui represente une femme)
            } else if (homme.IsChecked == true) // sinon on vérifi que la case homme est bien coché 
            {
                sexeBuveur = true; // Si c'est le cas on initialise le sexe a vrai (true)
            }

            if (creationbuveur == false) { // Si le buveur n'existe pas encore
                JeanMichel.set_poids(poidsBuveur); // On modifie le poids avec le poids saisi par l'utilisateur
                JeanMichel.set_sexe(sexeBuveur); // On modifie le sexe avec le sexe choisi par l'utilisateur
                creationbuveur = true; // on modifie la valeur de creationbuveur a vrai pour le plus la modifier par la suite en repassant dans la boucle if
            }
        }

        // Permet d'ajouter une boisson et de calculer le taux d'alcool dans le sang en ajoutant cette nouvelle boisson
        public void ajouterBoisson()
        {
            InitBoisson(); // On initialise le buveur
            labelAffichageTaux.Content = "Vous avez " + JeanMichel.get_alcoolemieArrondie() + " g d'alcool dans le sang"; // On affiche ensuite son taux d'alcool dans le sang
        }


        public MainWindow()
        {
            InitializeComponent();
            remplirListeAlcool(); // Permet de remplir la liste des alcool prédéfinis
            // Place la fenetre au centre de l'écran
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            // Permet de définir la taille de la fenetre
            this.MaxHeight = 600;
            this.MaxWidth = 530;
            this.MinHeight = 600;
            this.MinWidth = 530;
        }

        // Bouton ajouter personne
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            // Variable pour la vérification tryParse
            int testTry = 1;
            // On vérifie si les champs néccésaires sont bien remplis
            if (textBoxPoids.Text != "" && femme.IsChecked == true || homme.IsChecked == true && Int32.TryParse(textBoxPoids.Text, out testTry))
                {
                    InitBuveur(); // Si les champs sont bien remplis on enregistre le poids et le sexe de la personne
                    if (sexeBuveur) // Si sexeBuveur est a vrai, c'est un homme 
                    {
                        StringsBuveur = "un homme";
                    } else // Sinon c'est une femme
                    {
                        StringsBuveur = "une femme";
                    }
                // La personne a été ajoutée, on peut donc cacher les champs lié a la récupération des données sur l'utilisateurs qui ne sont plus utiles
                labelPoids.Visibility = Visibility.Hidden;
                textBoxPoids.Visibility = Visibility.Hidden;
                Sexe.Visibility = Visibility.Hidden;
                buttonAjouterPersonne.Visibility = Visibility.Hidden;
                labelPersonneCree.Visibility = Visibility.Visible;
                checkBoxJeuneConducteur.Visibility = Visibility.Hidden;
                labelConduite.Visibility = Visibility.Hidden;
                labelAffichageTaux.Visibility = Visibility.Hidden;
                // Affichage du poids et du sexe de l'utilisateur
                string PersonneCreeS="";
                if (poidsBuveur == 1) { 
                    PersonneCreeS = "Vous pesez " + poidsBuveur + " kg et vous etes " + StringsBuveur;
                } else if (poidsBuveur >= 1)
                {
                    PersonneCreeS = "Vous pesez " + poidsBuveur + " kgs et vous etes " + StringsBuveur;
                }else if (poidsBuveur == 0) // Si l'utilisateur a saisi un poids de 0 kg
                {
                    Window1 win = new Window1("Vous avez mal sasi votre poids \n Vous pesez réellement 0 kg ?");
                    win.ShowDialog();// On ouvre une fenetre pour le prévenir de sont erreur puis on affiche a nouveau les champs caché précedement pour qui corrige son erreur
                    JeanMichel.reset_alcoolemie();
                    labelAffichageTaux.Content = "";
                    textBoxPoids.Clear();
                    textBoxtaux.Clear();
                    textBoxquantite.Clear();
                    textBoxNomAlcool.Clear();
                    creationbuveur = false;
                    labelPersonneCree.Content = "";
                    homme.IsChecked = false;
                    femme.IsChecked = false;
                    labelPoids.Visibility = Visibility.Visible;
                    textBoxPoids.Visibility = Visibility.Visible;
                    Sexe.Visibility = Visibility.Visible;
                    buttonAjouterPersonne.Visibility = Visibility.Visible;
                    labelPersonneCree.Visibility = Visibility.Hidden;
                    checkBoxJeuneConducteur.Visibility = Visibility.Hidden;
                    labelConduite.Visibility = Visibility.Hidden;
                    labelAffichageTaux.Visibility = Visibility.Hidden;
                }
                else if (poidsBuveur <= 0) // Pareil si il saisi un poids négatif, on le previent qu'il a fait une erreur
                {
                    Window1 win = new Window1("Un poids négatif, \n Bravo, vous etes un champion");
                    win.ShowDialog();
                    JeanMichel.reset_alcoolemie();
                    labelAffichageTaux.Content = "";
                    textBoxPoids.Clear();
                    textBoxtaux.Clear();
                    textBoxquantite.Clear();
                    textBoxNomAlcool.Clear();
                    creationbuveur = false;
                    labelPersonneCree.Content = "";
                    homme.IsChecked = false;
                    femme.IsChecked = false;
                    labelPoids.Visibility = Visibility.Visible;
                    textBoxPoids.Visibility = Visibility.Visible;
                    Sexe.Visibility = Visibility.Visible;
                    buttonAjouterPersonne.Visibility = Visibility.Visible;
                    labelPersonneCree.Visibility = Visibility.Hidden;
                    checkBoxJeuneConducteur.Visibility = Visibility.Hidden;
                    labelConduite.Visibility = Visibility.Hidden;
                    labelAffichageTaux.Visibility = Visibility.Hidden;
                }
                labelPersonneCree.Content = PersonneCreeS; // On affiche ensuite les données dans une phrase
                }
                else
                {
                    Window1 win = new Window1("Vous avez mal rempli les champs poids et sexe");
                    win.ShowDialog();
                
            }
        }

        // Cette fonction permet de calculer le temps restant avant de pouvoir conduire
        public string temps_Elimination_Alcool()
        {
            double alcool_a_eliminer = 0.0;
            string minutes;
            // On perd 0.15g par heure
            if (checkBoxJeuneConducteur.IsChecked == true) {
                alcool_a_eliminer = JeanMichel.get_alcoolemie() - 0.2; // on soustrait le taux autorisé au taux d'alcool dans le sang de l'utilisateur, 0.2 dans le cas d'un jeune conducteur

            }else if (checkBoxJeuneConducteur.IsChecked == false)
            {
                alcool_a_eliminer = JeanMichel.get_alcoolemie() - 0.8; // on soustrait le taux autorisé au taux d'alcool dans le sang de l'utilisateur, 0.8 si ce n'est pas un jeune conducteur
            }
            double resultat = alcool_a_eliminer / 0.15; // Division par 0.15 pour avoir le nombre d'heure nécéssaire a l'élimination
            double heure = (int)resultat; // on stock la partie entière du resultat dans une viriable heure

            // Permet de ne pas essayer de prendre les deux premier caractères de la chaine minute quand elle vaut 0 sur un seul carctère
            if ((resultat - (int)resultat) != 0) { 
                double minutesDouble = (resultat - (int)resultat) * 60.0; // puis on récupère la partie décimal que l'on multipli par 60 pour avoir le nombre de minutes
                minutes = minutesDouble.ToString().Substring(0, 2); // on ne récupère que les deux premier caractère, on a pas besoin de plus
            }else { minutes = "00"; }
            if (minutes[1] == ',') // si le deuxième caractère est une , alors le nombre de minutes est inferieur a 10 donc 
            {
                minutes = "0" + minutes[0]; // on modifie la chaine pour avoir un format d'heure correct
            }
            string temps_restant;
            if (heure == 0)
            {
                if (Int32.Parse(minutes) < 10) {
                    minutes = Int32.Parse(minutes).ToString();
                }
                temps_restant = "Il vous reste " + minutes + " min a attendre pour pouvoir conduire"; // Si heure=0 alors on affiche une phrase avec uniquement des minutes
            }else if (Int32.Parse(minutes)==0)
            {
                temps_restant = "Il vous reste " + heure + "h a attendre pour pouvoir conduire"; // Si le nombre de minutes est nul alors on affiche une phrase avec uniquement des heures
            }else // Sinon il y a un nombre de minutes et un nombre d'heure alors on affiche la phrase adéquate 
            {
                temps_restant = "Il vous reste " + heure + "h" + minutes + "min a attendre pour pouvoir conduire";
            }


            return temps_restant; // On retrourne la phrase avec le temps restant pour pouvoir conduire
        }

        // bouton Calculer taux
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Variable pour la vérification des tryParse
            double testTry = 1;
            int testTryInt = 1;
            textBoxtaux.Text = textBoxtaux.Text.Replace('.', ','); // On remplace les . par des , dans le champs taux pour éviter des problème avec les calcules sur les doubles
            // On vérifie que les valeurs saisis sont correctes
            if (creationbuveur == true && Double.TryParse(textBoxtaux.Text, out testTry) && Int32.TryParse(textBoxquantite.Text, out testTryInt) && Int32.Parse(textBoxquantite.Text)>0)
            {
                if(textBoxquantite.Text.ToString() != "" && textBoxquantite.Text.ToString() != "")
                {
                    ajouterBoisson(); // Si tout est bien saisi on ajoute la boisson pour recalculer le taux dans le sang
                }else
                {
                    Window1 win = new Window1("Vous n'avez pas saisi la quantité et le taux"); // Sinon on prévient l'utilisateur de son erreur
                    win.ShowDialog();
                }
            }
            else if(!Double.TryParse(textBoxtaux.Text, out testTry)) // On vérifi le champs taux
            {
                Window1 win = new Window1("Vous n'avez pas correctement saisi le taux");
                win.ShowDialog();
            }
            else if(!Int32.TryParse(textBoxquantite.Text, out testTryInt))
            {
                Window1 win = new Window1("Vous n'avez pas correctement saisi la quantité \n La quantité doit être un entier (en cl)");
                win.ShowDialog();
            }
            else if (Int32.Parse(textBoxquantite.Text) < 0)
            {
                Window1 win = new Window1("Merci de saisir une quantité positive");
                win.ShowDialog();
            }
            else
            {
                Window1 win = new Window1("Vous n'avez pas saisi correctement votre poids et votre sexe");
                win.ShowDialog();
            }

            // Ce code permet de gérer la checkbox jeune conducteur
            if (checkBoxJeuneConducteur.IsChecked == true && JeanMichel.get_alcoolemie()<= 0.2 && JeanMichel.get_alcoolemie() > 0 && textBoxquantite.Text != "" && creationbuveur==true)
            {
                labelConduite.Visibility = Visibility.Visible;
                labelConduite.Content = "Vous pouvez prendre le volant";
            }else if (checkBoxJeuneConducteur.IsChecked == true && JeanMichel.get_alcoolemie() > 0.2 && textBoxquantite.Text != "" && creationbuveur == true)
            {
                labelConduite.Visibility = Visibility.Visible;
                string text = "Vous ne pouvez pas prendre le volant. \n" + temps_Elimination_Alcool().ToString();
                labelConduite.Content = text;
            } else if (checkBoxJeuneConducteur.IsChecked == false && JeanMichel.get_alcoolemie()<= 0.8 && JeanMichel.get_alcoolemie() > 0 && textBoxquantite.Text != "" && creationbuveur == true)
            {
                labelConduite.Visibility = Visibility.Visible;
                labelConduite.Content = "Vous pouvez prendre le volant";
            }else if (checkBoxJeuneConducteur.IsChecked == false && JeanMichel.get_alcoolemie() > 0.8 && textBoxquantite.Text != "" && creationbuveur == true)
            {
                labelConduite.Visibility = Visibility.Visible;
                string text = "Vous ne pouvez pas prendre le volant. \n" + temps_Elimination_Alcool().ToString();
                labelConduite.Content = text;
            }
            if (creationbuveur == true)
            {
                labelAffichageTaux.Visibility = Visibility.Visible;
            }
        }

        // Permet de remplir la liste des alcool prédéfini a partir de la base de donnée
        public void remplirListeAlcool()
        {
            try
            {
                listBoxAlcool.Items.Clear(); // On vide la liste
                                             // ouverture de la connexion avec la base de donnée
                mysqlconn();
                string SQLSelectAlcool = "SELECT `Nom`, `taux` FROM `listealcool` order by `Nom`"; // Requete SQL qui va nous servir a récupèrer les données a mettre dans la liste
                MySqlCommand cmd = new MySqlCommand(SQLSelectAlcool, conn);
                MySqlDataReader rdr = cmd.ExecuteReader(); // On éxécute la requete

                while (rdr.Read()) // Tant qu'il y a des resultat dans la requete
                {
                    string nom = rdr[0].ToString(); // On récupère le champ nom 
                    string taux = rdr[1].ToString(); // On recupère le champ taux
                    listBoxAlcool.Items.Add(nom); // On ajoute l'alcool dans la liste
                }
                rdr.Close(); // On peut ensuite fermer la connexion SQL
            }
            catch
            {
                Window1 win = new Window1("Impossible de récupérer la liste des alcools", 1);
                win.ShowDialog();
                this.Close();
                
            }
            
        }


        // Bouton réinitialiser
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textBoxNomAlcool.IsReadOnly = false;
            JeanMichel.reset_alcoolemie();
             labelAffichageTaux.Content = "";
             textBoxPoids.Clear();
             textBoxtaux.Clear();
             textBoxquantite.Clear();
             textBoxNomAlcool.Clear();
             creationbuveur = false;
             labelPersonneCree.Content = "";
             homme.IsChecked = false;
             femme.IsChecked = false;
             labelPoids.Visibility = Visibility.Visible;
             textBoxPoids.Visibility = Visibility.Visible;
             Sexe.Visibility = Visibility.Visible;
             buttonAjouterPersonne.Visibility = Visibility.Visible;
            labelPersonneCree.Visibility = Visibility.Hidden;
            checkBoxJeuneConducteur.Visibility = Visibility.Visible;
            labelConduite.Visibility = Visibility.Hidden;
            checkBoxJeuneConducteur.IsChecked = false;
            listBoxAlcool.SelectedIndex = -1;
        }

        // Permet d'ajouter un alcool dans la base de donnée et donc dans la liste
        public void ajouterDansListe()
        {
            mysqlconn(); // Ouverture d'une connexion
            string SQLAddAlcool = "INSERT INTO `listealcool`(`idListeAlcool`, `Nom`, `taux`) VALUES (NULL,'"+ textBoxNomAlcool.Text +"',"+textBoxtaux.Text + ")"; // Requete utiliser pour ajouter un alcool dans la base de donnée
            MySqlCommand cmd = new MySqlCommand(SQLAddAlcool, conn); // Création de l'objet de connexion
            cmd.ExecuteNonQuery(); // Execution la requete SQL d'insertion
            remplirListeAlcool(); // Actualisation de la liste a partir de la base de donnée
            conn.Close(); // Fermeture de la connexion
        }

        // Bouton ajouter a la liste
        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            bool estPresentDansliste = false; // Bollean qui va permettre de ne pas mettre deux fois la même boisson dans la liste
            Double test=1; // Variable qui permte de vérifier le tryParse
            textBoxtaux.Text = textBoxtaux.Text.Replace(',', '.'); // On remplace les , par des . dans le champ taux pour éviter des problème dans la base de donnée
            if (textBoxNomAlcool.Text.ToString() != "" && textBoxtaux.Text.ToString() != "") // On vérifie si les champs sont bien remplis pour ajouter dans la liste
            {
                
                    foreach (string listboxitem in listBoxAlcool.Items) // On parcours la liste 
                    {
                        if (listboxitem == textBoxNomAlcool.Text.ToString()) // Si l'alcool est déjà dans la liste on passe le booleen a vrai
                        {
                            estPresentDansliste = true;
                        }
                    }
                    if (estPresentDansliste == true)  // On vérifie si l'alcool était dans la liste parcourus
                    {
                        Window1 win = new Window1("Cette boisson est déjà dans la liste"); // Si c'est le cas on affiche un message pour prevenir l'utilisateur
                        win.ShowDialog();
                    } else { // sinon on l'ajoute dans la liste
                        ajouterDansListe();
                    }
            }
            else if (!Double.TryParse(textBoxtaux.Text, out test))
            {
                Window1 win = new Window1("Vous avez mal saisi le taux");  // Vérification du champ taux
                win.ShowDialog();
            }
            else
            {
                Window1 win = new Window1("Veuillez sasir le nom et le taux de l'alcool a ajouter dans la liste");
                win.ShowDialog();
            }
        }

        // Permet de remplir les champs avec les valeurs de la liste
        private void listBoxAlcool_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Permet d'utiliser selectedIndex=-1 dans le bouton réinitialiser (ne pas avoir d'alcool selectionner dans la liste après avoir réinitialiser
            if (listBoxAlcool.SelectedIndex >= 0) { 
                // ouverture de la connexion avec la base de donnée
                mysqlconn();
            string SQLSelectAlcool = "SELECT `Nom`, `taux` FROM `listealcool` where `Nom`='" + e.AddedItems[0].ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(SQLSelectAlcool, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                textBoxNomAlcool.Text = rdr[0].ToString();
                textBoxtaux.Text = rdr[1].ToString();
            }
            rdr.Close(); // Fermeture de connexion a la base de donnée
            textBoxNomAlcool.IsReadOnly = true;
            }
        }

        // Action du clic sur bouton de fermeture
        private void buttonFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Action du clic sur le bouton de reduction de la fenetre
        private void buttonRediure_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Action du bouton agrandir fenetre
        private void buttonAgrandir_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized) // Si la fentre n'est pas agrandie
            {
                // On change la valeur de la taille max de l'appli, ces grandes valeurs permettre de prendre en charge de grande résolutions comme le 4k (3840*2160)
                this.MaxHeight = 6000;
                this.MaxWidth = 5300;
                this.WindowState = WindowState.Maximized; // Puis on agrandit la fentre
            }else // Sinon la fentre doit être diminuée 
            {
                this.MaxHeight = 600;
                this.MaxWidth = 530;
                this.MinHeight = 600;
                this.MinWidth = 530;
                this.WindowState = WindowState.Normal; // On la remet a sa taille normale
            }
        }

        // Permet de déplacer la fenetre avec la souris
        // Utile étant donnée que l'application n'a plus de bord
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        // Action clic sur le label textboxAlcool
        private void textBoxNomAlcool_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxNomAlcool.IsReadOnly == true)
            {
                // Prévient l'utilisateur qui ne peut pas modifier le champ au moment on il commence a taper quelque chose au clavier dans un champ en readOnly
                Window1 win = new Window1("Vous n'avez pas le droit de modifier la valeur de la liste");
                win.ShowDialog();
            }
        }

        // Action clic sur le bouton info
        private void buttonInfo_Click(object sender, RoutedEventArgs e)
        {
            // Permet d'afficher une fenetre avec les infos sur l'applications
            Window1 win = new Window1("Application developpée par Tiburce Richardeau\n\nIcon made by Freepik from flaticon.com is licensed under CC BY 3.0\n\nTheme MaterialDesignInXamlToolkit by ButchersBoy under Ms-PL License\nhttps://github.com/ButchersBoy/MaterialDesignInXamlToolkit\n\n\nL'alcool est dangereux pour la santé, à consommer avec modération", "info");
            win.ShowDialog();
        }
    }
}