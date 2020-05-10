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
            this.mainMenuControl = new MainMenuControl(game);
            this.levelsControl = new LevelsControl(game);
            this.fieldControl = new FieldControl(game);
            this.SuspendLayout();
            // 
            // mainMenuControl
            // 
            this.mainMenuControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenuControl.Location = new System.Drawing.Point(0, 0);
            this.mainMenuControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainMenuControl.Name = "mainMenuControl";
            this.mainMenuControl.Size = new System.Drawing.Size(1920, 1080);
            this.mainMenuControl.TabIndex = 0;
            //
            // levelsControl
            //
            this.levelsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelsControl.Location = new System.Drawing.Point(0, 0);
            this.levelsControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.levelsControl.Name = "levelsControl";
            this.levelsControl.Size = new System.Drawing.Size(800, 600);
            this.levelsControl.TabIndex = 1;
            //
            // fieldControl
            //
            this.fieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldControl.Location = new System.Drawing.Point(0, 0);
            this.fieldControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fieldControl.Name = "fieldControl";
            //this.fieldControl.Size = new System.Drawing.Size(game.CurrentLevel.Field.Width * 32,
            //    game.CurrentLevel.Field.Height * 32);
            this.fieldControl.Size = new System.Drawing.Size(800, 600);
            this.fieldControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
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