namespace Singboxui_refactored
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label7 = new Label();
            comboBox1 = new ComboBox();
            button4 = new Button();
            button5 = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            فارسیToolStripMenuItem = new ToolStripMenuItem();
            中文ToolStripMenuItem = new ToolStripMenuItem();
            русскийToolStripMenuItem = new ToolStripMenuItem();
            appearanceToolStripMenuItem = new ToolStripMenuItem();
            darkModeToolStripMenuItem = new ToolStripMenuItem();
            colorsToolStripMenuItem = new ToolStripMenuItem();
            blueToolStripMenuItem = new ToolStripMenuItem();
            redToolStripMenuItem = new ToolStripMenuItem();
            yellowToolStripMenuItem = new ToolStripMenuItem();
            purpleToolStripMenuItem = new ToolStripMenuItem();
            blueGrayToolStripMenuItem = new ToolStripMenuItem();
            brownToolStripMenuItem = new ToolStripMenuItem();
            tealToolStripMenuItem = new ToolStripMenuItem();
            orangeToolStripMenuItem = new ToolStripMenuItem();
            pinkToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            bindingSource1 = new BindingSource(components);
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            checkBox1 = new CheckBox();
            notifyIcon1 = new NotifyIcon(components);
            textBox3 = new TextBox();
            label8 = new Label();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 439);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(464, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "Hello";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(90, 17);
            toolStripStatusLabel1.Text = "I'm a status bar ";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(11, 367);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 1;
            label1.Text = "Location | IP :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(102, 367);
            label2.Name = "label2";
            label2.Size = new Size(62, 13);
            label2.TabIndex = 2;
            label2.Text = "Updating..";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(352, 363);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 3;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(352, 337);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 4;
            button2.Text = "PROXY MODE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 341);
            label3.Name = "label3";
            label3.Size = new Size(201, 15);
            label3.TabIndex = 5;
            label3.Text = "VPN Mode (Reconnection Required) ";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 341);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 6;
            label4.Text = "Proxy Port: 2080";
            label4.Visible = false;
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 260);
            label5.Name = "label5";
            label5.Size = new Size(150, 15);
            label5.TabIndex = 8;
            label5.Text = "Use Local Config (json) File";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 286);
            label6.Name = "label6";
            label6.Size = new Size(121, 15);
            label6.TabIndex = 9;
            label6.Text = "Dashboard Secret Key";
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(352, 283);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 10;
            textBox1.Text = "YEBEKHE";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(136, 141);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(316, 23);
            textBox2.TabIndex = 11;
            textBox2.Text = "https://raw.githubusercontent.com/yebekhe/TelegramV2rayCollector/main/singbox/sfasfi/reality.json";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 144);
            label7.Name = "label7";
            label7.Size = new Size(101, 15);
            label7.TabIndex = 12;
            label7.Text = "Subscription Link:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.IntegralHeight = false;
            comboBox1.ItemHeight = 15;
            comboBox1.Location = new Point(136, 170);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(316, 23);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Location = new Point(311, 208);
            button4.Name = "button4";
            button4.Size = new Size(141, 23);
            button4.TabIndex = 15;
            button4.Text = "Delete All Links";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(136, 208);
            button5.Name = "button5";
            button5.Size = new Size(141, 23);
            button5.TabIndex = 16;
            button5.Text = "Delete Current Link";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.GripMargin = new Padding(0, 2, 0, 2);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(0, 2, 0, 2);
            menuStrip1.Size = new Size(464, 24);
            menuStrip1.TabIndex = 17;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { languageToolStripMenuItem, appearanceToolStripMenuItem, aboutToolStripMenuItem });
            toolStripMenuItem1.ForeColor = SystemColors.ActiveCaptionText;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(80, 20);
            toolStripMenuItem1.Text = "Main Menu";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem, فارسیToolStripMenuItem, 中文ToolStripMenuItem, русскийToolStripMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            languageToolStripMenuItem.Size = new Size(137, 22);
            languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Size = new Size(119, 22);
            englishToolStripMenuItem.Text = "English";
            englishToolStripMenuItem.Click += englishToolStripMenuItem_Click;
            // 
            // فارسیToolStripMenuItem
            // 
            فارسیToolStripMenuItem.Name = "فارسیToolStripMenuItem";
            فارسیToolStripMenuItem.Size = new Size(119, 22);
            فارسیToolStripMenuItem.Text = "فارسی";
            فارسیToolStripMenuItem.Click += فارسیToolStripMenuItem_Click;
            // 
            // 中文ToolStripMenuItem
            // 
            中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
            中文ToolStripMenuItem.Size = new Size(119, 22);
            中文ToolStripMenuItem.Text = "中文";
            中文ToolStripMenuItem.Click += 中文ToolStripMenuItem_Click;
            // 
            // русскийToolStripMenuItem
            // 
            русскийToolStripMenuItem.Name = "русскийToolStripMenuItem";
            русскийToolStripMenuItem.Size = new Size(119, 22);
            русскийToolStripMenuItem.Text = "Русский";
            русскийToolStripMenuItem.Click += русскийToolStripMenuItem_Click;
            // 
            // appearanceToolStripMenuItem
            // 
            appearanceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { darkModeToolStripMenuItem, colorsToolStripMenuItem });
            appearanceToolStripMenuItem.Name = "appearanceToolStripMenuItem";
            appearanceToolStripMenuItem.Size = new Size(137, 22);
            appearanceToolStripMenuItem.Text = "Appearance";
            // 
            // darkModeToolStripMenuItem
            // 
            darkModeToolStripMenuItem.Name = "darkModeToolStripMenuItem";
            darkModeToolStripMenuItem.Size = new Size(132, 22);
            darkModeToolStripMenuItem.Text = "Dark Mode";
            darkModeToolStripMenuItem.Click += darkModeToolStripMenuItem_Click;
            // 
            // colorsToolStripMenuItem
            // 
            colorsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { blueToolStripMenuItem, redToolStripMenuItem, yellowToolStripMenuItem, purpleToolStripMenuItem, blueGrayToolStripMenuItem, brownToolStripMenuItem, tealToolStripMenuItem, orangeToolStripMenuItem, pinkToolStripMenuItem });
            colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            colorsToolStripMenuItem.Size = new Size(132, 22);
            colorsToolStripMenuItem.Text = "Colors";
            colorsToolStripMenuItem.Click += colorsToolStripMenuItem_Click;
            // 
            // blueToolStripMenuItem
            // 
            blueToolStripMenuItem.BackColor = Color.Blue;
            blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            blueToolStripMenuItem.Size = new Size(67, 22);
            blueToolStripMenuItem.Click += blueToolStripMenuItem_Click;
            // 
            // redToolStripMenuItem
            // 
            redToolStripMenuItem.BackColor = Color.Red;
            redToolStripMenuItem.Name = "redToolStripMenuItem";
            redToolStripMenuItem.Size = new Size(67, 22);
            redToolStripMenuItem.Click += redToolStripMenuItem_Click;
            // 
            // yellowToolStripMenuItem
            // 
            yellowToolStripMenuItem.BackColor = Color.Yellow;
            yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            yellowToolStripMenuItem.Size = new Size(67, 22);
            yellowToolStripMenuItem.Click += yellowToolStripMenuItem_Click;
            // 
            // purpleToolStripMenuItem
            // 
            purpleToolStripMenuItem.BackColor = Color.Purple;
            purpleToolStripMenuItem.Name = "purpleToolStripMenuItem";
            purpleToolStripMenuItem.Size = new Size(67, 22);
            purpleToolStripMenuItem.Click += purpleToolStripMenuItem_Click;
            // 
            // blueGrayToolStripMenuItem
            // 
            blueGrayToolStripMenuItem.BackColor = Color.DarkBlue;
            blueGrayToolStripMenuItem.Name = "blueGrayToolStripMenuItem";
            blueGrayToolStripMenuItem.Size = new Size(67, 22);
            blueGrayToolStripMenuItem.Click += blueGrayToolStripMenuItem_Click;
            // 
            // brownToolStripMenuItem
            // 
            brownToolStripMenuItem.BackColor = Color.SaddleBrown;
            brownToolStripMenuItem.Name = "brownToolStripMenuItem";
            brownToolStripMenuItem.Size = new Size(67, 22);
            brownToolStripMenuItem.Click += brownToolStripMenuItem_Click;
            // 
            // tealToolStripMenuItem
            // 
            tealToolStripMenuItem.BackColor = Color.Teal;
            tealToolStripMenuItem.Name = "tealToolStripMenuItem";
            tealToolStripMenuItem.Size = new Size(67, 22);
            tealToolStripMenuItem.Click += tealToolStripMenuItem_Click;
            // 
            // orangeToolStripMenuItem
            // 
            orangeToolStripMenuItem.BackColor = Color.Orange;
            orangeToolStripMenuItem.Name = "orangeToolStripMenuItem";
            orangeToolStripMenuItem.Size = new Size(67, 22);
            orangeToolStripMenuItem.Click += orangeToolStripMenuItem_Click;
            // 
            // pinkToolStripMenuItem
            // 
            pinkToolStripMenuItem.BackColor = Color.Pink;
            pinkToolStripMenuItem.Name = "pinkToolStripMenuItem";
            pinkToolStripMenuItem.Size = new Size(67, 22);
            pinkToolStripMenuItem.Click += pinkToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(137, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // button6
            // 
            button6.Location = new Point(179, 53);
            button6.Name = "button6";
            button6.Size = new Size(153, 54);
            button6.TabIndex = 18;
            button6.Text = "CONNECT";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.AutoSize = true;
            button7.Location = new Point(12, 401);
            button7.Name = "button7";
            button7.Size = new Size(200, 25);
            button7.TabIndex = 21;
            button7.Text = "Singbox Dashboard";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.AutoSize = true;
            button8.Location = new Point(252, 401);
            button8.Name = "button8";
            button8.Size = new Size(200, 25);
            button8.TabIndex = 22;
            button8.Text = "List Servers";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(437, 261);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 23;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "SingboxUI";
            notifyIcon1.Visible = true;
            // 
            // textBox3
            // 
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(352, 310);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 24;
            textBox3.Text = "8.8.8.8";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 314);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 25;
            label8.Text = "DNS";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(464, 461);
            Controls.Add(label8);
            Controls.Add(textBox3);
            Controls.Add(checkBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(480, 500);
            MinimumSize = new Size(480, 500);
            Name = "Form1";
            RightToLeft = RightToLeft.No;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SingBoxUI - By: Yebekhe & Aleph";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label7;
        private ComboBox comboBox1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button button4;
        private Button button5;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem فارسیToolStripMenuItem;
        private ToolStripMenuItem 中文ToolStripMenuItem;
        private ToolStripMenuItem русскийToolStripMenuItem;
        private ToolStripMenuItem appearanceToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private BindingSource bindingSource1;
        private Button button6;
        private ToolStripMenuItem darkModeToolStripMenuItem;
        private Button button7;
        private Button button8;
        private CheckBox checkBox1;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem colorsToolStripMenuItem;
        private ToolStripMenuItem blueToolStripMenuItem;
        private ToolStripMenuItem redToolStripMenuItem;
        private ToolStripMenuItem yellowToolStripMenuItem;
        private ToolStripMenuItem purpleToolStripMenuItem;
        private ToolStripMenuItem blueGrayToolStripMenuItem;
        private ToolStripMenuItem brownToolStripMenuItem;
        private ToolStripMenuItem tealToolStripMenuItem;
        private ToolStripMenuItem orangeToolStripMenuItem;
        private ToolStripMenuItem pinkToolStripMenuItem;
        private TextBox textBox3;
        private Label label8;
    }
}


public class CustomButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        this.BackColor = Color.FromArgb(31, 165, 243); // Equivalent to "#1fa5f3"
        this.ForeColor = Color.White;
    }
}

public class CustomSwitch : CheckBox
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        this.BackColor = this.Checked ? Color.Green : Color.Red;
    }
}


public class RoundToggleButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        this.BackColor = this.Enabled ? Color.Green : Color.Red;
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); // Transparent
    }
}
