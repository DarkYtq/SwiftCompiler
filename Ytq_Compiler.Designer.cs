namespace YCompiler
{
    partial class Ytq_Compiler 
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            } 
            base.Dispose(disposing);
        }
        // base.BaseInitializeComponent(); 需要添加在InitializeComponent() 
        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        public  void InitializeComponent()
        {
            base.BaseInitializeComponent();
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ytq_Compiler));
            this.LinePanel = new System.Windows.Forms.Panel();
            this.LineText = new System.Windows.Forms.RichTextBox();
            this.StepIntoBox = new System.Windows.Forms.PictureBox();
            this.StepNumSlider = new System.Windows.Forms.TrackBar();
            this.StepNumText = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ButtonTip = new System.Windows.Forms.ToolTip(this.components);
            this.SetPathBox = new System.Windows.Forms.PictureBox();
            this.LoadLineBox = new System.Windows.Forms.PictureBox();
            this.Star2Box = new System.Windows.Forms.PictureBox();
            this.Star1Box = new System.Windows.Forms.PictureBox();
            this.InputText = new System.Windows.Forms.TextBox();
            this.InputConfirmBox = new System.Windows.Forms.PictureBox();
            this.NeedRecordCheckBox = new System.Windows.Forms.CheckBox();
            this.CodeText = new System.Windows.Forms.RichTextBox();
            this.DefineSizeTip = new System.Windows.Forms.TextBox();
            this.DefineAddrTip = new System.Windows.Forms.TextBox();
            this.DefineLevelTip = new System.Windows.Forms.TextBox();
            this.DefineValueTip = new System.Windows.Forms.TextBox();
            this.DefineTypeTip = new System.Windows.Forms.TextBox();
            this.DefineNameTip = new System.Windows.Forms.TextBox();
            this.StackTip = new System.Windows.Forms.TextBox();
            this.StackText = new System.Windows.Forms.RichTextBox();
            this.AnswerText = new System.Windows.Forms.RichTextBox();
            this.CodePanel = new System.Windows.Forms.Panel();
            this.DefineText = new System.Windows.Forms.RichTextBox();
            this.DefinePanel = new System.Windows.Forms.Panel();
            this.StackPanel = new System.Windows.Forms.Panel();
            this.AnswerPanel = new System.Windows.Forms.Panel();
            this.LinePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StepIntoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepNumSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPathBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadLineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputConfirmBox)).BeginInit();
            this.CodePanel.SuspendLayout();
            this.DefinePanel.SuspendLayout();
            this.StackPanel.SuspendLayout();
            this.AnswerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LinePanel
            // 
            this.LinePanel.BackColor = System.Drawing.Color.Transparent;
            this.LinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LinePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LinePanel.Controls.Add(this.LineText);
            this.LinePanel.Location = new System.Drawing.Point(152, 138);
            this.LinePanel.Name = "LinePanel";
            this.LinePanel.Size = new System.Drawing.Size(318, 495);
            this.LinePanel.TabIndex = 1;
            this.LinePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LineText
            // 
            this.LineText.BackColor = System.Drawing.Color.PowderBlue;
            this.LineText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LineText.Location = new System.Drawing.Point(0, 0);
            this.LineText.Name = "LineText";
            this.LineText.ReadOnly = true;
            this.LineText.Size = new System.Drawing.Size(320, 495);
            this.LineText.TabIndex = 19;
            this.LineText.Text = resources.GetString("LineText.Text");
            this.ButtonTip.SetToolTip(this.LineText, "原始代码区域");
            // 
            // StepIntoBox
            // 
            this.StepIntoBox.BackColor = System.Drawing.Color.Transparent;
            this.StepIntoBox.Image = global::YCompiler.Properties.Resources.SearchButton;
            this.StepIntoBox.Location = new System.Drawing.Point(1226, 344);
            this.StepIntoBox.Name = "StepIntoBox";
            this.StepIntoBox.Size = new System.Drawing.Size(75, 78);
            this.StepIntoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.StepIntoBox.TabIndex = 0;
            this.StepIntoBox.TabStop = false;
            this.ButtonTip.SetToolTip(this.StepIntoBox, "开始调试");
            this.StepIntoBox.Click += new System.EventHandler(this.StepIntoBox_Click);
            // 
            // StepNumSlider
            // 
            this.StepNumSlider.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StepNumSlider.Location = new System.Drawing.Point(954, 367);
            this.StepNumSlider.Maximum = 20;
            this.StepNumSlider.Name = "StepNumSlider";
            this.StepNumSlider.Size = new System.Drawing.Size(247, 45);
            this.StepNumSlider.TabIndex = 13;
            this.ButtonTip.SetToolTip(this.StepNumSlider, "调试的步数（0为运行至结束）");
            this.StepNumSlider.Value = 1;
            this.StepNumSlider.Scroll += new System.EventHandler(this.StepNumSlider_Scroll);
            // 
            // StepNumText
            // 
            this.StepNumText.BackColor = System.Drawing.SystemColors.InfoText;
            this.StepNumText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StepNumText.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StepNumText.ForeColor = System.Drawing.SystemColors.Control;
            this.StepNumText.Location = new System.Drawing.Point(873, 370);
            this.StepNumText.Name = "StepNumText";
            this.StepNumText.ReadOnly = true;
            this.StepNumText.Size = new System.Drawing.Size(60, 32);
            this.StepNumText.TabIndex = 14;
            this.StepNumText.Text = "1";
            this.ButtonTip.SetToolTip(this.StepNumText, "调试的步数（0为运行至结束）");
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = global::YCompiler.Properties.Resources.ExitButton;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Location = new System.Drawing.Point(1258, 20);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(65, 61);
            this.ExitButton.TabIndex = 15;
            this.ButtonTip.SetToolTip(this.ExitButton, "退出");
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ButtonTip
            // 
            this.ButtonTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // SetPathBox
            // 
            this.SetPathBox.BackColor = System.Drawing.Color.Transparent;
            this.SetPathBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SetPathBox.Image = global::YCompiler.Properties.Resources.SetDatabaseButton;
            this.SetPathBox.Location = new System.Drawing.Point(1190, 28);
            this.SetPathBox.Name = "SetPathBox";
            this.SetPathBox.Size = new System.Drawing.Size(39, 38);
            this.SetPathBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SetPathBox.TabIndex = 16;
            this.SetPathBox.TabStop = false;
            this.ButtonTip.SetToolTip(this.SetPathBox, "QQ：1070007954");
            // 
            // LoadLineBox
            // 
            this.LoadLineBox.BackColor = System.Drawing.Color.Transparent;
            this.LoadLineBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoadLineBox.Image = global::YCompiler.Properties.Resources.LoadedButton;
            this.LoadLineBox.Location = new System.Drawing.Point(845, 33);
            this.LoadLineBox.Name = "LoadLineBox";
            this.LoadLineBox.Size = new System.Drawing.Size(78, 78);
            this.LoadLineBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoadLineBox.TabIndex = 0;
            this.LoadLineBox.TabStop = false;
            this.ButtonTip.SetToolTip(this.LoadLineBox, "载入要编译的文件");
            this.LoadLineBox.Click += new System.EventHandler(this.LoadFileBox_Click);
            // 
            // Star2Box
            // 
            this.Star2Box.BackColor = System.Drawing.Color.Transparent;
            this.Star2Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Star2Box.Image = global::YCompiler.Properties.Resources.SetDatabaseButton;
            this.Star2Box.Location = new System.Drawing.Point(1299, 670);
            this.Star2Box.Name = "Star2Box";
            this.Star2Box.Size = new System.Drawing.Size(39, 38);
            this.Star2Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Star2Box.TabIndex = 17;
            this.Star2Box.TabStop = false;
            this.ButtonTip.SetToolTip(this.Star2Box, "更多作品：https://pan.baidu.com/s/1kU6UUm7");
            // 
            // Star1Box
            // 
            this.Star1Box.BackColor = System.Drawing.Color.Transparent;
            this.Star1Box.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Star1Box.Image = global::YCompiler.Properties.Resources.SetDatabaseButton;
            this.Star1Box.Location = new System.Drawing.Point(110, 670);
            this.Star1Box.Name = "Star1Box";
            this.Star1Box.Size = new System.Drawing.Size(39, 38);
            this.Star1Box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Star1Box.TabIndex = 18;
            this.Star1Box.TabStop = false;
            this.ButtonTip.SetToolTip(this.Star1Box, "QQ群：234867393~欢迎你的加入~");
            // 
            // InputText
            // 
            this.InputText.BackColor = System.Drawing.SystemColors.InfoText;
            this.InputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputText.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputText.ForeColor = System.Drawing.SystemColors.Control;
            this.InputText.Location = new System.Drawing.Point(1247, 520);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(60, 32);
            this.InputText.TabIndex = 29;
            this.InputText.Text = "1234";
            this.ButtonTip.SetToolTip(this.InputText, "数字输入区");
            // 
            // InputConfirmBox
            // 
            this.InputConfirmBox.BackColor = System.Drawing.Color.Transparent;
            this.InputConfirmBox.Image = global::YCompiler.Properties.Resources.ConfirmInputButton;
            this.InputConfirmBox.Location = new System.Drawing.Point(1239, 567);
            this.InputConfirmBox.Name = "InputConfirmBox";
            this.InputConfirmBox.Size = new System.Drawing.Size(75, 78);
            this.InputConfirmBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.InputConfirmBox.TabIndex = 32;
            this.InputConfirmBox.TabStop = false;
            this.ButtonTip.SetToolTip(this.InputConfirmBox, "确定输入");
            this.InputConfirmBox.Click += new System.EventHandler(this.InputConfirmBox_Click);
            // 
            // NeedRecordCheckBox
            // 
            this.NeedRecordCheckBox.AutoSize = true;
            this.NeedRecordCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.NeedRecordCheckBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NeedRecordCheckBox.ForeColor = System.Drawing.Color.Maroon;
            this.NeedRecordCheckBox.Location = new System.Drawing.Point(1226, 438);
            this.NeedRecordCheckBox.Name = "NeedRecordCheckBox";
            this.NeedRecordCheckBox.Size = new System.Drawing.Size(93, 25);
            this.NeedRecordCheckBox.TabIndex = 33;
            this.NeedRecordCheckBox.Text = "需要记录";
            this.ButtonTip.SetToolTip(this.NeedRecordCheckBox, "是否高亮已运行的代码");
            this.NeedRecordCheckBox.UseVisualStyleBackColor = false;
            this.NeedRecordCheckBox.CheckedChanged += new System.EventHandler(this.NeedRecordCheckBox_CheckedChanged);
            // 
            // CodeText
            // 
            this.CodeText.BackColor = System.Drawing.Color.PowderBlue;
            this.CodeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CodeText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CodeText.Location = new System.Drawing.Point(1, 0);
            this.CodeText.Name = "CodeText";
            this.CodeText.ReadOnly = true;
            this.CodeText.Size = new System.Drawing.Size(300, 492);
            this.CodeText.TabIndex = 21;
            this.CodeText.Text = "var i;\nvar j;\nvar k;\nvar p;\nvar t;\nvar q;\nfor i in 2...100 {\n  t = 0;\n  q = i - 1" +
    ";\n  for j in 2...q {\n    k = i / j;\n    k = k * j;\n    p = i - k;\n    if p == 0 " +
    "{";
            this.ButtonTip.SetToolTip(this.CodeText, "目标代码区域");
            // 
            // DefineSizeTip
            // 
            this.DefineSizeTip.BackColor = System.Drawing.Color.PowderBlue;
            this.DefineSizeTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefineSizeTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(90)))), ((int)(((byte)(167)))));
            this.DefineSizeTip.Location = new System.Drawing.Point(1159, 139);
            this.DefineSizeTip.Name = "DefineSizeTip";
            this.DefineSizeTip.ReadOnly = true;
            this.DefineSizeTip.Size = new System.Drawing.Size(38, 23);
            this.DefineSizeTip.TabIndex = 27;
            this.DefineSizeTip.Text = "Size";
            this.DefineSizeTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonTip.SetToolTip(this.DefineSizeTip, "符号表(数据颜色对应类型颜色)");
            // 
            // DefineAddrTip
            // 
            this.DefineAddrTip.BackColor = System.Drawing.Color.PowderBlue;
            this.DefineAddrTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefineAddrTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(109)))));
            this.DefineAddrTip.Location = new System.Drawing.Point(1073, 139);
            this.DefineAddrTip.Name = "DefineAddrTip";
            this.DefineAddrTip.ReadOnly = true;
            this.DefineAddrTip.Size = new System.Drawing.Size(84, 23);
            this.DefineAddrTip.TabIndex = 26;
            this.DefineAddrTip.Text = "Address";
            this.DefineAddrTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonTip.SetToolTip(this.DefineAddrTip, "符号表(数据颜色对应类型颜色)");
            // 
            // DefineLevelTip
            // 
            this.DefineLevelTip.BackColor = System.Drawing.Color.PowderBlue;
            this.DefineLevelTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefineLevelTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(12)))), ((int)(((byte)(123)))));
            this.DefineLevelTip.Location = new System.Drawing.Point(1022, 139);
            this.DefineLevelTip.Name = "DefineLevelTip";
            this.DefineLevelTip.ReadOnly = true;
            this.DefineLevelTip.Size = new System.Drawing.Size(49, 23);
            this.DefineLevelTip.TabIndex = 25;
            this.DefineLevelTip.Text = "Block";
            this.DefineLevelTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonTip.SetToolTip(this.DefineLevelTip, "符号表(数据颜色对应类型颜色)");
            // 
            // DefineValueTip
            // 
            this.DefineValueTip.BackColor = System.Drawing.Color.PowderBlue;
            this.DefineValueTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefineValueTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(178)))), ((int)(((byte)(191)))));
            this.DefineValueTip.Location = new System.Drawing.Point(970, 139);
            this.DefineValueTip.Name = "DefineValueTip";
            this.DefineValueTip.ReadOnly = true;
            this.DefineValueTip.Size = new System.Drawing.Size(50, 23);
            this.DefineValueTip.TabIndex = 24;
            this.DefineValueTip.Text = "Value";
            this.DefineValueTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonTip.SetToolTip(this.DefineValueTip, "符号表(数据颜色对应类型颜色)");
            // 
            // DefineTypeTip
            // 
            this.DefineTypeTip.BackColor = System.Drawing.Color.PowderBlue;
            this.DefineTypeTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefineTypeTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.DefineTypeTip.Location = new System.Drawing.Point(925, 139);
            this.DefineTypeTip.Name = "DefineTypeTip";
            this.DefineTypeTip.ReadOnly = true;
            this.DefineTypeTip.Size = new System.Drawing.Size(43, 23);
            this.DefineTypeTip.TabIndex = 23;
            this.DefineTypeTip.Text = "Type";
            this.DefineTypeTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonTip.SetToolTip(this.DefineTypeTip, "符号表(数据颜色对应类型颜色)");
            // 
            // DefineNameTip
            // 
            this.DefineNameTip.BackColor = System.Drawing.Color.PowderBlue;
            this.DefineNameTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefineNameTip.ForeColor = System.Drawing.Color.Black;
            this.DefineNameTip.Location = new System.Drawing.Point(872, 139);
            this.DefineNameTip.Name = "DefineNameTip";
            this.DefineNameTip.ReadOnly = true;
            this.DefineNameTip.Size = new System.Drawing.Size(51, 23);
            this.DefineNameTip.TabIndex = 22;
            this.DefineNameTip.Text = "Name";
            this.DefineNameTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonTip.SetToolTip(this.DefineNameTip, "符号表(数据颜色对应类型颜色)");
            // 
            // StackTip
            // 
            this.StackTip.BackColor = System.Drawing.Color.PowderBlue;
            this.StackTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StackTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(109)))));
            this.StackTip.Location = new System.Drawing.Point(871, 439);
            this.StackTip.Name = "StackTip";
            this.StackTip.ReadOnly = true;
            this.StackTip.Size = new System.Drawing.Size(97, 23);
            this.StackTip.TabIndex = 30;
            this.StackTip.Text = "DataStack";
            this.StackTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonTip.SetToolTip(this.StackTip, "数据栈");
            // 
            // StackText
            // 
            this.StackText.BackColor = System.Drawing.Color.PowderBlue;
            this.StackText.Enabled = false;
            this.StackText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StackText.ForeColor = System.Drawing.Color.Red;
            this.StackText.Location = new System.Drawing.Point(0, 0);
            this.StackText.Name = "StackText";
            this.StackText.ReadOnly = true;
            this.StackText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.StackText.Size = new System.Drawing.Size(149, 170);
            this.StackText.TabIndex = 0;
            this.StackText.Text = "var i;\nvar j;\nvar k;\nvar p;\nvar t;\nvar t;\nvar t;";
            this.ButtonTip.SetToolTip(this.StackText, "数据栈");
            // 
            // AnswerText
            // 
            this.AnswerText.BackColor = System.Drawing.Color.PowderBlue;
            this.AnswerText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AnswerText.Location = new System.Drawing.Point(1, -1);
            this.AnswerText.Name = "AnswerText";
            this.AnswerText.ReadOnly = true;
            this.AnswerText.Size = new System.Drawing.Size(227, 196);
            this.AnswerText.TabIndex = 2;
            this.AnswerText.Text = "";
            this.ButtonTip.SetToolTip(this.AnswerText, "结果显示区域");
            // 
            // CodePanel
            // 
            this.CodePanel.BackColor = System.Drawing.Color.Transparent;
            this.CodePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CodePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodePanel.Controls.Add(this.CodeText);
            this.CodePanel.Location = new System.Drawing.Point(520, 138);
            this.CodePanel.Name = "CodePanel";
            this.CodePanel.Size = new System.Drawing.Size(302, 495);
            this.CodePanel.TabIndex = 2;
            // 
            // DefineText
            // 
            this.DefineText.BackColor = System.Drawing.Color.PowderBlue;
            this.DefineText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DefineText.Location = new System.Drawing.Point(-1, 0);
            this.DefineText.Name = "DefineText";
            this.DefineText.ReadOnly = true;
            this.DefineText.Size = new System.Drawing.Size(327, 171);
            this.DefineText.TabIndex = 1;
            this.DefineText.Text = "";
            // 
            // DefinePanel
            // 
            this.DefinePanel.BackColor = System.Drawing.Color.Transparent;
            this.DefinePanel.Controls.Add(this.DefineText);
            this.DefinePanel.Location = new System.Drawing.Point(872, 163);
            this.DefinePanel.Name = "DefinePanel";
            this.DefinePanel.Size = new System.Drawing.Size(325, 171);
            this.DefinePanel.TabIndex = 28;
            // 
            // StackPanel
            // 
            this.StackPanel.BackColor = System.Drawing.Color.Transparent;
            this.StackPanel.Controls.Add(this.StackText);
            this.StackPanel.Location = new System.Drawing.Point(871, 463);
            this.StackPanel.Name = "StackPanel";
            this.StackPanel.Size = new System.Drawing.Size(96, 170);
            this.StackPanel.TabIndex = 31;
            // 
            // AnswerPanel
            // 
            this.AnswerPanel.BackColor = System.Drawing.Color.Transparent;
            this.AnswerPanel.Controls.Add(this.AnswerText);
            this.AnswerPanel.Location = new System.Drawing.Point(970, 438);
            this.AnswerPanel.Name = "AnswerPanel";
            this.AnswerPanel.Size = new System.Drawing.Size(227, 196);
            this.AnswerPanel.TabIndex = 34;
            // 
            // Ytq_Compiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YCompiler.Properties.Resources.Homework;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.AnswerPanel);
            this.Controls.Add(this.NeedRecordCheckBox);
            this.Controls.Add(this.InputConfirmBox);
            this.Controls.Add(this.StackPanel);
            this.Controls.Add(this.StackTip);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.DefinePanel);
            this.Controls.Add(this.DefineSizeTip);
            this.Controls.Add(this.DefineAddrTip);
            this.Controls.Add(this.Star1Box);
            this.Controls.Add(this.DefineLevelTip);
            this.Controls.Add(this.Star2Box);
            this.Controls.Add(this.DefineValueTip);
            this.Controls.Add(this.DefineTypeTip);
            this.Controls.Add(this.DefineNameTip);
            this.Controls.Add(this.StepIntoBox);
            this.Controls.Add(this.CodePanel);
            this.Controls.Add(this.LoadLineBox);
            this.Controls.Add(this.SetPathBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StepNumText);
            this.Controls.Add(this.StepNumSlider);
            this.Controls.Add(this.LinePanel);
            this.DoubleBuffered = true;
            this.Name = "Ytq_Compiler";
            this.Text = "Ytq_Compiler";
            this.LinePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StepIntoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StepNumSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetPathBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadLineBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputConfirmBox)).EndInit();
            this.CodePanel.ResumeLayout(false);
            this.DefinePanel.ResumeLayout(false);
            this.StackPanel.ResumeLayout(false);
            this.AnswerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LinePanel;
        private System.Windows.Forms.TrackBar StepNumSlider;
        private System.Windows.Forms.TextBox StepNumText;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.ToolTip ButtonTip;
        private System.Windows.Forms.PictureBox SetPathBox;
        private System.Windows.Forms.PictureBox StepIntoBox;
        private System.Windows.Forms.PictureBox LoadLineBox;
        private System.Windows.Forms.Panel CodePanel;
        private System.Windows.Forms.PictureBox Star2Box;
        private System.Windows.Forms.PictureBox Star1Box;
        private System.Windows.Forms.RichTextBox LineText;
        private System.Windows.Forms.RichTextBox CodeText;
        private System.Windows.Forms.TextBox DefineSizeTip;
        private System.Windows.Forms.TextBox DefineAddrTip;
        private System.Windows.Forms.TextBox DefineLevelTip;
        private System.Windows.Forms.TextBox DefineValueTip;
        private System.Windows.Forms.TextBox DefineTypeTip;
        private System.Windows.Forms.TextBox DefineNameTip;
        private System.Windows.Forms.RichTextBox DefineText;
        private System.Windows.Forms.Panel DefinePanel;
        private System.Windows.Forms.TextBox InputText;
        private System.Windows.Forms.TextBox StackTip;
        private System.Windows.Forms.Panel StackPanel;
        private System.Windows.Forms.RichTextBox StackText;
        private System.Windows.Forms.PictureBox InputConfirmBox;
        private System.Windows.Forms.CheckBox NeedRecordCheckBox;
        private System.Windows.Forms.RichTextBox AnswerText;
        private System.Windows.Forms.Panel AnswerPanel;
    }
}

