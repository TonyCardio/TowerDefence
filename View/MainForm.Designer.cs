namespace TowerDefence.View
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
            this.mainMenuControl = new MainMenuControl();
            this.levelsControl = new LevelsControl();
            this.fieldControl = new FieldControl();
            this.SuspendLayout();
            // 
            // mainMenuControl
            // 
            this.mainMenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuControl.Location = new System.Drawing.Point(0, 0);
            this.mainMenuControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainMenuControl.Name = "mainMenuControl";
            this.mainMenuControl.Size = new System.Drawing.Size(1920, 1050);
            this.mainMenuControl.TabIndex = 0;
            // 
            // levelsControl
            // 
            this.mainMenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuControl.Location = new System.Drawing.Point(0, 0);
            this.mainMenuControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainMenuControl.Name = "levelsControl";
            this.mainMenuControl.Size = new System.Drawing.Size(800, 600);
            this.mainMenuControl.TabIndex = 1;
            // 
            // fieldControl
            // 
            this.mainMenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuControl.Location = new System.Drawing.Point(0, 0);
            this.mainMenuControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainMenuControl.Name = "fieldControl";
            this.mainMenuControl.Size = new System.Drawing.Size(800, 600);
            this.mainMenuControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1050);
            this.Controls.Add(this.mainMenuControl);
            this.Controls.Add(this.levelsControl);
            this.Controls.Add(this.fieldControl);
            this.Name = "MainForm";
            this.Text = "TowerDefence";
            this.ResumeLayout(false);

        }

        #endregion

        private MainMenuControl mainMenuControl;
        private LevelsControl levelsControl;
        private FieldControl fieldControl;
    }
}