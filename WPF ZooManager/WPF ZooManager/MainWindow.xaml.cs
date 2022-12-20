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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Diagnostics;

namespace WPF_ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQLiteConnection con;

        public MainWindow()
        {
            InitializeComponent();
            
            // create connection string
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //create connection
            con = new SQLiteConnection(connectionString);
            showZoos();
            showAnimal();

            /*
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //            IDbConnection cnn = new SQLiteConnection(connectionString);
            IDbConnection cnn = new SQLiteConnection(connectionString);

            var ss = cnn.QueryFirstOrDefault<string>("SELECT FirstName FROM Person", new { Id = 1 });

            //string ss = SqlliteDataAccess.LoadPeople();
            MessageBox.Show(ss);

            string query = "select * from Zoo";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, cnn);
            */


            /////////////////////////// Example 1  connected architecure way below

            /*
            // easy query
            string stm = "SELECT SQLITE_VERSION()";
            //query to run
            string query = "select * from Zoo";
            //connection string
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //create connection
            var con = new SQLiteConnection(connectionString);

            con.Open();

            var cmd = new SQLiteCommand(query, con);
            string version = cmd.ExecuteScalar().ToString();
            MessageBox.Show($"SQLite version: {version}");
            */
            /////////////////////////// Example 1  connected architecure way below




            /////////////////////////// Example 2 do it the disconnected arhiecture way

            /*
            var SqliteCmd = new SQLiteCommand(query, con);
            SqliteCmd.CommandType = CommandType.Text;
            SQLiteDataAdapter SqlDa = new SQLiteDataAdapter(query, con);
            DataTable zooTable = new DataTable();

            SqlDa.Fill(zooTable);

            int numcount = zooTable.Rows.Count;
            MessageBox.Show(numcount.ToString());
            */
            /////////////////////////// Example 2 do it the disconnected arhiecture way


            /////////////////////////////////////////////////////////// example 3 connected way
            /**
           
            //query to run
            string query = "select * from Zoo";
            
            //connection string
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            
            //create connection
            var con = new SQLiteConnection(connectionString);
            // open the connection
            con.Open();
            // create a new sql command and pass in the open connection
            SQLiteCommand cmd2 = new SQLiteCommand(query,con);
            //create a sql reader with the command
            SQLiteDataReader rdr = cmd2.ExecuteReader();
          
            // maniupate the data returned
            var columns = new List<string>();
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                columns.Add(rdr.GetName(i));
            }
           
            foreach (string value in columns){
                System.Diagnostics.Trace.WriteLine(value);
            }

            columns.ForEach(value => System.Diagnostics.Trace.WriteLine(value));

            while (rdr.Read())
            {
                    
                string someval0 = rdr[0].ToString();
                string someval1 = rdr[1].ToString();
                System.Diagnostics.Trace.WriteLine(someval0 + " " + someval1);
        
            }
            //close the connection
            con.Close();
            MessageBox.Show("done");

            **/
            /////////////////////////////////////////////////////////// example 3 end connected way

        }

        

        private void showZoos()
        {
            Debug.WriteLine("start showZoos");
            try {

                string query = "select * from Zoo";
                SQLiteDataAdapter SqlDa = new SQLiteDataAdapter(query, con);
                using (SqlDa)
                {
                    DataTable zooTable = new DataTable();

                    SqlDa.Fill(zooTable);
                    Debug.WriteLine("showZoos after fill");
                    int numcount = zooTable.Rows.Count;
                    listZoos.DisplayMemberPath = "Location";
                    Debug.WriteLine("showZoos after displaymemberpath");
                    listZoos.SelectedValuePath = "Id";
                    Debug.WriteLine("showZoos after selectedvaluepath");
                    listZoos.ItemsSource = zooTable.DefaultView;
                    Debug.WriteLine("showZoos after itemsource");
                    //System.Diagnostics.Trace.WriteLine(numcount);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            Debug.WriteLine("ran showZoos");
        }//end function

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(listZoos.SelectedValue.ToString());
            //filter for sender.selectedinex = -1 which is a deletion or sender.selecteditem = null meaning fired by code
            Debug.WriteLine("running listZoos_SelectionChanged");
          
            if(listZoos.SelectedItem != null)
            {
                showAssociatedAnimals();
                showSelectedZooInTextBox();

            }


        }//function


        private void listAllAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("running listAllAnimals_SelectionChanged");

            if (listAllAnimals.SelectedItem != null)
            {
               
                showSelectedAnimalInTextBox();

            }
        }//function


        private void showAssociatedAnimals()
        {
            
            try
            {

                string query = "select * from Animal a inner join zooAnimal " + "za on a.Id = za.AnimalId where za.ZooId = @ZooId";
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, con);

                SQLiteDataAdapter SqlDa = new SQLiteDataAdapter(sqliteCommand);
                using (SqlDa)
                {

                    sqliteCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                //    System.Diagnostics.Trace.WriteLine(listZoos.SelectedValue.ToString());
                    DataTable animalTable = new DataTable();

                    SqlDa.Fill(animalTable);
                    int numcount = animalTable.Rows.Count;
                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    listAssociatedAnimals.SelectedValuePath = "Id";
                    listAssociatedAnimals.ItemsSource = animalTable.DefaultView;

                   // System.Diagnostics.Trace.WriteLine(numcount);
                }
                Debug.WriteLine("ran try in showAssoicatedAnimals");
            }
            catch (Exception e)
            {
                Debug.WriteLine("caught exception in showAssoicatedAnimals");
              
                MessageBox.Show(e.ToString());

            }

        }//end function

        private void showAnimal()
        {
            try
            {

                string query = "select * from Animal";
                SQLiteDataAdapter SqlDa = new SQLiteDataAdapter(query, con);
                using (SqlDa)
                {
                    DataTable allAnimalTable = new DataTable();

                    SqlDa.Fill(allAnimalTable);
                    int numcount = allAnimalTable.Rows.Count;
                    listAllAnimals.DisplayMemberPath = "Name";
                    listAllAnimals.SelectedValuePath = "Id";
                    listAllAnimals.ItemsSource = allAnimalTable.DefaultView;

                    //System.Diagnostics.Trace.WriteLine(numcount);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }//end function

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
           // System.Diagnostics.Trace.WriteLine("DeleteZoo_Click");
            Debug.WriteLine("DeleteZoo_Click");

            try
            {

                string query = "DELETE FROM Zoo WHERE Id = @ZooId";
                SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                con.Open();
                sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                sqliteCommand.ExecuteNonQuery();
                sqliteCommand.CommandText = query;
                sqliteCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                var result = sqliteCommand.ExecuteScalar();
                Debug.WriteLine("DeleteZoo_Click_try");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Debug.WriteLine("DeleteZoo_Click_before_close");
                con.Close();
                Debug.WriteLine("DeleteZoo_Click_before_Showzoos");
                showZoos();
            }

            /*This works but wont propogate FK deletions
             * try
            {

                string query = "DELETE FROM Zoo WHERE Id = @ZooId";
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, con);
                con.Open();
                sqliteCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                var result = sqliteCommand.ExecuteScalar();
                con.Close();
                showZoos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }//end function




        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("AddZoo_Click");


            if ( (myTextBox.Text).Trim() == "")
            {
                return;
            }

            try
            {

                string query = "INSERT INTO Zoo (Location) VALUES (@Location)";
                SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                con.Open();
                sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                sqliteCommand.ExecuteNonQuery();
                sqliteCommand.CommandText = query;
                sqliteCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                var result = sqliteCommand.ExecuteScalar();
                Debug.WriteLine("AddZoo_Click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
              
                con.Close();
             
                showZoos();
            }
        }

        private void addAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("addAnimalToZoo_Click");

            if(listZoos.SelectedValue != null && listAllAnimals.SelectedValue != null)
            {
                try
                {

                    string query = "INSERT INTO ZooAnimal (ZooId, AnimalId) VALUES (@ZooId,@AnimalId)";
                    SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                    con.Open();
                    sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                    sqliteCommand.ExecuteNonQuery();
                    sqliteCommand.CommandText = query;
                    sqliteCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                    sqliteCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                    var result = sqliteCommand.ExecuteScalar();
                    Debug.WriteLine("addAnimalToZoo_Click");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {

                    con.Close();
                    showAssociatedAnimals();
                }
            }

            else
            {
                return;
            }

        }

        private void removeAnimalFromZoo_Click(object sender, RoutedEventArgs e)
        {
            // NOT FINISHED

            Debug.WriteLine("removeAnimalFromZoo_Click");

            try
            {

                string query = "Delete FROM ZooAnimal WHERE ZooId = @ZooId AND AnimalId = @AnimalId";
                SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                con.Open();
                sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                sqliteCommand.ExecuteNonQuery();
                sqliteCommand.CommandText = query;
                sqliteCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqliteCommand.Parameters.AddWithValue("@AnimalId", listAssociatedAnimals.SelectedValue);
                var result = sqliteCommand.ExecuteScalar();
                Debug.WriteLine("removeAnimalFromZoo_Click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

                con.Close();
                showAssociatedAnimals();
            }



        }

        private void deleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("deleteAnimal_Click");

            try
            {

                string query = "DELETE FROM Animal WHERE Id = @Id";
                SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                con.Open();
                sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                sqliteCommand.ExecuteNonQuery();
                sqliteCommand.CommandText = query;
                sqliteCommand.Parameters.AddWithValue("@Id", listAllAnimals.SelectedValue);
                var result = sqliteCommand.ExecuteScalar();
                Debug.WriteLine("deleteAnimal_Click_try");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                showAnimal();
                showAssociatedAnimals();
            }

        }

        private void addAnimal_Click(object sender, RoutedEventArgs e)
        {
            
            Debug.WriteLine("addAnimal_Click");


            if ((myTextBox.Text).Trim() == "")
            {
                return;
            }

            try
            {
                //@Animal refers to the animal name taken from the textbox
                string query = "INSERT INTO Animal (Name) VALUES (@Animal)";
                SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                con.Open();
                sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                sqliteCommand.ExecuteNonQuery();
                sqliteCommand.CommandText = query;
                sqliteCommand.Parameters.AddWithValue("@Animal", myTextBox.Text);
                var result = sqliteCommand.ExecuteScalar();
                Debug.WriteLine("addAnimal_Click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

                con.Close();
                showAnimal();
            }
        }//end function

        private void showSelectedAnimalInTextBox()
        {
            try
            {

                string query = "SELECT Name from Animal where Id = @Id";
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, con);

                SQLiteDataAdapter SqlDa = new SQLiteDataAdapter(sqliteCommand);
                using (SqlDa)
                {

                    sqliteCommand.Parameters.AddWithValue("@Id", listAllAnimals.SelectedValue);
                    
                    DataTable animalDataTable  = new DataTable();

                    SqlDa.Fill(animalDataTable);
                    int numcount = animalDataTable.Rows.Count;
                    DebugTable(animalDataTable);
                    myTextBox.Text = animalDataTable.Rows[0]["Name"].ToString();
                   
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());

            }
        }//function


        private void showSelectedZooInTextBox()
        {
            try
            {

                string query = "SELECT Location from Zoo where Id = @ZooId";
                SQLiteCommand sqliteCommand = new SQLiteCommand(query, con);

                SQLiteDataAdapter SqlDa = new SQLiteDataAdapter(sqliteCommand);
                using (SqlDa)
                {

                    sqliteCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    DataTable zooDataTable = new DataTable();

                    SqlDa.Fill(zooDataTable);
                    int numcount = zooDataTable.Rows.Count;
                    DebugTable(zooDataTable);
                    myTextBox.Text = zooDataTable.Rows[0]["Location"].ToString();

                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());

            }
        }//function


        private void updateZoo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("updateZoo_Click");


            if ((myTextBox.Text).Trim() == "")
            {
                return;
            }

            try
            {

                string query = "UPDATE Zoo SET Location=@Location WHERE Id=@ZooId";
                SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                con.Open();
                sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                sqliteCommand.ExecuteNonQuery();
                sqliteCommand.CommandText = query;
                sqliteCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqliteCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                var result = sqliteCommand.ExecuteScalar();
                Debug.WriteLine("updateZoo_Click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

                con.Close();
                showZoos();
            }

        }//function

        private void updateAnimal_Click(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("updateAnimal_Click");


            if ((myTextBox.Text).Trim() == "")
            {
                return;
            }

            try
            {

                string query = "UPDATE Animal SET Name=@Name WHERE Id=@Id";
                SQLiteCommand sqliteCommand = new SQLiteCommand(con);
                con.Open();
                sqliteCommand.CommandText = "PRAGMA foreign_keys=ON";
                sqliteCommand.ExecuteNonQuery();
                sqliteCommand.CommandText = query;
                sqliteCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqliteCommand.Parameters.AddWithValue("@Id", listAllAnimals.SelectedValue);
                var result = sqliteCommand.ExecuteScalar();
                Debug.WriteLine("updateAnimal_Click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

                con.Close();
                showAnimal();
            }




        }//function





        public void DebugTable(DataTable table)
        {
            Debug.WriteLine("--- DebugTable(" + table.TableName + ") ---");
            int zeilen = table.Rows.Count;
            int spalten = table.Columns.Count;

            // Header
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string s = table.Columns[i].ToString();
                Debug.Write(String.Format("{0,-20} | ", s));
            }
            Debug.Write(Environment.NewLine);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Debug.Write("---------------------|-");
            }
            Debug.Write(Environment.NewLine);

            // Data
            for (int i = 0; i < zeilen; i++)
            {
                DataRow row = table.Rows[i];
                //Debug.WriteLine("{0} {1} ", row[0], row[1]);
                for (int j = 0; j < spalten; j++)
                {
                    string s = row[j].ToString();
                    if (s.Length > 20) s = s.Substring(0, 17) + "...";
                    Debug.Write(String.Format("{0,-20} | ", s));
                }
                Debug.Write(Environment.NewLine);
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Debug.Write("---------------------|-");
            }
            Debug.Write(Environment.NewLine);
        }//function

    } // end class
}//end namespace
