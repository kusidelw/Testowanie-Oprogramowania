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
            this.error_add_user_form = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAU_create_user = new System.Windows.Forms.Button();
            this.btn_anuluj = new System.Windows.Forms.Button();
            this.cb_gender = new System.Windows.Forms.ComboBox();
            this.txtlbl_apartment_number = new System.Windows.Forms.TextBox();
            this.lbl_apartment_number = new System.Windows.Forms.Label();
            this.txt_zip_code = new System.Windows.Forms.TextBox();
            this.lbl_zip_code = new System.Windows.Forms.Label();
            this.txt_property_number = new System.Windows.Forms.TextBox();
            this.lbl_property_number = new System.Windows.Forms.Label();
            this.txt_town = new System.Windows.Forms.TextBox();
            this.txt_street = new System.Windows.Forms.TextBox();
            this.lbl_town = new System.Windows.Forms.Label();
            this.lbl_street = new System.Windows.Forms.Label();
            this.lbl_address_data = new System.Windows.Forms.Label();
            this.lbl_contact_data = new System.Windows.Forms.Label();
            this.txt_birth_date = new System.Windows.Forms.TextBox();
            this.lbl_birth_date = new System.Windows.Forms.Label();
            this.lbl_gender = new System.Windows.Forms.Label();
            this.txt_phone_number = new System.Windows.Forms.TextBox();
            this.lbl_phone_number = new System.Windows.Forms.Label();
            this.lbl_personal_data = new System.Windows.Forms.Label();
            this.txt_PESEL = new System.Windows.Forms.TextBox();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.txt_surname = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.lbl_PESEL = new System.Windows.Forms.Label();
            this.lbl_surname = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_login = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error_add_user_form)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lbl_add_users);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 61);
            this.panel1.TabIndex = 0;
            // 
            // lbl_add_users
            // 
            this.lbl_add_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_add_users.Location = new System.Drawing.Point(3, 9);
            this.lbl_add_users.Name = "lbl_add_users";
            this.lbl_add_users.Size = new System.Drawing.Size(1179, 34);
            this.lbl_add_users.TabIndex = 0;
            this.lbl_add_users.Text = "DODAJ UŻYTKOWNIKA";
            this.lbl_add_users.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // error_add_user_form
            // 
            this.error_add_user_form.ContainerControl = this;
            // 
            // btnAU_create_user
            // 
            this.btnAU_create_user.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAU_create_user.AutoSize = true;
            this.btnAU_create_user.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAU_create_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAU_create_user.Location = new System.Drawing.Point(848, 526);
            this.btnAU_create_user.Name = "btnAU_create_user";
            this.btnAU_create_user.Size = new System.Drawing.Size(282, 89);
            this.btnAU_create_user.TabIndex = 96;
            this.btnAU_create_user.Text = "UTWÓRZ UŻYTKOWNIKA";
            this.btnAU_create_user.UseVisualStyleBackColor = false;
            this.btnAU_create_user.Click += new System.EventHandler(this.btnAU_create_user_Click);
            // 
            // btn_anuluj
            // 
            this.btn_anuluj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_anuluj.AutoSize = true;
            this.btn_anuluj.BackColor = System.Drawing.Color.LightCoral;
            this.btn_anuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_anuluj.Location = new System.Drawing.Point(97, 526);
            this.btn_anuluj.Name = "btn_anuluj";
            this.btn_anuluj.Size = new System.Drawing.Size(282, 89);
            this.btn_anuluj.TabIndex = 95;
            this.btn_anuluj.Text = "AULUJ DODAWANIE";
            this.btn_anuluj.UseVisualStyleBackColor = false;
            this.btn_anuluj.Click += new System.EventHandler(this.btn_anuluj_Click_1);
            // 
            // cb_gender
            // 
            this.cb_gender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_gender.FormattingEnabled = true;
            this.cb_gender.Location = new System.Drawing.Point(274, 307);
            this.cb_gender.Name = "cb_gender";
            this.cb_gender.Size = new System.Drawing.Size(264, 33);
            this.cb_gender.TabIndex = 94;
            // 
            // txtlbl_apartment_number
            // 
            this.txtlbl_apartment_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlbl_apartment_number.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtlbl_apartment_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtlbl_apartment_number.Location = new System.Drawing.Point(866, 254);
            this.txtlbl_apartment_number.Name = "txtlbl_apartment_number";
            this.txtlbl_apartment_number.Size = new System.Drawing.Size(264, 30);
            this.txtlbl_apartment_number.TabIndex = 93;
            // 
            // lbl_apartment_number
            // 
            this.lbl_apartment_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_apartment_number.AutoSize = true;
            this.lbl_apartment_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_apartment_number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_apartment_number.Location = new System.Drawing.Point(674, 254);
            this.lbl_apartment_number.Name = "lbl_apartment_number";
            this.lbl_apartment_number.Size = new System.Drawing.Size(137, 25);
            this.lbl_apartment_number.TabIndex = 92;
            this.lbl_apartment_number.Text = "Numer  lokalu:";
            // 
            // txt_zip_code
            // 
            this.txt_zip_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_zip_code.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_zip_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_zip_code.Location = new System.Drawing.Point(866, 146);
            this.txt_zip_code.Name = "txt_zip_code";
            this.txt_zip_code.Size = new System.Drawing.Size(264, 30);
            this.txt_zip_code.TabIndex = 91;
            // 
            // lbl_zip_code
            // 
            this.lbl_zip_code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_zip_code.AutoSize = true;
            this.lbl_zip_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_zip_code.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_zip_code.Location = new System.Drawing.Point(674, 146);
            this.lbl_zip_code.Name = "lbl_zip_code";
            this.lbl_zip_code.Size = new System.Drawing.Size(141, 25);
            this.lbl_zip_code.TabIndex = 90;
            this.lbl_zip_code.Text = "Kod pocztowy:";
            // 
            // txt_property_number
            // 
            this.txt_property_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_property_number.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_property_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_property_number.Location = new System.Drawing.Point(866, 218);
            this.txt_property_number.Name = "txt_property_number";
            this.txt_property_number.Size = new System.Drawing.Size(264, 30);
            this.txt_property_number.TabIndex = 89;
            // 
            // lbl_property_number
            // 
            this.lbl_property_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_property_number.AutoSize = true;
            this.lbl_property_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_property_number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_property_number.Location = new System.Drawing.Point(674, 218);
            this.lbl_property_number.Name = "lbl_property_number";
            this.lbl_property_number.Size = new System.Drawing.Size(142, 25);
            this.lbl_property_number.TabIndex = 88;
            this.lbl_property_number.Text = "Numer posesji:";
            // 
            // txt_town
            // 
            this.txt_town.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_town.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_town.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_town.Location = new System.Drawing.Point(866, 182);
            this.txt_town.MaxLength = 11;
            this.txt_town.Name = "txt_town";
            this.txt_town.Size = new System.Drawing.Size(264, 30);
            this.txt_town.TabIndex = 87;
            // 
            // txt_street
            // 
            this.txt_street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_street.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_street.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_street.Location = new System.Drawing.Point(866, 110);
            this.txt_street.Name = "txt_street";
            this.txt_street.Size = new System.Drawing.Size(264, 30);
            this.txt_street.TabIndex = 86;
            // 
            // lbl_town
            // 
            this.lbl_town.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_town.AutoSize = true;
            this.lbl_town.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_town.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_town.Location = new System.Drawing.Point(674, 182);
            this.lbl_town.Name = "lbl_town";
            this.lbl_town.Size = new System.Drawing.Size(130, 25);
            this.lbl_town.TabIndex = 85;
            this.lbl_town.Text = "Miejscowość:";
            // 
            // lbl_street
            // 
            this.lbl_street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_street.AutoSize = true;
            this.lbl_street.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_street.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_street.Location = new System.Drawing.Point(674, 110);
            this.lbl_street.Name = "lbl_street";
            this.lbl_street.Size = new System.Drawing.Size(61, 25);
            this.lbl_street.TabIndex = 84;
            this.lbl_street.Text = "Ulica:";
            // 
            // lbl_address_data
            // 
            this.lbl_address_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_address_data.AutoSize = true;
            this.lbl_address_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_address_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_address_data.Location = new System.Drawing.Point(637, 75);
            this.lbl_address_data.Name = "lbl_address_data";
            this.lbl_address_data.Size = new System.Drawing.Size(286, 32);
            this.lbl_address_data.TabIndex = 83;
            this.lbl_address_data.Text = "Adres zamieszkania";
            // 
            // lbl_contact_data
            // 
            this.lbl_contact_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_contact_data.AutoSize = true;
            this.lbl_contact_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_contact_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_contact_data.Location = new System.Drawing.Point(45, 367);
            this.lbl_contact_data.Name = "lbl_contact_data";
            this.lbl_contact_data.Size = new System.Drawing.Size(253, 32);
            this.lbl_contact_data.TabIndex = 82;
            this.lbl_contact_data.Text = "Dane Kontaktowe";
            // 
            // txt_birth_date
            // 
            this.txt_birth_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_birth_date.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_birth_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_birth_date.Location = new System.Drawing.Point(274, 271);
            this.txt_birth_date.Name = "txt_birth_date";
            this.txt_birth_date.Size = new System.Drawing.Size(264, 30);
            this.txt_birth_date.TabIndex = 81;
            // 
            // lbl_birth_date
            // 
            this.lbl_birth_date.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_birth_date.AutoSize = true;
            this.lbl_birth_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_birth_date.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_birth_date.Location = new System.Drawing.Point(92, 271);
            this.lbl_birth_date.Name = "lbl_birth_date";
            this.lbl_birth_date.Size = new System.Drawing.Size(153, 25);
            this.lbl_birth_date.TabIndex = 80;
            this.lbl_birth_date.Text = "Data Urodzenia:";
            // 
            // lbl_gender
            // 
            this.lbl_gender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_gender.AutoSize = true;
            this.lbl_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_gender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_gender.Location = new System.Drawing.Point(92, 307);
            this.lbl_gender.Name = "lbl_gender";
            this.lbl_gender.Size = new System.Drawing.Size(56, 25);
            this.lbl_gender.TabIndex = 79;
            this.lbl_gender.Text = "Płeć:";
            // 
            // txt_phone_number
            // 
            this.txt_phone_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_phone_number.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_phone_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_phone_number.Location = new System.Drawing.Point(274, 448);
            this.txt_phone_number.Name = "txt_phone_number";
            this.txt_phone_number.Size = new System.Drawing.Size(264, 30);
            this.txt_phone_number.TabIndex = 78;
            // 
            // lbl_phone_number
            // 
            this.lbl_phone_number.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_phone_number.AutoSize = true;
            this.lbl_phone_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_phone_number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_phone_number.Location = new System.Drawing.Point(92, 448);
            this.lbl_phone_number.Name = "lbl_phone_number";
            this.lbl_phone_number.Size = new System.Drawing.Size(150, 25);
            this.lbl_phone_number.TabIndex = 77;
            this.lbl_phone_number.Text = "Numer telefonu:";
            // 
            // lbl_personal_data
            // 
            this.lbl_personal_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_personal_data.AutoSize = true;
            this.lbl_personal_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_personal_data.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_personal_data.Location = new System.Drawing.Point(45, 86);
            this.lbl_personal_data.Name = "lbl_personal_data";
            this.lbl_personal_data.Size = new System.Drawing.Size(221, 32);
            this.lbl_personal_data.TabIndex = 66;
            this.lbl_personal_data.Text = "Dane Osobowe";
            // 
            // txt_PESEL
            // 
            this.txt_PESEL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_PESEL.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_PESEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_PESEL.Location = new System.Drawing.Point(274, 235);
            this.txt_PESEL.MaxLength = 11;
            this.txt_PESEL.Name = "txt_PESEL";
            this.txt_PESEL.Size = new System.Drawing.Size(264, 30);
            this.txt_PESEL.TabIndex = 76;
            // 
            // txt_mail
            // 
            this.txt_mail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_mail.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_mail.Location = new System.Drawing.Point(274, 412);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(264, 30);
            this.txt_mail.TabIndex = 75;
            // 
            // txt_surname
            // 
            this.txt_surname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_surname.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_surname.Location = new System.Drawing.Point(274, 199);
            this.txt_surname.Name = "txt_surname";
            this.txt_surname.Size = new System.Drawing.Size(264, 30);
            this.txt_surname.TabIndex = 74;
            // 
            // txt_name
            // 
            this.txt_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_name.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_name.Location = new System.Drawing.Point(274, 163);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(264, 30);
            this.txt_name.TabIndex = 73;
            // 
            // txt_login
            // 
            this.txt_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_login.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_login.Location = new System.Drawing.Point(274, 127);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(264, 30);
            this.txt_login.TabIndex = 72;
            // 
            // lbl_mail
            // 
            this.lbl_mail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_mail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_mail.Location = new System.Drawing.Point(92, 412);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(121, 25);
            this.lbl_mail.TabIndex = 71;
            this.lbl_mail.Text = "Adres email:";
            // 
            // lbl_PESEL
            // 
            this.lbl_PESEL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_PESEL.AutoSize = true;
            this.lbl_PESEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_PESEL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_PESEL.Location = new System.Drawing.Point(92, 235);
            this.lbl_PESEL.Name = "lbl_PESEL";
            this.lbl_PESEL.Size = new System.Drawing.Size(82, 25);
            this.lbl_PESEL.TabIndex = 70;
            this.lbl_PESEL.Text = "PESEL:";
            // 
            // lbl_surname
            // 
            this.lbl_surname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_surname.AutoSize = true;
            this.lbl_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_surname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_surname.Location = new System.Drawing.Point(92, 199);
            this.lbl_surname.Name = "lbl_surname";
            this.lbl_surname.Size = new System.Drawing.Size(102, 25);
            this.lbl_surname.TabIndex = 69;
            this.lbl_surname.Text = "Nazwisko:";
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_name.Location = new System.Drawing.Point(92, 163);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(54, 25);
            this.lbl_name.TabIndex = 68;
            this.lbl_name.Text = "Imię:";
            // 
            // lbl_login
            // 
            this.lbl_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_login.AutoSize = true;
            this.lbl_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_login.Location = new System.Drawing.Point(92, 127);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(66, 25);
            this.lbl_login.TabIndex = 67;
            this.lbl_login.Text = "Login:";
            // 
            // UCAddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnAU_create_user);
            this.Controls.Add(this.btn_anuluj);
            this.Controls.Add(this.cb_gender);
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
            this.Name = "UCAddUsers";
            this.Size = new System.Drawing.Size(1182, 682);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error_add_user_form)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_add_users;
        private System.Windows.Forms.ErrorProvider error_add_user_form;
        private System.Windows.Forms.Button btnAU_create_user;
        private System.Windows.Forms.Button btn_anuluj;
        private System.Windows.Forms.ComboBox cb_gender;
        private System.Windows.Forms.TextBox txtlbl_apartment_number;
        private System.Windows.Forms.Label lbl_apartment_number;
        private System.Windows.Forms.TextBox txt_zip_code;
        private System.Windows.Forms.Label lbl_zip_code;
        private System.Windows.Forms.TextBox txt_property_number;
        private System.Windows.Forms.Label lbl_property_number;
        private System.Windows.Forms.TextBox txt_town;
        private System.Windows.Forms.TextBox txt_street;
        private System.Windows.Forms.Label lbl_town;
        private System.Windows.Forms.Label lbl_street;
        private System.Windows.Forms.Label lbl_address_data;
        private System.Windows.Forms.Label lbl_contact_data;
        private System.Windows.Forms.TextBox txt_birth_date;
        private System.Windows.Forms.Label lbl_birth_date;
        private System.Windows.Forms.Label lbl_gender;
        private System.Windows.Forms.TextBox txt_phone_number;
        private System.Windows.Forms.Label lbl_phone_number;
        private System.Windows.Forms.Label lbl_personal_data;
        private System.Windows.Forms.TextBox txt_PESEL;
        private System.Windows.Forms.TextBox txt_mail;
        private System.Windows.Forms.TextBox txt_surname;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.Label lbl_mail;
        private System.Windows.Forms.Label lbl_PESEL;
        private System.Windows.Forms.Label lbl_surname;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_login;
    }
}
