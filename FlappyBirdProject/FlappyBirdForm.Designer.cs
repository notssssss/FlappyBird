
namespace FlappyBirdProject
{
	partial class FlappyBirdForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlappyBirdForm));
			this.FlappyBirdSprite = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.FlappyBirdSprite)).BeginInit();
			this.SuspendLayout();
			// 
			// FlappyBirdSprite
			// 
			this.FlappyBirdSprite.BackColor = System.Drawing.Color.Transparent;
			this.FlappyBirdSprite.Image = ((System.Drawing.Image)(resources.GetObject("FlappyBirdSprite.Image")));
			this.FlappyBirdSprite.Location = new System.Drawing.Point(33, 247);
			this.FlappyBirdSprite.Name = "FlappyBirdSprite";
			this.FlappyBirdSprite.Size = new System.Drawing.Size(37, 38);
			this.FlappyBirdSprite.TabIndex = 0;
			this.FlappyBirdSprite.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// FlappyBirdForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(271, 470);
			this.Controls.Add(this.FlappyBirdSprite);
			this.Name = "FlappyBirdForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Flappy Bird";
			((System.ComponentModel.ISupportInitialize)(this.FlappyBirdSprite)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox FlappyBirdSprite;
		private System.Windows.Forms.Timer timer1;
	}
}

