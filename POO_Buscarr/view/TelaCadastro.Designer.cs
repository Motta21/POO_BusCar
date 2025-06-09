using System;
using System.Drawing;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using POO_Buscarr.controller;

namespace POO_Buscarr.view
{
    partial class TelaCadastro
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
            this.pbBotao = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.campoNome = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.campoEmail = new System.Windows.Forms.TextBox();
            this.campoCPF = new System.Windows.Forms.TextBox();
            this.campoSenha1 = new System.Windows.Forms.TextBox();
            this.campoSenha2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBotao
            // 
            this.pbBotao.BackColor = System.Drawing.Color.Transparent;
            this.pbBotao.Location = new System.Drawing.Point(100, 100);
            this.pbBotao.Name = "pbBotao";
            this.pbBotao.Size = new System.Drawing.Size(100, 50);
            this.pbBotao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBotao.TabIndex = 0;
            this.pbBotao.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1095, 942);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 35);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_cadastrar.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.ForeColor = System.Drawing.Color.Transparent;
            this.btn_cadastrar.Image = global::POO_Buscarr.Properties.Resources.btnCadastrar;
            this.btn_cadastrar.Location = new System.Drawing.Point(1060, 831);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(438, 89);
            this.btn_cadastrar.TabIndex = 24;
            this.btn_cadastrar.UseVisualStyleBackColor = false;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // campoNome
            // 
            this.campoNome.BackColor = System.Drawing.SystemColors.Window;
            this.campoNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoNome.ForeColor = System.Drawing.SystemColors.Desktop;
            this.campoNome.Location = new System.Drawing.Point(968, 229);
            this.campoNome.Name = "campoNome";
            this.campoNome.Size = new System.Drawing.Size(619, 55);
            this.campoNome.TabIndex = 25;
            this.campoNome.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // campoEmail
            // 
            this.campoEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoEmail.Location = new System.Drawing.Point(967, 347);
            this.campoEmail.Name = "campoEmail";
            this.campoEmail.Size = new System.Drawing.Size(619, 55);
            this.campoEmail.TabIndex = 26;
            this.campoEmail.TextChanged += new System.EventHandler(this.campoEmail_TextChanged);
            // 
            // campoCPF
            // 
            this.campoCPF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.campoCPF.Location = new System.Drawing.Point(967, 458);
            this.campoCPF.Name = "campoCPF";
            this.campoCPF.Size = new System.Drawing.Size(619, 55);
            this.campoCPF.TabIndex = 27;
            this.campoCPF.TextChanged += new System.EventHandler(this.campoCPF_TextChanged);
            // 
            // campoSenha1
            // 
            this.campoSenha1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoSenha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.campoSenha1.Location = new System.Drawing.Point(967, 574);
            this.campoSenha1.Name = "campoSenha1";
            this.campoSenha1.PasswordChar = '*';
            this.campoSenha1.Size = new System.Drawing.Size(619, 55);
            this.campoSenha1.TabIndex = 28;
            this.campoSenha1.TextChanged += new System.EventHandler(this.campoSenha1_TextChanged);
            // 
            // campoSenha2
            // 
            this.campoSenha2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.campoSenha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.campoSenha2.Location = new System.Drawing.Point(967, 689);
            this.campoSenha2.Name = "campoSenha2";
            this.campoSenha2.PasswordChar = '*';
            this.campoSenha2.Size = new System.Drawing.Size(611, 55);
            this.campoSenha2.TabIndex = 29;
            this.campoSenha2.TextChanged += new System.EventHandler(this.campoSenha2_TextChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1404, 789);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(1179, 789);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // TelaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.TelaCadastroAtualizada;
            this.ClientSize = new System.Drawing.Size(1653, 936);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.campoSenha2);
            this.Controls.Add(this.campoSenha1);
            this.Controls.Add(this.campoCPF);
            this.Controls.Add(this.campoEmail);
            this.Controls.Add(this.campoNome);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TelaCadastro";
            this.Text = "TelaCadastro";
            ((System.ComponentModel.ISupportInitialize)(this.pbBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pbBotao;
        private PictureBox pictureBox1;
        private Button btn_cadastrar;
        private TextBox campoNome;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox campoEmail;
        private TextBox campoCPF;
        private TextBox campoSenha1;
        private TextBox campoSenha2;
        private ContextMenuStrip contextMenuStrip2;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
    }
}