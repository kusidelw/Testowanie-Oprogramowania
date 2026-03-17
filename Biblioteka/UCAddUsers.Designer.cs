namespace Biblioteka
{
    partial class UCAddUsers
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_add_users = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAU_create_user = new System.Windows.Forms.Button();
            this.btnAU_clear_data = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_surname = new System.Windows.Forms.TextBox();
            this.txt_city = new System.Windows.Forms.TextBox();
            this.txt_postcode = new System.Windows.Forms.TextBox();
            this.txt_house_number = new System.Windows.Forms.TextBox();
            this.txt_pesel = new System.Windows.Forms.TextBox();
            this.txt_birth_date = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_phone_number = new System.Windows.Forms.TextBox();
            this.txt_street = new System.Windows.Forms.TextBox();
            this.txt_local_number = new System.Windows.Forms.TextBox();
            this.btn_female = new System.Windows.Forms.RadioButton();
            this.btn_male = new System.Windows.Forms.RadioButton();
            this.error_add_user_form = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucFindForgottenUsers1 = new Biblioteka.UCFindForgottenUsers();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error_add_user_form)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.Controls.Add(this.lbl_add_users);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1306, 32);
            this.panel1.TabIndex = 0;
            // 
            // lbl_add_users
            // 
            this.lbl_add_users.AutoSize = true;
            this.lbl_add_users.Location = new System.Drawing.Point(11, 8);
            this.lbl_add_users.Name = "lbl_add_users";
            this.lbl_add_users.Size = new System.Drawing.Size(119, 16);
            this.lbl_add_users.TabIndex = 0;
            this.lbl_add_users.Text = "Dodaj użytkownika";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel2.Controls.Add(this.btnAU_create_user);
            this.panel2.Controls.Add(this.btnAU_clear_data);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 553);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1306, 116);
            this.panel2.TabIndex = 1;
            // 
            // btnAU_create_user
            // 
            this.btnAU_create_user.Location = new System.Drawing.Point(723, 22);
            this.btnAU_create_user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAU_create_user.Name = "btnAU_create_user";
            this.btnAU_create_user.Size = new System.Drawing.Size(171, 70);
            this.btnAU_create_user.TabIndex = 4;
            this.btnAU_create_user.Text = "Utwórz użytkownika";
            this.btnAU_create_user.UseVisualStyleBackColor = true;
            this.btnAU_create_user.Click += new System.EventHandler(this.btnAU_create_user_Click);
            // 
            // btnAU_clear_data
            // 
            this.btnAU_clear_data.Location = new System.Drawing.Point(459, 22);
            this.btnAU_clear_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAU_clear_data.Name = "btnAU_clear_data";
            this.btnAU_clear_data.Size = new System.Drawing.Size(171, 70);
            this.btnAU_clear_data.TabIndex = 3;
            this.btnAU_clear_data.Text = "Wyczyść dane";
            this.btnAU_clear_data.UseVisualStyleBackColor = true;
            this.btnAU_clear_data.Click += new System.EventHandler(this.btnAU_clear_data_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(455, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Imie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nazwisko";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Miejscowość";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Kod pocztowy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Numer posesji";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(455, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "PESEL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(455, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Data urodzenia";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(455, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Płeć";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(452, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Adres email";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(452, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 13;
            this.label11.Text = "Numer telefonu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(455, 415);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "Ulica";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(455, 440);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 16);
            this.label13.TabIndex = 15;
            this.label13.Text = "Numer lokalu";
            // 
            // txt_login
            // 
            this.txt_login.Location = new System.Drawing.Point(565, 64);
            this.txt_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(224, 22);
            this.txt_login.TabIndex = 16;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(565, 102);
            this.txt_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(224, 22);
            this.txt_name.TabIndex = 17;
            // 
            // txt_surname
            // 
            this.txt_surname.Location = new System.Drawing.Point(565, 136);
            this.txt_surname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_surname.Name = "txt_surname";
            this.txt_surname.Size = new System.Drawing.Size(224, 22);
            this.txt_surname.TabIndex = 18;
            // 
            // txt_city
            // 
            this.txt_city.Location = new System.Drawing.Point(565, 171);
            this.txt_city.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_city.Name = "txt_city";
            this.txt_city.Size = new System.Drawing.Size(224, 22);
            this.txt_city.TabIndex = 19;
            // 
            // txt_postcode
            // 
            this.txt_postcode.Location = new System.Drawing.Point(565, 210);
            this.txt_postcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_postcode.Name = "txt_postcode";
            this.txt_postcode.Size = new System.Drawing.Size(224, 22);
            this.txt_postcode.TabIndex = 20;
            // 
            // txt_house_number
            // 
            this.txt_house_number.Location = new System.Drawing.Point(565, 243);
            this.txt_house_number.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_house_number.Name = "txt_house_number";
            this.txt_house_number.Size = new System.Drawing.Size(224, 22);
            this.txt_house_number.TabIndex = 21;
            // 
            // txt_pesel
            // 
            this.txt_pesel.Location = new System.Drawing.Point(565, 273);
            this.txt_pesel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_pesel.MaxLength = 11;
            this.txt_pesel.Name = "txt_pesel";
            this.txt_pesel.Size = new System.Drawing.Size(224, 22);
            this.txt_pesel.TabIndex = 22;
            // 
            // txt_birth_date
            // 
            this.txt_birth_date.Location = new System.Drawing.Point(565, 303);
            this.txt_birth_date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_birth_date.Name = "txt_birth_date";
            this.txt_birth_date.Size = new System.Drawing.Size(224, 22);
            this.txt_birth_date.TabIndex = 23;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(565, 362);
            this.txt_email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(224, 22);
            this.txt_email.TabIndex = 25;
            // 
            // txt_phone_number
            // 
            this.txt_phone_number.Location = new System.Drawing.Point(565, 390);
            this.txt_phone_number.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_phone_number.MaxLength = 9;
            this.txt_phone_number.Name = "txt_phone_number";
            this.txt_phone_number.Size = new System.Drawing.Size(224, 22);
            this.txt_phone_number.TabIndex = 26;
            // 
            // txt_street
            // 
            this.txt_street.Location = new System.Drawing.Point(565, 415);
            this.txt_street.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_street.Name = "txt_street";
            this.txt_street.Size = new System.Drawing.Size(224, 22);
            this.txt_street.TabIndex = 27;
            // 
            // txt_local_number
            // 
            this.txt_local_number.Location = new System.Drawing.Point(565, 441);
            this.txt_local_number.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_local_number.Name = "txt_local_number";
            this.txt_local_number.Size = new System.Drawing.Size(224, 22);
            this.txt_local_number.TabIndex = 28;
            // 
            // btn_female
            // 
            this.btn_female.AutoSize = true;
            this.btn_female.Location = new System.Drawing.Point(565, 332);
            this.btn_female.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_female.Name = "btn_female";
            this.btn_female.Size = new System.Drawing.Size(74, 20);
            this.btn_female.TabIndex = 29;
            this.btn_female.TabStop = true;
            this.btn_female.Text = "Kobieta";
            this.btn_female.UseVisualStyleBackColor = true;
            // 
            // btn_male
            // 
            this.btn_male.AutoSize = true;
            this.btn_male.Location = new System.Drawing.Point(698, 332);
            this.btn_male.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_male.Name = "btn_male";
            this.btn_male.Size = new System.Drawing.Size(94, 20);
            this.btn_male.TabIndex = 30;
            this.btn_male.TabStop = true;
            this.btn_male.Text = "Mężczyzna";
            this.btn_male.UseVisualStyleBackColor = true;
            // 
            // error_add_user_form
            // 
            this.error_add_user_form.ContainerControl = this;
            // 
            // ucFindForgottenUsers1
            // 
            this.ucFindForgottenUsers1.BackColor = System.Drawing.Color.Plum;
            this.ucFindForgottenUsers1.Location = new System.Drawing.Point(488, 186);
            this.ucFindForgottenUsers1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucFindForgottenUsers1.Name = "ucFindForgottenUsers1";
            this.ucFindForgottenUsers1.Size = new System.Drawing.Size(7, 6);
            this.ucFindForgottenUsers1.TabIndex = 5;
            // 
            // UCAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.btn_male);
            this.Controls.Add(this.btn_female);
            this.Controls.Add(this.txt_local_number);
            this.Controls.Add(this.txt_street);
            this.Controls.Add(this.txt_phone_number);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.txt_birth_date);
            this.Controls.Add(this.txt_pesel);
            this.Controls.Add(this.txt_house_number);
            this.Controls.Add(this.txt_postcode);
            this.Controls.Add(this.txt_city);
            this.Controls.Add(this.txt_surname);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_login);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ucFindForgottenUsers1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCAddUsers";
            this.Size = new System.Drawing.Size(1306, 669);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error_add_user_form)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_add_users;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAU_create_user;
        private System.Windows.Forms.Button btnAU_clear_data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private UCFindForgottenUsers ucFindForgottenUsers1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_surname;
        private System.Windows.Forms.TextBox txt_city;
        private System.Windows.Forms.TextBox txt_postcode;
        private System.Windows.Forms.TextBox txt_house_number;
        private System.Windows.Forms.TextBox txt_pesel;
        private System.Windows.Forms.TextBox txt_birth_date;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_phone_number;
        private System.Windows.Forms.TextBox txt_street;
        private System.Windows.Forms.TextBox txt_local_number;
        private System.Windows.Forms.RadioButton btn_female;
        private System.Windows.Forms.RadioButton btn_male;
        private System.Windows.Forms.ErrorProvider error_add_user_form;
    }
}
