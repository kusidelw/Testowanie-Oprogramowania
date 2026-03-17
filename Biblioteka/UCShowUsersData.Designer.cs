namespace Biblioteka
{
    partial class UCShowUsersData
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
            this.lbl_show_users_data = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_personal_data = new System.Windows.Forms.Label();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_surname = new System.Windows.Forms.Label();
            this.lbl_PESEL = new System.Windows.Forms.Label();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_surname = new System.Windows.Forms.TextBox();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.txt_PESEL = new System.Windows.Forms.TextBox();
            this.txt_phone_number = new System.Windows.Forms.TextBox();
            this.lbl_phone_number = new System.Windows.Forms.Label();
            this.txt_gender = new System.Windows.Forms.TextBox();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.txt_birth_date = new System.Windows.Forms.TextBox();
            this.lbl_birth_date = new System.Windows.Forms.Label();
            this.lbl_contact_data = new System.Windows.Forms.Label();
            this.lbl_address_data = new System.Windows.Forms.Label();
            this.txt_zip_code = new System.Windows.Forms.TextBox();
            this.lbl_zip_code = new System.Windows.Forms.Label();
            this.txt_property_number = new System.Windows.Forms.TextBox();
            this.lbl_property_number = new System.Windows.Forms.Label();
            this.txt_town = new System.Windows.Forms.TextBox();
            this.txt_street = new System.Windows.Forms.TextBox();
            this.lbl_town = new System.Windows.Forms.Label();
            this.lbl_street = new System.Windows.Forms.Label();
            this.txtlbl_apartment_number = new System.Windows.Forms.TextBox();
            this.lbl_apartment_number = new System.Windows.Forms.Label();
            this.btn_back_to_list = new System.Windows.Forms.Button();
            this.btn_edit_data = new System.Windows.Forms.Button();
            this.lbl_anonymization_message = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_show_users_data
            // 
            this.lbl_show_users_data.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_show_users_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_show_users_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_show_users_data.Location = new System.Drawing.Point(0, 20);
            this.lbl_show_users_data.Name = "lbl_show_users_data";
            this.lbl_show_users_data.Size = new System.Drawing.Size(1081, 29);
            this.lbl_show_users_data.TabIndex = 0;
            this.lbl_show_users_data.Text = "KARTA UŻYTKOWNIKA";
            this.lbl_show_users_data.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_show_users_data);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 63);
            this.panel1.TabIndex = 2;
            // 
            // lbl_personal_data
            // 
            this.lbl_personal_data.AutoSize = true;
            this.lbl_personal_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_personal_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_personal_data.Location = new System.Drawing.Point(36, 133);
            this.lbl_personal_data.Name = "lbl_personal_data";
            this.lbl_personal_data.Size = new System.Drawing.Size(221, 32);
            this.lbl_personal_data.TabIndex = 3;
            this.lbl_personal_data.Text = "Dane Osobowe";
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_login.Location = new System.Drawing.Point(83, 174);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(66, 25);
            this.lbl_login.TabIndex = 4;
            this.lbl_login.Text = "Login:";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_name.Location = new System.Drawing.Point(83, 210);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(54, 25);
            this.lbl_name.TabIndex = 5;
            this.lbl_name.Text = "Imię:";
            // 
            // lbl_surname
            // 
            this.lbl_surname.AutoSize = true;
            this.lbl_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_surname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_surname.Location = new System.Drawing.Point(83, 246);
            this.lbl_surname.Name = "lbl_surname";
            this.lbl_surname.Size = new System.Drawing.Size(102, 25);
            this.lbl_surname.TabIndex = 6;
            this.lbl_surname.Text = "Nazwisko:";
            // 
            // lbl_PESEL
            // 
            this.lbl_PESEL.AutoSize = true;
            this.lbl_PESEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PESEL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_PESEL.Location = new System.Drawing.Point(83, 282);
            this.lbl_PESEL.Name = "lbl_PESEL";
            this.lbl_PESEL.Size = new System.Drawing.Size(82, 25);
            this.lbl_PESEL.TabIndex = 7;
            this.lbl_PESEL.Text = "PESEL:";
            // 
            // lbl_mail
            // 
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_mail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_mail.Location = new System.Drawing.Point(83, 459);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(121, 25);
            this.lbl_mail.TabIndex = 8;
            this.lbl_mail.Text = "Adres email:";
            // 
            // txt_login
            // 
            this.txt_login.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_login.Location = new System.Drawing.Point(265, 174);
            this.txt_login.Name = "txt_login";
            this.txt_login.ReadOnly = true;
            this.txt_login.Size = new System.Drawing.Size(264, 30);
            this.txt_login.TabIndex = 10;
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_name.Location = new System.Drawing.Point(265, 210);
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            this.txt_name.Size = new System.Drawing.Size(264, 30);
            this.txt_name.TabIndex = 11;
            // 
            // txt_surname
            // 
            this.txt_surname.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_surname.Location = new System.Drawing.Point(265, 246);
            this.txt_surname.Name = "txt_surname";
            this.txt_surname.ReadOnly = true;
            this.txt_surname.Size = new System.Drawing.Size(264, 30);
            this.txt_surname.TabIndex = 12;
            // 
            // txt_mail
            // 
            this.txt_mail.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_mail.Location = new System.Drawing.Point(265, 459);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.ReadOnly = true;
            this.txt_mail.Size = new System.Drawing.Size(264, 30);
            this.txt_mail.TabIndex = 13;
            // 
            // txt_PESEL
            // 
            this.txt_PESEL.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_PESEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_PESEL.Location = new System.Drawing.Point(265, 282);
            this.txt_PESEL.MaxLength = 11;
            this.txt_PESEL.Name = "txt_PESEL";
            this.txt_PESEL.ReadOnly = true;
            this.txt_PESEL.Size = new System.Drawing.Size(264, 30);
            this.txt_PESEL.TabIndex = 13;
            // 
            // txt_phone_number
            // 
            this.txt_phone_number.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_phone_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_phone_number.Location = new System.Drawing.Point(265, 495);
            this.txt_phone_number.Name = "txt_phone_number";
            this.txt_phone_number.ReadOnly = true;
            this.txt_phone_number.Size = new System.Drawing.Size(264, 30);
            this.txt_phone_number.TabIndex = 16;
            // 
            // lbl_phone_number
            // 
            this.lbl_phone_number.AutoSize = true;
            this.lbl_phone_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_phone_number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_phone_number.Location = new System.Drawing.Point(83, 495);
            this.lbl_phone_number.Name = "lbl_phone_number";
            this.lbl_phone_number.Size = new System.Drawing.Size(150, 25);
            this.lbl_phone_number.TabIndex = 15;
            this.lbl_phone_number.Text = "Numer telefonu:";
            // 
            // txt_gender
            // 
            this.txt_gender.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_gender.Location = new System.Drawing.Point(265, 354);
            this.txt_gender.Name = "txt_gender";
            this.txt_gender.ReadOnly = true;
            this.txt_gender.Size = new System.Drawing.Size(264, 30);
            this.txt_gender.TabIndex = 18;
            // 
            // lbl_gender
            // 
            this.lbl_gender.AutoSize = true;
            this.lbl_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_gender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_gender.Location = new System.Drawing.Point(83, 354);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(56, 25);
            this.lbl_gender.TabIndex = 17;
            this.lbl_gender.Text = "Płeć:";
            // 
            // txt_birth_date
            // 
            this.txt_birth_date.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_birth_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_birth_date.Location = new System.Drawing.Point(265, 318);
            this.txt_birth_date.Name = "txt_birth_date";
            this.txt_birth_date.ReadOnly = true;
            this.txt_birth_date.Size = new System.Drawing.Size(264, 30);
            this.txt_birth_date.TabIndex = 20;
            // 
            // lbl_birth_date
            // 
            this.lbl_birth_date.AutoSize = true;
            this.lbl_birth_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_birth_date.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_birth_date.Location = new System.Drawing.Point(83, 318);
            this.lbl_birth_date.Name = "lbl_birth_date";
            this.lbl_birth_date.Size = new System.Drawing.Size(153, 25);
            this.lbl_birth_date.TabIndex = 19;
            this.lbl_birth_date.Text = "Data Urodzenia:";
            // 
            // lbl_contact_data
            // 
            this.lbl_contact_data.AutoSize = true;
            this.lbl_contact_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_contact_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_contact_data.Location = new System.Drawing.Point(36, 414);
            this.lbl_contact_data.Name = "lbl_contact_data";
            this.lbl_contact_data.Size = new System.Drawing.Size(253, 32);
            this.lbl_contact_data.TabIndex = 21;
            this.lbl_contact_data.Text = "Dane Kontaktowe";
            // 
            // lbl_address_data
            // 
            this.lbl_address_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_address_data.AutoSize = true;
            this.lbl_address_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_address_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_address_data.Location = new System.Drawing.Point(562, 133);
            this.lbl_address_data.Name = "lbl_address_data";
            this.lbl_address_data.Size = new System.Drawing.Size(286, 32);
            this.lbl_address_data.TabIndex = 22;
            this.lbl_address_data.Text = "Adres zamieszkania";
            // 
            // txt_zip_code
            // 
            this.txt_zip_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_zip_code.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_zip_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_zip_code.Location = new System.Drawing.Point(791, 204);
            this.txt_zip_code.Name = "txt_zip_code";
            this.txt_zip_code.ReadOnly = true;
            this.txt_zip_code.Size = new System.Drawing.Size(264, 30);
            this.txt_zip_code.TabIndex = 30;
            // 
            // lbl_zip_code
            // 
            this.lbl_zip_code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_zip_code.AutoSize = true;
            this.lbl_zip_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_zip_code.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_zip_code.Location = new System.Drawing.Point(599, 204);
            this.lbl_zip_code.Name = "lbl_zip_code";
            this.lbl_zip_code.Size = new System.Drawing.Size(141, 25);
            this.lbl_zip_code.TabIndex = 29;
            this.lbl_zip_code.Text = "Kod pocztowy:";
            // 
            // txt_property_number
            // 
            this.txt_property_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_property_number.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_property_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_property_number.Location = new System.Drawing.Point(791, 276);
            this.txt_property_number.Name = "txt_property_number";
            this.txt_property_number.ReadOnly = true;
            this.txt_property_number.Size = new System.Drawing.Size(264, 30);
            this.txt_property_number.TabIndex = 28;
            // 
            // lbl_property_number
            // 
            this.lbl_property_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_property_number.AutoSize = true;
            this.lbl_property_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_property_number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_property_number.Location = new System.Drawing.Point(599, 276);
            this.lbl_property_number.Name = "lbl_property_number";
            this.lbl_property_number.Size = new System.Drawing.Size(142, 25);
            this.lbl_property_number.TabIndex = 27;
            this.lbl_property_number.Text = "Numer posesji:";
            // 
            // txt_town
            // 
            this.txt_town.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_town.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_town.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_town.Location = new System.Drawing.Point(791, 240);
            this.txt_town.MaxLength = 11;
            this.txt_town.Name = "txt_town";
            this.txt_town.ReadOnly = true;
            this.txt_town.Size = new System.Drawing.Size(264, 30);
            this.txt_town.TabIndex = 26;
            // 
            // txt_street
            // 
            this.txt_street.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_street.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_street.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_street.Location = new System.Drawing.Point(791, 168);
            this.txt_street.Name = "txt_street";
            this.txt_street.ReadOnly = true;
            this.txt_street.Size = new System.Drawing.Size(264, 30);
            this.txt_street.TabIndex = 25;
            // 
            // lbl_town
            // 
            this.lbl_town.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_town.AutoSize = true;
            this.lbl_town.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_town.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_town.Location = new System.Drawing.Point(599, 240);
            this.lbl_town.Name = "lbl_town";
            this.lbl_town.Size = new System.Drawing.Size(130, 25);
            this.lbl_town.TabIndex = 24;
            this.lbl_town.Text = "Miejscowość:";
            // 
            // lbl_street
            // 
            this.lbl_street.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_street.AutoSize = true;
            this.lbl_street.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_street.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_street.Location = new System.Drawing.Point(599, 168);
            this.lbl_street.Name = "lbl_street";
            this.lbl_street.Size = new System.Drawing.Size(61, 25);
            this.lbl_street.TabIndex = 23;
            this.lbl_street.Text = "Ulica:";
            // 
            // txtlbl_apartment_number
            // 
            this.txtlbl_apartment_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlbl_apartment_number.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtlbl_apartment_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtlbl_apartment_number.Location = new System.Drawing.Point(791, 312);
            this.txtlbl_apartment_number.Name = "txtlbl_apartment_number";
            this.txtlbl_apartment_number.ReadOnly = true;
            this.txtlbl_apartment_number.Size = new System.Drawing.Size(264, 30);
            this.txtlbl_apartment_number.TabIndex = 32;
            // 
            // lbl_apartment_number
            // 
            this.lbl_apartment_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_apartment_number.AutoSize = true;
            this.lbl_apartment_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_apartment_number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_apartment_number.Location = new System.Drawing.Point(599, 312);
            this.lbl_apartment_number.Name = "lbl_apartment_number";
            this.lbl_apartment_number.Size = new System.Drawing.Size(137, 25);
            this.lbl_apartment_number.TabIndex = 31;
            this.lbl_apartment_number.Text = "Numer  lokalu:";
            // 
            // btn_back_to_list
            // 
            this.btn_back_to_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_back_to_list.AutoSize = true;
            this.btn_back_to_list.BackColor = System.Drawing.Color.LightCoral;
            this.btn_back_to_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_back_to_list.Location = new System.Drawing.Point(88, 575);
            this.btn_back_to_list.Name = "btn_back_to_list";
            this.btn_back_to_list.Size = new System.Drawing.Size(223, 71);
            this.btn_back_to_list.TabIndex = 33;
            this.btn_back_to_list.Text = "WRÓĆ DO LISTY";
            this.btn_back_to_list.UseVisualStyleBackColor = false;
            this.btn_back_to_list.Click += new System.EventHandler(this.btn_back_to_list_Click);
            // 
            // btn_edit_data
            // 
            this.btn_edit_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_edit_data.AutoSize = true;
            this.btn_edit_data.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_edit_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_edit_data.Location = new System.Drawing.Point(791, 575);
            this.btn_edit_data.Name = "btn_edit_data";
            this.btn_edit_data.Size = new System.Drawing.Size(223, 71);
            this.btn_edit_data.TabIndex = 34;
            this.btn_edit_data.Text = "EDYTUJ DANE";
            this.btn_edit_data.UseVisualStyleBackColor = false;
            this.btn_edit_data.Click += new System.EventHandler(this.btn_edit_data_Click);
            // 
            // lbl_anonymization_message
            // 
            this.lbl_anonymization_message.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_anonymization_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_anonymization_message.ForeColor = System.Drawing.Color.Red;
            this.lbl_anonymization_message.Location = new System.Drawing.Point(5, 82);
            this.lbl_anonymization_message.Name = "lbl_anonymization_message";
            this.lbl_anonymization_message.Size = new System.Drawing.Size(1073, 25);
            this.lbl_anonymization_message.TabIndex = 35;
            this.lbl_anonymization_message.Text = "UŻYTKOWNIK ZANONIMIZOWANY (RODO)";
            this.lbl_anonymization_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCShowUsersData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lbl_anonymization_message);
            this.Controls.Add(this.btn_edit_data);
            this.Controls.Add(this.btn_back_to_list);
            this.Controls.Add(this.txtlbl_apartment_number);
            this.Controls.Add(this.lbl_apartment_number);
            this.Controls.Add(this.txt_zip_code);
            this.Controls.Add(this.lbl_zip_code);
            this.Controls.Add(this.txt_property_number);
            this.Controls.Add(this.lbl_property_number);
            this.Controls.Add(this.txt_town);
            this.Controls.Add(this.txt_street);
            this.Controls.Add(this.lbl_town);
            this.Controls.Add(this.lbl_street);
            this.Controls.Add(this.lbl_address_data);
            this.Controls.Add(this.lbl_contact_data);
            this.Controls.Add(this.txt_birth_date);
            this.Controls.Add(this.lbl_birth_date);
            this.Controls.Add(this.txt_gender);
            this.Controls.Add(this.lbl_gender);
            this.Controls.Add(this.txt_phone_number);
            this.Controls.Add(this.lbl_phone_number);
            this.Controls.Add(this.lbl_personal_data);
            this.Controls.Add(this.txt_PESEL);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.txt_surname);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_login);
            this.Controls.Add(this.lbl_mail);
            this.Controls.Add(this.lbl_PESEL);
            this.Controls.Add(this.lbl_surname);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCShowUsersData";
            this.Size = new System.Drawing.Size(1081, 690);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_show_users_data;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_personal_data;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_surname;
        private System.Windows.Forms.Label lbl_PESEL;
        private System.Windows.Forms.Label lbl_mail;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_surname;
        private System.Windows.Forms.TextBox txt_mail;
        private System.Windows.Forms.TextBox txt_PESEL;
        private System.Windows.Forms.TextBox txt_phone_number;
        private System.Windows.Forms.Label lbl_phone_number;
        private System.Windows.Forms.TextBox txt_gender;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.TextBox txt_birth_date;
        private System.Windows.Forms.Label lbl_birth_date;
        private System.Windows.Forms.Label lbl_contact_data;
        private System.Windows.Forms.Label lbl_address_data;
        private System.Windows.Forms.TextBox txt_zip_code;
        private System.Windows.Forms.Label lbl_zip_code;
        private System.Windows.Forms.TextBox txt_property_number;
        private System.Windows.Forms.Label lbl_property_number;
        private System.Windows.Forms.TextBox txt_town;
        private System.Windows.Forms.TextBox txt_street;
        private System.Windows.Forms.Label lbl_town;
        private System.Windows.Forms.Label lbl_street;
        private System.Windows.Forms.TextBox txtlbl_apartment_number;
        private System.Windows.Forms.Label lbl_apartment_number;
        private System.Windows.Forms.Button btn_back_to_list;
        private System.Windows.Forms.Button btn_edit_data;
        private System.Windows.Forms.Label lbl_anonymization_message;
    }
}
