namespace AutoOnmyoji
{
    partial class MainForm
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
            this.testButton = new System.Windows.Forms.Button();
            this.explore_button = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.exploreTab = new System.Windows.Forms.TabPage();
            this.autoCloseGame = new System.Windows.Forms.CheckBox();
            this.numericTurnTotalExplore = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFoodType = new System.Windows.Forms.ComboBox();
            this.testTab = new System.Windows.Forms.TabPage();
            this.mainTab.SuspendLayout();
            this.exploreTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTurnTotalExplore)).BeginInit();
            this.testTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(6, 19);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(120, 23);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // explore_button
            // 
            this.explore_button.Location = new System.Drawing.Point(7, 298);
            this.explore_button.Name = "explore_button";
            this.explore_button.Size = new System.Drawing.Size(460, 37);
            this.explore_button.TabIndex = 1;
            this.explore_button.Text = "EXPLORE";
            this.explore_button.UseVisualStyleBackColor = true;
            this.explore_button.Click += new System.EventHandler(this.explore_button_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(7, 341);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(456, 35);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "STOP";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.exploreTab);
            this.mainTab.Controls.Add(this.testTab);
            this.mainTab.Location = new System.Drawing.Point(12, 12);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(480, 408);
            this.mainTab.TabIndex = 3;
            // 
            // exploreTab
            // 
            this.exploreTab.Controls.Add(this.numericTurnTotalExplore);
            this.exploreTab.Controls.Add(this.label2);
            this.exploreTab.Controls.Add(this.label1);
            this.exploreTab.Controls.Add(this.stopButton);
            this.exploreTab.Controls.Add(this.cbxFoodType);
            this.exploreTab.Controls.Add(this.explore_button);
            this.exploreTab.Location = new System.Drawing.Point(4, 22);
            this.exploreTab.Name = "exploreTab";
            this.exploreTab.Padding = new System.Windows.Forms.Padding(3);
            this.exploreTab.Size = new System.Drawing.Size(472, 382);
            this.exploreTab.TabIndex = 0;
            this.exploreTab.Text = "Explore";
            this.exploreTab.UseVisualStyleBackColor = true;
            // 
            // autoCloseGame
            // 
            this.autoCloseGame.AutoSize = true;
            this.autoCloseGame.Location = new System.Drawing.Point(16, 426);
            this.autoCloseGame.Name = "autoCloseGame";
            this.autoCloseGame.Size = new System.Drawing.Size(111, 17);
            this.autoCloseGame.TabIndex = 8;
            this.autoCloseGame.Text = "Tự động tắt game";
            this.autoCloseGame.UseVisualStyleBackColor = true;
            this.autoCloseGame.CheckedChanged += new System.EventHandler(this.autoCloseGame_CheckedChanged);
            // 
            // numericTurnTotalExplore
            // 
            this.numericTurnTotalExplore.Location = new System.Drawing.Point(10, 79);
            this.numericTurnTotalExplore.Name = "numericTurnTotalExplore";
            this.numericTurnTotalExplore.Size = new System.Drawing.Size(120, 20);
            this.numericTurnTotalExplore.TabIndex = 6;
            this.numericTurnTotalExplore.ValueChanged += new System.EventHandler(this.numericTurnTotalExplore_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số lượt đánh (tự động tắt game khi hết lượt)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Loại food muốn famr :";
            // 
            // cbxFoodType
            // 
            this.cbxFoodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFoodType.FormattingEnabled = true;
            this.cbxFoodType.Items.AddRange(new object[] {
            "N",
            "Daruma",
            "R"});
            this.cbxFoodType.Location = new System.Drawing.Point(10, 27);
            this.cbxFoodType.Name = "cbxFoodType";
            this.cbxFoodType.Size = new System.Drawing.Size(106, 21);
            this.cbxFoodType.TabIndex = 2;
            this.cbxFoodType.SelectedIndexChanged += new System.EventHandler(this.cbxFoodType_SelectedIndexChanged);
            // 
            // testTab
            // 
            this.testTab.Controls.Add(this.testButton);
            this.testTab.Location = new System.Drawing.Point(4, 22);
            this.testTab.Name = "testTab";
            this.testTab.Padding = new System.Windows.Forms.Padding(3);
            this.testTab.Size = new System.Drawing.Size(472, 405);
            this.testTab.TabIndex = 1;
            this.testTab.Text = "Test";
            this.testTab.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 455);
            this.Controls.Add(this.autoCloseGame);
            this.Controls.Add(this.mainTab);
            this.Name = "MainForm";
            this.Text = "OnmyojiAuto";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainTab.ResumeLayout(false);
            this.exploreTab.ResumeLayout(false);
            this.exploreTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTurnTotalExplore)).EndInit();
            this.testTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button explore_button;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage exploreTab;
        private System.Windows.Forms.ComboBox cbxFoodType;
        private System.Windows.Forms.TabPage testTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericTurnTotalExplore;
        private System.Windows.Forms.CheckBox autoCloseGame;
    }
}

