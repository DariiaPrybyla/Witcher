namespace Witcher
{
    partial class background
    {
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(background));
            this.character = new System.Windows.Forms.PictureBox();
            this.text_history = new System.Windows.Forms.Label();
            this.quen_indicator = new System.Windows.Forms.PictureBox();
            this.thunder = new System.Windows.Forms.Button();
            this.martin = new System.Windows.Forms.Button();
            this.quen = new System.Windows.Forms.Button();
            this.igni = new System.Windows.Forms.Button();
            this.health_Herald = new System.Windows.Forms.ProgressBar();
            this.health_enemy = new System.Windows.Forms.ProgressBar();
            this.kill_Herald = new System.Windows.Forms.PictureBox();
            this.kill_Enemy = new System.Windows.Forms.PictureBox();
            this.start = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.character)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quen_indicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kill_Herald)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kill_Enemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).BeginInit();
            this.SuspendLayout();
            // 
            // character
            // 
            this.character.BackColor = System.Drawing.Color.Transparent;
            this.character.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.character.Location = new System.Drawing.Point(212, 62);
            this.character.Name = "character";
            this.character.Size = new System.Drawing.Size(360, 480);
            this.character.TabIndex = 48;
            this.character.TabStop = false;
            // 
            // text_history
            // 
            this.text_history.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.text_history.Location = new System.Drawing.Point(0, 437);
            this.text_history.Name = "text_history";
            this.text_history.Size = new System.Drawing.Size(785, 125);
            this.text_history.TabIndex = 47;
            this.text_history.Text = "label1";
            this.text_history.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quen_indicator
            // 
            this.quen_indicator.BackColor = System.Drawing.Color.Transparent;
            this.quen_indicator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quen_indicator.Location = new System.Drawing.Point(12, 100);
            this.quen_indicator.Name = "quen_indicator";
            this.quen_indicator.Size = new System.Drawing.Size(50, 50);
            this.quen_indicator.TabIndex = 46;
            this.quen_indicator.TabStop = false;
            // 
            // thunder
            // 
            this.thunder.BackColor = System.Drawing.Color.Transparent;
            this.thunder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.thunder.ForeColor = System.Drawing.Color.Transparent;
            this.thunder.Location = new System.Drawing.Point(12, 388);
            this.thunder.Name = "thunder";
            this.thunder.Size = new System.Drawing.Size(43, 43);
            this.thunder.TabIndex = 42;
            this.thunder.UseVisualStyleBackColor = false;
            this.thunder.Click += new System.EventHandler(this.thunder_Click);
            // 
            // martin
            // 
            this.martin.BackColor = System.Drawing.Color.Transparent;
            this.martin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.martin.ForeColor = System.Drawing.Color.Transparent;
            this.martin.Location = new System.Drawing.Point(64, 388);
            this.martin.Name = "martin";
            this.martin.Size = new System.Drawing.Size(43, 43);
            this.martin.TabIndex = 43;
            this.martin.UseVisualStyleBackColor = false;
            this.martin.Click += new System.EventHandler(this.martin_Click);
            // 
            // quen
            // 
            this.quen.BackColor = System.Drawing.Color.Transparent;
            this.quen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quen.ForeColor = System.Drawing.Color.Transparent;
            this.quen.Location = new System.Drawing.Point(121, 388);
            this.quen.Name = "quen";
            this.quen.Size = new System.Drawing.Size(43, 43);
            this.quen.TabIndex = 44;
            this.quen.UseVisualStyleBackColor = false;
            this.quen.Click += new System.EventHandler(this.quen_Click);
            // 
            // igni
            // 
            this.igni.BackColor = System.Drawing.Color.Transparent;
            this.igni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.igni.ForeColor = System.Drawing.Color.Transparent;
            this.igni.Location = new System.Drawing.Point(173, 388);
            this.igni.Name = "igni";
            this.igni.Size = new System.Drawing.Size(43, 43);
            this.igni.TabIndex = 45;
            this.igni.UseVisualStyleBackColor = false;
            this.igni.Click += new System.EventHandler(this.igni_Click);
            // 
            // health_Herald
            // 
            this.health_Herald.Location = new System.Drawing.Point(12, 71);
            this.health_Herald.Name = "health_Herald";
            this.health_Herald.Size = new System.Drawing.Size(194, 23);
            this.health_Herald.TabIndex = 41;
            // 
            // health_enemy
            // 
            this.health_enemy.Location = new System.Drawing.Point(578, 71);
            this.health_enemy.Name = "health_enemy";
            this.health_enemy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.health_enemy.RightToLeftLayout = true;
            this.health_enemy.Size = new System.Drawing.Size(194, 23);
            this.health_enemy.TabIndex = 40;
            // 
            // kill_Herald
            // 
            this.kill_Herald.BackColor = System.Drawing.Color.Transparent;
            this.kill_Herald.Location = new System.Drawing.Point(75, 62);
            this.kill_Herald.Name = "kill_Herald";
            this.kill_Herald.Size = new System.Drawing.Size(290, 375);
            this.kill_Herald.TabIndex = 39;
            this.kill_Herald.TabStop = false;
            // 
            // kill_Enemy
            // 
            this.kill_Enemy.BackColor = System.Drawing.Color.Transparent;
            this.kill_Enemy.Location = new System.Drawing.Point(383, 29);
            this.kill_Enemy.Name = "kill_Enemy";
            this.kill_Enemy.Size = new System.Drawing.Size(360, 480);
            this.kill_Enemy.TabIndex = 38;
            this.kill_Enemy.TabStop = false;
            this.kill_Enemy.Click += new System.EventHandler(this.kill_Enemy_Click);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Transparent;
            this.start.FlatAppearance.BorderSize = 0;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.start.Location = new System.Drawing.Point(22, 160);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(182, 36);
            this.start.TabIndex = 37;
            this.start.Text = " ";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Location = new System.Drawing.Point(22, 63);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(303, 75);
            this.title.TabIndex = 36;
            this.title.TabStop = false;
            // 
            // background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Witcher.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.text_history);
            this.Controls.Add(this.quen_indicator);
            this.Controls.Add(this.thunder);
            this.Controls.Add(this.martin);
            this.Controls.Add(this.quen);
            this.Controls.Add(this.igni);
            this.Controls.Add(this.health_Herald);
            this.Controls.Add(this.health_enemy);
            this.Controls.Add(this.kill_Herald);
            this.Controls.Add(this.kill_Enemy);
            this.Controls.Add(this.start);
            this.Controls.Add(this.title);
            this.Controls.Add(this.character);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "background";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Witcher";
            this.Click += new System.EventHandler(this.background_Click);
            ((System.ComponentModel.ISupportInitialize)(this.character)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quen_indicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kill_Herald)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kill_Enemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox character;
        private System.Windows.Forms.Label text_history;
        private System.Windows.Forms.PictureBox quen_indicator;
        private System.Windows.Forms.Button thunder;
        private System.Windows.Forms.Button martin;
        private System.Windows.Forms.Button quen;
        private System.Windows.Forms.Button igni;
        private System.Windows.Forms.ProgressBar health_Herald;
        private System.Windows.Forms.ProgressBar health_enemy;
        private System.Windows.Forms.PictureBox kill_Herald;
        private System.Windows.Forms.PictureBox kill_Enemy;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.PictureBox title;
    }
}

