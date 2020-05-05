using System.Windows.Forms;
using System.Drawing;

namespace TowerDefence.View
{
    partial class MainMenuControl
    {
        #region
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new TableLayoutPanel();
            this.pictureBox = new PictureBox();
            this.startButton = new Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 600F));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.pictureBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.startButton, 1, 2);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(0, 0);
            this.tableLayoutPanel.Margin = new Padding(4, 5, 4, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 800F));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1200, 923);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = DockStyle.Fill;
            this.pictureBox.Image = global::TowerDefence.Properties.Resources.MainMenu;
            this.pictureBox.Location = new Point(304, 66);
            this.pictureBox.Margin = new Padding(4, 5, 4, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new Size(592, 790);
            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
            this.startButton.ForeColor = SystemColors.ActiveCaptionText;
            this.startButton.Location = new Point(450, 874);
            this.startButton.Margin = new Padding(150, 0, 150, 0);
            this.startButton.Name = "startButton";
            this.startButton.Size = new Size(300, 35);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Начать игру";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // MainMenuControl
            // 
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new Padding(4, 5, 4, 5);
            this.Name = "MainMenuControl";
            this.Size = new Size(1200, 923);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PictureBox pictureBox;
        private Button startButton;


    }
}
