namespace Multi_platform_Translation
{
    partial class FrmTranslation
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTranslation));
            this.textOriginal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBing = new System.Windows.Forms.TextBox();
            this.textGoogle = new System.Windows.Forms.TextBox();
            this.textBaidu = new System.Windows.Forms.TextBox();
            this.textYoudao = new System.Windows.Forms.TextBox();
            this.textSogou = new System.Windows.Forms.TextBox();
            this.textQQ = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTranslation = new System.Windows.Forms.Button();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.cobForm = new System.Windows.Forms.ComboBox();
            this.cobTo = new System.Windows.Forms.ComboBox();
            this.btnCrossing = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkBing = new System.Windows.Forms.CheckBox();
            this.chkBaidu = new System.Windows.Forms.CheckBox();
            this.chkSogou = new System.Windows.Forms.CheckBox();
            this.chkQQ = new System.Windows.Forms.CheckBox();
            this.chkYoudao = new System.Windows.Forms.CheckBox();
            this.chkGoogle = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textOriginal
            // 
            this.textOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOriginal.HideSelection = false;
            this.textOriginal.Location = new System.Drawing.Point(32, 7);
            this.textOriginal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textOriginal.Multiline = true;
            this.textOriginal.Name = "textOriginal";
            this.textOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOriginal.Size = new System.Drawing.Size(255, 178);
            this.textOriginal.TabIndex = 29;
            this.textOriginal.TextChanged += new System.EventHandler(this.TextOriginal_TextChanged);
            this.textOriginal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextOriginal_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 186);
            this.label4.TabIndex = 15;
            this.label4.Text = "翻译原文";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.DoubleClick += new System.EventHandler(this.Label4_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(296, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 186);
            this.label3.TabIndex = 17;
            this.label3.Text = "翻译设置";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBing
            // 
            this.textBing.BackColor = System.Drawing.SystemColors.Window;
            this.textBing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBing.Enabled = false;
            this.textBing.HideSelection = false;
            this.textBing.Location = new System.Drawing.Point(32, 196);
            this.textBing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBing.Multiline = true;
            this.textBing.Name = "textBing";
            this.textBing.ReadOnly = true;
            this.textBing.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBing.Size = new System.Drawing.Size(255, 178);
            this.textBing.TabIndex = 31;
            this.textBing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSelectAll);
            // 
            // textGoogle
            // 
            this.textGoogle.BackColor = System.Drawing.SystemColors.Window;
            this.textGoogle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textGoogle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textGoogle.Enabled = false;
            this.textGoogle.HideSelection = false;
            this.textGoogle.Location = new System.Drawing.Point(322, 196);
            this.textGoogle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textGoogle.Multiline = true;
            this.textGoogle.Name = "textGoogle";
            this.textGoogle.ReadOnly = true;
            this.textGoogle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textGoogle.Size = new System.Drawing.Size(256, 178);
            this.textGoogle.TabIndex = 32;
            this.textGoogle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSelectAll);
            // 
            // textBaidu
            // 
            this.textBaidu.BackColor = System.Drawing.SystemColors.Window;
            this.textBaidu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBaidu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBaidu.Enabled = false;
            this.textBaidu.HideSelection = false;
            this.textBaidu.Location = new System.Drawing.Point(32, 385);
            this.textBaidu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBaidu.Multiline = true;
            this.textBaidu.Name = "textBaidu";
            this.textBaidu.ReadOnly = true;
            this.textBaidu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBaidu.Size = new System.Drawing.Size(255, 178);
            this.textBaidu.TabIndex = 33;
            this.textBaidu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSelectAll);
            // 
            // textYoudao
            // 
            this.textYoudao.BackColor = System.Drawing.SystemColors.Window;
            this.textYoudao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYoudao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textYoudao.Enabled = false;
            this.textYoudao.HideSelection = false;
            this.textYoudao.Location = new System.Drawing.Point(322, 385);
            this.textYoudao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textYoudao.Multiline = true;
            this.textYoudao.Name = "textYoudao";
            this.textYoudao.ReadOnly = true;
            this.textYoudao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textYoudao.Size = new System.Drawing.Size(256, 178);
            this.textYoudao.TabIndex = 34;
            this.textYoudao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSelectAll);
            // 
            // textSogou
            // 
            this.textSogou.BackColor = System.Drawing.SystemColors.Window;
            this.textSogou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSogou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSogou.Enabled = false;
            this.textSogou.HideSelection = false;
            this.textSogou.Location = new System.Drawing.Point(32, 574);
            this.textSogou.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textSogou.Multiline = true;
            this.textSogou.Name = "textSogou";
            this.textSogou.ReadOnly = true;
            this.textSogou.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSogou.Size = new System.Drawing.Size(255, 181);
            this.textSogou.TabIndex = 35;
            this.textSogou.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSelectAll);
            // 
            // textQQ
            // 
            this.textQQ.BackColor = System.Drawing.SystemColors.Window;
            this.textQQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textQQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textQQ.Enabled = false;
            this.textQQ.HideSelection = false;
            this.textQQ.Location = new System.Drawing.Point(322, 574);
            this.textQQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textQQ.Multiline = true;
            this.textQQ.Name = "textQQ";
            this.textQQ.ReadOnly = true;
            this.textQQ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textQQ.Size = new System.Drawing.Size(256, 181);
            this.textQQ.TabIndex = 36;
            this.textQQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextSelectAll);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnTranslation, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkTopMost, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cobForm, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cobTo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnCrossing, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(322, 7);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 178);
            this.tableLayoutPanel2.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 35);
            this.label6.TabIndex = 0;
            this.label6.Text = "原文语言";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 35);
            this.label7.TabIndex = 1;
            this.label7.Text = "译文语言";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTranslation
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btnTranslation, 2);
            this.btnTranslation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTranslation.Enabled = false;
            this.btnTranslation.Location = new System.Drawing.Point(3, 131);
            this.btnTranslation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTranslation.Name = "btnTranslation";
            this.btnTranslation.Size = new System.Drawing.Size(250, 43);
            this.btnTranslation.TabIndex = 2;
            this.btnTranslation.Text = "翻译(&T)";
            this.btnTranslation.UseVisualStyleBackColor = true;
            this.btnTranslation.Click += new System.EventHandler(this.BtnTranslation_Click);
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chkTopMost.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkTopMost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTopMost.Location = new System.Drawing.Point(3, 74);
            this.chkTopMost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(41, 49);
            this.chkTopMost.TabIndex = 3;
            this.chkTopMost.Text = "置顶";
            this.chkTopMost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTopMost.UseVisualStyleBackColor = true;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.ChkTopMost_CheckedChanged);
            // 
            // cobForm
            // 
            this.cobForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobForm.FormattingEnabled = true;
            this.cobForm.Items.AddRange(new object[] {
            "日语",
            "英语",
            "中文"});
            this.cobForm.Location = new System.Drawing.Point(50, 4);
            this.cobForm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cobForm.Name = "cobForm";
            this.cobForm.Size = new System.Drawing.Size(203, 25);
            this.cobForm.TabIndex = 4;
            // 
            // cobTo
            // 
            this.cobTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobTo.FormattingEnabled = true;
            this.cobTo.Items.AddRange(new object[] {
            "日语",
            "英语",
            "中文"});
            this.cobTo.Location = new System.Drawing.Point(50, 39);
            this.cobTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cobTo.Name = "cobTo";
            this.cobTo.Size = new System.Drawing.Size(203, 25);
            this.cobTo.TabIndex = 5;
            // 
            // btnCrossing
            // 
            this.btnCrossing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCrossing.Location = new System.Drawing.Point(50, 74);
            this.btnCrossing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCrossing.Name = "btnCrossing";
            this.btnCrossing.Size = new System.Drawing.Size(203, 49);
            this.btnCrossing.TabIndex = 6;
            this.btnCrossing.Text = "交换语言(&S)";
            this.btnCrossing.UseVisualStyleBackColor = true;
            this.btnCrossing.Click += new System.EventHandler(this.BtnCrossing_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chkBing, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkBaidu, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkSogou, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkQQ, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkYoudao, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textQQ, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textSogou, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textYoudao, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBaidu, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textGoogle, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBing, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textOriginal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkGoogle, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.99999F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 762);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chkBing
            // 
            this.chkBing.AutoSize = true;
            this.chkBing.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBing.Location = new System.Drawing.Point(6, 195);
            this.chkBing.Name = "chkBing";
            this.chkBing.Size = new System.Drawing.Size(17, 180);
            this.chkBing.TabIndex = 43;
            this.chkBing.Text = "必应翻译";
            this.chkBing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBing.UseVisualStyleBackColor = true;
            this.chkBing.CheckedChanged += new System.EventHandler(this.ChkBing_CheckedChanged);
            // 
            // chkBaidu
            // 
            this.chkBaidu.AutoSize = true;
            this.chkBaidu.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkBaidu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBaidu.Location = new System.Drawing.Point(6, 384);
            this.chkBaidu.Name = "chkBaidu";
            this.chkBaidu.Size = new System.Drawing.Size(17, 180);
            this.chkBaidu.TabIndex = 42;
            this.chkBaidu.Text = "百度翻译";
            this.chkBaidu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBaidu.UseVisualStyleBackColor = true;
            this.chkBaidu.CheckedChanged += new System.EventHandler(this.ChkBaidu_CheckedChanged);
            // 
            // chkSogou
            // 
            this.chkSogou.AutoSize = true;
            this.chkSogou.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSogou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSogou.Location = new System.Drawing.Point(6, 573);
            this.chkSogou.Name = "chkSogou";
            this.chkSogou.Size = new System.Drawing.Size(17, 183);
            this.chkSogou.TabIndex = 41;
            this.chkSogou.Text = "搜狗翻译";
            this.chkSogou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSogou.UseVisualStyleBackColor = true;
            this.chkSogou.CheckedChanged += new System.EventHandler(this.ChkSougo_CheckedChanged);
            // 
            // chkQQ
            // 
            this.chkQQ.AutoSize = true;
            this.chkQQ.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkQQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkQQ.Location = new System.Drawing.Point(296, 573);
            this.chkQQ.Name = "chkQQ";
            this.chkQQ.Size = new System.Drawing.Size(17, 183);
            this.chkQQ.TabIndex = 40;
            this.chkQQ.Text = "腾讯翻译";
            this.chkQQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkQQ.UseVisualStyleBackColor = true;
            this.chkQQ.CheckedChanged += new System.EventHandler(this.ChkQQ_CheckedChanged);
            // 
            // chkYoudao
            // 
            this.chkYoudao.AutoSize = true;
            this.chkYoudao.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkYoudao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkYoudao.Location = new System.Drawing.Point(296, 384);
            this.chkYoudao.Name = "chkYoudao";
            this.chkYoudao.Size = new System.Drawing.Size(17, 180);
            this.chkYoudao.TabIndex = 39;
            this.chkYoudao.Text = "有道翻译";
            this.chkYoudao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkYoudao.UseVisualStyleBackColor = true;
            this.chkYoudao.CheckedChanged += new System.EventHandler(this.ChkYoudao_CheckedChanged);
            // 
            // chkGoogle
            // 
            this.chkGoogle.AutoSize = true;
            this.chkGoogle.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkGoogle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkGoogle.Location = new System.Drawing.Point(296, 195);
            this.chkGoogle.Name = "chkGoogle";
            this.chkGoogle.Size = new System.Drawing.Size(17, 180);
            this.chkGoogle.TabIndex = 38;
            this.chkGoogle.Text = "谷歌翻译";
            this.chkGoogle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkGoogle.UseVisualStyleBackColor = true;
            this.chkGoogle.CheckedChanged += new System.EventHandler(this.ChkGoogle_CheckedChanged);
            // 
            // FrmTranslation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 762);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmTranslation";
            this.Text = "多平台翻译器";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textOriginal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBing;
        private System.Windows.Forms.TextBox textGoogle;
        private System.Windows.Forms.TextBox textBaidu;
        private System.Windows.Forms.TextBox textYoudao;
        private System.Windows.Forms.TextBox textSogou;
        private System.Windows.Forms.TextBox textQQ;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTranslation;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.ComboBox cobForm;
        private System.Windows.Forms.ComboBox cobTo;
        private System.Windows.Forms.Button btnCrossing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkGoogle;
        private System.Windows.Forms.CheckBox chkQQ;
        private System.Windows.Forms.CheckBox chkYoudao;
        private System.Windows.Forms.CheckBox chkBing;
        private System.Windows.Forms.CheckBox chkBaidu;
        private System.Windows.Forms.CheckBox chkSogou;
    }
}

