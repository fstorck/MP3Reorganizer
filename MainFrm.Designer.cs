namespace MP3TagRename
{
    partial class MainFrm
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
            this.BTN_SelectSrcDir = new System.Windows.Forms.Button();
            this.BTN_SelectDstDir = new System.Windows.Forms.Button();
            this.BTN_StartProcessing = new System.Windows.Forms.Button();
            this.FBD_SrcDir = new System.Windows.Forms.FolderBrowserDialog();
            this.FBD_DstDir = new System.Windows.Forms.FolderBrowserDialog();
            this.LBL_SrcDir = new System.Windows.Forms.Label();
            this.LBL_DstDir = new System.Windows.Forms.Label();
            this.BTN_Abort = new System.Windows.Forms.Button();
            this.PGB_Files = new System.Windows.Forms.ProgressBar();
            this.LBL_NumFiles = new System.Windows.Forms.Label();
            this.RTB_Log = new System.Windows.Forms.RichTextBox();
            this.LBL_Stats = new System.Windows.Forms.Label();
            this.RTB_Errors = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // BTN_SelectSrcDir
            // 
            this.BTN_SelectSrcDir.Location = new System.Drawing.Point(12, 12);
            this.BTN_SelectSrcDir.Name = "BTN_SelectSrcDir";
            this.BTN_SelectSrcDir.Size = new System.Drawing.Size(124, 23);
            this.BTN_SelectSrcDir.TabIndex = 0;
            this.BTN_SelectSrcDir.Text = "Select Source Dir";
            this.BTN_SelectSrcDir.UseVisualStyleBackColor = true;
            this.BTN_SelectSrcDir.Click += new System.EventHandler(this.BTN_SelectSrcDir_Click);
            // 
            // BTN_SelectDstDir
            // 
            this.BTN_SelectDstDir.Location = new System.Drawing.Point(12, 41);
            this.BTN_SelectDstDir.Name = "BTN_SelectDstDir";
            this.BTN_SelectDstDir.Size = new System.Drawing.Size(124, 23);
            this.BTN_SelectDstDir.TabIndex = 1;
            this.BTN_SelectDstDir.Text = "Select Destination Dir";
            this.BTN_SelectDstDir.UseVisualStyleBackColor = true;
            this.BTN_SelectDstDir.Click += new System.EventHandler(this.BTN_SelectDstDir_Click);
            // 
            // BTN_StartProcessing
            // 
            this.BTN_StartProcessing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_StartProcessing.Location = new System.Drawing.Point(12, 105);
            this.BTN_StartProcessing.Name = "BTN_StartProcessing";
            this.BTN_StartProcessing.Size = new System.Drawing.Size(398, 48);
            this.BTN_StartProcessing.TabIndex = 2;
            this.BTN_StartProcessing.Text = "Start Processing";
            this.BTN_StartProcessing.UseVisualStyleBackColor = true;
            this.BTN_StartProcessing.Click += new System.EventHandler(this.BTN_StartProcessing_Click);
            // 
            // LBL_SrcDir
            // 
            this.LBL_SrcDir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LBL_SrcDir.Location = new System.Drawing.Point(145, 12);
            this.LBL_SrcDir.Name = "LBL_SrcDir";
            this.LBL_SrcDir.Size = new System.Drawing.Size(402, 23);
            this.LBL_SrcDir.TabIndex = 3;
            this.LBL_SrcDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LBL_DstDir
            // 
            this.LBL_DstDir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LBL_DstDir.Location = new System.Drawing.Point(145, 41);
            this.LBL_DstDir.Name = "LBL_DstDir";
            this.LBL_DstDir.Size = new System.Drawing.Size(402, 23);
            this.LBL_DstDir.TabIndex = 3;
            this.LBL_DstDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BTN_Abort
            // 
            this.BTN_Abort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Abort.Location = new System.Drawing.Point(416, 105);
            this.BTN_Abort.Name = "BTN_Abort";
            this.BTN_Abort.Size = new System.Drawing.Size(131, 48);
            this.BTN_Abort.TabIndex = 2;
            this.BTN_Abort.Text = "Abort";
            this.BTN_Abort.UseVisualStyleBackColor = true;
            this.BTN_Abort.Click += new System.EventHandler(this.BTN_Abort_Click);
            // 
            // PGB_Files
            // 
            this.PGB_Files.Location = new System.Drawing.Point(145, 76);
            this.PGB_Files.Name = "PGB_Files";
            this.PGB_Files.Size = new System.Drawing.Size(402, 23);
            this.PGB_Files.TabIndex = 4;
            // 
            // LBL_NumFiles
            // 
            this.LBL_NumFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LBL_NumFiles.Location = new System.Drawing.Point(9, 76);
            this.LBL_NumFiles.Name = "LBL_NumFiles";
            this.LBL_NumFiles.Size = new System.Drawing.Size(127, 23);
            this.LBL_NumFiles.TabIndex = 5;
            this.LBL_NumFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RTB_Log
            // 
            this.RTB_Log.Location = new System.Drawing.Point(12, 262);
            this.RTB_Log.MaxLength = 128000;
            this.RTB_Log.Name = "RTB_Log";
            this.RTB_Log.Size = new System.Drawing.Size(535, 133);
            this.RTB_Log.TabIndex = 6;
            this.RTB_Log.Text = "";
            // 
            // LBL_Stats
            // 
            this.LBL_Stats.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LBL_Stats.Location = new System.Drawing.Point(12, 161);
            this.LBL_Stats.Name = "LBL_Stats";
            this.LBL_Stats.Size = new System.Drawing.Size(535, 28);
            this.LBL_Stats.TabIndex = 3;
            this.LBL_Stats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RTB_Errors
            // 
            this.RTB_Errors.BackColor = System.Drawing.Color.LightYellow;
            this.RTB_Errors.Location = new System.Drawing.Point(12, 192);
            this.RTB_Errors.MaxLength = 128000;
            this.RTB_Errors.Name = "RTB_Errors";
            this.RTB_Errors.Size = new System.Drawing.Size(535, 64);
            this.RTB_Errors.TabIndex = 7;
            this.RTB_Errors.Text = "";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 404);
            this.Controls.Add(this.RTB_Errors);
            this.Controls.Add(this.RTB_Log);
            this.Controls.Add(this.LBL_NumFiles);
            this.Controls.Add(this.PGB_Files);
            this.Controls.Add(this.LBL_Stats);
            this.Controls.Add(this.LBL_DstDir);
            this.Controls.Add(this.LBL_SrcDir);
            this.Controls.Add(this.BTN_Abort);
            this.Controls.Add(this.BTN_StartProcessing);
            this.Controls.Add(this.BTN_SelectDstDir);
            this.Controls.Add(this.BTN_SelectSrcDir);
            this.Name = "MainFrm";
            this.Text = "MP3 Reorganizer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_SelectSrcDir;
        private System.Windows.Forms.Button BTN_SelectDstDir;
        private System.Windows.Forms.Button BTN_StartProcessing;
        private System.Windows.Forms.FolderBrowserDialog FBD_SrcDir;
        private System.Windows.Forms.FolderBrowserDialog FBD_DstDir;
        private System.Windows.Forms.Label LBL_SrcDir;
        private System.Windows.Forms.Label LBL_DstDir;
        private System.Windows.Forms.Button BTN_Abort;
        private System.Windows.Forms.ProgressBar PGB_Files;
        private System.Windows.Forms.Label LBL_NumFiles;
        private System.Windows.Forms.RichTextBox RTB_Log;
        private System.Windows.Forms.Label LBL_Stats;
        private System.Windows.Forms.RichTextBox RTB_Errors;
    }
}

