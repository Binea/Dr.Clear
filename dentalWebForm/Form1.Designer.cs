namespace dentalWebForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.JKBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // JKBrowser
            // 
            this.JKBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JKBrowser.Location = new System.Drawing.Point(0, 0);
            this.JKBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.JKBrowser.Name = "JKBrowser";
            this.JKBrowser.Size = new System.Drawing.Size(1529, 813);
            this.JKBrowser.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 813);
            this.Controls.Add(this.JKBrowser);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser JKBrowser;
    }
}

