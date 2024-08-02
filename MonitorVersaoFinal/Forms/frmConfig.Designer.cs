namespace MonitorVersaoFinal.Forms
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.pnlConfiguracaoRSS = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.chkAtivoFonte = new System.Windows.Forms.CheckBox();
            this.chkAtivoTema = new System.Windows.Forms.CheckBox();
            this.lblCorTema = new System.Windows.Forms.Label();
            this.btnCor = new System.Windows.Forms.Button();
            this.btnCancelarTema = new System.Windows.Forms.Button();
            this.btnConfirmarTema = new System.Windows.Forms.Button();
            this.btnCancelarFonte = new System.Windows.Forms.Button();
            this.btnConfirmarFonte = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnDeletarTemas = new System.Windows.Forms.Button();
            this.btnEditarTemas = new System.Windows.Forms.Button();
            this.btnCadastrarTemas = new System.Windows.Forms.Button();
            this.cbTemas = new System.Windows.Forms.ComboBox();
            this.lblTemas = new System.Windows.Forms.Label();
            this.btnDeletarFontes = new System.Windows.Forms.Button();
            this.btnEditarFontes = new System.Windows.Forms.Button();
            this.btnCadastrarFontes = new System.Windows.Forms.Button();
            this.cbFontesRss = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tctrlFontesTemas = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlConfiguracaoGerais = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timerAtualizarClima = new System.Windows.Forms.DateTimePicker();
            this.btnSalvarConfig = new System.Windows.Forms.Button();
            this.timerAtualizarMoedas = new System.Windows.Forms.DateTimePicker();
            this.timerAtualizarPainel = new System.Windows.Forms.DateTimePicker();
            this.timerNoticia = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMoedaTempo = new System.Windows.Forms.Label();
            this.lblNoticiasSegu = new System.Windows.Forms.Label();
            this.tbPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTituloRssConfig = new System.Windows.Forms.Label();
            this.pnlConfiguracaoRSS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.tctrlFontesTemas.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlConfiguracaoGerais.SuspendLayout();
            this.tbPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlConfiguracaoRSS
            // 
            this.pnlConfiguracaoRSS.Controls.Add(this.btnSalvar);
            this.pnlConfiguracaoRSS.Controls.Add(this.pbLogo);
            this.pnlConfiguracaoRSS.Controls.Add(this.chkAtivoFonte);
            this.pnlConfiguracaoRSS.Controls.Add(this.chkAtivoTema);
            this.pnlConfiguracaoRSS.Controls.Add(this.lblCorTema);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnCor);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnCancelarTema);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnConfirmarTema);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnCancelarFonte);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnConfirmarFonte);
            this.pnlConfiguracaoRSS.Controls.Add(this.txtUrl);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnDeletarTemas);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnEditarTemas);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnCadastrarTemas);
            this.pnlConfiguracaoRSS.Controls.Add(this.cbTemas);
            this.pnlConfiguracaoRSS.Controls.Add(this.lblTemas);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnDeletarFontes);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnEditarFontes);
            this.pnlConfiguracaoRSS.Controls.Add(this.btnCadastrarFontes);
            this.pnlConfiguracaoRSS.Controls.Add(this.cbFontesRss);
            this.pnlConfiguracaoRSS.Controls.Add(this.label1);
            this.pnlConfiguracaoRSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfiguracaoRSS.Location = new System.Drawing.Point(3, 62);
            this.pnlConfiguracaoRSS.Name = "pnlConfiguracaoRSS";
            this.pnlConfiguracaoRSS.Size = new System.Drawing.Size(690, 282);
            this.pnlConfiguracaoRSS.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(294, 235);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(79, 29);
            this.btnSalvar.TabIndex = 30;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(599, 192);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(70, 70);
            this.pbLogo.TabIndex = 21;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // chkAtivoFonte
            // 
            this.chkAtivoFonte.AutoSize = true;
            this.chkAtivoFonte.Enabled = false;
            this.chkAtivoFonte.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivoFonte.Location = new System.Drawing.Point(506, 52);
            this.chkAtivoFonte.Name = "chkAtivoFonte";
            this.chkAtivoFonte.Size = new System.Drawing.Size(54, 20);
            this.chkAtivoFonte.TabIndex = 20;
            this.chkAtivoFonte.Text = "Ativo";
            this.chkAtivoFonte.UseVisualStyleBackColor = true;
            this.chkAtivoFonte.CheckedChanged += new System.EventHandler(this.chkAtivoFonte_CheckedChanged);
            // 
            // chkAtivoTema
            // 
            this.chkAtivoTema.AutoSize = true;
            this.chkAtivoTema.Enabled = false;
            this.chkAtivoTema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivoTema.Location = new System.Drawing.Point(506, 121);
            this.chkAtivoTema.Name = "chkAtivoTema";
            this.chkAtivoTema.Size = new System.Drawing.Size(54, 20);
            this.chkAtivoTema.TabIndex = 19;
            this.chkAtivoTema.Text = "Ativo";
            this.chkAtivoTema.UseVisualStyleBackColor = true;
            this.chkAtivoTema.CheckedChanged += new System.EventHandler(this.chkAtivoTema_CheckedChanged);
            // 
            // lblCorTema
            // 
            this.lblCorTema.AutoSize = true;
            this.lblCorTema.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorTema.Location = new System.Drawing.Point(589, 96);
            this.lblCorTema.Name = "lblCorTema";
            this.lblCorTema.Size = new System.Drawing.Size(80, 16);
            this.lblCorTema.TabIndex = 18;
            this.lblCorTema.Text = "Cor do Tema";
            // 
            // btnCor
            // 
            this.btnCor.Enabled = false;
            this.btnCor.Location = new System.Drawing.Point(619, 115);
            this.btnCor.Name = "btnCor";
            this.btnCor.Size = new System.Drawing.Size(30, 29);
            this.btnCor.TabIndex = 17;
            this.btnCor.UseVisualStyleBackColor = true;
            this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
            // 
            // btnCancelarTema
            // 
            this.btnCancelarTema.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelarTema.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarTema.BackgroundImage")));
            this.btnCancelarTema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelarTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancelarTema.Location = new System.Drawing.Point(420, 115);
            this.btnCancelarTema.Name = "btnCancelarTema";
            this.btnCancelarTema.Size = new System.Drawing.Size(32, 32);
            this.btnCancelarTema.TabIndex = 16;
            this.btnCancelarTema.UseVisualStyleBackColor = false;
            this.btnCancelarTema.Visible = false;
            this.btnCancelarTema.Click += new System.EventHandler(this.btnCancelarTema_Click);
            // 
            // btnConfirmarTema
            // 
            this.btnConfirmarTema.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfirmarTema.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmarTema.BackgroundImage")));
            this.btnConfirmarTema.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmarTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnConfirmarTema.Location = new System.Drawing.Point(382, 117);
            this.btnConfirmarTema.Name = "btnConfirmarTema";
            this.btnConfirmarTema.Size = new System.Drawing.Size(32, 32);
            this.btnConfirmarTema.TabIndex = 15;
            this.btnConfirmarTema.UseVisualStyleBackColor = false;
            this.btnConfirmarTema.Visible = false;
            this.btnConfirmarTema.Click += new System.EventHandler(this.btnConfirmarTema_Click);
            // 
            // btnCancelarFonte
            // 
            this.btnCancelarFonte.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancelarFonte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarFonte.BackgroundImage")));
            this.btnCancelarFonte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelarFonte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancelarFonte.Location = new System.Drawing.Point(420, 47);
            this.btnCancelarFonte.Name = "btnCancelarFonte";
            this.btnCancelarFonte.Size = new System.Drawing.Size(32, 32);
            this.btnCancelarFonte.TabIndex = 14;
            this.btnCancelarFonte.UseVisualStyleBackColor = false;
            this.btnCancelarFonte.Visible = false;
            this.btnCancelarFonte.Click += new System.EventHandler(this.btnCancelarFonte_Click);
            // 
            // btnConfirmarFonte
            // 
            this.btnConfirmarFonte.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfirmarFonte.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfirmarFonte.BackgroundImage")));
            this.btnConfirmarFonte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmarFonte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnConfirmarFonte.Location = new System.Drawing.Point(382, 47);
            this.btnConfirmarFonte.Name = "btnConfirmarFonte";
            this.btnConfirmarFonte.Size = new System.Drawing.Size(32, 32);
            this.btnConfirmarFonte.TabIndex = 13;
            this.btnConfirmarFonte.UseVisualStyleBackColor = false;
            this.btnConfirmarFonte.Visible = false;
            this.btnConfirmarFonte.Click += new System.EventHandler(this.btnConfirmarFonte_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.Wheat;
            this.txtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txtUrl.Location = new System.Drawing.Point(25, 151);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(644, 21);
            this.txtUrl.TabIndex = 11;
            this.txtUrl.Text = "URL...";
            // 
            // btnDeletarTemas
            // 
            this.btnDeletarTemas.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeletarTemas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletarTemas.BackgroundImage")));
            this.btnDeletarTemas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeletarTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDeletarTemas.Location = new System.Drawing.Point(458, 116);
            this.btnDeletarTemas.Name = "btnDeletarTemas";
            this.btnDeletarTemas.Size = new System.Drawing.Size(32, 32);
            this.btnDeletarTemas.TabIndex = 10;
            this.btnDeletarTemas.UseVisualStyleBackColor = false;
            this.btnDeletarTemas.Click += new System.EventHandler(this.btnDeletarTemas_Click);
            // 
            // btnEditarTemas
            // 
            this.btnEditarTemas.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditarTemas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarTemas.BackgroundImage")));
            this.btnEditarTemas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEditarTemas.Location = new System.Drawing.Point(420, 116);
            this.btnEditarTemas.Name = "btnEditarTemas";
            this.btnEditarTemas.Size = new System.Drawing.Size(32, 32);
            this.btnEditarTemas.TabIndex = 9;
            this.btnEditarTemas.UseVisualStyleBackColor = false;
            this.btnEditarTemas.Click += new System.EventHandler(this.btnEditarTemas_Click);
            // 
            // btnCadastrarTemas
            // 
            this.btnCadastrarTemas.BackColor = System.Drawing.SystemColors.Control;
            this.btnCadastrarTemas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCadastrarTemas.BackgroundImage")));
            this.btnCadastrarTemas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCadastrarTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCadastrarTemas.Location = new System.Drawing.Point(382, 117);
            this.btnCadastrarTemas.Name = "btnCadastrarTemas";
            this.btnCadastrarTemas.Size = new System.Drawing.Size(32, 32);
            this.btnCadastrarTemas.TabIndex = 8;
            this.btnCadastrarTemas.UseVisualStyleBackColor = false;
            this.btnCadastrarTemas.Click += new System.EventHandler(this.btnCadastrarTemas_Click);
            // 
            // cbTemas
            // 
            this.cbTemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemas.Enabled = false;
            this.cbTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTemas.FormattingEnabled = true;
            this.cbTemas.Location = new System.Drawing.Point(25, 117);
            this.cbTemas.Name = "cbTemas";
            this.cbTemas.Size = new System.Drawing.Size(351, 28);
            this.cbTemas.TabIndex = 7;
            this.cbTemas.SelectedIndexChanged += new System.EventHandler(this.cbTemas_SelectedIndexChanged);
            // 
            // lblTemas
            // 
            this.lblTemas.AutoSize = true;
            this.lblTemas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemas.Location = new System.Drawing.Point(23, 90);
            this.lblTemas.Name = "lblTemas";
            this.lblTemas.Size = new System.Drawing.Size(68, 24);
            this.lblTemas.TabIndex = 6;
            this.lblTemas.Text = "Temas";
            // 
            // btnDeletarFontes
            // 
            this.btnDeletarFontes.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeletarFontes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletarFontes.BackgroundImage")));
            this.btnDeletarFontes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeletarFontes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDeletarFontes.Location = new System.Drawing.Point(458, 46);
            this.btnDeletarFontes.Name = "btnDeletarFontes";
            this.btnDeletarFontes.Size = new System.Drawing.Size(32, 32);
            this.btnDeletarFontes.TabIndex = 5;
            this.btnDeletarFontes.UseVisualStyleBackColor = false;
            this.btnDeletarFontes.Click += new System.EventHandler(this.btnDeletarFontes_Click);
            // 
            // btnEditarFontes
            // 
            this.btnEditarFontes.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditarFontes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditarFontes.BackgroundImage")));
            this.btnEditarFontes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarFontes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEditarFontes.Location = new System.Drawing.Point(420, 46);
            this.btnEditarFontes.Name = "btnEditarFontes";
            this.btnEditarFontes.Size = new System.Drawing.Size(32, 32);
            this.btnEditarFontes.TabIndex = 4;
            this.btnEditarFontes.UseVisualStyleBackColor = false;
            this.btnEditarFontes.Click += new System.EventHandler(this.btnEditarFontes_Click);
            // 
            // btnCadastrarFontes
            // 
            this.btnCadastrarFontes.BackColor = System.Drawing.SystemColors.Control;
            this.btnCadastrarFontes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCadastrarFontes.BackgroundImage")));
            this.btnCadastrarFontes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCadastrarFontes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCadastrarFontes.Location = new System.Drawing.Point(382, 46);
            this.btnCadastrarFontes.Name = "btnCadastrarFontes";
            this.btnCadastrarFontes.Size = new System.Drawing.Size(32, 32);
            this.btnCadastrarFontes.TabIndex = 2;
            this.btnCadastrarFontes.UseVisualStyleBackColor = false;
            this.btnCadastrarFontes.Click += new System.EventHandler(this.btnCadastrarFontes_Click);
            // 
            // cbFontesRss
            // 
            this.cbFontesRss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontesRss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFontesRss.FormattingEnabled = true;
            this.cbFontesRss.Location = new System.Drawing.Point(27, 47);
            this.cbFontesRss.Name = "cbFontesRss";
            this.cbFontesRss.Size = new System.Drawing.Size(349, 28);
            this.cbFontesRss.TabIndex = 1;
            this.cbFontesRss.SelectedIndexChanged += new System.EventHandler(this.cbFontesRss_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fontes";
            // 
            // tctrlFontesTemas
            // 
            this.tctrlFontesTemas.Controls.Add(this.tabPage2);
            this.tctrlFontesTemas.Controls.Add(this.tbPage1);
            this.tctrlFontesTemas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tctrlFontesTemas.Location = new System.Drawing.Point(0, 0);
            this.tctrlFontesTemas.Name = "tctrlFontesTemas";
            this.tctrlFontesTemas.SelectedIndex = 0;
            this.tctrlFontesTemas.Size = new System.Drawing.Size(710, 379);
            this.tctrlFontesTemas.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(702, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gerais";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnlConfiguracaoGerais, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.52022F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.47978F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(696, 347);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 54);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Configurações Gerais";
            // 
            // pnlConfiguracaoGerais
            // 
            this.pnlConfiguracaoGerais.Controls.Add(this.btnSair);
            this.pnlConfiguracaoGerais.Controls.Add(this.label4);
            this.pnlConfiguracaoGerais.Controls.Add(this.timerAtualizarClima);
            this.pnlConfiguracaoGerais.Controls.Add(this.btnSalvarConfig);
            this.pnlConfiguracaoGerais.Controls.Add(this.timerAtualizarMoedas);
            this.pnlConfiguracaoGerais.Controls.Add(this.timerAtualizarPainel);
            this.pnlConfiguracaoGerais.Controls.Add(this.timerNoticia);
            this.pnlConfiguracaoGerais.Controls.Add(this.label3);
            this.pnlConfiguracaoGerais.Controls.Add(this.lblMoedaTempo);
            this.pnlConfiguracaoGerais.Controls.Add(this.lblNoticiasSegu);
            this.pnlConfiguracaoGerais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfiguracaoGerais.Location = new System.Drawing.Point(3, 63);
            this.pnlConfiguracaoGerais.Name = "pnlConfiguracaoGerais";
            this.pnlConfiguracaoGerais.Size = new System.Drawing.Size(690, 281);
            this.pnlConfiguracaoGerais.TabIndex = 1;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(608, 249);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(79, 29);
            this.btnSair.TabIndex = 32;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(386, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Tempo de Atualização do Clima";
            this.label4.Visible = false;
            // 
            // timerAtualizarClima
            // 
            this.timerAtualizarClima.CalendarForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.timerAtualizarClima.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
            this.timerAtualizarClima.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timerAtualizarClima.Location = new System.Drawing.Point(389, 109);
            this.timerAtualizarClima.Name = "timerAtualizarClima";
            this.timerAtualizarClima.Size = new System.Drawing.Size(117, 20);
            this.timerAtualizarClima.TabIndex = 30;
            this.timerAtualizarClima.Visible = false;
            // 
            // btnSalvarConfig
            // 
            this.btnSalvarConfig.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSalvarConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarConfig.Location = new System.Drawing.Point(294, 234);
            this.btnSalvarConfig.Name = "btnSalvarConfig";
            this.btnSalvarConfig.Size = new System.Drawing.Size(79, 29);
            this.btnSalvarConfig.TabIndex = 29;
            this.btnSalvarConfig.Text = "Salvar";
            this.btnSalvarConfig.UseVisualStyleBackColor = false;
            this.btnSalvarConfig.Click += new System.EventHandler(this.btnSalvarConfig_Click);
            // 
            // timerAtualizarMoedas
            // 
            this.timerAtualizarMoedas.CalendarForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.timerAtualizarMoedas.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
            this.timerAtualizarMoedas.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timerAtualizarMoedas.Location = new System.Drawing.Point(28, 109);
            this.timerAtualizarMoedas.Name = "timerAtualizarMoedas";
            this.timerAtualizarMoedas.Size = new System.Drawing.Size(117, 20);
            this.timerAtualizarMoedas.TabIndex = 28;
            // 
            // timerAtualizarPainel
            // 
            this.timerAtualizarPainel.CalendarForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.timerAtualizarPainel.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
            this.timerAtualizarPainel.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timerAtualizarPainel.Location = new System.Drawing.Point(391, 43);
            this.timerAtualizarPainel.Name = "timerAtualizarPainel";
            this.timerAtualizarPainel.Size = new System.Drawing.Size(117, 20);
            this.timerAtualizarPainel.TabIndex = 27;
            // 
            // timerNoticia
            // 
            this.timerNoticia.CalendarForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.timerNoticia.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
            this.timerNoticia.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timerNoticia.Location = new System.Drawing.Point(28, 43);
            this.timerNoticia.Name = "timerNoticia";
            this.timerNoticia.Size = new System.Drawing.Size(117, 20);
            this.timerNoticia.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tempo de Atualização das Moedas ";
            // 
            // lblMoedaTempo
            // 
            this.lblMoedaTempo.AutoSize = true;
            this.lblMoedaTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoedaTempo.Location = new System.Drawing.Point(386, 19);
            this.lblMoedaTempo.Name = "lblMoedaTempo";
            this.lblMoedaTempo.Size = new System.Drawing.Size(285, 16);
            this.lblMoedaTempo.TabIndex = 24;
            this.lblMoedaTempo.Text = "Tempo de Atualização do Painel Inferior";
            // 
            // lblNoticiasSegu
            // 
            this.lblNoticiasSegu.AutoSize = true;
            this.lblNoticiasSegu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoticiasSegu.Location = new System.Drawing.Point(23, 19);
            this.lblNoticiasSegu.Name = "lblNoticiasSegu";
            this.lblNoticiasSegu.Size = new System.Drawing.Size(206, 16);
            this.lblNoticiasSegu.TabIndex = 23;
            this.lblNoticiasSegu.Text = "Tempo de Troca de Notícias";
            // 
            // tbPage1
            // 
            this.tbPage1.Controls.Add(this.tableLayoutPanel1);
            this.tbPage1.Location = new System.Drawing.Point(4, 22);
            this.tbPage1.Name = "tbPage1";
            this.tbPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tbPage1.Size = new System.Drawing.Size(702, 353);
            this.tbPage1.TabIndex = 0;
            this.tbPage1.Text = "Fontes e Temas";
            this.tbPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlConfiguracaoRSS, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.25067F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.74933F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(696, 347);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.Controls.Add(this.lblTituloRssConfig);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitulo.Location = new System.Drawing.Point(3, 3);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(690, 53);
            this.pnlTitulo.TabIndex = 0;
            // 
            // lblTituloRssConfig
            // 
            this.lblTituloRssConfig.AutoSize = true;
            this.lblTituloRssConfig.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRssConfig.Location = new System.Drawing.Point(198, 17);
            this.lblTituloRssConfig.Name = "lblTituloRssConfig";
            this.lblTituloRssConfig.Size = new System.Drawing.Size(292, 22);
            this.lblTituloRssConfig.TabIndex = 0;
            this.lblTituloRssConfig.Text = "Configuração de Fontes e Temas";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 379);
            this.Controls.Add(this.tctrlFontesTemas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfig";
            this.Text = "frmConfig";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.pnlConfiguracaoRSS.ResumeLayout(false);
            this.pnlConfiguracaoRSS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.tctrlFontesTemas.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlConfiguracaoGerais.ResumeLayout(false);
            this.pnlConfiguracaoGerais.PerformLayout();
            this.tbPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlConfiguracaoRSS;
        private System.Windows.Forms.Label lblCorTema;
        private System.Windows.Forms.Button btnCor;
        private System.Windows.Forms.Button btnCancelarTema;
        private System.Windows.Forms.Button btnConfirmarTema;
        private System.Windows.Forms.Button btnCancelarFonte;
        private System.Windows.Forms.Button btnConfirmarFonte;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnDeletarTemas;
        private System.Windows.Forms.Button btnEditarTemas;
        private System.Windows.Forms.Button btnCadastrarTemas;
        private System.Windows.Forms.ComboBox cbTemas;
        private System.Windows.Forms.Label lblTemas;
        private System.Windows.Forms.Button btnDeletarFontes;
        private System.Windows.Forms.Button btnEditarFontes;
        private System.Windows.Forms.Button btnCadastrarFontes;
        private System.Windows.Forms.ComboBox cbFontesRss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tctrlFontesTemas;
        private System.Windows.Forms.TabPage tbPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTituloRssConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAtivoTema;
        private System.Windows.Forms.CheckBox chkAtivoFonte;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlConfiguracaoGerais;
        internal System.Windows.Forms.Button btnSalvarConfig;
        internal System.Windows.Forms.DateTimePicker timerAtualizarMoedas;
        internal System.Windows.Forms.DateTimePicker timerAtualizarPainel;
        internal System.Windows.Forms.DateTimePicker timerNoticia;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblMoedaTempo;
        internal System.Windows.Forms.Label lblNoticiasSegu;
        internal System.Windows.Forms.Button btnSalvar;
        internal System.Windows.Forms.DateTimePicker timerAtualizarClima;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnSair;
    }
}