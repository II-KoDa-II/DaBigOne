
namespace ConsoleApp3
{
  partial class Form1
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
      this.ButtonCreate = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
      this.button4 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // ButtonCreate
      // 
      this.ButtonCreate.Location = new System.Drawing.Point(451, 21);
      this.ButtonCreate.Name = "ButtonCreate";
      this.ButtonCreate.Size = new System.Drawing.Size(178, 56);
      this.ButtonCreate.TabIndex = 0;
      this.ButtonCreate.Text = "Создать файл";
      this.ButtonCreate.UseVisualStyleBackColor = true;
      this.ButtonCreate.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(451, 83);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(177, 56);
      this.button2.TabIndex = 1;
      this.button2.Text = "Изменить файл";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(451, 145);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(177, 56);
      this.button3.TabIndex = 2;
      this.button3.Text = "Удалить файл";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // folderBrowserDialog1
      // 
      this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(212, 12);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(223, 34);
      this.button4.TabIndex = 3;
      this.button4.Text = "Выбрать путь";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(12, 12);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(185, 34);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "FileName";
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(12, 52);
      this.textBox2.Multiline = true;
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(423, 244);
      this.textBox2.TabIndex = 6;
      this.textBox2.Text = "File Text";
      this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(641, 308);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.ButtonCreate);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button ButtonCreate;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
  }
}
