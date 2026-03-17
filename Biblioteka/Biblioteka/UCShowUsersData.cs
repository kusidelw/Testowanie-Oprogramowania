using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Biblioteka
{
    public partial class UCShowUsersData : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["BibliotekaConn"].ConnectionString;

        private int currentUserId;

        public UCShowUsersData()
        {
            InitializeComponent();
            lbl_anonymization_message.Visible = false;
        }

        public void ZaladujDaneUzytkownika(int userId)
        {
            currentUserId = userId;
            string query = "SELECT * FROM Uzytkownicy WHERE ID = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //DANE OSOBOWE
                            txt_login.Text = reader["Login"].ToString();
                            txt_name.Text = reader["Imie"].ToString();
                            txt_surname.Text = reader["Nazwisko"].ToString();
                            txt_PESEL.Text = reader["PESEL"].ToString();
                            txt_birth_date.Text = Convert.ToDateTime(reader["DataUrodzenia"]).ToShortDateString();
                            txt_gender.Text = reader["Plec"].ToString() == "K" ? "Kobieta" : "Mężczyzna";

                            //DANE KONTAKTOWE
                            txt_mail.Text = reader["Email"].ToString();
                            txt_phone_number.Text = reader["Telefon"].ToString();

                            //ADRES
                            txt_street.Text = reader["Ulica"].ToString();
                            txt_zip_code.Text = reader["KodPocztowy"].ToString();
                            txt_town.Text = reader["Miejscowosc"].ToString();
                            txt_property_number.Text = reader["NumerPosesji"].ToString();
                            txtlbl_apartment_number.Text = reader["NumerLokalu"].ToString();

                            // OBSŁUGA RODO
                            bool czyZapomniany = Convert.ToBoolean(reader["CzyZapomniany"]);

                            if (czyZapomniany)
                            {
                                lbl_anonymization_message.Visible = true;
                                btn_edit_data.Enabled = false; 
                                btn_edit_data.BackColor = Color.Gray;
                            }
                            else
                            {
                                lbl_anonymization_message.Visible = false;
                                btn_edit_data.Enabled = true;
                                btn_edit_data.BackColor = Color.DarkSeaGreen;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Przycisk "Wróć do listy"
        private void btn_back_to_list_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.FindForm();
            if (mainForm != null)
            {
                mainForm.WrocDoWyszukiwarki(); 
            }
        }

        // Przycisk "Edytuj dane"
        private void btn_edit_data_Click(object sender, EventArgs e)
        {
            Form1 mainForm = (Form1)this.FindForm();
            if (mainForm != null)
            {
                mainForm.PrzejdzDoEdycji(currentUserId); 
            }
        }
    }
}