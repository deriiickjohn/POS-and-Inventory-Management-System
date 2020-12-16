using POS_and_Inventory_Management_System.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace POS_and_Inventory_Management_System.Windows
{
    /// <summary>
    /// Interaction logic for ManageUser.xaml
    /// </summary>
    public partial class ManageUser : Window
    {
        DBConnection dbCon = new DBConnection();
        SqlConnection cn;
        SqlDataReader dr;
        List<Users> user = new List<Users>();
        int roleId;

        public ManageUser()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            cn = new SqlConnection(dbCon.Connection());


            cn.Open();

            this.LoadRoles();
            this.InitializedButtonState();

        }

        private void UpdateUsers()
        {



            dataGridUser.ItemsSource = GetUser();
            dataGridUser.Items.Refresh();


        }

        private List<Users> GetUser()
        {

            user.Clear();

            SqlCommand comUsers = new SqlCommand("SELECT u.UserId, u.Fullname, u.Username, u.Password, u.RoleId, u.Contact,u.Email, r.RoleName from ManageUser as u inner join Role as r on r.RoleId = u.RoleId", cn);

            dr = comUsers.ExecuteReader();

            while (dr.Read())
            {
                user.Add(new Users
                {
                    UserId = (int)dr[0],
                    Fullname = dr[1].ToString(),
                    Username = dr[2].ToString(),
                    Password = dr[3].ToString(),
                    RoleId = (int)dr[4],
                    Contact = (int)dr[5],
                    Email = dr[6].ToString(),
                    RoleName = dr[7].ToString()

                });
            }

            dr.Close();



            return user;
        }


        private void AddUpdateDelete(string sql, string state)
        {



            SqlCommand comAUD = new SqlCommand(sql, cn);



            comAUD.Parameters.AddWithValue("Fullname", textBoxFullName.Text);
            comAUD.Parameters.AddWithValue("Username", textBoxUserName.Text);
            comAUD.Parameters.AddWithValue("Password", textBoxPassword.Password);
            comAUD.Parameters.AddWithValue("Contact", textBoxContact.Text);
            comAUD.Parameters.AddWithValue("Email", textBoxEmail.Text);
            comAUD.Parameters.AddWithValue("RoleId", GetRoleID());
            comAUD.Parameters.AddWithValue("UserId", Int32.Parse(labelUserId.Text));
            comAUD.ExecuteNonQuery();

            if (state == "Add") MessageBox.Show("User added successfully");
            else if (state == "Update") MessageBox.Show("User updated successfully");
            else if (state == "Delete") MessageBox.Show("User deleted successfully");

            this.InitializedButtonState();
            this.UpdateUsers();
            this.Clear();


        }

        private void LoadRoles()
        {


            SqlCommand com = new SqlCommand("SELECT RoleName from Role", cn);
            dr = com.ExecuteReader();

            while (dr.Read())
            {
                comboBoxRole.Items.Add(dr[0].ToString());
            }

            dr.Close();
        }

        private int GetRoleID()
        {

            SqlCommand com = new SqlCommand("SELECT RoleId from Role where RoleName like '" + comboBoxRole.SelectedItem.ToString() + "'", cn);

            dr = com.ExecuteReader();

            dr.Read();

            if (dr.HasRows)
            {
                roleId = (int)dr[0];
            }

            dr.Close();

            return roleId;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.UpdateUsers();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            cn.Close();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.AddUpdateDelete("UPDATE ManageUser SET Fullname = @Fullname,Username = @Username, Password = @Password,RoleId = @RoleId, Contact = @Contact, Email = @Email Where UserId = @UserId", "Update");

        }

        private void buttonNew_Click(object sender, RoutedEventArgs e)
        {
            this.AddUpdateDelete("INSERT INTO ManageUser (Fullname,Username,Password,RoleId,Contact,Email) VALUES (@Fullname,@Username,@Password,@RoleId,@Contact,@Email)", "Add");



        }
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();
        }

        private void dataGridUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView row = dg.SelectedItem as DataRowView;

            for (int i = 0; i < user.Count; i++)
            {
                if (dg.SelectedIndex == i)
                {
                    labelUserId.Text = user[i].UserId.ToString();
                    textBoxFullName.Text = user[i].Fullname;
                    textBoxUserName.Text = user[i].Username;
                    textBoxPassword.Password = user[i].Password;
                    textBoxContact.Text = user[i].Contact.ToString();
                    comboBoxRole.Text = user[i].RoleName;
                    textBoxEmail.Text = user[i].Email;

                }
            }

            buttonUpdate.IsEnabled = true;
            buttonNew.IsEnabled = false;
            buttonDelete.IsEnabled = true;

        }

        private void InitializedButtonState()
        {

            buttonUpdate.IsEnabled = false;
            buttonDelete.IsEnabled = false;
            buttonNew.IsEnabled = true;
            labelUserId.Text = (GetUser()[GetUser().Count - 1].UserId + 1).ToString();
        }

        private void Clear()
        {

            labelUserId.Text = "";
            textBoxFullName.Text = "";
            textBoxUserName.Text = "";
            textBoxPassword.Password = "";
            textBoxContact.Text = "";
            comboBoxRole.Text = "";
            textBoxEmail.Text = "";

        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            this.Clear();
            this.InitializedButtonState();
        }
    }
}
