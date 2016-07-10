using System.Data.SQLite;

namespace Buveur
{
    class SQLite
    {
        SQLiteConnection DBConnection;
        public SQLite(string DBName)
        {
            SQLiteConnection.CreateFile(DBName + ".sqlite");
        }

        private bool connexion()
        {
            try
            {
                DBConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
                DBConnection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool créerTableAlcool()
        {
            try
            {
                string sql = "create table listealcool (nom varchar(20), taux double)";
                SQLiteCommand command = new SQLiteCommand(sql, DBConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        private bool insertAlcool(string nom, double taux)
        {
            try
            {
                string sql = "insert into listealcool (nom, taux) values ('" + nom + "', " + taux + ")";
                SQLiteCommand command = new SQLiteCommand(sql, DBConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        private void remplirDB()
        {
            /*
                (1, 'Vodka', 37.5),
                (2, 'Whisky', 40),
                (3, 'Rhum', 40),
                (4, 'Tequila', 35),
                (5, 'Get 27', 21),
                (6, 'Kronenbourg', 4.2),
                (7, '1664', 5.5),
                (8, 'Grimbergen', 6.7),
                (9, 'San Miguel', 5.5),
                (10, 'Pastis', 45),
                (11, 'Gin', 37.5),
                (12, 'Ricard', 45),
                (13, 'Leffe', 6.6),
                (14, 'Hoegaarden', 5),
                (15, 'Heineken', 5),
            */
            insertAlcool("Vodka", 37.5);
            insertAlcool("Whisky", 40);
            insertAlcool("Rhum", 40);
            insertAlcool("Tequila", 35);
            insertAlcool("Get 27", 21);
            insertAlcool("Kronenbourg", 4.2);
            insertAlcool("1664", 5.5);
            insertAlcool("Grimbergen", 45);
            insertAlcool("San Miguel", 37.5);
            insertAlcool("Pastis", 45);
            insertAlcool("Gin", 6.6);
            insertAlcool("Ricard", 45);
            insertAlcool("Leffe", 6.6);
            insertAlcool("Hoegaarden", 5);
            insertAlcool("Heineken", 5);
        }
    }
}
