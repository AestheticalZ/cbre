﻿namespace CBRE.Editor.Compiling {
    partial class ExportForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textureDims = new System.Windows.Forms.TextBox();
            this.downscaleFactor = new System.Windows.Forms.TextBox();
            this.blurRadius = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ambientRed = new System.Windows.Forms.TextBox();
            this.ambientGreen = new System.Windows.Forms.TextBox();
            this.ambientBlue = new System.Windows.Forms.TextBox();
            this.render = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ambientColorBox = new System.Windows.Forms.Panel();
            this.ProgressLog = new System.Windows.Forms.RichTextBox();
            this.export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Texture dimensions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Downscale factor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Blur radius";
            // 
            // textureDims
            // 
            this.textureDims.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textureDims.Location = new System.Drawing.Point(113, 12);
            this.textureDims.Name = "textureDims";
            this.textureDims.Size = new System.Drawing.Size(561, 20);
            this.textureDims.TabIndex = 4;
            this.textureDims.LostFocus += new System.EventHandler(this.textureDims_LostFocus);
            // 
            // downscaleFactor
            // 
            this.downscaleFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downscaleFactor.Location = new System.Drawing.Point(113, 38);
            this.downscaleFactor.Name = "downscaleFactor";
            this.downscaleFactor.Size = new System.Drawing.Size(561, 20);
            this.downscaleFactor.TabIndex = 5;
            this.downscaleFactor.LostFocus += new System.EventHandler(this.downscaleFactor_LostFocus);
            // 
            // blurRadius
            // 
            this.blurRadius.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blurRadius.Location = new System.Drawing.Point(113, 64);
            this.blurRadius.Name = "blurRadius";
            this.blurRadius.Size = new System.Drawing.Size(561, 20);
            this.blurRadius.TabIndex = 6;
            this.blurRadius.LostFocus += new System.EventHandler(this.blurRadius_LostFocus);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ambient color";
            // 
            // ambientRed
            // 
            this.ambientRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ambientRed.Location = new System.Drawing.Point(113, 90);
            this.ambientRed.Name = "ambientRed";
            this.ambientRed.Size = new System.Drawing.Size(41, 20);
            this.ambientRed.TabIndex = 8;
            this.ambientRed.TextChanged += new System.EventHandler(this.ambientRed_TextChanged);
            this.ambientRed.LostFocus += new System.EventHandler(this.ambientRed_LostFocus);
            // 
            // ambientGreen
            // 
            this.ambientGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ambientGreen.Location = new System.Drawing.Point(160, 90);
            this.ambientGreen.Name = "ambientGreen";
            this.ambientGreen.Size = new System.Drawing.Size(41, 20);
            this.ambientGreen.TabIndex = 9;
            this.ambientGreen.TextChanged += new System.EventHandler(this.ambientGreen_TextChanged);
            this.ambientGreen.LostFocus += new System.EventHandler(this.ambientGreen_LostFocus);
            // 
            // ambientBlue
            // 
            this.ambientBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ambientBlue.Location = new System.Drawing.Point(207, 90);
            this.ambientBlue.Name = "ambientBlue";
            this.ambientBlue.Size = new System.Drawing.Size(41, 20);
            this.ambientBlue.TabIndex = 10;
            this.ambientBlue.TextChanged += new System.EventHandler(this.ambientBlue_TextChanged);
            this.ambientBlue.LostFocus += new System.EventHandler(this.ambientBlue_LostFocus);
            // 
            // render
            // 
            this.render.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.render.Location = new System.Drawing.Point(12, 360);
            this.render.Name = "render";
            this.render.Size = new System.Drawing.Size(75, 23);
            this.render.TabIndex = 12;
            this.render.Text = "Render";
            this.render.UseVisualStyleBackColor = true;
            this.render.Click += new System.EventHandler(this.render_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Enabled = false;
            this.cancel.Location = new System.Drawing.Point(599, 360);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Enabled = false;
            this.ProgressBar.Location = new System.Drawing.Point(12, 331);
            this.ProgressBar.Maximum = 10000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(662, 23);
            this.ProgressBar.TabIndex = 14;
            // 
            // ambientColorBox
            // 
            this.ambientColorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ambientColorBox.Location = new System.Drawing.Point(274, 90);
            this.ambientColorBox.Name = "ambientColorBox";
            this.ambientColorBox.Size = new System.Drawing.Size(42, 20);
            this.ambientColorBox.TabIndex = 16;
            this.ambientColorBox.Click += new System.EventHandler(this.ambientColorBox_Click);
            // 
            // ProgressLog
            // 
            this.ProgressLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProgressLog.HideSelection = false;
            this.ProgressLog.Location = new System.Drawing.Point(12, 116);
            this.ProgressLog.Name = "ProgressLog";
            this.ProgressLog.ReadOnly = true;
            this.ProgressLog.Size = new System.Drawing.Size(662, 209);
            this.ProgressLog.TabIndex = 17;
            this.ProgressLog.Text = "";
            // 
            // export
            // 
            this.export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.export.Location = new System.Drawing.Point(93, 360);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 18;
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(254, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "=";
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 395);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.export);
            this.Controls.Add(this.ProgressLog);
            this.Controls.Add(this.ambientColorBox);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.render);
            this.Controls.Add(this.ambientBlue);
            this.Controls.Add(this.ambientGreen);
            this.Controls.Add(this.ambientRed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.blurRadius);
            this.Controls.Add(this.downscaleFactor);
            this.Controls.Add(this.textureDims);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximumSize = new System.Drawing.Size(600000, 600000);
            this.MinimumSize = new System.Drawing.Size(420, 270);
            this.Name = "ExportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Export / Lightmap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.Load += new System.EventHandler(this.ExportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textureDims;
        private System.Windows.Forms.TextBox downscaleFactor;
        private System.Windows.Forms.TextBox blurRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ambientRed;
        private System.Windows.Forms.TextBox ambientGreen;
        private System.Windows.Forms.TextBox ambientBlue;
        private System.Windows.Forms.Button render;
        private System.Windows.Forms.Button cancel;
        public System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Panel ambientColorBox;
        public System.Windows.Forms.RichTextBox ProgressLog;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Label label6;
    }
}
