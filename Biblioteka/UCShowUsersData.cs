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

namespace Biblioteka
{
    public partial class UCShowUsersData : UserControl
    {
        private string connectionString = "Server=localhost;Database=BibliotekaDB;Integrated Security=True;TrustServerCertificate=True;";
        public UCShowUsersData()
        {
            InitializeComponent();

            lbl_anonymization_message.Visible = false;
        }

        /// <summary>
        /// Główna metoda ładująca dane z bazy do pól na ekranie
        /// </summary>
        /// <param name="userId">ID wybranego użytkownika z listy</param>
        public void ZaladujDaneUzytkownika(int userId)
        {
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
                            //Dane Osobowe
                            txt_login.Text = reader["Login"].ToString();
                            txt_name.Text = reader["Imie"].ToString();
                            txt_surname.Text = reader["Nazwisko"].ToString();
                            txt_PESEL.Text = reader["PESEL"].ToString();
                            txt_birth_date.Text = Convert.ToDateTime(reader["DataUrodzenia"]).ToShortDateString();
                            txt_gender.Text = reader["Plec"].ToString() == "K" ? "Kobieta" : "Mężczyzna";

                            //Dane Konatktowe
                            txt_mail.Text = reader["Email"].ToString();
                            txt_phone_number.Text = reader["Telefon"].ToString();

                            //Adres
                            txt_street.Text = reader["Ulica"].ToString();
                            txt_zip_code.Text = reader["KodPocztowy"].ToString();
                            txt_town.Text = reader["Miejscowosc"].ToString();
                            txt_property_number.Text = reader["NumerPosesji"].ToString();
                            txtlbl_apartment_number.Text = reader["NumerLokalu"].ToString();

                            //Rodo
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

        // Obsługa przycisku powrotu 
        private void btn_back_to_list_Click(object sender, EventArgs e)
        {
            Form1 main = (Form1)this.FindForm();

            UCFindUsers findUsers = new UCFindUsers();

            main.PokazWidokZeStanem(findUsers);
        }
    }
}
