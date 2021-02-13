
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
			this.GravityTimer = new System.Windows.Forms.Timer(this.components);
			this.JumpTimer = new System.Windows.Forms.Timer(this.components);
			this.JumpAnimationWaitTimer = new System.Windows.Forms.Timer(this.components);
			this.Sounds = new AxWMPLib.AxWindowsMediaPlayer();
			((System.ComponentModel.ISupportInitialize)(this.FlappyBirdSprite)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Sounds)).BeginInit();
			this.SuspendLayout();
			// 
			// FlappyBirdSprite
			// 
			this.FlappyBirdSprite.BackColor = System.Drawing.Color.Transparent;
			this.FlappyBirdSprite.Image = ((System.Drawing.Image)(resources.GetObject("FlappyBirdSprite.Image")));
			this.FlappyBirdSprite.Location = new System.Drawing.Point(44, 304);
			this.FlappyBirdSprite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.FlappyBirdSprite.Name = "FlappyBirdSprite";
			this.FlappyBirdSprite.Size = new System.Drawing.Size(49, 47);
			this.FlappyBirdSprite.TabIndex = 0;
			this.FlappyBirdSprite.TabStop = false;
			// 
			// GravityTimer
			// 
			this.GravityTimer.Interval = 10;
			this.GravityTimer.Tick += new System.EventHandler(this.GravityTimer_Tick);
			// 
			// JumpTimer
			// 
			this.JumpTimer.Interval = 10;
			this.JumpTimer.Tick += new System.EventHandler(this.JumpTimer_Tick);
			// 
			// JumpAnimationWaitTimer
			// 
			this.JumpAnimationWaitTimer.Interval = 10;
			this.JumpAnimationWaitTimer.Tick += new System.EventHandler(this.JumpAnimationWait_Tick);
			// 
			// Sounds
			// 
			this.Sounds.Enabled = true;
			this.Sounds.Location = new System.Drawing.Point(274, 519);
			this.Sounds.Name = "Sounds";
			this.Sounds.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Sounds.OcxState")));
			this.Sounds.Size = new System.Drawing.Size(75, 47);
			this.Sounds.TabIndex = 1;
			this.Sounds.Visible = false;
			// 
			// FlappyBirdForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(361, 578);
			this.Controls.Add(this.Sounds);
			this.Controls.Add(this.FlappyBirdSprite);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FlappyBirdForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Flappy Bird";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.FlappyBirdSprite)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Sounds)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox FlappyBirdSprite;
		private System.Windows.Forms.Timer GravityTimer;
		private System.Windows.Forms.Timer JumpTimer;
		private System.Windows.Forms.Timer JumpAnimationWaitTimer;
		private AxWMPLib.AxWindowsMediaPlayer Sounds;
	}
}

